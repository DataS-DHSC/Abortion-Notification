function validate(sessionData, formData) {
  const answer = formData?.patientInformation?.hospitalOrClinic?.numberKnown;
  const errors = [];

  if (!answer || (answer !== 'yes' && answer !== 'no')) {
    errors.push({
      field: 'patientInformation.hospitalOrClinic.numberKnown',
      message: 'Select yes if you know the hospital or clinic number'
    });
  }

  return errors;
}

function resolve(sessionData, formData) {
  const answer = sessionData?.patientInformation?.hospitalOrClinic?.numberKnown;
  if (answer === 'yes') return 'what-is-the-hospital-or-clinic-number';
  if (answer === 'no') return 'what-is-the-patients-name';
  return null;
}

module.exports = { validate, resolve };
