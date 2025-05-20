exports.validate = function (session) {
    const value = session.patientInformation?.ethnicGroupWhite;
    if (!value) {
      return [{
        field: 'patientInformation.ethnicGroupWhite',
        message: "Select the patient's background"
      }];
    }
    return [];
  };
  
  exports.resolve = function () {
    return '';
  };
  