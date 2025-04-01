using System.ComponentModel.DataAnnotations;
using DHSC.ANS.API.Consumer.Enums;
using DHSC.ANS.API.Consumer.Utilities;

namespace DHSC.ANS.API.Consumer.DTOs;

/// <summary>
/// Patient's Details - Section 3
/// Required information:
/// - Patient's hospital number and NHS number (if available).
/// - Full name, date of birth, address, and postcode.
/// - Country of residence, ethnic group, and marital status.
/// - Number of previous live births over 24 weeks, miscarriages, and terminations.
/// For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3)
/// </summary>
/// <remarks>
/// <para>
/// <strong>Section 3: Patient’s Details</strong>
/// </para>
/// <para>
/// You must provide the patient's hospital number or NHS number if available, along with their full name, date of birth, address, and postcode.
/// For residents outside of England and Wales, provide the patient's country of residence. If the country of residence is not known, provide the patient's full postcode or address for their temporary stay in England or Wales.
/// </para>
/// <para>
/// Ethnicity and marital status must be reported if known. The parity section should detail previous live births over 24 weeks, miscarriages, and legal terminations.
/// </para>
/// </remarks>
public class PatientDetails
{
    /// <summary>
    /// The patient's hospital or clinic number.
    /// </summary>
    public string HospitalNumber { get; set; }

    /// <summary>
    /// The patient's NHS number.
    /// </summary>
    [RegularExpression(@"^\d{10}$")]
    [RestrictionsAttribute("Valid 10 digit NHS Number")]
    public string NHSNumber { get; set; }

    /// <summary>
    /// The patient's full name.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// The patient's date of birth.
    /// </summary>
    [Required]
    [RestrictionsAttribute("YYYY-MM-DDT00:00:00")]
    public required DateTime DateOfBirth { get; set; }

    /// <summary>
    /// The patient's full postcode (if applicable).
    /// </summary>
    [RegularExpression(@"^[A-Z]{1,2}\d{1,2}[A-Z]?\s?\d[A-Z]{2}$")]
    [RestrictionsAttribute("Valid UK Postcode")]
    public string Postcode { get; set; }

    /// <summary>
    /// The patient's address (if full postcode is not provided).
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// The patient's country of residence.
    /// </summary>
    [Required]
    public required string CountryOfResidence { get; set; }

    /// <summary>
    /// The patient's self-reported ethnicity.
    /// </summary>
    [Required]
    public required Ethnicity EthnicGroup { get; set; }

    /// <summary>
    /// The patient's marital status.
    /// </summary>
    [Required]
    public required MaritalStatus MaritalStatus { get; set; }

    /// <summary>
    /// Number of previous live births over 24 weeks.
    /// </summary>
    [Required]
    public required int PreviousLiveBirthsOver24Weeks { get; set; }

    /// <summary>
    /// Number of previous miscarriages.
    /// </summary>
    [Required]
    public required int PreviousMiscarriages { get; set; }

    /// <summary>
    /// Number of previous terminations.
    /// </summary>
    [Required]
    public required int PreviousTerminations { get; set; }
}
