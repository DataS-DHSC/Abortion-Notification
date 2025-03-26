# DHSC HSA4 Form Submission API

The **DHSC HSA4 Form Submission API** allows authorised systems to submit HSA4 form data related to abortion notifications. This API is designed to securely collect and process data for the Department of Health and Social Care (DHSC), as part of the Abortion Notification Service (ANS).  

Under the [**Abortion Act 1967**](https://www.legislation.gov.uk/ukpga/1967/87/enacted), registered medical practitioners in England and Wales are legally required to notify the Chief Medical Officer (CMO) of each abortion they perform by submitting an HSA4 form within **14 days** of the procedure. Failure to submit the HSA4 form is a **criminal offence** under the Act. This notification is necessary to ensure compliance with the Act and to facilitate the collection of data for statistical purposes. The HSA4 form must include detailed information about the procedure, including the names and addresses of the certifying doctors, gestational age, method used, and place of termination.  

The HSA4 Form Submission API is accessed via [HTTP](https://en.wikipedia.org/wiki/Hypertext_Transfer_Protocol) and returns data in [JSON](https://en.wikipedia.org/wiki/JSON) format. The [reference documentation](reference.html) provides detailed information about the available endpoints and response formats.


## What you can do with this API

The DHSC HSA4 Form Submission API provides functionality for consumers to interact with the Abortion Notification Service (ANS) by enabling the following capabilities:

- **Submission of HSA4 Form Data:**  
  Consumers can submit completed or partially completed HSA4 form data to be stored and validated by ANS. The data will be checked for correctness and compliance with required standards before being stored.

- **Authorisation of Forms:**  
  When the forms are ready for submission, the API allows authorised practitioners to approve the forms. Once authorised, the forms will be submitted for verification by ANS.

- **Retrieval of Saved Forms:**  
  Consumers can retrieve previously submitted forms that have not yet been authorised, allowing them to continue editing or reviewing forms before submission.

- **Checking Submission Status:**  
  The API also allows consumers to check the current status of previous submissions, ensuring transparency and accessibility to the progress of submitted forms.

This API provides a structured and secure method for handling HSA4 form data to ensure compliance with the Abortion Act 1967 and facilitate accurate record-keeping.


## What you can't do with this API

The DHSC HSA4 Form Submission API has certain limitations to ensure data integrity, security, and compliance with legal requirements:

- **Editing Authorised Forms:**  
  Users cannot change or edit HSA4 forms that have been previously authorised by a practitioner. Once authorised, the data is considered final and cannot be modified.

- **Deletion of Submissions:**  
  HSA4 submissions cannot be deleted under any circumstances. All submissions are retained for audit and compliance purposes.

- **Lack of Legacy Protocol Support:**  
  The API currently does not support legacy protocols such as SOAP. All interactions are handled via modern RESTful HTTP requests using JSON format.

- **Unauthorised Access Prohibited:**  
  The API cannot be accessed without proper authorisation. User credentials must be arranged with ANS prior to using the API to ensure secure access.

- **Strict Schema Compliance:**  
  Users cannot submit data that is not directly supported by the HSA4 schema. All submissions must conform to the defined schema, which is documented in the [reference documentation](reference.html).

These restrictions are in place to maintain the integrity and security of the data submitted through the API.


## Quick Start

The DHSC HSA4 Form Submission API is designed to securely collect and process HSA4 form data. Due to the sensitive nature of the information submitted, consumers should not attempt to interact with the API without appropriate authorisation and credentials arranged with ANS.  

### Test Environment  
To ensure systems are working correctly before making live submissions, a **test environment** may be available for integration testing. Please contact ANS to obtain credentials and access details for the test environment.  

### Making a Submission  
To submit an HSA4 form, you must send a `POST` request to the following endpoint:  

```shell
POST /api/HSA4Form
```

The request body must be a JSON payload conforming to the **HSA4 schema**. Refer to the [reference documentation](reference.html) for detailed information about the required structure and data types.

You can use tools such as [curl](https://curl.se/), [Postman](https://www.postman.com/), or your preferred programming language to make requests to the API.  

#### Example Request (curl)  
```shell
curl -X POST "https://<API-URL>/api/HSA4Form" \
  -H "Content-Type: application/json" \
  -d @@HSA4Form.json
```

#### Example Request Body (JSON)  
```json
{
  "practitioner": {
    "fullName": "Dr. John Doe",
    "address": "123 Medical Street, London, SW1A 1AA",
    "gmcNumber": "1234567",
    "dateOfSignature": "2025-03-26T14:15:22Z"
  },
  "patient": {
    "hospitalNumber": "H12345",
    "nhsNumber": "9876543210",
    "fullName": "Jane Smith",
    "dateOfBirth": "1990-01-01T00:00:00Z",
    "postcode": "AB1 2CD",
    "address": "456 Health Road, London",
    "countryOfResidence": "UK",
    "ethnicGroup": 1,
    "maritalStatus": 2,
    "previousLiveBirthsOver24Weeks": 0,
    "previousMiscarriages": 1,
    "previousTerminations": 0
  },
  "treatment": {
    "placeOfTerminationName": "Healthcare Clinic",
    "placeOfTerminationAddress": "789 Clinic Ave, London",
    "funding": 0,
    "terminationDate": "2025-03-25T10:00:00Z",
    "admissionDate": "2025-03-25T09:00:00Z",
    "dischargeDate": "2025-03-25T12:00:00Z",
    "surgicalMethod": "Vacuum aspiration",
    "administrationSetting": 1,
    "serviceProviderOrganisation": "NHS Trust"
  },
  "pregnancy": {
    "gestationWeeks": 10,
    "gestationDays": 2,
    "grounds": [1],
    "groundC_RiskToMentalHealth": true
  }
}
```

### Checking Submission Status  
To check the status of a previously submitted HSA4 form, use the relevant status-checking endpoint documented in the [reference documentation](reference.html).  

### Important  
This API should **only be used by authorised systems**. Any attempt to submit unauthorised data will be rejected, and such actions may result in further investigation.  


## Alpha Software  

We are actively developing and improving this API as part of its **Alpha phase**. Your feedback is essential to ensure the API meets your needs and functions as intended.  

Please take a few moments to complete this survey. Your responses will help us identify areas for improvement, enhance the quality of the API, and ensure it aligns with your requirements.  

If you encounter issues or have suggestions, this is your opportunity to share them with us. Thank you for your participation and valuable feedback.  

[Complete the Feedback Survey](https://www.smartsurvey.co.uk/s/ZB7YZG/)


## Authentication  

The DHSC HSA4 Form Submission API uses **Bearer Token Authentication** to ensure only authorised systems can access the service.  

### Obtaining Access  
To access the API, you must have an account provided by the ANS team. If you do not have an account, please contact the ANS team to request credentials.  

### Obtaining a Bearer Token  
Once you have received your credentials, you will need to **exchange them for a Bearer Token** by making a request to the ANS Authentication Server.  

#### Example Token Request (Using `curl`)  
```shell
curl -X POST "https://<AUTH-SERVER-URL>/token" \
  -H "Content-Type: application/x-www-form-urlencoded" \
  -d "grant_type=client_credentials&client_id=your_client_id&client_secret=your_client_secret"
```

#### Example Response (JSON)
```json
{
  "access_token": "your_access_token",
  "token_type": "Bearer",
  "expires_in": 3600
}
```

### Making Authenticated Requests  
After obtaining the token, include it in the `Authorization` header of all requests made to the API.  

#### Example Request Header  
```http
Authorization: Bearer your_access_token
```

### Important  
- Without a valid token, your requests will be rejected with a `401 Unauthorized` response.  
- Tokens will have an expiry time (e.g., 3600 seconds / 1 hour). You will need to request a new token when the previous one expires.  
- If you experience difficulties obtaining or using your token, please contact the ANS team for support.  


## Security and Compliance  

### Reporting Vulnerabilities  
If you believe there is a security issue with the DHSC HSA4 Form Submission API, please **read our security policy** and **contact us immediately** using the information provided.  

- [Security Policy](https://your-documentation-website/security-policy)  
- [Report a Vulnerability](https://your-documentation-website/report-vulnerability)  

Please do not disclose suspected vulnerabilities publicly until they have been resolved.  

### HTTPS  
The DHSC HSA4 Form Submission API follows government HTTPS security guidelines. All connections to the API are made using **Hypertext Transfer Protocol Secure (HTTPS)**, which incorporates the **Transport Layer Security (TLS)** protocol to ensure secure communication.  

### Security Patches  
We treat security vulnerabilities in the platform and underlying libraries as a high priority. The codebase will be updated as soon as possible when vulnerabilities are discovered or reported.  

The framework and library code used by this API are frequently upgraded to the latest versions to enhance security and functionality.  


## Rate Limiting  

There is a maximum limit of **10 requests per second per client**. If you exceed this limit, your request will not be processed until the rate of requests is reduced, and you may encounter timeout errors.  

We believe this limit should be sufficient for all users of the DHSC HSA4 Form Submission API. However, if you believe your application requires a higher rate limit, please [contact support](#support).  


## Support

The DHSC HSA4 Form Submission API is currently in an **Alpha phase** and may be subject to changes and improvements as we gather feedback.

If you experience any issues or have questions regarding the DHSC HSA4 Form Submission API, please contact the Abortion Notification Service (ANS) support team:

- **If you are part of a government department:** Contact the ANS team via **Email:** [HSA4@dhsc.gov.uk](mailto:HSA4@dhsc.gov.uk) or **Telephone:** 020 7972 5541.
- **Otherwise:** Contact the ANS team via **Email:** [HSA4@@dhsc.gov.uk](mailto:HSA4@dhsc.gov.uk).

Our support team is available to assist you with any technical or procedural queries related to the API.

### Additional Resources

For further guidance on HSA4 form submissions and the associated legal framework, please refer to the following resources:

- **Guidance Notes for Completing HSA4 Forms:** Detailed instructions on how to complete and submit HSA4 forms.
  - [Guidance for Paper Forms](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms)
  - [Guidance for Electronic Forms](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-electronic-forms)

- **Abortion Act 1967:** The legislation governing abortion procedures in the UK.
  - [Full Text of the Abortion Act 1967](https://www.legislation.gov.uk/ukpga/1967/87/enacted)

[HTTP]: https://en.wikipedia.org/wiki/Hypertext_Transfer_Protocol
[JSON]: https://en.wikipedia.org/wiki/JSON

