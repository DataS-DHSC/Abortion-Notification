<!-- Generator: Widdershins v4.0.1 -->

<h1 id="dhsc-ans-api-consumer">DHSC.ANS.API.Consumer v1</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

Registered medical practitioners must complete and send HSA4 forms to the Chief Medical Officer (CMO), in accordance with the Abortion Act 1967, **within 14 days** of the termination.

Web: <a href="https://www.gov.uk">DHSC</a> 

<h1 id="dhsc-ans-api-consumer-hsa4form">HSA4Form</h1>

## post__api_HSA4Form

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
  "gestation": {
    "gestationWeeks": 4,
    "gestationDays": 6
  },
  "terminationGroundsDto": {
    "grounds": [
      0
    ],
    "mainCondition": "string",
    "riskToMentalHealth": true,
    "physicalCondition": "string"
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

*Submit a new HSA4 abortion notification form.*

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
  "gestation": {
    "gestationWeeks": 4,
    "gestationDays": 6
  },
  "terminationGroundsDto": {
    "grounds": [
      0
    ],
    "mainCondition": "string",
    "riskToMentalHealth": true,
    "physicalCondition": "string"
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

<h3 id="post__api_hsa4form-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[HSA4FormDto](#schemahsa4formdto)|false|none|

<h3 id="post__api_hsa4form-responses">Responses</h3>

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
For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-2-certification)
<p>
<strong>Section 2: Certification</strong>
</p>
<p>
You must provide the full name and address of both registered medical practitioners who certified the patient had grounds for the abortion. 
If one of these practitioners was also the practitioner who terminated the pregnancy, ensure to complete the relevant certification information accordingly.
</p>
<p>
Forms will be returned if no information is given, if a hospital stamp is used but no doctor’s name is provided, or if the same doctor is listed twice as shown in Section 1.
</p>
<p>
For digital submissions, practitioners should be selected from a predefined list, or entered manually if not present. Manually entered details will be saved for future use.
</p>

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|certifyingDoctor1Name|string|true|none|Full name of the first certifying doctor.|
|certifyingDoctor1Address|string|true|none|Address of the first certifying doctor.|
|certifyingDoctor2Name|string|true|none|Full name of the second certifying doctor.|
|certifyingDoctor2Address|string|true|none|Address of the second certifying doctor.|
|performingDoctorWasSignatory|boolean|false|none|Indicates if the performing doctor was one of the certifying doctors.|

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
This section must be completed for all cases. Indicate if screening for chlamydia was offered or if screening and prophylactic antibiotic treatment were offered.
The 'Yes' box should not be ticked if prophylactic treatment alone was offered without screening.

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|screeningOffered|boolean|true|none|Indicates whether chlamydia screening or screening and prophylactic antibiotic treatment was offered.|

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
This section should be completed if any complications occurred up until the time of discharge from the place of termination.
Note: Do not include evacuations of retained products of conception or failed terminations as complications.
A medical practitioner scrutinises all complications listed under ‘other’ and additional information may be requested as needed.

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|complications|[[Complication](#schemacomplication)]¦null|false|none|The list of complications experienced during or after the procedure.|
|otherComplicationDetails|string¦null|false|none|Details of any other complications not listed above.|

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

<h2 id="tocS_GestationDetailsDto">GestationDetailsDto</h2>
<!-- backwards compatibility -->
<a id="schemagestationdetailsdto"></a>
<a id="schema_GestationDetailsDto"></a>
<a id="tocSgestationdetailsdto"></a>
<a id="tocsgestationdetailsdto"></a>

```json
{
  "gestationWeeks": 4,
  "gestationDays": 6
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|gestationWeeks|integer(int32)|true|Valid range: 4 - 40 weeks. Provide additional details if exactly 24 weeks or over.|The gestation period in completed weeks.|
|gestationDays|integer(int32)¦null|false|Valid range: 0 - 6 days. Only applicable when gestation is 24 weeks or more.|The additional days past the completed weeks (0 to 6 days).|

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
  "gestation": {
    "gestationWeeks": 4,
    "gestationDays": 6
  },
  "terminationGroundsDto": {
    "grounds": [
      0
    ],
    "mainCondition": "string",
    "riskToMentalHealth": true,
    "physicalCondition": "string"
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
The HSA4 form must be electronically signed within 14 days of the termination by the responsible registered medical practitioner. In the case of medical abortions, this is usually the practitioner prescribing mifepristone. 
Forms that are not electronically signed within 14 days may be removed from the doctor's account and returned as paper forms for manual processing, which can cause delays and additional workload.
It is critical for the accuracy of national statistics and operational efficiency that the forms are completed and signed promptly.

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|practitioner|[PractitionerInfoDto](#schemapractitionerinfodto)|true|none|Practitioner Information - Section 1<br>Required information:<br>- Full name of the practitioner.<br>- Address of the practitioner.<br>- GMC number (7 digits).<br>- Date of signature.<br>For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-1-practitioner-terminating-the-pregnancy)<br><p><br><strong>Section 1: Practitioner Terminating the Pregnancy</strong><br></p><br><p><br>You must provide a full name, address, and General Medical Council (GMC) registration number, signature, and date.<br></p><br><p><br>The address stated does not have to be the one shown on the GMC’s annual registration certificate. <br>However, if the form is incomplete and the place of termination is missing, the form will be returned to the address held by the GMC.<br></p><br><p><br>In cases of medical termination, details of the terminating practitioner must be provided, <br>even if the practitioner has been unable to confirm that the pregnancy has been terminated. <br>For more information, refer to <br><a href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details" target="_blank">Section 4: Treatment Details</a> in the guidance document.<br></p><br><p><br>Providing practitioner details constitutes a signed declaration of the following statement <br>(as found on the paper form):  <br></p><br><blockquote><br>Hereby give notice that I terminated the pregnancy of the woman identified overleaf, and to the best of my knowledge, <br>the particulars on this form are correct. I further certify that I joined/did not join (delete as appropriate) <br>in giving HSA1 having seen/not seen (delete as appropriate) and examined/not examined (delete as appropriate) her before doing so.<br></blockquote><br><p><br>Forms will be returned if the practitioner’s name, address, GMC number, or signature are missing, or if the GMC number <br>cannot be found on the GMC register.<br></p><br><p><br>For <a href="https://www.gov.uk/government/consultations/home-use-of-both-pills-for-early-medical-abortion/home-use-of-both-pills-for-early-medical-abortion-up-to-10-weeks-gestation#:~:text=EMAs%20are%20defined%20as%20a,basis%20for%20England%20and%20Wales" target="_blank">medical abortions</a>, when more than one doctor may be involved in the termination, the <em>terminating practitioner</em> <br>is the doctor taking responsibility for the abortion. Usually, this will be the practitioner prescribing the <a href="https://bnf.nice.org.uk/drugs/mifepristone/" target="_blank">Mifepristone</a> or <a href="https://bnf.nice.org.uk/drugs/misoprostol/" target="_blank">Misoprostol</a>.<br></p>|
|certification|[CertificationInfoDto](#schemacertificationinfodto)|true|none|Certification Information - Section 2 (Non-Emergency Cases)<br>Required information:<br>- Names and addresses of two certifying doctors.<br>- Indicate if the performing doctor was a signatory.<br>For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-2-certification)<br><p><br><strong>Section 2: Certification</strong><br></p><br><p><br>You must provide the full name and address of both registered medical practitioners who certified the patient had grounds for the abortion. <br>If one of these practitioners was also the practitioner who terminated the pregnancy, ensure to complete the relevant certification information accordingly.<br></p><br><p><br>Forms will be returned if no information is given, if a hospital stamp is used but no doctor’s name is provided, or if the same doctor is listed twice as shown in Section 1.<br></p><br><p><br>For digital submissions, practitioners should be selected from a predefined list, or entered manually if not present. Manually entered details will be saved for future use.<br></p>|
|patient|[PatientDetailsDto](#schemapatientdetailsdto)|true|none|Patient's Details - Section 3<br>Required information:<br>- Patient's hospital number and NHS number (if available).<br>- Full name, date of birth, address, and postcode.<br>- Country of residence, ethnic group, and marital status.<br>- Number of previous live births over 24 weeks, miscarriages, and terminations.<br>For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3)<br><p><br><strong>Section 3: Patient’s Details</strong><br></p><br><p><br>You must provide the patient's hospital number or NHS number if available, along with their full name, date of birth, address, and postcode.<br>For residents outside of England and Wales, provide the patient's country of residence. If the country of residence is not known, provide the patient's full postcode or address for their temporary stay in England or Wales.<br></p><br><p><br>Ethnicity and marital status must be reported if known. The parity section should detail previous live births over 24 weeks, miscarriages, and legal terminations.<br></p>|
|treatment|[TreatmentDetailsDto](#schematreatmentdetailsdto)|true|none|Treatment Details - Section 4<br>Required information:<br>- Treatment location, dates of termination, admission, and discharge.<br>- Type of procedure performed (medical or surgical).<br>- Funding type (NHS, Private).<br>For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4)<br><p><br><strong>Section 4: Treatment Details</strong><br></p><br><p><br>You must specify whether the abortion was NHS funded or privately funded. For surgical terminations, indicate the procedure performed and provide relevant dates and methods used.<br>For medical terminations, specify the administration setting (e.g., all at home, partially at home, or in clinic), and if applicable, the organisation providing off-site treatment.<br></p><br><p><br>If feticide was used, provide the method and date. For all methods, the dates of admission, termination, and discharge (if applicable) must be specified.<br></p><br><p><br>Failure to provide correct details may result in the form being returned.<br></p>|
|gestation|[GestationDetailsDto](#schemagestationdetailsdto)|true|none|none|
|terminationGroundsDto|[TerminationGroundsDto](#schematerminationgroundsdto)|true|none|Termination Grounds - Section 6<br>Required information:<br>- Grounds for termination as stated on HSA1 or HSA2 form.<br>- Additional conditions or reasons as applicable.<br>For further details, see: [Termination Grounds - Section 6](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-6)<br>Grounds for termination must be selected as stated on the HSA1 or HSA2 form. The available grounds are:<br>- Risk to the life of the pregnant woman.<br>- To prevent grave permanent injury to the physical or mental health of the pregnant woman.<br>- Risk of injury to the physical or mental health of the pregnant woman (up to 24 weeks).<br>- Risk of injury to the physical or mental health of any existing children of the family of the pregnant woman (up to 24 weeks).<br>- Substantial risk that if the child were born, they would suffer from such physical or mental abnormalities as to be seriously handicapped.<br>- To save the life of the pregnant woman in an emergency.<br>- To prevent grave permanent injury to the physical or mental health of the pregnant woman in an emergency.<br>For applicable grounds, further details should be provided. If the pregnancy was terminated after exceeding the 24th week, provide a full statement of the medical condition.|
|selectiveTermination|[SelectiveTerminationInfoDto](#schemaselectiveterminationinfodto)|false|none|Selective Termination - Section 7<br>Required Information:<br>- Original number of fetuses before selective termination.<br>- Number of fetuses remaining after the procedure.<br>For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)<br>This section should only be completed if the original number of fetuses was 2 or more and reduced to 1 or more. All other relevant sections of the form must be completed.<br>A medical practitioner will scrutinise all forms relating to selective terminations, and more information may be requested on a case-by-case basis.|
|chlamydiaScreening|[ChlamydiaInfoDto](#schemachlamydiainfodto)|false|none|Chlamydia Screening - Section 8<br>Required Information:<br>- Indication if screening for chlamydia was offered.<br>- Response is mandatory for all cases.<br>For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)<br>This section must be completed for all cases. Indicate if screening for chlamydia was offered or if screening and prophylactic antibiotic treatment were offered.<br>The 'Yes' box should not be ticked if prophylactic treatment alone was offered without screening.|
|complications|[ComplicationsInfoDto](#schemacomplicationsinfodto)|false|none|Complications - Section 9<br>Required Information:<br>- List of complications experienced, if any.<br>- Additional details if complications are not listed.<br>For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9)<br>This section should be completed if any complications occurred up until the time of discharge from the place of termination.<br>Note: Do not include evacuations of retained products of conception or failed terminations as complications.<br>A medical practitioner scrutinises all complications listed under ‘other’ and additional information may be requested as needed.|
|maternalDeath|[MaternalDeathInfoDto](#schemamaternaldeathinfodto)|false|none|Death of Woman - Section 10<br>Required Information:<br>- Indicate if a maternal death occurred.<br>- Date and cause of death if applicable.<br>For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)<br>If a maternal death occurs as a result of the termination, you must state the date and the cause of death. This section will be scrutinised by a medical practitioner, and additional information may be requested.|

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
If a maternal death occurs as a result of the termination, you must state the date and the cause of death. This section will be scrutinised by a medical practitioner, and additional information may be requested.

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|maternalDeathOccurred|boolean|true|none|Indicates whether a maternal death occurred as a result of the termination.|
|dateOfDeath|string(date-time)¦null|false|YYYY-MM-DDTHH:MM:SSZ (UTC time)|The date of death, if applicable.|
|causeOfDeath|string¦null|false|none|The cause of death, if applicable.|

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
<p>
<strong>Section 3: Patient’s Details</strong>
</p>
<p>
You must provide the patient's hospital number or NHS number if available, along with their full name, date of birth, address, and postcode.
For residents outside of England and Wales, provide the patient's country of residence. If the country of residence is not known, provide the patient's full postcode or address for their temporary stay in England or Wales.
</p>
<p>
Ethnicity and marital status must be reported if known. The parity section should detail previous live births over 24 weeks, miscarriages, and legal terminations.
</p>

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|hospitalNumber|string¦null|false|none|The patient's hospital or clinic number.|
|nhsNumber|string¦null|false|Valid 10 digit NHS Number|The patient's NHS number.|
|fullName|string¦null|false|none|The patient's full name.|
|dateOfBirth|string(date-time)|true|YYYY-MM-DDT00:00:00|The patient's date of birth.|
|postcode|string¦null|false|Valid UK Postcode|The patient's full postcode (if applicable).|
|address|string¦null|false|none|The patient's address (if full postcode is not provided).|
|countryOfResidence|string|true|none|The patient's country of residence.|
|ethnicGroup|[Ethnicity](#schemaethnicity)|true|none|Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.<br>Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)|
|maritalStatus|[MaritalStatus](#schemamaritalstatus)|true|none|Enumeration representing the patient's marital status.<br>Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)|
|previousLiveBirthsOver24Weeks|integer(int32)|true|none|Number of previous live births over 24 weeks.|
|previousMiscarriages|integer(int32)|true|none|Number of previous miscarriages.|
|previousTerminations|integer(int32)|true|none|Number of previous terminations.|

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
For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-1-practitioner-terminating-the-pregnancy)
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
In cases of medical termination, details of the terminating practitioner must be provided, 
even if the practitioner has been unable to confirm that the pregnancy has been terminated. 
For more information, refer to 
<a href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details" target="_blank">Section 4: Treatment Details</a> in the guidance document.
</p>
<p>
Providing practitioner details constitutes a signed declaration of the following statement 
(as found on the paper form):  
</p>
<blockquote>
Hereby give notice that I terminated the pregnancy of the woman identified overleaf, and to the best of my knowledge, 
the particulars on this form are correct. I further certify that I joined/did not join (delete as appropriate) 
in giving HSA1 having seen/not seen (delete as appropriate) and examined/not examined (delete as appropriate) her before doing so.
</blockquote>
<p>
Forms will be returned if the practitioner’s name, address, GMC number, or signature are missing, or if the GMC number 
cannot be found on the GMC register.
</p>
<p>
For <a href="https://www.gov.uk/government/consultations/home-use-of-both-pills-for-early-medical-abortion/home-use-of-both-pills-for-early-medical-abortion-up-to-10-weeks-gestation#:~:text=EMAs%20are%20defined%20as%20a,basis%20for%20England%20and%20Wales" target="_blank">medical abortions</a>, when more than one doctor may be involved in the termination, the <em>terminating practitioner</em> 
is the doctor taking responsibility for the abortion. Usually, this will be the practitioner prescribing the <a href="https://bnf.nice.org.uk/drugs/mifepristone/" target="_blank">Mifepristone</a> or <a href="https://bnf.nice.org.uk/drugs/misoprostol/" target="_blank">Misoprostol</a>.
</p>

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|fullName|string|true|none|The full name of the practitioner responsible for the termination, required for form validity.|
|address|string|true|none|The address of the practitioner, which does not have to match the GMC’s registration certificate.|
|gmcNumber|string|true|Valid 7 digit GMC Reference|The practitioner's GMC registration number as registered on the GMC register.|
|dateOfSignature|string(date-time)|true|YYYY-MM-DDTHH:MM:SSZ  (UTC time)|The date the practitioner signed the form.|

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
This section should only be completed if the original number of fetuses was 2 or more and reduced to 1 or more. All other relevant sections of the form must be completed.
A medical practitioner will scrutinise all forms relating to selective terminations, and more information may be requested on a case-by-case basis.

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|originalFetusCount|integer(int32)|true|none|The number of fetuses originally present before the selective termination.|
|remainingFetusCount|integer(int32)|true|none|The number of fetuses remaining after the selective termination.|

<h2 id="tocS_TerminationGroundsDto">TerminationGroundsDto</h2>
<!-- backwards compatibility -->
<a id="schematerminationgroundsdto"></a>
<a id="schema_TerminationGroundsDto"></a>
<a id="tocSterminationgroundsdto"></a>
<a id="tocsterminationgroundsdto"></a>

```json
{
  "grounds": [
    0
  ],
  "mainCondition": "string",
  "riskToMentalHealth": true,
  "physicalCondition": "string"
}

```

Termination Grounds - Section 6
Required information:
- Grounds for termination as stated on HSA1 or HSA2 form.
- Additional conditions or reasons as applicable.
For further details, see: [Termination Grounds - Section 6](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-6)
Grounds for termination must be selected as stated on the HSA1 or HSA2 form. The available grounds are:
- Risk to the life of the pregnant woman.
- To prevent grave permanent injury to the physical or mental health of the pregnant woman.
- Risk of injury to the physical or mental health of the pregnant woman (up to 24 weeks).
- Risk of injury to the physical or mental health of any existing children of the family of the pregnant woman (up to 24 weeks).
- Substantial risk that if the child were born, they would suffer from such physical or mental abnormalities as to be seriously handicapped.
- To save the life of the pregnant woman in an emergency.
- To prevent grave permanent injury to the physical or mental health of the pregnant woman in an emergency.
For applicable grounds, further details should be provided. If the pregnancy was terminated after exceeding the 24th week, provide a full statement of the medical condition.

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|grounds|[[AbortionGround](#schemaabortionground)]|true|none|Grounds for termination selected from HSA1 or HSA2 form.|
|mainCondition|string¦null|false|none|The main condition relevant to grounds concerning the health or life of the pregnant woman or fetus.|
|riskToMentalHealth|boolean¦null|false|none|Specifies if the risk to mental health was the reason for termination.|
|physicalCondition|string¦null|false|none|The physical condition that warranted termination under the specified grounds.|

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
<p>
<strong>Section 4: Treatment Details</strong>
</p>
<p>
You must specify whether the abortion was NHS funded or privately funded. For surgical terminations, indicate the procedure performed and provide relevant dates and methods used.
For medical terminations, specify the administration setting (e.g., all at home, partially at home, or in clinic), and if applicable, the organisation providing off-site treatment.
</p>
<p>
If feticide was used, provide the method and date. For all methods, the dates of admission, termination, and discharge (if applicable) must be specified.
</p>
<p>
Failure to provide correct details may result in the form being returned.
</p>

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|placeOfTerminationName|string|true|none|Name of the place where the termination was performed.|
|placeOfTerminationAddress|string|true|none|Address of the place where the termination was performed.|
|funding|[FundingType](#schemafundingtype)|true|none|Enumeration representing the funding type of the treatment.<br>Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)|
|feticideDate|string(date-time)¦null|false|YYYY-MM-DDTHH:MM:SSZ (UTC time)|The date feticide was performed, if applicable.|
|feticideMethod|string¦null|false|none|The method of feticide, if applicable.|
|terminationDate|string(date-time)|true|YYYY-MM-DDTHH:MM:SSZ (UTC time)|The date of termination.|
|admissionDate|string(date-time)¦null|false|YYYY-MM-DDTHH:MM:SSZ (UTC time)|The date of admission to the facility (if an overnight stay was required).|
|dischargeDate|string(date-time)¦null|false|YYYY-MM-DDTHH:MM:SSZ (UTC time)|The date of discharge from the facility.|
|surgicalMethod|string¦null|false|none|The surgical method used, if applicable.|
|administrationSetting|[AdministrationSetting](#schemaadministrationsetting)|true|none|Enumeration representing the administration setting of the treatment.<br>Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)|
|serviceProviderOrganisation|string¦null|false|none|Provider's organisation if treatment was administered off-site.|

undefined

