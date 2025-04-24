exports.validate = function (session) {
  const value = session.patientInformation?.country?.name;
  if (!value) {
    return [{
      field: 'patientInformation.country.name',
      message: 'Select the country the patient lives in'
    }];
  }
  return [];
};

exports.resolve = function () {
  return '';
};
