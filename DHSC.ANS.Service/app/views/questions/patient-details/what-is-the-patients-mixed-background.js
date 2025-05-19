exports.validate = function (session) {
    const value = session.patientInformation?.ethnicGroupMixed;
    if (!value) {
      return [{
        field: 'patientInformation.ethnicGroupMixed',
        message: 'Select the option that best describes the patient’s mixed or multiple ethnic groups background'
      }];
    }
    return [];
  };
  
  exports.resolve = function () {
    return '';
  };
  