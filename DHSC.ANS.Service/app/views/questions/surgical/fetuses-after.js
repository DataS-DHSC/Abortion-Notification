module.exports = {
  resolve: () => null,
  validate: (sessionData, formData) => {
    const errors = [];
    const value = formData?.terminationInformation?.surgical?.fetusesAfter;

    if (!value) {
      errors.push({
        field: 'terminationInformation.surgical.fetusesAfter',
        message: 'Enter the number of fetuses after'
      });
    } else if (!/^\d+$/.test(value)) {
      errors.push({
        field: 'terminationInformation.surgical.fetusesAfter',
        message: 'The number must not contain letters'
      });
    }

    return errors;
  }
};
