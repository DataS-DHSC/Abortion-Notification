function validate(sessionData, formData) {
  const value = formData?.patientInformation?.nhsNumber?.nhsNumber;
  const errors = [];

  if (!value || value.trim() === '') {
    errors.push({
      field: 'patientInformation.nhsNumber.nhsNumber',
      message: 'Enter the NHS number'
    });
  } else if (!/^\d+$/.test(value)) {
    errors.push({
      field: 'patientInformation.nhsNumber.nhsNumber',
      message: 'The NHS number must not contain letters'
    });
  } else if (value.length !== 10) {
    errors.push({
      field: 'patientInformation.nhsNumber.nhsNumber',
      message: 'The NHS number must be 10 digits long'
    });
  }

  return errors;
}

function resolve() {
  return ''; // or next page slug
}

module.exports = { validate, resolve };
