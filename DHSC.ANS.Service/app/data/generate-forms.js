/* app/data/generate-forms.js */
const fs   = require('fs');
const path = require('path');

const TOTAL_RECORDS = 150;
const STATUSES      = Array(13).fill('INCOMPLETE').concat(['RETURNED', 'SUBMITTED']);
const CLINICS       = [
  'Riverside Women’s Health Centre',
  'Northgate Reproductive Care Clinic',
  'St Anne’s Women’s Services Unit',
  'Maple Grove Medical Centre',
  'Harbourview Reproductive Health Clinic'
];

const forms = [];

for (let i = 0; i < TOTAL_RECORDS; i += 1) {
  const date       = new Date(2024, 11, 14 + Math.floor(i / 15));      // 14 Dec 2024 onwards
  const formatted  = date.toLocaleDateString('en-GB');                 // dd/mm/yyyy
  const clinicName = CLINICS[i % CLINICS.length];                      // round-robin distribution

  forms.push({
    dateCreated:       formatted,
    formId:            `S2406-${(i + 1).toString().padStart(4, '0')}`,
    patientReference:  `2132313${(2123 + i).toString().padStart(4, '0')}`,
    clinicName,
    formStatus:        STATUSES[i % STATUSES.length]
  });
}

fs.writeFileSync(
  path.join(__dirname, 'forms.json'),
  JSON.stringify(forms, null, 2)
);

console.log(`✔ Generated ${forms.length} test records across ${CLINICS.length} clinics → app/data/forms.json`);
