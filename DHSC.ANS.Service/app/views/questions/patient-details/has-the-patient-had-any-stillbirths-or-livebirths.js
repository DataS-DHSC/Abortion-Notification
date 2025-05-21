exports.validate = function (sessionData) {
    console.log("\n--- VALIDATE FUNCTION CALLED (has-the-patient-had-any-stillbirths-or-livebirths.js) ---");
    // Log the entire patientHistory object as received
    console.log("Received sessionData.patientHistory:", JSON.stringify(sessionData.patientHistory, null, 2));
    // Also log the full sessionData to see if patientHistory is nested correctly
    // console.log("Full sessionData received by validate:", JSON.stringify(sessionData, null, 2));


    const errors = [];
    const history = sessionData.patientHistory || {};

    // --- Stillbirths or livebirths over 24 weeks ---
    const stillbirthsKnown = history.stillbirthsOrLivebirthsOver24Weeks?.known;
    const stillbirthsNumberRaw = history.stillbirthsOrLivebirthsOver24Weeks?.number;
    console.log("[Stillbirths] 'known' value from session:", stillbirthsKnown, "(type:", typeof stillbirthsKnown + ")");
    console.log("[Stillbirths] 'numberRaw' value from session:", stillbirthsNumberRaw, "(type:", typeof stillbirthsNumberRaw + ")");

    if (!stillbirthsKnown) {
        console.log("LOG [Stillbirths]: 'known' is falsy. Adding error: 'Select yes if...'");
        errors.push({
            field: 'patientHistory.stillbirthsOrLivebirthsOver24Weeks.known',
            message: 'Select yes if the patient has had any stillbirths or livebirths over 24 weeks'
        });
    } else if (stillbirthsKnown === 'yes') {
        console.log("LOG [Stillbirths]: 'known' is 'yes'. Validating number.");
        const stillbirthsNumberTrimmed = stillbirthsNumberRaw?.trim();
        console.log("LOG [Stillbirths]: Number Trimmed:", stillbirthsNumberTrimmed);
        if (!stillbirthsNumberTrimmed) {
            console.log("LOG [Stillbirths]: Number is blank. Adding error: 'Enter the number...'");
            errors.push({
                field: 'patientHistory.stillbirthsOrLivebirthsOver24Weeks.number',
                message: 'Enter the number of stillbirths or livebirths over 24 weeks'
            });
        } else if (!/^\d+$/.test(stillbirthsNumberTrimmed)) {
            console.log("LOG [Stillbirths]: Number contains non-digits. Adding error: 'Enter numbers only...'");
            errors.push({
                field: 'patientHistory.stillbirthsOrLivebirthsOver24Weeks.number',
                message: 'Enter numbers only, do not use letters'
            });
        } else {
            console.log("LOG [Stillbirths]: Number is valid ('yes' path).");
        }
    } else if (stillbirthsKnown === 'no') {
        console.log("LOG [Stillbirths]: 'known' is 'no'. No errors for this section.");
    } else {
        console.log("LOG [Stillbirths]: 'known' is an unexpected value:", stillbirthsKnown);
        // This case might indicate an issue if 'known' is neither 'yes', 'no', nor falsy
        errors.push({
            field: 'patientHistory.stillbirthsOrLivebirthsOver24Weeks.known',
            message: 'Invalid selection for stillbirths or livebirths over 24 weeks'
        });
    }

    // --- Spontaneous miscarriages or ectopic pregnancies ---
    const miscarriagesKnown = history.spontaneousMiscarriagesOrEctopic?.known;
    const miscarriagesNumberRaw = history.spontaneousMiscarriagesOrEctopic?.number;
    console.log("[Miscarriages] 'known' value from session:", miscarriagesKnown, "(type:", typeof miscarriagesKnown + ")");
    console.log("[Miscarriages] 'numberRaw' value from session:", miscarriagesNumberRaw, "(type:", typeof miscarriagesNumberRaw + ")");

    if (!miscarriagesKnown) {
        console.log("LOG [Miscarriages]: 'known' is falsy. Adding error: 'Select yes if...'");
        errors.push({
            field: 'patientHistory.spontaneousMiscarriagesOrEctopic.known',
            message: 'Select yes if the patient has had any spontaneous miscarriages or ectopic pregnancies'
        });
    } else if (miscarriagesKnown === 'yes') {
        console.log("LOG [Miscarriages]: 'known' is 'yes'. Validating number.");
        const miscarriagesNumberTrimmed = miscarriagesNumberRaw?.trim();
        console.log("LOG [Miscarriages]: Number Trimmed:", miscarriagesNumberTrimmed);
        if (!miscarriagesNumberTrimmed) {
            console.log("LOG [Miscarriages]: Number is blank. Adding error: 'Enter the number...'");
            errors.push({
                field: 'patientHistory.spontaneousMiscarriagesOrEctopic.number',
                message: 'Enter the number of spontaneous miscarriages or ectopic pregnancies'
            });
        } else if (!/^\d+$/.test(miscarriagesNumberTrimmed)) {
            console.log("LOG [Miscarriages]: Number contains non-digits. Adding error: 'Enter numbers only...'");
            errors.push({
                field: 'patientHistory.spontaneousMiscarriagesOrEctopic.number',
                message: 'Enter numbers only, do not use letters'
            });
        } else {
            console.log("LOG [Miscarriages]: Number is valid ('yes' path).");
        }
    } else if (miscarriagesKnown === 'no') {
        console.log("LOG [Miscarriages]: 'known' is 'no'. No errors for this section.");
    } else {
        console.log("LOG [Miscarriages]: 'known' is an unexpected value:", miscarriagesKnown);
        errors.push({
            field: 'patientHistory.spontaneousMiscarriagesOrEctopic.known',
            message: 'Invalid selection for spontaneous miscarriages or ectopic pregnancies'
        });
    }

    // --- Legal abortions before ---
    const abortionsKnown = history.previousLegalAbortions?.known;
    const abortionsNumberRaw = history.previousLegalAbortions?.number;
    console.log("[Abortions] 'known' value from session:", abortionsKnown, "(type:", typeof abortionsKnown + ")");
    console.log("[Abortions] 'numberRaw' value from session:", abortionsNumberRaw, "(type:", typeof abortionsNumberRaw + ")");

    if (!abortionsKnown) {
        console.log("LOG [Abortions]: 'known' is falsy. Adding error: 'Select yes if...'");
        errors.push({
            field: 'patientHistory.previousLegalAbortions.known',
            message: 'Select yes if the patient has had any legal abortions before'
        });
    } else if (abortionsKnown === 'yes') {
        console.log("LOG [Abortions]: 'known' is 'yes'. Validating number.");
        const abortionsNumberTrimmed = abortionsNumberRaw?.trim();
        console.log("LOG [Abortions]: Number Trimmed:", abortionsNumberTrimmed);
        if (!abortionsNumberTrimmed) {
            console.log("LOG [Abortions]: Number is blank. Adding error: 'Enter the number...'");
            errors.push({
                field: 'patientHistory.previousLegalAbortions.number',
                message: 'Enter the number of legal abortions'
            });
        } else if (!/^\d+$/.test(abortionsNumberTrimmed)) {
            console.log("LOG [Abortions]: Number contains non-digits. Adding error: 'Enter numbers only...'");
            errors.push({
                field: 'patientHistory.previousLegalAbortions.number',
                message: 'Enter numbers only, do not use letters'
            });
        } else {
            console.log("LOG [Abortions]: Number is valid ('yes' path).");
        }
    } else if (abortionsKnown === 'no') {
        console.log("LOG [Abortions]: 'known' is 'no'. No errors for this section.");
    } else {
        console.log("LOG [Abortions]: 'known' is an unexpected value:", abortionsKnown);
        errors.push({
            field: 'patientHistory.previousLegalAbortions.known',
            message: 'Invalid selection for previous legal abortions'
        });
    }

    console.log("--- VALIDATE FUNCTION RETURNING ERRORS ---:", JSON.stringify(errors, null, 2));
    return errors;
};

// exports.resolve = function (sessionData) {
//     console.log("--- RESOLVE FUNCTION CALLED (has-the-patient-had-any-stillbirths-or-livebirths.js) ---");
//     return '/forms';
// };