// app/routes/questions.js
const govukPrototypeKit = require('govuk-prototype-kit');
const router            = govukPrototypeKit.requests.setupRouter();
const set               = require('lodash.set');
const fs                = require('fs');
const path              = require('path');
const { parse }         = require('url');
const qs                = require('querystring');

// Load BASE_FORMS data, similar to forms.js
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

/* helper (unchanged) */
function getBackLink(history) {
  return history && history.length > 1 ? history[history.length - 2] : '/';
}

/* ---------- QUESTIONS FLOW (GET part unchanged) ---------- */
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

  const backLink = getBackLink(history);
  res.render(`questions/${group}/${page}`, { backLink });
});

router.post('/questions/:group/:page', (req, res) => {
  const { group, page } = req.params;
  const META = ['currentPage', 'questionGroup', 'nextPage', 'backPage'];
  const raw  = req.body;

  const formData = {};
  Object.entries(raw).forEach(([k, v]) => {
    if (!META.includes(k)) set(formData, k, v);
  });

  req.session.data.formData = req.session.data.formData || {};
  Object.entries(formData).forEach(([k, v]) => set(req.session.data.formData, k, v));

  const pageJsPath = path.join(__dirname, `../views/questions/${group}/${page}.js`);
  let nextPage = raw.nextPage;
  let errors   = [];

  if (fs.existsSync(pageJsPath)) {
    const pageModule = require(pageJsPath);
    if (typeof pageModule.validate === 'function') errors = pageModule.validate(req.session.data.formData, formData);
    if (!errors.length && typeof pageModule.resolve === 'function') nextPage = pageModule.resolve(req.session.data.formData, formData);
  }

  const backLink = getBackLink(req.session.data.history);

  if (errors.length) {
    return res.render(`questions/${group}/${page}`, { errors, backLink });
  }

  // console.log(page) // Kept for your debugging
  // console.log(group) // Kept for your debugging

  if (page === 'has-the-patient-had-any-stillbirths-or-livebirths') {
    // This block only runs if there were no validation errors from page.js
    // (since the errors.length check above would have returned)
    // console.log("NEW FORM TESTTTTTTT") // Kept for your debugging

    const now = new Date();
    const dd = String(now.getDate()).padStart(2, '0');
    const mm = String(now.getMonth() + 1).padStart(2, '0'); // getMonth() is 0-indexed
    const yy = now.getFullYear().toString().slice(-2);
    const yearForDate = now.getFullYear(); // Use a distinct variable name for clarity
    const rand = Math.floor(Math.random() * 10000).toString().padStart(4, '0');

    const formId = `S${yy}${mm}-${rand}`;
    // Corrected variable name for the year in formattedDate:
    const formattedDate = `${dd}/${mm}/${yearForDate}`;

    // console.log(formattedDate) // Kept for your debugging

    // --- MODIFIED SECTION ---
    // Ensure req.session.data.forms is initialized with BASE_FORMS if it's not already set.
    // This logic mirrors the initialization in forms.js middleware.
    if (!req.session.data.forms) { // Checks for undefined, null, "", 0, false, NaN
      console.log("questions.js: Initializing req.session.data.forms from BASE_FORMS_IN_QUESTIONS");
      // Deep clone to prevent modification of the loaded BASE_FORMS_IN_QUESTIONS object
      req.session.data.forms = JSON.parse(JSON.stringify(BASE_FORMS_IN_QUESTIONS));
    }
    // --- END MODIFIED SECTION ---

    if (!req.session.data.forms) {
      console.log("questions.js: Initializing req.session.data.forms from BASE_FORMS_IN_QUESTIONS");
      req.session.data.forms = JSON.parse(JSON.stringify(BASE_FORMS_IN_QUESTIONS)); // Deep clone
    }
    
    // Add new form
    req.session.data.forms.push({
      dateCreated: formattedDate,
      formId: formId,
      patientReference: "21323132232", // Consider making this dynamic
      clinicName: "Harbourview Reproductive Health Clinic", // Consider making this dynamic
      formStatus: "INCOMPLETE"
    });

    req.session.save(err => {
      if (err) {
        console.error("Error saving session in questions.js:", err); // Use console.error for errors
      }
      const redirectQs = qs.stringify(req.query);
      // It's good practice to clear specific temporary form data from session after successful submission to avoid reuse
      // For example: delete req.session.data.formData; (if formData is per-submission)
      res.redirect(303, `/forms${redirectQs ? `?${redirectQs}` : ''}#${formId}`);
    });

    return; // Essential to prevent falling through to the next res.redirect
  }
  else { // This else is for when page !== 'has-the-patient-had-any-stillbirths-or-livebirths'
    res.redirect(`/questions/${group}/${nextPage}`);
  }
});

module.exports = router;