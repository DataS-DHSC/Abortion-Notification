function resolve(sessionData, formData) {
    const answer = sessionData?.patientInformation?.hospitalNumber?.known;
    if (answer === 'yes') return 'what-is-the-patients-date-of-birth';
    if (answer === 'no') return 'do-you-know-the-place-number';
    return null;
}

function validate(sessionData, formData) {
    const errors = [];
    
    const value = formData?.patientInformation?.hospitalNumber?.known;
    if (!value) {
        errors.push({
            field: 'patientInformation.hospitalNumber.known',
            message: 'Select yes if you know the patient’s hospital or clinic number'
        });
    }

    // If "yes" is selected, validate the input field
    if (value === 'yes') {

        const number = formData?.patientInformation?.hospitalNumber?.number;

        if (!number || number.trim() === '') {
            errors.push({
                field: 'patientInformation.hospitalNumber.number',
                message: 'Enter the patient’s hospital or clinic number'
            });
        } else if (number.length > 10) {
            console.log("10 chars")
            errors.push({
                field: 'patientInformation.hospitalNumber.number',
                message: 'The hospital or clinic number must be 10 characters or fewer'
            });
        }
    }

    return errors;
}

module.exports = {
    resolve,
    validate
};
