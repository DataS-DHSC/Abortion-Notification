function resolve(sessionData, formData) {
    const funding = sessionData?.termination?.funding?.source;

    if (funding === 'nhs')   return 'did-the-termination-take-place-at-this-clinic-or-hospital';
    if (funding === 'private') return 'which-provider-funded-the-abortion';

    return null;
}

function validate(sessionData, formData) {
    const errors = [];

    const value = formData?.termination?.funding?.source;
    if (!value) {
        errors.push({
            field: 'termination.funding.source',
            message: 'Select whether the abortion was NHS or privately funded'
        });
    }

    return errors;
}

module.exports = { resolve, validate };
