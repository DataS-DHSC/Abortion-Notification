// app/routes/forms.js

const govukPrototypeKit = require('govuk-prototype-kit');
const router            = govukPrototypeKit.requests.setupRouter();
const fs                = require('fs');
const path              = require('path');
const qs                = require('querystring');

/* ---------- load data ---------- */
//const FORMS     = JSON.parse(fs.readFileSync(path.join(__dirname, '../data/forms.json')));
const PAGE_SIZE = 15;

const BASE_FORMS = JSON.parse(
    fs.readFileSync(path.join(__dirname, '../data/forms.json'))
  );


const SORT_FIELDS = {
  dateCreated:      'dateCreated',
  formId:           'formId',
  patientReference: 'patientReference',
  clinicName:       'clinicName',
  formStatus:       'formStatus'
};

router.use('/forms', (req, res, next) => {
    if (!req.session.data || !req.session.data.forms) {
        // deep-clone so that changes to req.session.forms
        // don’t accidentally change BASE_FORMS in memory
        req.session.data.forms = JSON.parse(JSON.stringify(BASE_FORMS));
    }
    next();
});

/* ---------- GET /forms ---------- */
router.get('/forms', (req, res) => {

  const FORMS = req.session.data.forms;
  
  /* raw query params */
  const page         = parseInt(req.query.page, 10) || 1;
  const search       = (req.query.q || '').trim().toLowerCase();
  const rawClin      = [].concat(req.query.clinic  || []);
  const rawStat      = [].concat(req.query.status  || []);
  const selectedClin = rawClin.filter(v => v !== '_unchecked');
  const selectedStat = rawStat.filter(v => v !== '_unchecked');

  /* counts */
  const clinicCounts = {};
  const statusCounts = {};
  FORMS.forEach(f => {
    clinicCounts[f.clinicName] = (clinicCounts[f.clinicName] || 0) + 1;
    statusCounts[f.formStatus] = (statusCounts[f.formStatus] || 0) + 1;
  });

  /* apply filters */
  let filtered = FORMS;
  if (search) {
    filtered = filtered.filter(f =>
      f.formId.toLowerCase().includes(search) ||
      f.patientReference.includes(search)     ||
      f.clinicName.toLowerCase().includes(search)
    );
  }
  if (selectedClin.length) filtered = filtered.filter(f => selectedClin.includes(f.clinicName));
  if (selectedStat.length) filtered = filtered.filter(f => selectedStat.includes(f.formStatus));

  /* sorting */
  const sort      = SORT_FIELDS[req.query.sort] ? req.query.sort : 'dateCreated';
  const direction = req.query.direction === 'asc' ? 'asc' : 'desc';
  filtered.sort((a, b) => {
    let va = a[SORT_FIELDS[sort]];
    let vb = b[SORT_FIELDS[sort]];
    // For dates dd/mm/yyyy, parse to ISO
    if (sort === 'dateCreated') {
      const [da, ma, ya] = va.split('/');
      va = new Date(`${ya}-${ma}-${da}`);
      const [db, mb, yb] = vb.split('/');
      vb = new Date(`${yb}-${mb}-${db}`);
    }
    if (va < vb) return direction === 'asc' ? -1 : 1;
    if (va > vb) return direction === 'asc' ? 1  : -1;
    return 0;
  });

  /* pagination slice */
  const totalFiltered = filtered.length;
  const totalPages    = Math.ceil(totalFiltered / PAGE_SIZE);
  const start         = (page - 1) * PAGE_SIZE;
  const pageItems     = filtered.slice(start, start + PAGE_SIZE);

  /* query-string suffix (sort, direction, then filters) */
  const qsParts = [
    `sort=${sort}`,
    `direction=${direction}`
  ];
  if (search)                            qsParts.push(`q=${encodeURIComponent(search)}`);
  selectedClin.forEach(c =>             qsParts.push(`clinic=${encodeURIComponent(c)}`));
  selectedStat.forEach(s =>             qsParts.push(`status=${encodeURIComponent(s)}`));
  const qs = qsParts.length ? `&${qsParts.join('&')}` : '';

  /* GOV.UK pagination object */
  function link(n) {
    return {
      number:  n,
      current: n === page,
      href:    `/forms?page=${n}${qs}`
    };
  }
  const items = [];
  if (totalPages >= 1) items.push(link(1));
  if (totalPages >= 2) items.push(link(2));
  if (totalPages > 3) {
    if (page > 2 && page < totalPages) {
      items.push({ ellipsis: true }, link(page));
    }
    if (page < totalPages - 1) items.push({ ellipsis: true });
    items.push(link(totalPages));
  }
  const pagination = {
    previous: page > 1         ? { href: `/forms?page=${page - 1}${qs}` } : false,
    next:     page < totalPages ? { href: `/forms?page=${page + 1}${qs}` } : false,
    items
  };

  /* -------- arrays for MOJ Filter component -------- */
  const clinicItems = Object.keys(clinicCounts).sort().map(name => ({
    text:    name,
    value:   name,
    checked: selectedClin.includes(name)
  }));

  const statusItems = Object.keys(statusCounts).sort().map(name => ({
    text:    name[0].toUpperCase() + name.slice(1).toLowerCase(),
    value:   name,
    checked: selectedStat.includes(name)
  }));

  /* “remove this filter” links */
  const selectedClinItems = selectedClin.map(c => {
    const parts = [
      `page=1`,
      `sort=${sort}`,
      `direction=${direction}`,
      ...(search ? [`q=${encodeURIComponent(search)}`] : []),
      // all other clinics
      ...selectedClin.filter(x => x !== c)
                   .map(x => `clinic=${encodeURIComponent(x)}`),
      // all statuses
      ...selectedStat.map(s => `status=${encodeURIComponent(s)}`)
    ];
    return {
      href: `/forms?${parts.join('&')}`,
      text: c
    };
  });

  const selectedStatItems = selectedStat.map(s => {
    const parts = [
      `page=1`,
      `sort=${sort}`,
      `direction=${direction}`,
      `remove=${s}`,
      ...(search ? [`q=${encodeURIComponent(search)}`] : []),
      // all clinics
      ...selectedClin.map(c => `clinic=${encodeURIComponent(c)}`),
      // all other statuses
      ...selectedStat.filter(x => x !== s)
                     .map(x => `status=${encodeURIComponent(x)}`)
    ];
    return {
      href: `/forms?${parts.join('&')}`,
      text: s
    };
  });

  const filtersAndSort = [
    `page=${page}`,
    `sort=${sort}`,
    `direction=${direction}`,
    ...(search ? [`q=${encodeURIComponent(search)}`] : []),
    // all clinics
    ...selectedClin.map(c => `clinic=${encodeURIComponent(c)}`),
    // all other statuses
    ...selectedStat.map(x => `status=${encodeURIComponent(x)}`)
]

  /* render */
  res.render('forms', {
    forms: pageItems,

    /* counts & filters */
    page,
    totalPages,
    totalFiltered,
    totalAll: FORMS.length,
    search, sort, direction,
    clinics:  Object.keys(clinicCounts).sort().map(n => ({ name: n, count: clinicCounts[n] })),
    statuses: Object.keys(statusCounts).sort().map(n => ({ name: n, count: statusCounts[n] })),
    selectedClin,
    selectedStat,
    filterAndSort: filtersAndSort.join('&'),

    /* MOJ filter arrays */
    clinicItems,
    statusItems,
    selectedClinItems,
    selectedStatItems,

    /* GOV.UK pagination */
    pagination
  });
});

// POST /forms/:id/status  — example “action” endpoint
router.post('/forms/:formId/archive', (req, res) => {
    const { formId } = req.params;
    const { newStatus } = req.body;       
    const forms = req.session.data.forms;
  
    // find and mutate
    const f = forms.find(f => f.formId === formId);
    if (f) f.formStatus = "ARCHIVED";
  
    // redirect back to the listing (with whatever querystring you like)
    const redirectQs = qs.stringify(req.query);
    res.redirect('/forms' + (redirectQs ? '?' + redirectQs : '') + `#${formId}`);
  });

module.exports = router;
