using System.ComponentModel.DataAnnotations;
using DHSC.ANS.API.Consumer.Enums;
using DHSC.ANS.API.Consumer.Utilities;

namespace DHSC.ANS.API.Consumer.DTOs;

/// <summary>
/// Treatment Details - Section 4
/// Required information:
/// - Treatment location, dates of termination, admission, and discharge.
/// - Type of procedure performed (medical or surgical).
/// - Funding type (NHS, Private).
/// For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4)
/// </summary>
/// <remarks>
/// <para>
/// <strong>Section 4: Treatment Details</strong>
/// </para>
/// <para>
/// You must specify whether the abortion was NHS funded or privately funded. For surgical terminations, indicate the procedure performed and provide relevant dates and methods used.
/// For medical terminations, specify the administration setting (e.g., all at home, partially at home, or in clinic), and if applicable, the organisation providing off-site treatment.
/// </para>
/// <para>
/// If feticide was used, provide the method and date. For all methods, the dates of admission, termination, and discharge (if applicable) must be specified.
/// </para>
/// <para>
/// Failure to provide correct details may result in the form being returned.
/// </para>
/// </remarks>
public class TreatmentDetailsDto
{
    /// <summary>
    /// Name of the place where the termination was performed.
    /// </summary>
    [Required]
    public required string PlaceOfTerminationName { get; set; }

    /// <summary>
    /// Address of the place where the termination was performed.
    /// </summary>
    [Required]
    public required string PlaceOfTerminationAddress { get; set; }

    /// <summary>
    /// Funding type: NHS or Private.
    /// </summary>
    [Required]
    public required FundingType Funding { get; set; }

    /// <summary>
    /// The date feticide was performed, if applicable.
    /// </summary>
    [RestrictionsAttribute("YYYY-MM-DDTHH:MM:SSZ (UTC time)")]
    public DateTime? FeticideDate { get; set; }

    /// <summary>
    /// The method of feticide, if applicable.
    /// </summary>
    public string FeticideMethod { get; set; }

    /// <summary>
    /// The date of termination.
    /// </summary>
    [Required]
    [RestrictionsAttribute("YYYY-MM-DDTHH:MM:SSZ (UTC time)")]
    public required DateTime TerminationDate { get; set; }

    /// <summary>
    /// The date of admission to the facility (if an overnight stay was required).
    /// </summary>
    [RestrictionsAttribute("YYYY-MM-DDTHH:MM:SSZ (UTC time)")]
    public DateTime? AdmissionDate { get; set; }

    /// <summary>
    /// The date of discharge from the facility.
    /// </summary>
    [RestrictionsAttribute("YYYY-MM-DDTHH:MM:SSZ (UTC time)")]
    public DateTime? DischargeDate { get; set; }

    /// <summary>
    /// The surgical method used, if applicable.
    /// </summary>
    public string SurgicalMethod { get; set; }

    /// <summary>
    /// Administration setting: AllAtHome, PartiallyAtHome, or InClinic.
    /// </summary>
    [Required]
    public required AdministrationSetting AdministrationSetting { get; set; }

    /// <summary>
    /// Provider's organisation if treatment was administered off-site.
    /// </summary>
    public string ServiceProviderOrganisation { get; set; }
}

