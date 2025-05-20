
exports.validate = function (session) {
    const errors = [];
    const maritalStatus = session.patientInformation?.maritalStatus;

    if (!maritalStatus) {
        errors.push({
            field: 'patientInformation.maritalStatus',
            message: 'Select a marital or civil partnership status'
        });
    }
    return errors;
};

// exports.resolve = function (session) {
//     const maritalStatus = session.patientInformation?.maritalStatus;
//    
//    
//     return '';
// };