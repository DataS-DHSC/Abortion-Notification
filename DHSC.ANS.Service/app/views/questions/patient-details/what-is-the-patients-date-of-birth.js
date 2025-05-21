function validate(_, formData) {
  const dob = formData?.patientInformation?.dateOfBirth || {};
  const { day, month, year } = dob;
  const errors = [];

  if (!day || !month || !year) {
    if (!day) {
      errors.push({
        field: 'patientInformation.dateOfBirth',
        message: 'Date of birth must include a day'
      });
    }

    if (!month) {
      errors.push({
        field: 'patientInformation.dateOfBirth',
        message: 'Date of birth must include a month'
      });
    }

    if (!year) {
      errors.push({
        field: 'patientInformation.dateOfBirth',
        message: 'Date of birth must include a year'
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
      field: 'patientInformation.dateOfBirth',
      message: 'Wrong date format'
    });
    return errors;
  }

  const dobDate = new Date(`${yearNum}-${monthNum}-${dayNum}`);
  const today = new Date();

  if (dobDate > today) {
    errors.push({
      field: 'patientInformation.dateOfBirth',
      message: 'Date of birth must be in the past'
    });
  }

  return errors;
}

// function resolve() {
//   return ''; // Replace with next page slug
// }

module.exports = { validate };
