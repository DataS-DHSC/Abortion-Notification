exports.validate = function (session) {
    const value = session.patientInformation?.ethnicGroupWhite;
    if (!value) {
      return [{
        field: 'patientInformation.ethnicGroupWhite',
        message: 'Select the option that best describes the patient’s White background'
      }];
    }
    return [];
  };
  
  exports.resolve = function () {
    return '';
  };
  