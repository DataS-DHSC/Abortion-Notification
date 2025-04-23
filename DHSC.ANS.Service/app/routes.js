const govukPrototypeKit = require('govuk-prototype-kit');
const router = govukPrototypeKit.requests.setupRouter();
const set = require('lodash.set');
const fs = require('fs');
const path = require('path');

const DEBUG = true;

// GET route with session-based backLink and debug output
router.get('/questions/:group/:page', (req, res) => {
    const { group, page } = req.params;
    const currentPath = `/questions/${group}/${page}`;
  
    // Initialise history array if not present
    req.session.history = req.session.history || [];
  
    // Output current history before update
    console.log('--- PAGE LOAD ---');
    console.log('Current page:', currentPath);
    console.log('Session history BEFORE:', [...req.session.history]);
  
    // Push current path to history only if it's not the same as the last
    const last = req.session.history[req.session.history.length - 1];
    if (last !== currentPath) {
      req.session.history.push(currentPath);
    }
  
    // Output updated history
    console.log('Session history AFTER:', [...req.session.history]);
  
    const backLink = req.session.history.length > 1
      ? req.session.history[req.session.history.length - 2]
      : '/';
  
    console.log('Back link calculated as:', backLink);
    console.log('-------------------\n');
  
    res.render(`questions/${group}/${page}`, {
      backLink
    });
  });
  

router.post('/question/:group/:page', async function (req, res) {
  const { group, page } = req.params;

  const META_FIELDS = ['currentPage', 'questionGroup', 'nextPage', 'backPage'];
  const rawForm = req.body;

  if (DEBUG) {
    console.log('--- FORM SUBMISSION START ---');
    console.log(`Route: /question/${group}/${page}`);
    console.log('Raw req.body:', JSON.stringify(rawForm, null, 2));
  }

  const currentPage = rawForm.currentPage;
  const nextPageFromForm = rawForm.nextPage;

  // Clean and nest form data
  const formData = {};
  Object.entries(rawForm).forEach(([key, value]) => {
    if (!META_FIELDS.includes(key)) {
      set(formData, key, value);
    }
  });

  // Build clean session object
  const cleanSession = {};
  Object.entries(req.session.data || {}).forEach(([key, value]) => {
    const isFlatKey = key.includes('.');
    const isMeta = META_FIELDS.includes(key);
    if (!isFlatKey && !isMeta) {
      cleanSession[key] = value;
    }
  });
  Object.entries(formData).forEach(([key, value]) => {
    set(cleanSession, key, value);
  });
  req.session.data = cleanSession;

  if (DEBUG) {
    console.log('Cleaned formData (nested):', JSON.stringify(formData, null, 2));
    console.log('Updated session data:', JSON.stringify(req.session.data, null, 2));
  }

  // Load optional page logic
  const pageJsPath = path.join(__dirname, `./views/questions/${group}/${page}.js`);
  let nextPage;
  let errors = [];

  if (fs.existsSync(pageJsPath)) {
    const pageModule = require(pageJsPath);

    if (typeof pageModule.validate === 'function') {
      errors = pageModule.validate(req.session.data, formData);
      if (DEBUG && errors.length) console.log('Validation errors:', JSON.stringify(errors, null, 2));
    }

    if (!errors.length && typeof pageModule.resolve === 'function') {
      nextPage = pageModule.resolve(req.session.data, formData);
      if (DEBUG) console.log('Page resolver selected next page:', nextPage);
    }
  }

  // Determine backlink for error re-render
  const currentPath = `/questions/${group}/${page}`;
  req.session.history = req.session.history || [];
  
  const backLink = req.session.history.length > 1
    ? req.session.history[req.session.history.length - 2]
    : '/';

  if (errors.length) {
    if (DEBUG) {
      console.log('Re-rendering page due to validation errors.');
      console.log('--- FORM SUBMISSION END (with errors) ---\n');
    }
    return res.render(`questions/${group}/${page}`, {
      errors,
      backLink
    });
  }

  // Use fallback nextPage if needed
  if (!nextPage) {
    nextPage = nextPageFromForm;
    if (DEBUG) console.log('Falling back to template-defined nextPage:', nextPage);
  }

  if (DEBUG) {
    console.log(`Redirecting to: /questions/${group}/${nextPage}`);
    console.log('--- FORM SUBMISSION END (success) ---\n');
  }

  res.redirect(`/questions/${group}/${nextPage}`);
});
