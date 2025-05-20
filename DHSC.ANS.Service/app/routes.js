const govukPrototypeKit = require('govuk-prototype-kit');
const router = govukPrototypeKit.requests.setupRouter();

// ──────────────────────────────────────────────────────────────
// Mount extra route-files here (one line per file)
// ──────────────────────────────────────────────────────────────
router.use('/', require('./routes/forms'));      // --> app/routes/forms.js
router.use('/', require('./routes/questions'));  // --> app/routes/questions.js

module.exports = router;
