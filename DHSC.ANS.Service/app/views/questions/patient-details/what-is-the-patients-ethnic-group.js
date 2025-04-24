exports.validate = function (session) {
    const value = session.patientInformation?.ethnicGroup;
    if (!value) {
      return [{
        field: 'patientInformation.ethnicGroup',
        message: 'Select the patient’s ethnic group'
      }];
    }
    return [];
  };
  
  exports.resolve = function () {
    return '';
  };
  