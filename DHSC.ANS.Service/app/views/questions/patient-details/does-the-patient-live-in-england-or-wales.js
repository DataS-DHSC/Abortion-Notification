exports.validate = function (session) {
  const value = session.patientInformation?.livesInEnglandOrWales;
  if (!value) {
    return [{
      field: 'patientInformation.livesInEnglandOrWales',
      message: 'Select yes if the patient lives in England or Wales'
    }];
  }
  return [];
};

// exports.resolve = function (session) {
//   return session.patientInformation.livesInEnglandOrWales === 'yes'
//     ? 'what-is-the-patients-postcode'
//     : 'does-the-patient-live-in-another-country';
// };
