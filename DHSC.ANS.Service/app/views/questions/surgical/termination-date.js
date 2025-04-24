module.exports = {
  resolve: () => null,
  validate: (sessionData, formData) => {
    const errors = [];
    const dob = formData?.terminationInformation?.surgical?.terminationDate || {};
    const { day, month, year } = dob;

    if (!day || !month || !year) {
      if (!day) {
        errors.push({
          field: 'terminationInformation.surgical.terminationDate',
          message: 'Termination date must include a day'
        });
      }

      if (!month) {
        errors.push({
          field: 'terminationInformation.surgical.terminationDate',
          message: 'Termination date must include a month'
        });
      }

      if (!year) {
        errors.push({
          field: 'terminationInformation.surgical.terminationDate',
          message: 'Termination date must include a year'
        });
      }

      return errors;
    }

    const dayNum = parseInt(day, 10);
    const monthNum = parseInt(month, 10);
    const yearNum = parseInt(year, 10);

    const isValidDate = !isNaN(dayNum) && !isNaN(monthNum) && !isNaN(yearNum)
      && dayNum >= 1 && dayNum <= 31
      && monthNum >= 1 && monthNum <= 12
      && yearNum >= 1000 && yearNum <= 9999;

    if (!isValidDate) {
      errors.push({
        field: 'terminationInformation.surgical.terminationDate',
        message: 'Wrong date format'
      });
      return errors;
    }

    const termDate = new Date(`${yearNum}-${monthNum}-${dayNum}`);
    const today = new Date();

    if (termDate > today) {
      errors.push({
        field: 'terminationInformation.surgical.terminationDate',
        message: 'Termination date must be in the past'
      });
    }

    return errors;
  }
};
