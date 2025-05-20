exports.validate = function (session) {
    const errors = [];
    const demographics = session.patientDemographics || {};
    const nhsNumberKnown = demographics.nhsNumberKnown;
    const nhsNumberValueRaw = demographics.nhsNumberValue;

    if (!nhsNumberKnown) {
        errors.push({
            field: 'patientDemographics.nhsNumberKnown',
            message: 'Select yes if you know the patient’s NHS number'
        });
    } else if (nhsNumberKnown === 'yes') {
        const nhsNumberTrimmed = nhsNumberValueRaw?.trim();

        if (!nhsNumberTrimmed) {
            errors.push({
                field: 'patientDemographics.nhsNumberValue',
                message: 'Enter the NHS number'
            });
        } else {
            const processedNhsNumber = nhsNumberTrimmed.replace(/[-\s]/g, "");

            if (!/^\d*$/.test(processedNhsNumber)) {
                errors.push({
                    field: 'patientDemographics.nhsNumberValue',
                    message: 'The NHS number must not contain letters'
                });
            } else if (processedNhsNumber.length > 10) {
                errors.push({
                    field: 'patientDemographics.nhsNumberValue',
                    message: 'The patient\'s NHS number is too long'
                });
            } else if (processedNhsNumber.length < 10) {
                errors.push({
                    field: 'patientDemographics.nhsNumberValue',
                    message: 'The patient\'s NHS number is too short'
                });
            }
        }
    }
    return errors;
};

exports.resolve = function (session) {
   return session.patientDemographics.nhsNumberKnown == 'yes' ? 'what-is-the-patients-date-of-birth' : 'what-is-the-patients-name';
}; 