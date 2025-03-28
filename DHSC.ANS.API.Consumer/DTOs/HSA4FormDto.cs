using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace DHSC.ANS.API.Consumer.DTOs;

/// <summary>
/// HSA4 Form DTO - Represents the entire form submission.
/// This object aggregates all the sections of the HSA4 form as specified by the official guidance.
/// Each section is represented by a dedicated DTO.
/// For further details, see: [HSA4 Form Guidance](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
/// </summary>
/// <remarks>
/// The HSA4 form must be electronically signed within 14 days of the termination by the responsible registered medical practitioner. In the case of medical abortions, this is usually the practitioner prescribing mifepristone. 
/// Forms that are not electronically signed within 14 days may be removed from the doctor's account and returned as paper forms for manual processing, which can cause delays and additional workload.
/// It is critical for the accuracy of national statistics and operational efficiency that the forms are completed and signed promptly.
/// </remarks>
public class HSA4FormDto
{
    /// <summary>
    /// Section 1 - Practitioner Information
    /// </summary>
    [Required]
    public required PractitionerInfoDto Practitioner { get; set; }

    /// <summary>
    /// Section 2 - Certification (Non-Emergency Cases)
    /// </summary>
    [Required]
    public required CertificationInfoDto Certification { get; set; }

    /// <summary>
    /// Section 3 - Patient's Details
    /// </summary>
    [Required]
    public required PatientDetailsDto Patient { get; set; }

    /// <summary>
    /// Section 4 - Treatment Details
    /// </summary>
    [Required]
    public required TreatmentDetailsDto Treatment { get; set; }

    /// <summary>
    /// Sections 5 - Gestation Details
    /// </summary>
    [Required]
    public required GestationDetailsDto Gestation { get; set; }

    /// <summary>
    /// Sections 6 - Termination Details
    /// </summary>
    [Required]
    public required TerminationGroundsDto TerminationGroundsDto { get; set; }

    /// <summary>
    /// Section 7 - Selective Termination (if applicable)
    /// </summary>
    public SelectiveTerminationInfoDto? SelectiveTermination { get; set; }

    /// <summary>
    /// Section 8 - Chlamydia Screening
    /// </summary>
    public ChlamydiaInfoDto? ChlamydiaScreening { get; set; }

    /// <summary>
    /// Section 9 - Complications
    /// </summary>
    public ComplicationsInfoDto? Complications { get; set; }

    /// <summary>
    /// Section 10 - Death of Woman (if applicable)
    /// </summary>
    public MaternalDeathInfoDto? MaternalDeath { get; set; }
}