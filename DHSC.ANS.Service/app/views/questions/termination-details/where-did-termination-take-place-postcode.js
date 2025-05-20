function validate(sessionData, formData) {
    const value = sessionData?.termination?.location?.postcode?.trim();
    const errors = [];

    if (!value) {
        errors.push({
            field: 'termination.location.postcode', 
            message: 'Enter the postcode'         
        });
    } else if (!/^[A-Z]{1,2}\d[A-Z\d]?\s?\d[A-Z]{2}$/i.test(value)) {
        errors.push({
            field: 'termination.location.postcode', 
            message: 'Enter a valid UK postcode'   
        });
    }

    return errors;
}

function resolve(sessionData, formData) {
    return 'hospital-or-clinic-address-where-abortion-took-place';
}

module.exports = { resolve, validate };