module.exports = {
  validate(sessionData) {
    const value = sessionData?.patientInformation?.address?.postcode?.trim();
    const errors = [];

    if (!value) {
      errors.push({
        field: 'patientInformation.address.postcode',
        message: 'Enter the postcode'
      });
    } else if (!/^[A-Z]{1,2}\d[A-Z\d]?\s?\d[A-Z]{2}$/i.test(value)) {
      errors.push({
        field: 'patientInformation.address.postcode',
        message: 'Enter a valid UK postcode'
      });
    }

    return errors;
  },

  resolve() {
    return ''; // next screen slug
  }
};
