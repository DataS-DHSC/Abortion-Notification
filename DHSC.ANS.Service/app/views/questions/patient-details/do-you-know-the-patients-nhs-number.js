function resolve(sessionData, formData) {
    const answer = sessionData?.patientInformation?.nhsNumber?.nhsNumberKnown;
    if (answer === 'yes') return 'what-is-the-patients-nhs-number';
    if (answer === 'no') return 'do-you-know-the-place-number';
    return null;
}

function validate(sessionData, formData) {
    const errors = [];
  
    console.log("here");

    const value = formData?.patientInformation?.nhsNumber?.nhsNumberKnown;
    if (!value) {
      errors.push({
        field: 'patientInformation.nhsNumber.nhsNumberKnown',
        message: 'Select yes if you know the patient’s NHS number'
      });
    }
  
    return errors;
}

module.exports = { 
    resolve, 
    validate 
};