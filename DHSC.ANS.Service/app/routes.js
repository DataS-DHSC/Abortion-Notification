const govukPrototypeKit = require('govuk-prototype-kit');
const router = govukPrototypeKit.requests.setupRouter();
const set = require('lodash.set');
const fs = require('fs');
const path = require('path');
const { parse } = require('url');

const DEBUG = true;

function getBackLink(sessionHistory) {
    return sessionHistory && sessionHistory.length > 1
      ? sessionHistory[sessionHistory.length - 2]
      : '/';
  }
 
// GET route with session-based backLink and debug output
router.get('/questions/:group/:page', (req, res) => {
    const { group, page } = req.params;
    const currentPath = `/questions/${group}/${page}`;
    const referrer = req.get('Referer') || '';
    const referrerPath = parse(referrer).pathname;
  
    req.session.data.history = req.session.data.history || [];
  
    // Is this a back navigation?
    const history = req.session.data.history;
    const last = history[history.length - 1];
    const secondLast = history[history.length - 2];
  
    console.log('--- PAGE LOAD ---');
    console.log('Current:', currentPath);
    console.log('Referrer:', referrerPath);
    console.log('Session BEFORE:', [...history]);

    console.log(`Comparing for back nav: referrerPath=${referrerPath}, last=${last}, currentPath=${currentPath}, secondLast=${secondLast}`);

    if (referrerPath === last && currentPath === secondLast) {
      // Back nav detected: Remove both last and second-last, replace with current
      history.pop(); // currentPath
      history.pop(); // referrerPath
      history.push(currentPath);
    } else if (last !== currentPath) {
      // Forward nav or new load
      history.push(currentPath);
    }
  
    const backLink = getBackLink(req.session.data.history);
  
    console.log('Session AFTER:', [...history]);
    console.log('Back link:', backLink);
    console.log('-----------------\n');
  
    res.render(`questions/${group}/${page}`, { backLink });
  });
  

  router.post('/questions/:group/:page', async function (req, res) {
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
  
    // Initialise session.data.formData if needed
    req.session.data.formData = req.session.data.formData || {};
  
    // Merge cleaned formData into session.data.formData
    Object.entries(formData).forEach(([key, value]) => {
      set(req.session.data.formData, key, value);
    });
  
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
        errors = pageModule.validate(req.session.data.formData, formData);
        if (DEBUG && errors.length) console.log('Validation errors:', JSON.stringify(errors, null, 2));
      }
  
      if (!errors.length && typeof pageModule.resolve === 'function') {
        nextPage = pageModule.resolve(req.session.data.formData, formData);
        if (DEBUG) console.log('Page resolver selected next page:', nextPage);
      }
    }
  
    // Determine backlink for error re-render
    const currentPath = `/questions/${group}/${page}`;
    req.session.history = req.session.history || [];
  
    const backLink = getBackLink(req.session.data.history);
  
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