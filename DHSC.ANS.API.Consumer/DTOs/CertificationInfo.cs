using System.ComponentModel.DataAnnotations;

namespace DHSC.ANS.API.Consumer.DTOs;

/// <summary>
/// Certification Information - Section 2 (Non-Emergency Cases)
/// Required information:
/// - Names and addresses of two certifying doctors.
/// - Indicate if the performing doctor was a signatory.
/// For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-2-certification)
/// </summary>
/// <remarks>
/// <para>
/// <strong>Section 2: Certification</strong>
/// </para>
/// <para>
/// You must provide the full name and address of both registered medical practitioners who certified the patient had grounds for the abortion. 
/// If one of these practitioners was also the practitioner who terminated the pregnancy, ensure to complete the relevant certification information accordingly.
/// </para>
/// <para>
/// Forms will be returned if no information is given, if a hospital stamp is used but no doctor’s name is provided, or if the same doctor is listed twice as shown in Section 1.
/// </para>
/// <para>
/// For digital submissions, practitioners should be selected from a predefined list, or entered manually if not present. Manually entered details will be saved for future use.
/// </para>
/// </remarks>
public class CertificationInfo
{
    /// <summary>
    /// Full name of the first certifying doctor.
    /// </summary>
    [Required]
    public required string CertifyingDoctor1Name { get; set; }

    /// <summary>
    /// Address of the first certifying doctor.
    /// </summary>
    [Required]
    public required string CertifyingDoctor1Address { get; set; }

    /// <summary>
    /// Full name of the second certifying doctor.
    /// </summary>
    [Required]
    public required string CertifyingDoctor2Name { get; set; }

    /// <summary>
    /// Address of the second certifying doctor.
    /// </summary>
    [Required]
    public required string CertifyingDoctor2Address { get; set; }

    /// <summary>
    /// Indicates if the performing doctor was one of the certifying doctors.
    /// </summary>
    public bool PerformingDoctorWasSignatory { get; set; }
}

