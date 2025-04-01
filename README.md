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
