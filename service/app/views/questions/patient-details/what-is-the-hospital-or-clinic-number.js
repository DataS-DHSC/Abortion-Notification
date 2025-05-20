function validate(sessionData, formData) {
  const errors = [];
  const value = formData.patientInformation.hospitalOrClinic.hospitalOrClinicNumber?.trim();
console.log(formData)
  if (!value) {
    errors.push({
      field: 'patientInformation.hospitalOrClinic.hospitalOrClinicNumber',
      message: 'Enter the hospital or clinic number'
    });
  } else if (!/^\d+$/.test(value)) {
    errors.push({
      field: 'patientInformation.hospitalOrClinic.hospitalOrClinicNumber',
      message: 'The hospital or clinic number must not contain letters'
    });
  } else if (value.length !== 10) {
    errors.push({
      field: 'patientInformation.hospitalOrClinic.hospitalOrClinicNumber',
      message: `The hospital or clinic number is too ${value.length < 10 ? 'short' : 'long'}`
    });
  }

  return errors;
}

function resolve() {
  return '';
}

module.exports = { validate, resolve };
