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
/// <para>
/// The HSA4 form must be electronically signed within 14 days of the termination by the responsible registered medical practitioner. In the case of medical abortions, this is usually the practitioner prescribing mifepristone. 
/// </para>
/// <para>
/// Forms that are not electronically signed within 14 days may be removed from the doctor's account and returned as paper forms for manual processing, which can cause delays and additional workload.
/// </para>
/// <para>
/// It is critical for the accuracy of national statistics and operational efficiency that the forms are completed and signed promptly.
/// </para>
/// </remarks>
public class HSA4Form
{
    /// <summary>
    /// Section 1 - Practitioner Information
    /// </summary>
    public PractitionerInfo? Practitioner { get; set; }

    /// <summary>
    /// Section 2 - Certification (Non-Emergency Cases)
    /// </summary>
    public CertificationInfo? Certification { get; set; }

    /// <summary>
    /// Section 3 - Patient's Details
    /// </summary>
    public PatientDetails? Patient { get; set; }

    /// <summary>
    /// Section 4 - Treatment Details
    /// </summary>
    public TreatmentDetails? Treatment { get; set; }

    /// <summary>
    /// Sections 5 - Gestation Details
    /// </summary>
    public GestationDetails? Gestation { get; set; }

    /// <summary>
    /// Sections 6 - Termination Details
    /// </summary>
    public TerminationGrounds? TerminationGroundsDto { get; set; }

    /// <summary>
    /// Section 7 - Selective Termination (if applicable)
    /// </summary>
    public SelectiveTerminationInfo? SelectiveTermination { get; set; }

    /// <summary>
    /// Section 8 - Chlamydia Screening
    /// </summary>
    public ChlamydiaInfo? ChlamydiaScreening { get; set; }

    /// <summary>
    /// Section 9 - Complications
    /// </summary>
    public ComplicationsInfo? Complications { get; set; }

    /// <summary>
    /// Section 10 - Death of Woman (if applicable)
    /// </summary>
    public MaternalDeathInfo? MaternalDeath { get; set; }
}