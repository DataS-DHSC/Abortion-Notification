// File: views/questions/practitioner-details/hsa1-signing-location-postcode.js

module.exports = {
  validate: (sessionData, formData) => {
    const errors = [];

    const postcode = formData["practitionerInfo.hsa1SigningLocation.postcode"];
    const selectedAddress = formData["practitionerInfo.hsa1SigningLocation.selectedAddress"];

    if (!postcode || postcode.trim() === "") {
      errors.push({
        field: "practitionerInfo.hsa1SigningLocation.postcode",
        message: "Enter a postcode"
      });
    }

    if (!selectedAddress || selectedAddress.trim() === "") {
      errors.push({
        field: "practitionerInfo.hsa1SigningLocation.selectedAddress",
        message: "Select an address from the list"
      });
    }

    return errors;
  },

  resolve: (sessionData, formData) => {
    const addressKey = formData["practitionerInfo.hsa1SigningLocation.selectedAddress"];
    const addressBook = {
      "1": {
        name: "Prime Minister & First Lord of the Treasury",
        address: "10 Downing Street",
        postcode: "SW1A 2AA"
      },
      "2": {
        name: "Chancellor of the Exchequer",
        address: "11 Downing Street",
        postcode: "SW1A 2AB"
      },
      "3": {
        name: "Government Chief Whips Office",
        address: "12 Downing Street",
        postcode: "SW1A 2AD"
      }
    };

    if (addressKey && addressBook[addressKey]) {
      sessionData.practitionerInfo = sessionData.practitionerInfo || {};
      sessionData.practitionerInfo.hsa1SigningLocation = {
        name: addressBook[addressKey].name,
        address: addressBook[addressKey].address,
        postcode: addressBook[addressKey].postcode
      };
    }

    return "hsa1-signing-location-address";
  }
};
