<!-- Generator: Widdershins v4.0.1 -->

<h1 id="dhsc-ans-api-consumer">DHSC.ANS.API.Consumer v1</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

Registered medical practitioners must complete and send HSA4 forms to the Chief Medical Officer (CMO), in accordance with the Abortion Act 1967, **within 14 days** of the termination.

## Contact Details

For England, you must send completed paper forms to The Chief Medical Officer, 39 Victoria Street, London, SW1H 0EU.

For Wales, you must send completed paper forms to The Chief Medical Officer, National Assembly for Wales, Cathays Park, Cardiff, CF10 3NQ.

If you require further information on completing HSA4 forms, telephone **020 7972 5541** or email [abortion.statistics@dhsc.gov.uk](mailto:abortion.statistics@dhsc.gov.uk).

Web: <a href="https://www.gov.uk">DHSC</a> 

<h1 id="dhsc-ans-api-consumer-hsa4form">HSA4Form</h1>

## Submit a new HSA4 abortion notification form.

> Code samples

```shell
# You can also use wget
curl -X POST /api/HSA4Form \
  -H 'Content-Type: application/json'

```

```javascript
const inputBody = '{
  "practitioner": {
    "fullName": "string",
    "address": "string",
    "gmcNumber": "string",
    "dateOfSignature": "2019-08-24T14:15:22Z"
  },
  "certification": {
    "certifyingDoctor1Name": "string",
    "certifyingDoctor1Address": "string",
    "certifyingDoctor2Name": "string",
    "certifyingDoctor2Address": "string",
    "performingDoctorWasSignatory": true
  },
  "patient": {
    "hospitalNumber": "string",
    "nhsNumber": "string",
    "fullName": "string",
    "dateOfBirth": "2019-08-24T14:15:22Z",
    "postcode": "string",
    "address": "string",
    "countryOfResidence": "string",
    "ethnicGroup": 0,
    "maritalStatus": 0,
    "previousLiveBirthsOver24Weeks": 0,
    "previousMiscarriages": 0,
    "previousTerminations": 0
  },
  "treatment": {
    "placeOfTerminationName": "string",
    "placeOfTerminationAddress": "string",
    "funding": 0,
    "feticideDate": "2019-08-24T14:15:22Z",
    "feticideMethod": "string",
    "terminationDate": "2019-08-24T14:15:22Z",
    "admissionDate": "2019-08-24T14:15:22Z",
    "dischargeDate": "2019-08-24T14:15:22Z",
    "surgicalMethod": "string",
    "administrationSetting": 0,
    "serviceProviderOrganisation": "string"
  },
  "pregnancy": {
    "gestationWeeks": 4,
    "gestationDays": 0,
    "grounds": [
      0
    ],
    "mainConditionForGroundsAorBorForG": "string",
    "groundC_RiskToMentalHealth": true,
    "groundC_PhysicalCondition": "string"
  },
  "selectiveTermination": {
    "originalFetusCount": 0,
    "remainingFetusCount": 0
  },
  "chlamydiaScreening": {
    "screeningOffered": true
  },
  "complications": {
    "complications": [
      0
    ],
    "otherComplicationDetails": "string"
  },
  "maternalDeath": {
    "maternalDeathOccurred": true,
    "dateOfDeath": "2019-08-24T14:15:22Z",
    "causeOfDeath": "string"
  }
}';
const headers = {
  'Content-Type':'application/json'
};

fetch('/api/HSA4Form',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': 'application/json'
}

r = requests.post('/api/HSA4Form', headers = headers)

print(r.json())

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'application/json'
}

result = RestClient.post '/api/HSA4Form',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"application/json"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "/api/HSA4Form", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/HSA4Form`

This endpoint accepts a JSON payload representing the HSA4 form. All required fields as per the Abortion Act 1967 notification requirements must be provided.

Refer to the guidance document: [Guidance note for completing HSA4 paper forms](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms) for detailed information on how to complete the form correctly.

> Body parameter

```json
{
  "practitioner": {
    "fullName": "string",
    "address": "string",
    "gmcNumber": "string",
    "dateOfSignature": "2019-08-24T14:15:22Z"
  },
  "certification": {
    "certifyingDoctor1Name": "string",
    "certifyingDoctor1Address": "string",
    "certifyingDoctor2Name": "string",
    "certifyingDoctor2Address": "string",
    "performingDoctorWasSignatory": true
  },
  "patient": {
    "hospitalNumber": "string",
    "nhsNumber": "string",
    "fullName": "string",
    "dateOfBirth": "2019-08-24T14:15:22Z",
    "postcode": "string",
    "address": "string",
    "countryOfResidence": "string",
    "ethnicGroup": 0,
    "maritalStatus": 0,
    "previousLiveBirthsOver24Weeks": 0,
    "previousMiscarriages": 0,
    "previousTerminations": 0
  },
  "treatment": {
    "placeOfTerminationName": "string",
    "placeOfTerminationAddress": "string",
    "funding": 0,
    "feticideDate": "2019-08-24T14:15:22Z",
    "feticideMethod": "string",
    "terminationDate": "2019-08-24T14:15:22Z",
    "admissionDate": "2019-08-24T14:15:22Z",
    "dischargeDate": "2019-08-24T14:15:22Z",
    "surgicalMethod": "string",
    "administrationSetting": 0,
    "serviceProviderOrganisation": "string"
  },
  "pregnancy": {
    "gestationWeeks": 4,
    "gestationDays": 0,
    "grounds": [
      0
    ],
    "mainConditionForGroundsAorBorForG": "string",
    "groundC_RiskToMentalHealth": true,
    "groundC_PhysicalCondition": "string"
  },
  "selectiveTermination": {
    "originalFetusCount": 0,
    "remainingFetusCount": 0
  },
  "chlamydiaScreening": {
    "screeningOffered": true
  },
  "complications": {
    "complications": [
      0
    ],
    "otherComplicationDetails": "string"
  },
  "maternalDeath": {
    "maternalDeathOccurred": true,
    "dateOfDeath": "2019-08-24T14:15:22Z",
    "causeOfDeath": "string"
  }
}
```

<h3 id="submit-a-new-hsa4-abortion-notification-form.-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[HSA4FormDto](#schemahsa4formdto)|false|none|

<h3 id="submit-a-new-hsa4-abortion-notification-form.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Form successfully submitted.|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Validation failed.|None|

<aside class="success">
This operation does not require authentication
</aside>

# Schemas

<h2 id="tocS_AbortionGround">AbortionGround</h2>
<!-- backwards compatibility -->
<a id="schemaabortionground"></a>
<a id="schema_AbortionGround"></a>
<a id="tocSabortionground"></a>
<a id="tocsabortionground"></a>

```json
0

```

Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.
Valid Grounds:
- Risk to the life of the pregnant woman.
- Preventing grave permanent injury to physical or mental health.
- Preventing injury to health of the woman or existing children under 24 weeks.
- Substantial risk of severe abnormality if the child were born.
- Emergency to save life or prevent grave permanent injury.
Refer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.<br>Valid Grounds:<br>- Risk to the life of the pregnant woman.<br>- Preventing grave permanent injury to physical or mental health.<br>- Preventing injury to health of the woman or existing children under 24 weeks.<br>- Substantial risk of severe abnormality if the child were born.<br>- Emergency to save life or prevent grave permanent injury.<br>Refer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation)|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|0|
|*anonymous*|1|
|*anonymous*|2|
|*anonymous*|3|
|*anonymous*|4|
|*anonymous*|5|
|*anonymous*|6|

<h2 id="tocS_AdministrationSetting">AdministrationSetting</h2>
<!-- backwards compatibility -->
<a id="schemaadministrationsetting"></a>
<a id="schema_AdministrationSetting"></a>
<a id="tocSadministrationsetting"></a>
<a id="tocsadministrationsetting"></a>

```json
0

```

Enumeration representing the administration setting of the treatment.
Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|Enumeration representing the administration setting of the treatment.<br>Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|0|
|*anonymous*|1|
|*anonymous*|2|

<h2 id="tocS_CertificationInfoDto">CertificationInfoDto</h2>
<!-- backwards compatibility -->
<a id="schemacertificationinfodto"></a>
<a id="schema_CertificationInfoDto"></a>
<a id="tocScertificationinfodto"></a>
<a id="tocscertificationinfodto"></a>

```json
{
  "certifyingDoctor1Name": "string",
  "certifyingDoctor1Address": "string",
  "certifyingDoctor2Name": "string",
  "certifyingDoctor2Address": "string",
  "performingDoctorWasSignatory": true
}

```

Certification Information - Section 2 (Non-Emergency Cases)
Required information:
- Names and addresses of two certifying doctors.
- Indicate if the performing doctor was a signatory.
For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|certifyingDoctor1Name|string|true|none|none|
|certifyingDoctor1Address|string|true|none|none|
|certifyingDoctor2Name|string|true|none|none|
|certifyingDoctor2Address|string|true|none|none|
|performingDoctorWasSignatory|boolean|false|none|none|

<h2 id="tocS_ChlamydiaInfoDto">ChlamydiaInfoDto</h2>
<!-- backwards compatibility -->
<a id="schemachlamydiainfodto"></a>
<a id="schema_ChlamydiaInfoDto"></a>
<a id="tocSchlamydiainfodto"></a>
<a id="tocschlamydiainfodto"></a>

```json
{
  "screeningOffered": true
}

```

Chlamydia Screening - Section 8
Required Information:
- Indication if screening for chlamydia was offered.
- Response is mandatory for all cases.
For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|screeningOffered|boolean|true|none|none|

<h2 id="tocS_Complication">Complication</h2>
<!-- backwards compatibility -->
<a id="schemacomplication"></a>
<a id="schema_Complication"></a>
<a id="tocScomplication"></a>
<a id="tocscomplication"></a>

```json
0

```

Enumeration representing possible complications of the treatment.
Refer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|Enumeration representing possible complications of the treatment.<br>Refer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications)|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|0|
|*anonymous*|1|
|*anonymous*|2|
|*anonymous*|3|
|*anonymous*|4|
|*anonymous*|5|
|*anonymous*|6|

<h2 id="tocS_ComplicationsInfoDto">ComplicationsInfoDto</h2>
<!-- backwards compatibility -->
<a id="schemacomplicationsinfodto"></a>
<a id="schema_ComplicationsInfoDto"></a>
<a id="tocScomplicationsinfodto"></a>
<a id="tocscomplicationsinfodto"></a>

```json
{
  "complications": [
    0
  ],
  "otherComplicationDetails": "string"
}

```

Complications - Section 9
Required Information:
- List of complications experienced, if any.
- Additional details if complications are not listed.
For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|complications|[[Complication](#schemacomplication)]¦null|false|none|[Enumeration representing possible complications of the treatment.<br>Refer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications)]|
|otherComplicationDetails|string¦null|false|none|none|

<h2 id="tocS_Ethnicity">Ethnicity</h2>
<!-- backwards compatibility -->
<a id="schemaethnicity"></a>
<a id="schema_Ethnicity"></a>
<a id="tocSethnicity"></a>
<a id="tocsethnicity"></a>

```json
0

```

Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.
Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.<br>Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|0|
|*anonymous*|1|
|*anonymous*|2|
|*anonymous*|3|
|*anonymous*|4|

<h2 id="tocS_FundingType">FundingType</h2>
<!-- backwards compatibility -->
<a id="schemafundingtype"></a>
<a id="schema_FundingType"></a>
<a id="tocSfundingtype"></a>
<a id="tocsfundingtype"></a>

```json
0

```

Enumeration representing the funding type of the treatment.
Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|Enumeration representing the funding type of the treatment.<br>Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|0|
|*anonymous*|1|

<h2 id="tocS_HSA4FormDto">HSA4FormDto</h2>
<!-- backwards compatibility -->
<a id="schemahsa4formdto"></a>
<a id="schema_HSA4FormDto"></a>
<a id="tocShsa4formdto"></a>
<a id="tocshsa4formdto"></a>

```json
{
  "practitioner": {
    "fullName": "string",
    "address": "string",
    "gmcNumber": "string",
    "dateOfSignature": "2019-08-24T14:15:22Z"
  },
  "certification": {
    "certifyingDoctor1Name": "string",
    "certifyingDoctor1Address": "string",
    "certifyingDoctor2Name": "string",
    "certifyingDoctor2Address": "string",
    "performingDoctorWasSignatory": true
  },
  "patient": {
    "hospitalNumber": "string",
    "nhsNumber": "string",
    "fullName": "string",
    "dateOfBirth": "2019-08-24T14:15:22Z",
    "postcode": "string",
    "address": "string",
    "countryOfResidence": "string",
    "ethnicGroup": 0,
    "maritalStatus": 0,
    "previousLiveBirthsOver24Weeks": 0,
    "previousMiscarriages": 0,
    "previousTerminations": 0
  },
  "treatment": {
    "placeOfTerminationName": "string",
    "placeOfTerminationAddress": "string",
    "funding": 0,
    "feticideDate": "2019-08-24T14:15:22Z",
    "feticideMethod": "string",
    "terminationDate": "2019-08-24T14:15:22Z",
    "admissionDate": "2019-08-24T14:15:22Z",
    "dischargeDate": "2019-08-24T14:15:22Z",
    "surgicalMethod": "string",
    "administrationSetting": 0,
    "serviceProviderOrganisation": "string"
  },
  "pregnancy": {
    "gestationWeeks": 4,
    "gestationDays": 0,
    "grounds": [
      0
    ],
    "mainConditionForGroundsAorBorForG": "string",
    "groundC_RiskToMentalHealth": true,
    "groundC_PhysicalCondition": "string"
  },
  "selectiveTermination": {
    "originalFetusCount": 0,
    "remainingFetusCount": 0
  },
  "chlamydiaScreening": {
    "screeningOffered": true
  },
  "complications": {
    "complications": [
      0
    ],
    "otherComplicationDetails": "string"
  },
  "maternalDeath": {
    "maternalDeathOccurred": true,
    "dateOfDeath": "2019-08-24T14:15:22Z",
    "causeOfDeath": "string"
  }
}

```

HSA4 Form DTO - Represents the entire form submission.
This object aggregates all the sections of the HSA4 form as specified by the official guidance.
Each section is represented by a dedicated DTO.
For further details, see: [HSA4 Form Guidance](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|practitioner|[PractitionerInfoDto](#schemapractitionerinfodto)|true|none|Practitioner Information - Section 1<br>Required information:<br>- Full name of the practitioner.<br>- Address of the practitioner.<br>- GMC number (7 digits).<br>- Date of signature.<br>For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)<br><p><br><strong>Section 1: Practitioner Terminating the Pregnancy</strong><br></p><br><p><br>You must provide a full name, address, and General Medical Council (GMC) registration number, signature, and date.<br></p><br><p><br>The address stated does not have to be the one shown on the GMC’s annual registration certificate. <br>However, if the form is incomplete and the place of termination is missing, the form will be returned to the address held by the GMC.<br></p><br><p><br>You must also complete the declaration, as appropriate. In the case of medical terminations, the form must be signed <br>even if the practitioner has been unable to confirm that the pregnancy has been terminated (see <a href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details" target="_blank">Section 4: treatment details</a> in the guidanace document).<br></p><br><p><br>Forms will be returned if the practitioner’s name, address, GMC number, or signature are missing, or if the GMC number <br>cannot be found on the GMC register.<br></p><br><p><br>For medical abortions, when more than one doctor may be involved in the termination, the <em>terminating practitioner</em> <br>is the doctor taking responsibility for the abortion. Usually, this will be the practitioner prescribing the mifepristone.<br></p>|
|certification|[CertificationInfoDto](#schemacertificationinfodto)|true|none|Certification Information - Section 2 (Non-Emergency Cases)<br>Required information:<br>- Names and addresses of two certifying doctors.<br>- Indicate if the performing doctor was a signatory.<br>For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)|
|patient|[PatientDetailsDto](#schemapatientdetailsdto)|true|none|Patient's Details - Section 3<br>Required information:<br>- Patient's hospital number and NHS number (if available).<br>- Full name, date of birth, address, and postcode.<br>- Country of residence, ethnic group, and marital status.<br>- Number of previous live births over 24 weeks, miscarriages, and terminations.<br>For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3)|
|treatment|[TreatmentDetailsDto](#schematreatmentdetailsdto)|true|none|Treatment Details - Section 4<br>Required information:<br>- Treatment location, dates of termination, admission, and discharge.<br>- Type of procedure performed (medical or surgical).<br>- Funding type (NHS, Private).<br>For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4)|
|pregnancy|[PregnancyDetailsDto](#schemapregnancydetailsdto)|true|none|none|
|selectiveTermination|[SelectiveTerminationInfoDto](#schemaselectiveterminationinfodto)|false|none|Selective Termination - Section 7<br>Required Information:<br>- Original number of fetuses before selective termination.<br>- Number of fetuses remaining after the procedure.<br>For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)|
|chlamydiaScreening|[ChlamydiaInfoDto](#schemachlamydiainfodto)|false|none|Chlamydia Screening - Section 8<br>Required Information:<br>- Indication if screening for chlamydia was offered.<br>- Response is mandatory for all cases.<br>For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)|
|complications|[ComplicationsInfoDto](#schemacomplicationsinfodto)|false|none|Complications - Section 9<br>Required Information:<br>- List of complications experienced, if any.<br>- Additional details if complications are not listed.<br>For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9)|
|maternalDeath|[MaternalDeathInfoDto](#schemamaternaldeathinfodto)|false|none|Death of Woman - Section 10<br>Required Information:<br>- Indicate if a maternal death occurred.<br>- Date and cause of death if applicable.<br>For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)|

<h2 id="tocS_MaritalStatus">MaritalStatus</h2>
<!-- backwards compatibility -->
<a id="schemamaritalstatus"></a>
<a id="schema_MaritalStatus"></a>
<a id="tocSmaritalstatus"></a>
<a id="tocsmaritalstatus"></a>

```json
0

```

Enumeration representing the patient's marital status.
Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|Enumeration representing the patient's marital status.<br>Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|0|
|*anonymous*|1|
|*anonymous*|2|
|*anonymous*|3|
|*anonymous*|4|
|*anonymous*|5|

<h2 id="tocS_MaternalDeathInfoDto">MaternalDeathInfoDto</h2>
<!-- backwards compatibility -->
<a id="schemamaternaldeathinfodto"></a>
<a id="schema_MaternalDeathInfoDto"></a>
<a id="tocSmaternaldeathinfodto"></a>
<a id="tocsmaternaldeathinfodto"></a>

```json
{
  "maternalDeathOccurred": true,
  "dateOfDeath": "2019-08-24T14:15:22Z",
  "causeOfDeath": "string"
}

```

Death of Woman - Section 10
Required Information:
- Indicate if a maternal death occurred.
- Date and cause of death if applicable.
For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|maternalDeathOccurred|boolean|false|none|none|
|dateOfDeath|string(date-time)¦null|false|none|none|
|causeOfDeath|string¦null|false|none|none|

<h2 id="tocS_PatientDetailsDto">PatientDetailsDto</h2>
<!-- backwards compatibility -->
<a id="schemapatientdetailsdto"></a>
<a id="schema_PatientDetailsDto"></a>
<a id="tocSpatientdetailsdto"></a>
<a id="tocspatientdetailsdto"></a>

```json
{
  "hospitalNumber": "string",
  "nhsNumber": "string",
  "fullName": "string",
  "dateOfBirth": "2019-08-24T14:15:22Z",
  "postcode": "string",
  "address": "string",
  "countryOfResidence": "string",
  "ethnicGroup": 0,
  "maritalStatus": 0,
  "previousLiveBirthsOver24Weeks": 0,
  "previousMiscarriages": 0,
  "previousTerminations": 0
}

```

Patient's Details - Section 3
Required information:
- Patient's hospital number and NHS number (if available).
- Full name, date of birth, address, and postcode.
- Country of residence, ethnic group, and marital status.
- Number of previous live births over 24 weeks, miscarriages, and terminations.
For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|hospitalNumber|string¦null|false|none|none|
|nhsNumber|string¦null|false|none|none|
|fullName|string¦null|false|none|none|
|dateOfBirth|string(date-time)|true|none|none|
|postcode|string¦null|false|none|none|
|address|string¦null|false|none|none|
|countryOfResidence|string|true|none|none|
|ethnicGroup|[Ethnicity](#schemaethnicity)|true|none|Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.<br>Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)|
|maritalStatus|[MaritalStatus](#schemamaritalstatus)|true|none|Enumeration representing the patient's marital status.<br>Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)|
|previousLiveBirthsOver24Weeks|integer(int32)|true|none|none|
|previousMiscarriages|integer(int32)|true|none|none|
|previousTerminations|integer(int32)|true|none|none|

<h2 id="tocS_PractitionerInfoDto">PractitionerInfoDto</h2>
<!-- backwards compatibility -->
<a id="schemapractitionerinfodto"></a>
<a id="schema_PractitionerInfoDto"></a>
<a id="tocSpractitionerinfodto"></a>
<a id="tocspractitionerinfodto"></a>

```json
{
  "fullName": "string",
  "address": "string",
  "gmcNumber": "string",
  "dateOfSignature": "2019-08-24T14:15:22Z"
}

```

Practitioner Information - Section 1
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
</p>

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|fullName|string|true|none|none|
|address|string|true|none|none|
|gmcNumber|string|true|none|none|
|dateOfSignature|string(date-time)|true|none|none|

<h2 id="tocS_PregnancyDetailsDto">PregnancyDetailsDto</h2>
<!-- backwards compatibility -->
<a id="schemapregnancydetailsdto"></a>
<a id="schema_PregnancyDetailsDto"></a>
<a id="tocSpregnancydetailsdto"></a>
<a id="tocspregnancydetailsdto"></a>

```json
{
  "gestationWeeks": 4,
  "gestationDays": 0,
  "grounds": [
    0
  ],
  "mainConditionForGroundsAorBorForG": "string",
  "groundC_RiskToMentalHealth": true,
  "groundC_PhysicalCondition": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|gestationWeeks|integer(int32)|true|none|none|
|gestationDays|integer(int32)¦null|false|none|none|
|grounds|[[AbortionGround](#schemaabortionground)]|true|none|[Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.<br>Valid Grounds:<br>- Risk to the life of the pregnant woman.<br>- Preventing grave permanent injury to physical or mental health.<br>- Preventing injury to health of the woman or existing children under 24 weeks.<br>- Substantial risk of severe abnormality if the child were born.<br>- Emergency to save life or prevent grave permanent injury.<br>Refer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation)]|
|mainConditionForGroundsAorBorForG|string¦null|false|none|none|
|groundC_RiskToMentalHealth|boolean¦null|false|none|none|
|groundC_PhysicalCondition|string¦null|false|none|none|

<h2 id="tocS_SelectiveTerminationInfoDto">SelectiveTerminationInfoDto</h2>
<!-- backwards compatibility -->
<a id="schemaselectiveterminationinfodto"></a>
<a id="schema_SelectiveTerminationInfoDto"></a>
<a id="tocSselectiveterminationinfodto"></a>
<a id="tocsselectiveterminationinfodto"></a>

```json
{
  "originalFetusCount": 0,
  "remainingFetusCount": 0
}

```

Selective Termination - Section 7
Required Information:
- Original number of fetuses before selective termination.
- Number of fetuses remaining after the procedure.
For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|originalFetusCount|integer(int32)|false|none|none|
|remainingFetusCount|integer(int32)|false|none|none|

<h2 id="tocS_TreatmentDetailsDto">TreatmentDetailsDto</h2>
<!-- backwards compatibility -->
<a id="schematreatmentdetailsdto"></a>
<a id="schema_TreatmentDetailsDto"></a>
<a id="tocStreatmentdetailsdto"></a>
<a id="tocstreatmentdetailsdto"></a>

```json
{
  "placeOfTerminationName": "string",
  "placeOfTerminationAddress": "string",
  "funding": 0,
  "feticideDate": "2019-08-24T14:15:22Z",
  "feticideMethod": "string",
  "terminationDate": "2019-08-24T14:15:22Z",
  "admissionDate": "2019-08-24T14:15:22Z",
  "dischargeDate": "2019-08-24T14:15:22Z",
  "surgicalMethod": "string",
  "administrationSetting": 0,
  "serviceProviderOrganisation": "string"
}

```

Treatment Details - Section 4
Required information:
- Treatment location, dates of termination, admission, and discharge.
- Type of procedure performed (medical or surgical).
- Funding type (NHS, Private).
For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|placeOfTerminationName|string¦null|false|none|none|
|placeOfTerminationAddress|string¦null|false|none|none|
|funding|[FundingType](#schemafundingtype)|false|none|Enumeration representing the funding type of the treatment.<br>Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)|
|feticideDate|string(date-time)¦null|false|none|none|
|feticideMethod|string¦null|false|none|none|
|terminationDate|string(date-time)¦null|false|none|none|
|admissionDate|string(date-time)¦null|false|none|none|
|dischargeDate|string(date-time)¦null|false|none|none|
|surgicalMethod|string¦null|false|none|none|
|administrationSetting|[AdministrationSetting](#schemaadministrationsetting)|false|none|Enumeration representing the administration setting of the treatment.<br>Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)|
|serviceProviderOrganisation|string¦null|false|none|If partial or all medicines are administered off-site, specify the provider's organisation.|

