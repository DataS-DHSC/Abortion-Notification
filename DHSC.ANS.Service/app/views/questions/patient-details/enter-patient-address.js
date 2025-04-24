exports.validate = function (session) {
    const address = session.patientInformation?.address || {};
    const errors = [];
  
    if (!address.line1) {
      errors.push({
        field: 'patientInformation.address.line1',
        message: 'Enter address line 1'
      });
    }
  
    if (!address.town) {
      errors.push({
        field: 'patientInformation.address.town',
        message: 'Enter the town or city'
      });
    }
  
    if (!address.postcode) {
      errors.push({
        field: 'patientInformation.address.postcode',
        message: 'Enter the postcode'
      });
    }
  
    return errors;
  };
  
  exports.resolve = function () {
    return '';
  };
  