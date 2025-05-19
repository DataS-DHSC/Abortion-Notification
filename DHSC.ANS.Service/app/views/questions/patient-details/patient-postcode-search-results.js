exports.validate = function (session) {
    const value = session.patientInformation?.address?.selectedAddress;
    if (!value) {
      return [{
        field: 'patientInformation.address.selectedAddress',
        message: 'Select an address or choose to manually add it'
      }];
    }
    return [];
  };
  
  exports.resolve = function () {
    return '';
  };
  