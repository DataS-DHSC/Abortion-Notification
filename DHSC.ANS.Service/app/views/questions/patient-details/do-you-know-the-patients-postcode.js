module.exports = {
  validate(sessionData) {
    const errors = [];
    const knowPostcode = sessionData?.patientInformation?.postcode?.known;
    const postcodeValueRaw = sessionData?.patientInformation?.address?.postcode;

    if (!knowPostcode) {
      errors.push({
        field: 'patientInformation.postcode.known',
        message: 'Select whether you know the patient’s postcode'
      });
    } else if (knowPostcode === 'yes') {
      if (!postcodeValueRaw || postcodeValueRaw.trim() === '') {
        errors.push({
          field: 'patientInformation.address.postcode',
          message: 'Enter a full UK postcode'
        });
      } else {
        const cleanedPostcode = postcodeValueRaw
            .replace(/[\s\-().]/g, '')
            .toUpperCase();

        if (cleanedPostcode === '') {
          errors.push({
            field: 'patientInformation.address.postcode',
            message: 'Enter a full UK postcode'
          });
        } else if (!/^[A-Z0-9]+$/.test(cleanedPostcode)) {
          errors.push({
            field: 'patientInformation.address.postcode',
            message: 'Enter a full UK postcode'
          });
        } else if (cleanedPostcode.length < 5 || cleanedPostcode.length > 7) {
          errors.push({
            field: 'patientInformation.address.postcode',
            message: 'Enter a full UK postcode'
          });
        } else {
          const inwardCode = cleanedPostcode.slice(-3);
          const outwardCode = cleanedPostcode.slice(0, -3);

          const isInvalidInwardFormat = !/^[0-9][A-Z]{2}$/.test(inwardCode);
          const outwardCodeLacksLetter = !/[A-Z]/.test(outwardCode);

          if (isInvalidInwardFormat || outwardCodeLacksLetter) {
            errors.push({
              field: 'patientInformation.address.postcode',
              message: 'Enter a full UK postcode'
            });
          }
        }
      }
    }
    return errors;
  },

  resolve(sessionData) {
    return 'what-is-the-patients-ethnic-group';
  }
};