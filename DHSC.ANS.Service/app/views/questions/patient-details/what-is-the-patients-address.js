exports.validate = function (session) {
    const errors = [];
    const address = session.patientAddress || {}; // Ensure address object exists

    const addressLine1 = address.line1?.trim();
    const townOrCity = address.townOrCity?.trim();

    if (!addressLine1) {
        errors.push({
            field: 'patientAddress.line1',
            message: 'Enter address line 1, typically the building and street'
        });
    }

    if (!townOrCity) {
        errors.push({
            field: 'patientAddress.townOrCity',
            message: 'Enter town or city'
        });
    }

    return errors;
};

    // exports.resolve = function (session) {
    //     // This function determines the next page slug after successful validation.
    //     // Update this based on your application's flow.
    //     return 'REPLACE_WITH_NEXT_PAGE_SLUG';
    // };