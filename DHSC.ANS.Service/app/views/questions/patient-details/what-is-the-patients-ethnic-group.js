exports.validate = function (session) {
    const value = session.patientInformation?.ethnicGroup;
    if (!value) {
      return [{
        field: 'patientInformation.ethnicGroup',
        message: 'Select an ethnic group'
      }];
    }
    return [];
  };
  
  exports.resolve = function (session) {
      console.log("RESOLVE")
    return session.patientInformation?.ethnicGroup == 'white' ? 'what-is-the-patients-white-background' : 'what-is-the-patients-marital-status';
  };
  