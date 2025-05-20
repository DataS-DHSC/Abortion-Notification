const postcodeRegex = /^[A-Z]{1,2}\d[A-Z\d]?\s?\d[A-Z]{2}$/i;

function validate(sessionData, formData) {
    const value = formData?.patient?.address?.postcode?.trim();
    const errors = [];

    if (!value) {
        errors.push({
            field: 'patient.address.postcode',
            message: 'Enter the postcode'
        });
    } else if (!postcodeRegex.test(value)) {
        errors.push({
            field: 'patient.address.postcode',
            message: 'Enter a valid UK postcode'
        });
    }

    return errors;
}

function resolve(sessionData, formData) {
    return 'patient-address-select';
}

module.exports = { resolve, validate };