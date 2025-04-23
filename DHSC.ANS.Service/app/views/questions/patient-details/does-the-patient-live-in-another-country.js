module.exports = {
  validate: (sessionData) => {
    const value = sessionData?.patientInformation?.country?.otherCountry;
    const errors = [];

    if (!value) {
      errors.push({
        field: "patientInformation.country.otherCountry",
        message: "Select yes if the patient lives in another country"
      });
    }

    return errors;
  },

  resolve: (sessionData) => {
    const answer = sessionData?.patientInformation?.country?.otherCountry;
    if (answer === "yes") {
      return "hsa1-signing-location-postcode";
    } else {
      return "what-is-the-patients-postcode";
    }
  }
};
