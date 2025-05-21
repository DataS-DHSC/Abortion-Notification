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

exports.resolve = function (session) {
  return session.patientInformation.livesInEnglandOrWales === 'yes'
    ? 'do-you-know-the-patients-postcode'
    : 'which-country-does-the-patient-live-in';
};
