module.exports = {
  validate: (data, formData) => {
    const errors = [];
    const fullName = formData?.patientInformation?.name?.fullName;

    if (!fullName || fullName.trim() === '') {
      errors.push({
        field: 'patientInformation.name.fullName',
        message: 'Enter the patient’s full name'
      });
    }

    return errors;
  },

  resolve: () => {
    return '';
  }
};
