module.exports = {
  resolve: () => null,
  validate: (sessionData, formData) => {
    const errors = [];
    const value = formData?.terminationInformation?.surgical?.fetusesBefore;

    if (!value) {
      errors.push({
        field: 'terminationInformation.surgical.fetusesBefore',
        message: 'Enter the number of fetuses before'
      });
    } else if (!/^\d+$/.test(value)) {
      errors.push({
        field: 'terminationInformation.surgical.fetusesBefore',
        message: 'The number must not contain letters'
      });
    }

    return errors;
  }
};
