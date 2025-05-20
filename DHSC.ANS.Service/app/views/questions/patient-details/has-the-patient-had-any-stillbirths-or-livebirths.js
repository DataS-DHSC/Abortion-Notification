exports.validate = function (session) {
    const errors = [];
    const history = session.patientHistory || {};

    const stillbirthsKnown = history.stillbirthsOrLivebirthsOver24Weeks?.known;
    const stillbirthsNumberRaw = history.stillbirthsOrLivebirthsOver24Weeks?.number;

    const miscarriagesKnown = history.spontaneousMiscarriagesOrEctopic?.known;
    const miscarriagesNumberRaw = history.spontaneousMiscarriagesOrEctopic?.number;

    const abortionsKnown = history.previousLegalAbortions?.known;
    const abortionsNumberRaw = history.previousLegalAbortions?.number;

    if (!stillbirthsKnown) {
        errors.push({
            field: 'patientHistory.stillbirthsOrLivebirthsOver24Weeks.known',
            message: 'Select yes if the patient has had any stillbirths or livebirths over 24 weeks'
        });
    } else if (stillbirthsKnown === 'yes') {
        const stillbirthsNumberTrimmed = stillbirthsNumberRaw?.trim();
        if (!stillbirthsNumberTrimmed) {
            errors.push({
                field: 'patientHistory.stillbirthsOrLivebirthsOver24Weeks.number',
                message: 'Enter the number of stillbirths or livebirths over 24 weeks'
            });
        } else if (!/^\d+$/.test(stillbirthsNumberTrimmed)) {
            errors.push({
                field: 'patientHistory.stillbirthsOrLivebirthsOver24Weeks.number',
                message: 'Enter numbers only, do not use letters'
            });
        }
    }

    if (!miscarriagesKnown) {
        errors.push({
            field: 'patientHistory.spontaneousMiscarriagesOrEctopic.known',
            message: 'Select yes if the patient has had any spontaneous miscarriages or ectopic pregnancies'
        });
    } else if (miscarriagesKnown === 'yes') {
        const miscarriagesNumberTrimmed = miscarriagesNumberRaw?.trim();
        if (!miscarriagesNumberTrimmed) {
            errors.push({
                field: 'patientHistory.spontaneousMiscarriagesOrEctopic.number',
                message: 'Enter the number of spontaneous miscarriages or ectopic pregnancies'
            });
        } else if (!/^\d+$/.test(miscarriagesNumberTrimmed)) {
            errors.push({
                field: 'patientHistory.spontaneousMiscarriagesOrEctopic.number',
                message: 'Enter numbers only, do not use letters'
            });
        }
    }

    if (!abortionsKnown) {
        errors.push({
            field: 'patientHistory.previousLegalAbortions.known',
            message: 'Select yes if the patient has had any legal abortions before'
        });
    } else if (abortionsKnown === 'yes') {
        const abortionsNumberTrimmed = abortionsNumberRaw?.trim();
        if (!abortionsNumberTrimmed) {
            errors.push({
                field: 'patientHistory.previousLegalAbortions.number',
                message: 'Enter the number of legal abortions'
            });
        } else if (!/^\d+$/.test(abortionsNumberTrimmed)) {
            errors.push({
                field: 'patientHistory.previousLegalAbortions.number',
                message: 'Enter numbers only, do not use letters'
            });
        }
    }

    return errors;
};

// Ensure your resolve function is defined as needed for your application flow
// For example, if it was the placeholder from before:
// exports.resolve = function (session) {
//   return 'REPLACE_WITH_NEXT_PAGE_SLUG';
// };