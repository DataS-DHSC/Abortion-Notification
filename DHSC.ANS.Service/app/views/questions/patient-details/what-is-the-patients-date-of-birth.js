  function validate(_, formData) {
    console.log("validate DOB")
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

  function resolve(formData) {
    console.log("PATIENT DOB RESOLVE")
    const dobData = formData?.patientInformation?.dateOfBirth || {};
    const { day, month, year } = dobData;

    // Assuming `validate` function has already run and ensured day, month, year are valid
    // and form a legitimate date that is in the past.
    // If validate didn't run or formData could be manipulated, add full validation here too.
    const dayNum = parseInt(day, 10);
    const monthNum = parseInt(month, 10); // month from form is 1-indexed
    const yearNum = parseInt(year, 10);

    const today = new Date();
    const birthDate = new Date(yearNum, monthNum - 1, dayNum); // JS Date month is 0-indexed

    let age = today.getFullYear() - birthDate.getFullYear();
    const monthDifference = today.getMonth() - birthDate.getMonth();

    if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }

    if (age > 55 || age < 13) {
      console.log(`PATIENT AGE IS: ${age}`)
      return 'confirm-patient-age';
    } else {
      // IMPORTANT: Replace this with the slug for your default next page
      return 'does-the-patient-live-in-england-or-wales';
    }
  }
  
  module.exports = { validate, resolve };
