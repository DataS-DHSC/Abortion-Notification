// app/routes/questions.js
const govukPrototypeKit = require('govuk-prototype-kit');
const router            = govukPrototypeKit.requests.setupRouter();
const set               = require('lodash.set');
const fs                = require('fs');
const path              = require('path');
const { parse }         = require('url');

/* helper */
function getBackLink(history) {
  return history && history.length > 1 ? history[history.length - 2] : '/';
}

/* ---------- QUESTIONS FLOW (unchanged) ---------- */

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

    console.log(page)
   console.log(group)


    //UPDATE
    if (page === 'has-the-patient-had-any-stillbirths-or-livebirths') {
      if (!errors.length) {
        console.log("NEW FORM TESTTTTTTT")

        const now = new Date();
        const dd = String(now.getDate()).padStart(2, '0');
        const mm = String(now.getMonth() + 1).padStart(2, '0');
        const yy = now.getFullYear().toString().slice(-2);
        const yyyy = now.getFullYear();
        const rand = Math.floor(Math.random() * 10000).toString().padStart(4, '0');

        const formId = `S${yy}${mm}-${rand}`;
        const formattedDate = `${dd}/${mm}/${yyyy}`; // dd/mm/yyyy
        
        console.log(formattedDate)
        
        // Add new form
        req.session.data.forms = req.session.data.forms || [];
        req.session.data.forms.push({
          dateCreated: formattedDate  ,
          formId: formId,
          patientReference: "21323132232",
          clinicName: "Harbourview Reproductive Health Clinic",
          formStatus: "INCOMPLETE"
        });

       res.redirect(`/forms`);
       return;
      }
    }

  res.redirect(`/questions/${group}/${nextPage}`);
});

module.exports = router;
