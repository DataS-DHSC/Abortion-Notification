// app/routes/questions.js
const govukPrototypeKit = require('govuk-prototype-kit');
const router            = govukPrototypeKit.requests.setupRouter();
const set               = require('lodash.set');
const fs                = require('fs');
const path              = require('path');
const { parse }         = require('url');
const qs                = require('querystring');

// ---- START: New/Modified code - Load BASE_FORMS data ----
// Load BASE_FORMS data, similar to forms.js, to ensure it's available for initialization
// Ensure the path to forms.json is correct relative to questions.js
const FORMS_DATA_PATH = path.join(__dirname, '../data/forms.json');
let BASE_FORMS_IN_QUESTIONS; // To avoid reading file on every request
try {
  // Read file synchronously at startup
  BASE_FORMS_IN_QUESTIONS = JSON.parse(fs.readFileSync(FORMS_DATA_PATH, 'utf8'));
} catch (err) {
  console.error("CRITICAL ERROR: Could not read or parse forms.json in questions.js. Defaulting to empty forms list.", err);
  BASE_FORMS_IN_QUESTIONS = []; // Default to an empty array if there's an error loading base forms
}
// ---- END: New/Modified code - Load BASE_FORMS data ----

/* helper */
function getBackLink(history) {
  return history && history.length > 1 ? history[history.length - 2] : '/';
}

/* ---------- QUESTIONS FLOW ---------- */

router.get('/questions/:group/:page', (req, res) => {
  const { group, page } = req.params;
  const currentPath     = `/questions/${group}/${page}`;
  const referrerPath    = parse(req.get('Referer') || '').pathname;

  req.session.data.history = req.session.data.history || [];
  const history    = req.session.data.history;
  const last       = history[history.length - 1];
  const secondLast = history[history.length - 2];

  if (referrerPath === last && currentPath === secondLast) {
    history.pop();
    history.pop();
    history.push(currentPath);
  } else if (last !== currentPath) {
    history.push(currentPath);
  }

  let viewData = {
    backLink: getBackLink(history),
    currentPage: page,
    questionGroup: group
    // Add other common variables your layout might need
  };

  // ---- START: New/Modified code - Prepare data for confirm-patient-age page ----
  if (page === 'confirm-patient-age') {
    const displayAge = req.session.patientDisplayAge;
    const displayAgeString = req.session.patientDisplayAgeString;

    if (typeof displayAge === 'undefined' || typeof displayAgeString === 'undefined') {
      console.warn('Age data not found in session for confirm-patient-age page. Redirecting to DOB entry.');
      // It's good practice to clear any potentially stale session data if redirecting due to missing info
      delete req.session.patientDisplayAge;
      delete req.session.patientDisplayAgeString;
      return res.redirect('/questions/patient-details/what-is-the-patients-date-of-birth'); // Adjust redirect as needed
    }

    viewData.data = {
      patientAge: displayAge,
      patientAgeCalculated: displayAgeString
    };

    // Add other specific variables needed by confirm-patient-age.njk (interruption card version)
    // These should align with what your Nunjucks template for confirm-patient-age expects for actions etc.
    viewData.nextPageSlug = "does-the-patient-live-in-england-or-wales"; // Slug for primary action
    viewData.backLinkTarget = "what-is-the-patients-date-of-birth";   // Slug for secondary action
    viewData.sectionTitle = "Patient's details"; // Example, if your layout uses it
  }
  // ---- END: New/Modified code - Prepare data for confirm-patient-age page ----

  res.render(`questions/${group}/${page}`, viewData);
});

router.post('/questions/:group/:page', (req, res, next) => { // Added 'next' for potential error handling in session.save
  const { group, page } = req.params;
  const META = ['currentPage', 'questionGroup', 'nextPage', 'backPage', '_csrf']; // Added _csrf as it's common
  const raw  = req.body;

  const formData = {};
  Object.entries(raw).forEach(([k, v]) => {
    if (!META.includes(k)) set(formData, k, v);
  });

  // Ensure formData related to the current page is stored correctly in session
  // This merges current page's form data into the session's formData
  req.session.data.formData = req.session.data.formData || {};
  Object.keys(formData).forEach(key => {
    set(req.session.data.formData, key, formData[key]);
  });


  const pageJsPath = path.join(__dirname, `../views/questions/${group}/${page}.js`);
  let nextPageFromResolve = raw.nextPage; // Default to nextPage from hidden input if any
  let errors   = [];

  if (fs.existsSync(pageJsPath)) {
    const pageModule = require(pageJsPath);
    // Pass the combined session formData for validation context, and current page's formData for specific validation
    if (typeof pageModule.validate === 'function') errors = pageModule.validate(req.session.data.formData, formData);
    if (!errors.length && typeof pageModule.resolve === 'function') {
      nextPageFromResolve = pageModule.resolve(req.session.data.formData, formData);
    }
  }

  const backLink = getBackLink(req.session.data.history);

  if (errors.length) {
    // When re-rendering due to errors, pass back the specific formData for this page
    // and also the full session formData if your templates rely on it for other things.
    // The 'data' object for repopulating inputs should primarily use 'formData' (current submission).
    return res.render(`questions/${group}/${page}`, {
      errors,
      backLink,
      data: formData, // For repopulating current page inputs
      sessionData: req.session.data.formData // For accessing other session data if needed
    });
  }

  // ---- START: New/Modified code - Calculate and store age in session for DOB page ----
  // This should match the slug of your actual Date of Birth page
  if (page === 'what-is-the-patients-date-of-birth') {
    const dobData = formData.patientInformation?.dateOfBirth || req.session.data.formData?.patientInformation?.dateOfBirth || {};
    const day = parseInt(dobData.day, 10);
    const month = parseInt(dobData.month, 10); // Month from form is 1-indexed
    const year = parseInt(dobData.year, 10);

    if (!isNaN(day) && !isNaN(month) && !isNaN(year)) {
      const today = new Date();
      const birthDate = new Date(year, month - 1, day); // JS Date month is 0-indexed

      let age = today.getFullYear() - birthDate.getFullYear();
      const monthDifference = today.getMonth() - birthDate.getMonth();
      if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birthDate.getDate())) {
        age--;
      }
      req.session.patientDisplayAge = String(age);
      req.session.patientDisplayAgeString = `${age} years old`;
      console.log(`questions.js POST: Calculated age ${age} for DOB page, stored in session.`);
    } else {
      console.error(`questions.js POST: Could not parse DOB components for age calculation from formData for page ${page}.`);
    }
  }
  // ---- END: New/Modified code - Calculate and store age in session for DOB page ----


  if (page === 'has-the-patient-had-any-stillbirths-or-livebirths') {
    // This block executes if the current page is 'has-the-patient-had-any-stillbirths-or-livebirths'
    // AND there were no validation errors from its specific page.js file.

    const now = new Date();
    const dd = String(now.getDate()).padStart(2, '0');
    const mm = String(now.getMonth() + 1).padStart(2, '0');
    const yy = now.getFullYear().toString().slice(-2);
    const yearForDate = now.getFullYear();
    const rand = Math.floor(Math.random() * 10000).toString().padStart(4, '0');

    const formId = `S${yy}${mm}-${rand}`;
    const formattedDate = `${dd}/${mm}/${yearForDate}`;

    // ---- START: New/Modified code - Ensure req.session.data.forms initialization ----
    if (!req.session.data.forms) {
      console.log("questions.js: Initializing req.session.data.forms from BASE_FORMS_IN_QUESTIONS for new form addition.");
      req.session.data.forms = JSON.parse(JSON.stringify(BASE_FORMS_IN_QUESTIONS));
    }
    // ---- END: New/Modified code - Ensure req.session.data.forms initialization ----

    req.session.data.forms.push({
      dateCreated: formattedDate,
      formId: formId,
      patientReference: "21323132232", // Consider making dynamic
      clinicName: "Harbourview Reproductive Health Clinic", // Consider making dynamic
      formStatus: "INCOMPLETE"
    });

    req.session.save(err => {
      if (err) {
        console.error("Error saving session after adding new form in questions.js:", err);
        // Optionally, pass error to an Express error handler if configured
        // return next(err);
      }
      // Clear per-submission formData from session after successful processing of a "journey end"
      // delete req.session.data.formData; // Or specific parts of it if it's a multi-step form
      const redirectQs = qs.stringify(req.query); // Preserves query params if any
      res.redirect(303, `/forms${redirectQs ? `?${redirectQs}` : ''}#${formId}`);
    });
    return; // Important: end execution here for this specific page logic
  }

  // Default redirect logic for other pages if not handled by the specific conditions above
  req.session.save(err => {
    if (err) {
      console.error('Session save error before default redirect:', err);
      return next(err); // Pass error to an error handler
    }
    res.redirect(`/questions/${group}/${nextPageFromResolve}`);
  });
});

module.exports = router;