using System.ComponentModel.DataAnnotations;
using DHSC.ANS.API.Consumer.Utilities;

namespace DHSC.ANS.API.Consumer.DTOs;

/// <summary>
/// Practitioner Information - Section 1
/// Required information:
/// - Full name of the practitioner.
/// - Address of the practitioner.
/// - GMC number (7 digits).
/// - Date of signature.
/// For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-1-practitioner-terminating-the-pregnancy)
/// </summary>
/// <remarks>
/// <para>
/// <strong>Section 1: Practitioner Terminating the Pregnancy</strong>
/// </para>
/// <para>
/// You must provide a full name, address, and General Medical Council (GMC) registration number, signature, and date.
/// </para>
/// <para>
/// The address stated does not have to be the one shown on the GMC’s annual registration certificate. 
/// However, if the form is incomplete and the place of termination is missing, the form will be returned to the address held by the GMC.
/// </para>
/// <para>
/// In cases of medical termination, details of the terminating practitioner must be provided, 
/// even if the practitioner has been unable to confirm that the pregnancy has been terminated. 
/// For more information, refer to 
/// [Section 4: Treatment Details](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details) in the guidance document.
/// </para>
/// <para>
/// Providing practitioner details constitutes a signed declaration of the following statement 
/// (as found on the paper form):  
/// </para>
/// <blockquote>
/// Hereby give notice that I terminated the pregnancy of the woman identified overleaf, and to the best of my knowledge, 
/// the particulars on this form are correct. I further certify that I joined/did not join (delete as appropriate) 
/// in giving HSA1 having seen/not seen (delete as appropriate) and examined/not examined (delete as appropriate) her before doing so.
/// </blockquote>
/// <para>
/// Forms will be returned if the practitioner’s name, address, GMC number, or signature are missing, or if the GMC number 
/// cannot be found on the GMC register.
/// </para>
/// <para>
/// For [medical abortions](https://www.gov.uk/government/consultations/home-use-of-both-pills-for-early-medical-abortion/home-use-of-both-pills-for-early-medical-abortion-up-to-10-weeks-gestation#:~:text=EMAs%20are%20defined%20as%20a,basis%20for%20England%20and%20Wales), when more than one doctor may be involved in the termination, the <em>terminating practitioner</em> 
/// is the doctor taking responsibility for the abortion. Usually, this will be the practitioner prescribing the [Mifepristone](https://bnf.nice.org.uk/drugs/mifepristone/) or [Misoprostol](https://bnf.nice.org.uk/drugs/misoprostol/).
/// </para>
/// </remarks>
public class PractitionerInfo
	{
    /// <summary>
    /// The full name of the practitioner responsible for the termination, required for form validity.
    /// </summary>
    [Required]
    public required string FullName { get; set; }

    /// <summary>
    /// The address of the practitioner, which does not have to match the GMC’s registration certificate.
    /// </summary>
    [Required]
    public required string Address { get; set; }

    /// <summary>
    /// The practitioner's GMC registration number as registered on the GMC register.
    /// </summary>
    [Required, RegularExpression(@"^\d{7}$")]
    [RestrictionsAttribute("Valid 7 digit GMC Reference")]
    public required string GmcNumber { get; set; }

    /// <summary>
    /// The date the practitioner signed the form.
    /// </summary>
    [Required]
    [RestrictionsAttribute("YYYY-MM-DDTHH:MM:SSZ  (UTC time)")]
    public required DateTime DateOfSignature { get; set; }
}
