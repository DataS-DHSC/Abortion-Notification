const govukPrototypeKit = require('govuk-prototype-kit');
const router = govukPrototypeKit.requests.setupRouter();

const path    = require('path');
const express = require('express');

// ──────────────────────────────────────────────────────────────
// Mount extra route-files here (one line per file)
// ──────────────────────────────────────────────────────────────
router.use('/', require('./routes/default'));      // --> app/routes/forms.js
router.use('/', require('./routes/forms'));      // --> app/routes/forms.js
router.use('/', require('./routes/questions'));  // --> app/routes/questions.js

router.use(
  '/assets',
  express.static(path.join(__dirname, 'assets'))
);

module.exports = router;
