# DHSC.ANS.API.Consumer

> Version v1

Registered medical practitioners must complete and send HSA4 forms to the Chief Medical Officer (CMO), in accordance with the Abortion Act 1967, **within 14 days** of the termination.

## Contact Details

For England, you must send completed paper forms to The Chief Medical Officer, 39 Victoria Street, London, SW1H 0EU.

For Wales, you must send completed paper forms to The Chief Medical Officer, National Assembly for Wales, Cathays Park, Cardiff, CF10 3NQ.

If you require further information on completing HSA4 forms, telephone **020 7972 5541** or email [abortion.statistics@dhsc.gov.uk](mailto:abortion.statistics@dhsc.gov.uk).



## Path Table

| Method | Path | Description |
| --- | --- | --- |
| POST | [/api/HSA4Form](#postapihsa4form) | Submit a new HSA4 abortion notification form. |

## Reference Table

| Name | Path | Description |
| --- | --- | --- |
| AbortionGround | [#/components/schemas/AbortionGround](#componentsschemasabortionground) | Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.
Valid Grounds:
- Risk to the life of the pregnant woman.
- Preventing grave permanent injury to physical or mental health.
- Preventing injury to health of the woman or existing children under 24 weeks.
- Substantial risk of severe abnormality if the child were born.
- Emergency to save life or prevent grave permanent injury.
Refer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation) |
| AdministrationSetting | [#/components/schemas/AdministrationSetting](#componentsschemasadministrationsetting) | Enumeration representing the administration setting of the treatment.
Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details) |
| CertificationInfoDto | [#/components/schemas/CertificationInfoDto](#componentsschemascertificationinfodto) | Certification Information - Section 2 (Non-Emergency Cases)
Required information:
- Names and addresses of two certifying doctors.
- Indicate if the performing doctor was a signatory.
For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales) |
| ChlamydiaInfoDto | [#/components/schemas/ChlamydiaInfoDto](#componentsschemaschlamydiainfodto) | Chlamydia Screening - Section 8
Required Information:
- Indication if screening for chlamydia was offered.
- Response is mandatory for all cases.
For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales) |
| Complication | [#/components/schemas/Complication](#componentsschemascomplication) | Enumeration representing possible complications of the treatment.
Refer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications) |
| ComplicationsInfoDto | [#/components/schemas/ComplicationsInfoDto](#componentsschemascomplicationsinfodto) | Complications - Section 9
Required Information:
- List of complications experienced, if any.
- Additional details if complications are not listed.
For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9) |
| Ethnicity | [#/components/schemas/Ethnicity](#componentsschemasethnicity) | Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.
Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details) |
| FundingType | [#/components/schemas/FundingType](#componentsschemasfundingtype) | Enumeration representing the funding type of the treatment.
Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details) |
| HSA4FormDto | [#/components/schemas/HSA4FormDto](#componentsschemashsa4formdto) | HSA4 Form DTO - Represents the entire form submission.
This object aggregates all the sections of the HSA4 form as specified by the official guidance.
Each section is represented by a dedicated DTO.
For further details, see: [HSA4 Form Guidance](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales) |
| MaritalStatus | [#/components/schemas/MaritalStatus](#componentsschemasmaritalstatus) | Enumeration representing the patient's marital status.
Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details) |
| MaternalDeathInfoDto | [#/components/schemas/MaternalDeathInfoDto](#componentsschemasmaternaldeathinfodto) | Death of Woman - Section 10
Required Information:
- Indicate if a maternal death occurred.
- Date and cause of death if applicable.
For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales) |
| PatientDetailsDto | [#/components/schemas/PatientDetailsDto](#componentsschemaspatientdetailsdto) | Patient's Details - Section 3
Required information:
- Patient's hospital number and NHS number (if available).
- Full name, date of birth, address, and postcode.
- Country of residence, ethnic group, and marital status.
- Number of previous live births over 24 weeks, miscarriages, and terminations.
For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3) |
| PractitionerInfoDto | [#/components/schemas/PractitionerInfoDto](#componentsschemaspractitionerinfodto) | Practitioner Information - Section 1
Required information:
- Full name of the practitioner.
- Address of the practitioner.
- GMC number (7 digits).
- Date of signature.
For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
<p>
<strong>Section 1: Practitioner Terminating the Pregnancy</strong>
</p>
<p>
You must provide a full name, address, and General Medical Council (GMC) registration number, signature, and date.
</p>
<p>
The address stated does not have to be the one shown on the GMC’s annual registration certificate. 
However, if the form is incomplete and the place of termination is missing, the form will be returned to the address held by the GMC.
</p>
<p>
You must also complete the declaration, as appropriate. In the case of medical terminations, the form must be signed 
even if the practitioner has been unable to confirm that the pregnancy has been terminated (see <a href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details" target="_blank">Section 4: treatment details</a> in the guidanace document).
</p>
<p>
Forms will be returned if the practitioner’s name, address, GMC number, or signature are missing, or if the GMC number 
cannot be found on the GMC register.
</p>
<p>
For medical abortions, when more than one doctor may be involved in the termination, the <em>terminating practitioner</em> 
is the doctor taking responsibility for the abortion. Usually, this will be the practitioner prescribing the mifepristone.
</p> |
| PregnancyDetailsDto | [#/components/schemas/PregnancyDetailsDto](#componentsschemaspregnancydetailsdto) |  |
| SelectiveTerminationInfoDto | [#/components/schemas/SelectiveTerminationInfoDto](#componentsschemasselectiveterminationinfodto) | Selective Termination - Section 7
Required Information:
- Original number of fetuses before selective termination.
- Number of fetuses remaining after the procedure.
For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales) |
| TreatmentDetailsDto | [#/components/schemas/TreatmentDetailsDto](#componentsschemastreatmentdetailsdto) | Treatment Details - Section 4
Required information:
- Treatment location, dates of termination, admission, and discharge.
- Type of procedure performed (medical or surgical).
- Funding type (NHS, Private).
For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4) |

## Path Details

***

### [POST]/api/HSA4Form

- Summary  
Submit a new HSA4 abortion notification form.

- Description  
  
This endpoint accepts a JSON payload representing the HSA4 form. All required fields as per the Abortion Act 1967 notification requirements must be provided.  
  
Refer to the guidance document: [Guidance note for completing HSA4 paper forms](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms) for detailed information on how to complete the form correctly.

#### RequestBody

- application/json

```ts
// HSA4 Form DTO - Represents the entire form submission.
// This object aggregates all the sections of the HSA4 form as specified by the official guidance.
// Each section is represented by a dedicated DTO.
// For further details, see: [HSA4 Form Guidance](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
{
  // Practitioner Information - Section 1
  // Required information:
  // - Full name of the practitioner.
  // - Address of the practitioner.
  // - GMC number (7 digits).
  // - Date of signature.
  // For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  // <p>
  // <strong>Section 1: Practitioner Terminating the Pregnancy</strong>
  // </p>
  // <p>
  // You must provide a full name, address, and General Medical Council (GMC) registration number, signature, and date.
  // </p>
  // <p>
  // The address stated does not have to be the one shown on the GMC’s annual registration certificate. 
  // However, if the form is incomplete and the place of termination is missing, the form will be returned to the address held by the GMC.
  // </p>
  // <p>
  // You must also complete the declaration, as appropriate. In the case of medical terminations, the form must be signed 
  // even if the practitioner has been unable to confirm that the pregnancy has been terminated (see <a href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details" target="_blank">Section 4: treatment details</a> in the guidanace document).
  // </p>
  // <p>
  // Forms will be returned if the practitioner’s name, address, GMC number, or signature are missing, or if the GMC number 
  // cannot be found on the GMC register.
  // </p>
  // <p>
  // For medical abortions, when more than one doctor may be involved in the termination, the <em>terminating practitioner</em> 
  // is the doctor taking responsibility for the abortion. Usually, this will be the practitioner prescribing the mifepristone.
  // </p>
  practitioner: {
    fullName: string
    address: string
    gmcNumber: string
    dateOfSignature: string
  }
  // Certification Information - Section 2 (Non-Emergency Cases)
  // Required information:
  // - Names and addresses of two certifying doctors.
  // - Indicate if the performing doctor was a signatory.
  // For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  certification: {
    certifyingDoctor1Name: string
    certifyingDoctor1Address: string
    certifyingDoctor2Name: string
    certifyingDoctor2Address: string
    performingDoctorWasSignatory?: boolean
  }
  // Patient's Details - Section 3
  // Required information:
  // - Patient's hospital number and NHS number (if available).
  // - Full name, date of birth, address, and postcode.
  // - Country of residence, ethnic group, and marital status.
  // - Number of previous live births over 24 weeks, miscarriages, and terminations.
  // For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3)
  patient: {
    hospitalNumber?: string
    nhsNumber?: string
    fullName?: string
    dateOfBirth: string
    postcode?: string
    address?: string
    countryOfResidence: string
    // Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.
    // Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
    ethnicGroup: enum[0, 1, 2, 3, 4]
    // Enumeration representing the patient's marital status.
    // Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
    maritalStatus: enum[0, 1, 2, 3, 4, 5]
    previousLiveBirthsOver24Weeks: integer
    previousMiscarriages: integer
    previousTerminations: integer
  }
  // Treatment Details - Section 4
  // Required information:
  // - Treatment location, dates of termination, admission, and discharge.
  // - Type of procedure performed (medical or surgical).
  // - Funding type (NHS, Private).
  // For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4)
  treatment: {
    placeOfTerminationName?: string
    placeOfTerminationAddress?: string
    // Enumeration representing the funding type of the treatment.
    // Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
    funding?: enum[0, 1]
    feticideDate?: string
    feticideMethod?: string
    terminationDate?: string
    admissionDate?: string
    dischargeDate?: string
    surgicalMethod?: string
    // Enumeration representing the administration setting of the treatment.
    // Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
    administrationSetting?: enum[0, 1, 2]
    // If partial or all medicines are administered off-site, specify the provider's organisation.
    serviceProviderOrganisation?: string
  }
  pregnancy: {
    gestationWeeks: integer
    gestationDays?: integer
    // Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.
    // Valid Grounds:
    // - Risk to the life of the pregnant woman.
    // - Preventing grave permanent injury to physical or mental health.
    // - Preventing injury to health of the woman or existing children under 24 weeks.
    // - Substantial risk of severe abnormality if the child were born.
    // - Emergency to save life or prevent grave permanent injury.
    // Refer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation)
    grounds?: enum[0, 1, 2, 3, 4, 5, 6][]
    mainConditionForGroundsAorBorForG?: string
    groundC_RiskToMentalHealth?: boolean
    groundC_PhysicalCondition?: string
  }
  // Selective Termination - Section 7
  // Required Information:
  // - Original number of fetuses before selective termination.
  // - Number of fetuses remaining after the procedure.
  // For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  selectiveTermination: {
    originalFetusCount?: integer
    remainingFetusCount?: integer
  }
  // Chlamydia Screening - Section 8
  // Required Information:
  // - Indication if screening for chlamydia was offered.
  // - Response is mandatory for all cases.
  // For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  chlamydiaScreening: {
    screeningOffered: boolean
  }
  // Complications - Section 9
  // Required Information:
  // - List of complications experienced, if any.
  // - Additional details if complications are not listed.
  // For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9)
  complications: {
    // Enumeration representing possible complications of the treatment.
    // Refer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications)
    complications?: enum[0, 1, 2, 3, 4, 5, 6][]
    otherComplicationDetails?: string
  }
  // Death of Woman - Section 10
  // Required Information:
  // - Indicate if a maternal death occurred.
  // - Date and cause of death if applicable.
  // For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  maternalDeath: {
    maternalDeathOccurred?: boolean
    dateOfDeath?: string
    causeOfDeath?: string
  }
}
```

- text/json

```ts
// HSA4 Form DTO - Represents the entire form submission.
// This object aggregates all the sections of the HSA4 form as specified by the official guidance.
// Each section is represented by a dedicated DTO.
// For further details, see: [HSA4 Form Guidance](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
{
  // Practitioner Information - Section 1
  // Required information:
  // - Full name of the practitioner.
  // - Address of the practitioner.
  // - GMC number (7 digits).
  // - Date of signature.
  // For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  // <p>
  // <strong>Section 1: Practitioner Terminating the Pregnancy</strong>
  // </p>
  // <p>
  // You must provide a full name, address, and General Medical Council (GMC) registration number, signature, and date.
  // </p>
  // <p>
  // The address stated does not have to be the one shown on the GMC’s annual registration certificate. 
  // However, if the form is incomplete and the place of termination is missing, the form will be returned to the address held by the GMC.
  // </p>
  // <p>
  // You must also complete the declaration, as appropriate. In the case of medical terminations, the form must be signed 
  // even if the practitioner has been unable to confirm that the pregnancy has been terminated (see <a href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details" target="_blank">Section 4: treatment details</a> in the guidanace document).
  // </p>
  // <p>
  // Forms will be returned if the practitioner’s name, address, GMC number, or signature are missing, or if the GMC number 
  // cannot be found on the GMC register.
  // </p>
  // <p>
  // For medical abortions, when more than one doctor may be involved in the termination, the <em>terminating practitioner</em> 
  // is the doctor taking responsibility for the abortion. Usually, this will be the practitioner prescribing the mifepristone.
  // </p>
  practitioner: {
    fullName: string
    address: string
    gmcNumber: string
    dateOfSignature: string
  }
  // Certification Information - Section 2 (Non-Emergency Cases)
  // Required information:
  // - Names and addresses of two certifying doctors.
  // - Indicate if the performing doctor was a signatory.
  // For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  certification: {
    certifyingDoctor1Name: string
    certifyingDoctor1Address: string
    certifyingDoctor2Name: string
    certifyingDoctor2Address: string
    performingDoctorWasSignatory?: boolean
  }
  // Patient's Details - Section 3
  // Required information:
  // - Patient's hospital number and NHS number (if available).
  // - Full name, date of birth, address, and postcode.
  // - Country of residence, ethnic group, and marital status.
  // - Number of previous live births over 24 weeks, miscarriages, and terminations.
  // For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3)
  patient: {
    hospitalNumber?: string
    nhsNumber?: string
    fullName?: string
    dateOfBirth: string
    postcode?: string
    address?: string
    countryOfResidence: string
    // Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.
    // Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
    ethnicGroup: enum[0, 1, 2, 3, 4]
    // Enumeration representing the patient's marital status.
    // Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
    maritalStatus: enum[0, 1, 2, 3, 4, 5]
    previousLiveBirthsOver24Weeks: integer
    previousMiscarriages: integer
    previousTerminations: integer
  }
  // Treatment Details - Section 4
  // Required information:
  // - Treatment location, dates of termination, admission, and discharge.
  // - Type of procedure performed (medical or surgical).
  // - Funding type (NHS, Private).
  // For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4)
  treatment: {
    placeOfTerminationName?: string
    placeOfTerminationAddress?: string
    // Enumeration representing the funding type of the treatment.
    // Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
    funding?: enum[0, 1]
    feticideDate?: string
    feticideMethod?: string
    terminationDate?: string
    admissionDate?: string
    dischargeDate?: string
    surgicalMethod?: string
    // Enumeration representing the administration setting of the treatment.
    // Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
    administrationSetting?: enum[0, 1, 2]
    // If partial or all medicines are administered off-site, specify the provider's organisation.
    serviceProviderOrganisation?: string
  }
  pregnancy: {
    gestationWeeks: integer
    gestationDays?: integer
    // Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.
    // Valid Grounds:
    // - Risk to the life of the pregnant woman.
    // - Preventing grave permanent injury to physical or mental health.
    // - Preventing injury to health of the woman or existing children under 24 weeks.
    // - Substantial risk of severe abnormality if the child were born.
    // - Emergency to save life or prevent grave permanent injury.
    // Refer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation)
    grounds?: enum[0, 1, 2, 3, 4, 5, 6][]
    mainConditionForGroundsAorBorForG?: string
    groundC_RiskToMentalHealth?: boolean
    groundC_PhysicalCondition?: string
  }
  // Selective Termination - Section 7
  // Required Information:
  // - Original number of fetuses before selective termination.
  // - Number of fetuses remaining after the procedure.
  // For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  selectiveTermination: {
    originalFetusCount?: integer
    remainingFetusCount?: integer
  }
  // Chlamydia Screening - Section 8
  // Required Information:
  // - Indication if screening for chlamydia was offered.
  // - Response is mandatory for all cases.
  // For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  chlamydiaScreening: {
    screeningOffered: boolean
  }
  // Complications - Section 9
  // Required Information:
  // - List of complications experienced, if any.
  // - Additional details if complications are not listed.
  // For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9)
  complications: {
    // Enumeration representing possible complications of the treatment.
    // Refer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications)
    complications?: enum[0, 1, 2, 3, 4, 5, 6][]
    otherComplicationDetails?: string
  }
  // Death of Woman - Section 10
  // Required Information:
  // - Indicate if a maternal death occurred.
  // - Date and cause of death if applicable.
  // For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  maternalDeath: {
    maternalDeathOccurred?: boolean
    dateOfDeath?: string
    causeOfDeath?: string
  }
}
```

- application/*+json

```ts
// HSA4 Form DTO - Represents the entire form submission.
// This object aggregates all the sections of the HSA4 form as specified by the official guidance.
// Each section is represented by a dedicated DTO.
// For further details, see: [HSA4 Form Guidance](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
{
  // Practitioner Information - Section 1
  // Required information:
  // - Full name of the practitioner.
  // - Address of the practitioner.
  // - GMC number (7 digits).
  // - Date of signature.
  // For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  // <p>
  // <strong>Section 1: Practitioner Terminating the Pregnancy</strong>
  // </p>
  // <p>
  // You must provide a full name, address, and General Medical Council (GMC) registration number, signature, and date.
  // </p>
  // <p>
  // The address stated does not have to be the one shown on the GMC’s annual registration certificate. 
  // However, if the form is incomplete and the place of termination is missing, the form will be returned to the address held by the GMC.
  // </p>
  // <p>
  // You must also complete the declaration, as appropriate. In the case of medical terminations, the form must be signed 
  // even if the practitioner has been unable to confirm that the pregnancy has been terminated (see <a href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details" target="_blank">Section 4: treatment details</a> in the guidanace document).
  // </p>
  // <p>
  // Forms will be returned if the practitioner’s name, address, GMC number, or signature are missing, or if the GMC number 
  // cannot be found on the GMC register.
  // </p>
  // <p>
  // For medical abortions, when more than one doctor may be involved in the termination, the <em>terminating practitioner</em> 
  // is the doctor taking responsibility for the abortion. Usually, this will be the practitioner prescribing the mifepristone.
  // </p>
  practitioner: {
    fullName: string
    address: string
    gmcNumber: string
    dateOfSignature: string
  }
  // Certification Information - Section 2 (Non-Emergency Cases)
  // Required information:
  // - Names and addresses of two certifying doctors.
  // - Indicate if the performing doctor was a signatory.
  // For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  certification: {
    certifyingDoctor1Name: string
    certifyingDoctor1Address: string
    certifyingDoctor2Name: string
    certifyingDoctor2Address: string
    performingDoctorWasSignatory?: boolean
  }
  // Patient's Details - Section 3
  // Required information:
  // - Patient's hospital number and NHS number (if available).
  // - Full name, date of birth, address, and postcode.
  // - Country of residence, ethnic group, and marital status.
  // - Number of previous live births over 24 weeks, miscarriages, and terminations.
  // For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3)
  patient: {
    hospitalNumber?: string
    nhsNumber?: string
    fullName?: string
    dateOfBirth: string
    postcode?: string
    address?: string
    countryOfResidence: string
    // Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.
    // Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
    ethnicGroup: enum[0, 1, 2, 3, 4]
    // Enumeration representing the patient's marital status.
    // Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
    maritalStatus: enum[0, 1, 2, 3, 4, 5]
    previousLiveBirthsOver24Weeks: integer
    previousMiscarriages: integer
    previousTerminations: integer
  }
  // Treatment Details - Section 4
  // Required information:
  // - Treatment location, dates of termination, admission, and discharge.
  // - Type of procedure performed (medical or surgical).
  // - Funding type (NHS, Private).
  // For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4)
  treatment: {
    placeOfTerminationName?: string
    placeOfTerminationAddress?: string
    // Enumeration representing the funding type of the treatment.
    // Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
    funding?: enum[0, 1]
    feticideDate?: string
    feticideMethod?: string
    terminationDate?: string
    admissionDate?: string
    dischargeDate?: string
    surgicalMethod?: string
    // Enumeration representing the administration setting of the treatment.
    // Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
    administrationSetting?: enum[0, 1, 2]
    // If partial or all medicines are administered off-site, specify the provider's organisation.
    serviceProviderOrganisation?: string
  }
  pregnancy: {
    gestationWeeks: integer
    gestationDays?: integer
    // Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.
    // Valid Grounds:
    // - Risk to the life of the pregnant woman.
    // - Preventing grave permanent injury to physical or mental health.
    // - Preventing injury to health of the woman or existing children under 24 weeks.
    // - Substantial risk of severe abnormality if the child were born.
    // - Emergency to save life or prevent grave permanent injury.
    // Refer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation)
    grounds?: enum[0, 1, 2, 3, 4, 5, 6][]
    mainConditionForGroundsAorBorForG?: string
    groundC_RiskToMentalHealth?: boolean
    groundC_PhysicalCondition?: string
  }
  // Selective Termination - Section 7
  // Required Information:
  // - Original number of fetuses before selective termination.
  // - Number of fetuses remaining after the procedure.
  // For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  selectiveTermination: {
    originalFetusCount?: integer
    remainingFetusCount?: integer
  }
  // Chlamydia Screening - Section 8
  // Required Information:
  // - Indication if screening for chlamydia was offered.
  // - Response is mandatory for all cases.
  // For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  chlamydiaScreening: {
    screeningOffered: boolean
  }
  // Complications - Section 9
  // Required Information:
  // - List of complications experienced, if any.
  // - Additional details if complications are not listed.
  // For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9)
  complications: {
    // Enumeration representing possible complications of the treatment.
    // Refer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications)
    complications?: enum[0, 1, 2, 3, 4, 5, 6][]
    otherComplicationDetails?: string
  }
  // Death of Woman - Section 10
  // Required Information:
  // - Indicate if a maternal death occurred.
  // - Date and cause of death if applicable.
  // For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  maternalDeath: {
    maternalDeathOccurred?: boolean
    dateOfDeath?: string
    causeOfDeath?: string
  }
}
```

#### Responses

- 201 Form successfully submitted.

- 400 Validation failed.

## References

### #/components/schemas/AbortionGround

```ts
{
  "enum": [
    0,
    1,
    2,
    3,
    4,
    5,
    6
  ],
  "type": "integer",
  "description": "Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.\r\nValid Grounds:\r\n- Risk to the life of the pregnant woman.\r\n- Preventing grave permanent injury to physical or mental health.\r\n- Preventing injury to health of the woman or existing children under 24 weeks.\r\n- Substantial risk of severe abnormality if the child were born.\r\n- Emergency to save life or prevent grave permanent injury.\r\nRefer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation)",
  "format": "int32"
}
```

### #/components/schemas/AdministrationSetting

```ts
{
  "enum": [
    0,
    1,
    2
  ],
  "type": "integer",
  "description": "Enumeration representing the administration setting of the treatment.\r\nRefer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)",
  "format": "int32"
}
```

### #/components/schemas/CertificationInfoDto

```ts
// Certification Information - Section 2 (Non-Emergency Cases)
// Required information:
// - Names and addresses of two certifying doctors.
// - Indicate if the performing doctor was a signatory.
// For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
{
  certifyingDoctor1Name: string
  certifyingDoctor1Address: string
  certifyingDoctor2Name: string
  certifyingDoctor2Address: string
  performingDoctorWasSignatory?: boolean
}
```

### #/components/schemas/ChlamydiaInfoDto

```ts
// Chlamydia Screening - Section 8
// Required Information:
// - Indication if screening for chlamydia was offered.
// - Response is mandatory for all cases.
// For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
{
  screeningOffered: boolean
}
```

### #/components/schemas/Complication

```ts
{
  "enum": [
    0,
    1,
    2,
    3,
    4,
    5,
    6
  ],
  "type": "integer",
  "description": "Enumeration representing possible complications of the treatment.\r\nRefer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications)",
  "format": "int32"
}
```

### #/components/schemas/ComplicationsInfoDto

```ts
// Complications - Section 9
// Required Information:
// - List of complications experienced, if any.
// - Additional details if complications are not listed.
// For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9)
{
  // Enumeration representing possible complications of the treatment.
  // Refer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications)
  complications?: enum[0, 1, 2, 3, 4, 5, 6][]
  otherComplicationDetails?: string
}
```

### #/components/schemas/Ethnicity

```ts
{
  "enum": [
    0,
    1,
    2,
    3,
    4
  ],
  "type": "integer",
  "description": "Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.\r\nRefer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)",
  "format": "int32"
}
```

### #/components/schemas/FundingType

```ts
{
  "enum": [
    0,
    1
  ],
  "type": "integer",
  "description": "Enumeration representing the funding type of the treatment.\r\nRefer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)",
  "format": "int32"
}
```

### #/components/schemas/HSA4FormDto

```ts
// HSA4 Form DTO - Represents the entire form submission.
// This object aggregates all the sections of the HSA4 form as specified by the official guidance.
// Each section is represented by a dedicated DTO.
// For further details, see: [HSA4 Form Guidance](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
{
  // Practitioner Information - Section 1
  // Required information:
  // - Full name of the practitioner.
  // - Address of the practitioner.
  // - GMC number (7 digits).
  // - Date of signature.
  // For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  // <p>
  // <strong>Section 1: Practitioner Terminating the Pregnancy</strong>
  // </p>
  // <p>
  // You must provide a full name, address, and General Medical Council (GMC) registration number, signature, and date.
  // </p>
  // <p>
  // The address stated does not have to be the one shown on the GMC’s annual registration certificate. 
  // However, if the form is incomplete and the place of termination is missing, the form will be returned to the address held by the GMC.
  // </p>
  // <p>
  // You must also complete the declaration, as appropriate. In the case of medical terminations, the form must be signed 
  // even if the practitioner has been unable to confirm that the pregnancy has been terminated (see <a href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details" target="_blank">Section 4: treatment details</a> in the guidanace document).
  // </p>
  // <p>
  // Forms will be returned if the practitioner’s name, address, GMC number, or signature are missing, or if the GMC number 
  // cannot be found on the GMC register.
  // </p>
  // <p>
  // For medical abortions, when more than one doctor may be involved in the termination, the <em>terminating practitioner</em> 
  // is the doctor taking responsibility for the abortion. Usually, this will be the practitioner prescribing the mifepristone.
  // </p>
  practitioner: {
    fullName: string
    address: string
    gmcNumber: string
    dateOfSignature: string
  }
  // Certification Information - Section 2 (Non-Emergency Cases)
  // Required information:
  // - Names and addresses of two certifying doctors.
  // - Indicate if the performing doctor was a signatory.
  // For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  certification: {
    certifyingDoctor1Name: string
    certifyingDoctor1Address: string
    certifyingDoctor2Name: string
    certifyingDoctor2Address: string
    performingDoctorWasSignatory?: boolean
  }
  // Patient's Details - Section 3
  // Required information:
  // - Patient's hospital number and NHS number (if available).
  // - Full name, date of birth, address, and postcode.
  // - Country of residence, ethnic group, and marital status.
  // - Number of previous live births over 24 weeks, miscarriages, and terminations.
  // For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3)
  patient: {
    hospitalNumber?: string
    nhsNumber?: string
    fullName?: string
    dateOfBirth: string
    postcode?: string
    address?: string
    countryOfResidence: string
    // Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.
    // Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
    ethnicGroup: enum[0, 1, 2, 3, 4]
    // Enumeration representing the patient's marital status.
    // Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
    maritalStatus: enum[0, 1, 2, 3, 4, 5]
    previousLiveBirthsOver24Weeks: integer
    previousMiscarriages: integer
    previousTerminations: integer
  }
  // Treatment Details - Section 4
  // Required information:
  // - Treatment location, dates of termination, admission, and discharge.
  // - Type of procedure performed (medical or surgical).
  // - Funding type (NHS, Private).
  // For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4)
  treatment: {
    placeOfTerminationName?: string
    placeOfTerminationAddress?: string
    // Enumeration representing the funding type of the treatment.
    // Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
    funding?: enum[0, 1]
    feticideDate?: string
    feticideMethod?: string
    terminationDate?: string
    admissionDate?: string
    dischargeDate?: string
    surgicalMethod?: string
    // Enumeration representing the administration setting of the treatment.
    // Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
    administrationSetting?: enum[0, 1, 2]
    // If partial or all medicines are administered off-site, specify the provider's organisation.
    serviceProviderOrganisation?: string
  }
  pregnancy: {
    gestationWeeks: integer
    gestationDays?: integer
    // Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.
    // Valid Grounds:
    // - Risk to the life of the pregnant woman.
    // - Preventing grave permanent injury to physical or mental health.
    // - Preventing injury to health of the woman or existing children under 24 weeks.
    // - Substantial risk of severe abnormality if the child were born.
    // - Emergency to save life or prevent grave permanent injury.
    // Refer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation)
    grounds?: enum[0, 1, 2, 3, 4, 5, 6][]
    mainConditionForGroundsAorBorForG?: string
    groundC_RiskToMentalHealth?: boolean
    groundC_PhysicalCondition?: string
  }
  // Selective Termination - Section 7
  // Required Information:
  // - Original number of fetuses before selective termination.
  // - Number of fetuses remaining after the procedure.
  // For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  selectiveTermination: {
    originalFetusCount?: integer
    remainingFetusCount?: integer
  }
  // Chlamydia Screening - Section 8
  // Required Information:
  // - Indication if screening for chlamydia was offered.
  // - Response is mandatory for all cases.
  // For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  chlamydiaScreening: {
    screeningOffered: boolean
  }
  // Complications - Section 9
  // Required Information:
  // - List of complications experienced, if any.
  // - Additional details if complications are not listed.
  // For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9)
  complications: {
    // Enumeration representing possible complications of the treatment.
    // Refer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications)
    complications?: enum[0, 1, 2, 3, 4, 5, 6][]
    otherComplicationDetails?: string
  }
  // Death of Woman - Section 10
  // Required Information:
  // - Indicate if a maternal death occurred.
  // - Date and cause of death if applicable.
  // For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
  maternalDeath: {
    maternalDeathOccurred?: boolean
    dateOfDeath?: string
    causeOfDeath?: string
  }
}
```

### #/components/schemas/MaritalStatus

```ts
{
  "enum": [
    0,
    1,
    2,
    3,
    4,
    5
  ],
  "type": "integer",
  "description": "Enumeration representing the patient's marital status.\r\nRefer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)",
  "format": "int32"
}
```

### #/components/schemas/MaternalDeathInfoDto

```ts
// Death of Woman - Section 10
// Required Information:
// - Indicate if a maternal death occurred.
// - Date and cause of death if applicable.
// For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
{
  maternalDeathOccurred?: boolean
  dateOfDeath?: string
  causeOfDeath?: string
}
```

### #/components/schemas/PatientDetailsDto

```ts
// Patient's Details - Section 3
// Required information:
// - Patient's hospital number and NHS number (if available).
// - Full name, date of birth, address, and postcode.
// - Country of residence, ethnic group, and marital status.
// - Number of previous live births over 24 weeks, miscarriages, and terminations.
// For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3)
{
  hospitalNumber?: string
  nhsNumber?: string
  fullName?: string
  dateOfBirth: string
  postcode?: string
  address?: string
  countryOfResidence: string
  // Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.
  // Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
  ethnicGroup: enum[0, 1, 2, 3, 4]
  // Enumeration representing the patient's marital status.
  // Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
  maritalStatus: enum[0, 1, 2, 3, 4, 5]
  previousLiveBirthsOver24Weeks: integer
  previousMiscarriages: integer
  previousTerminations: integer
}
```

### #/components/schemas/PractitionerInfoDto

```ts
// Practitioner Information - Section 1
// Required information:
// - Full name of the practitioner.
// - Address of the practitioner.
// - GMC number (7 digits).
// - Date of signature.
// For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
// <p>
// <strong>Section 1: Practitioner Terminating the Pregnancy</strong>
// </p>
// <p>
// You must provide a full name, address, and General Medical Council (GMC) registration number, signature, and date.
// </p>
// <p>
// The address stated does not have to be the one shown on the GMC’s annual registration certificate. 
// However, if the form is incomplete and the place of termination is missing, the form will be returned to the address held by the GMC.
// </p>
// <p>
// You must also complete the declaration, as appropriate. In the case of medical terminations, the form must be signed 
// even if the practitioner has been unable to confirm that the pregnancy has been terminated (see <a href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details" target="_blank">Section 4: treatment details</a> in the guidanace document).
// </p>
// <p>
// Forms will be returned if the practitioner’s name, address, GMC number, or signature are missing, or if the GMC number 
// cannot be found on the GMC register.
// </p>
// <p>
// For medical abortions, when more than one doctor may be involved in the termination, the <em>terminating practitioner</em> 
// is the doctor taking responsibility for the abortion. Usually, this will be the practitioner prescribing the mifepristone.
// </p>
{
  fullName: string
  address: string
  gmcNumber: string
  dateOfSignature: string
}
```

### #/components/schemas/PregnancyDetailsDto

```ts
{
  gestationWeeks: integer
  gestationDays?: integer
  // Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.
  // Valid Grounds:
  // - Risk to the life of the pregnant woman.
  // - Preventing grave permanent injury to physical or mental health.
  // - Preventing injury to health of the woman or existing children under 24 weeks.
  // - Substantial risk of severe abnormality if the child were born.
  // - Emergency to save life or prevent grave permanent injury.
  // Refer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation)
  grounds?: enum[0, 1, 2, 3, 4, 5, 6][]
  mainConditionForGroundsAorBorForG?: string
  groundC_RiskToMentalHealth?: boolean
  groundC_PhysicalCondition?: string
}
```

### #/components/schemas/SelectiveTerminationInfoDto

```ts
// Selective Termination - Section 7
// Required Information:
// - Original number of fetuses before selective termination.
// - Number of fetuses remaining after the procedure.
// For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
{
  originalFetusCount?: integer
  remainingFetusCount?: integer
}
```

### #/components/schemas/TreatmentDetailsDto

```ts
// Treatment Details - Section 4
// Required information:
// - Treatment location, dates of termination, admission, and discharge.
// - Type of procedure performed (medical or surgical).
// - Funding type (NHS, Private).
// For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4)
{
  placeOfTerminationName?: string
  placeOfTerminationAddress?: string
  // Enumeration representing the funding type of the treatment.
  // Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
  funding?: enum[0, 1]
  feticideDate?: string
  feticideMethod?: string
  terminationDate?: string
  admissionDate?: string
  dischargeDate?: string
  surgicalMethod?: string
  // Enumeration representing the administration setting of the treatment.
  // Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
  administrationSetting?: enum[0, 1, 2]
  // If partial or all medicines are administered off-site, specify the provider's organisation.
  serviceProviderOrganisation?: string
}
```