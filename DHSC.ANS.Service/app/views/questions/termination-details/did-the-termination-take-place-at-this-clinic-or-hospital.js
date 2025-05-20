function resolve(sessionData, formData) {
    const answer = sessionData?.termination?.location?.atClinic;
    
    if (answer === 'yes') return 'where-did-termination-take-place-postcode';
    if (answer === 'no')  return 'where-did-termination-take-place-postcode';
    
    return null;
}

function validate(sessionData, formData) {
    const errors = [];

    const value = formData?.termination?.location?.atClinic;
    if (!value) {
        errors.push({
            field: 'termination.location.atClinic',
            message: 'Select yes if the termination took place at this clinic or hospital'
        });
    }

    return errors;
}

module.exports = { resolve, validate };
