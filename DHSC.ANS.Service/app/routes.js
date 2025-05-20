const govukPrototypeKit = require('govuk-prototype-kit');
const router            = govukPrototypeKit.requests.setupRouter();
const set               = require('lodash.set');
const fs                = require('fs');
const path              = require('path');
const { parse }         = require('url');

const DEBUG = true;

/* ---------- helper for the questions flow --------- */
function getBackLink(history) {
  return history && history.length > 1 ? history[history.length - 2] : '/';
}

/* ---------- FORMS LIST ROUTE ---------- */

const FORMS      = JSON.parse(fs.readFileSync(path.join(__dirname, '../data/forms.json')));
const PAGE_SIZE  = 15;

router.get('/forms', (req, res) => {
  const page   = parseInt(req.query.page, 10) || 1;
  const search = (req.query.q || '').trim().toLowerCase();

  let filtered = FORMS;
  if (search) {
    filtered = FORMS.filter(f =>
      f.formId.toLowerCase().includes(search) ||
      f.patientReference.includes(search)     ||
      f.clinicName.toLowerCase().includes(search)
    );
  }

  const totalPages = Math.ceil(filtered.length / PAGE_SIZE);
  const start      = (page - 1) * PAGE_SIZE;
  const items      = filtered.slice(start, start + PAGE_SIZE);

  res.render('forms', { forms: items, page, totalPages, search });
});

/* ---------- QUESTIONS FLOW (unchanged) ---------- */

router.get('/questions/:group/:page', (req, res) => {
  const { group, page } = req.params;
  const currentPath     = `/questions/${group}/${page}`;
  const referrerPath    = parse(req.get('Referer') || '').pathname;

  req.session.data.history = req.session.data.history || [];
  const history     = req.session.data.history;
  const last        = history[history.length - 1];
  const secondLast  = history[history.length - 2];

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

  const pageJsPath = path.join(__dirname, `./views/questions/${group}/${page}.js`);
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

  res.redirect(`/questions/${group}/${nextPage}`);
});

module.exports = router;
