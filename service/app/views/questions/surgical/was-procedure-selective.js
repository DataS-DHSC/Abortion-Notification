module.exports = {
  resolve: (sessionData) => {
    const answer = sessionData?.terminationInformation?.surgical?.wasSelective;
    if (answer === 'yes') return 'fetuses-before';
    if (answer === 'no') return 'termination-date';
    return null;
  },
  validate: (sessionData, formData) => {
    const errors = [];

    const value = formData?.terminationInformation?.surgical?.wasSelective;
    if (!value) {
      errors.push({
        field: 'terminationInformation.surgical.wasSelective',
        message: 'Select yes if the procedure was selective'
      });
    }

    return errors;
  }
};
