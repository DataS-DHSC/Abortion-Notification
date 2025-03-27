using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DHSC.ANS.API.Consumer.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace DHSC.ANS.API.Consumer.DTOs
{
	/// <summary>
	/// HSA4 Form DTO - Represents the entire form submission.
	/// This object aggregates all the sections of the HSA4 form as specified by the official guidance.
	/// Each section is represented by a dedicated DTO.
	/// For further details, see: [HSA4 Form Guidance](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
	/// </summary>
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
		/// Sections 5 & 6 - Pregnancy Details
		/// </summary>
		[Required]
		public required PregnancyDetailsDto Pregnancy { get; set; }

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


    /// <summary>
    /// Practitioner Information - Section 1
    /// Required information:
    /// - Full name of the practitioner.
    /// - Address of the practitioner.
    /// - GMC number (7 digits).
    /// - Date of signature.
    /// For further details, see: [Practitioner Information - Section 1](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
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

    public class PractitionerInfoDto
	{
		[Required]
		public required string FullName { get; set; }

		[Required]
		public required string Address { get; set; }

		[Required, RegularExpression(@"^\d{7}$")]
		public required string GmcNumber { get; set; }

		[Required]
		public required DateTime DateOfSignature { get; set; }
	}

	// ------------------------------------------------------------------------
	// 2. CertificationInfoDto
	// ------------------------------------------------------------------------
	/// <summary>
	/// Certification Information - Section 2 (Non-Emergency Cases)
	/// Required information:
	/// - Names and addresses of two certifying doctors.
	/// - Indicate if the performing doctor was a signatory.
	/// For further details, see: [Certification Information - Section 2](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
	/// </summary>
	public class CertificationInfoDto
	{
		[Required]
		public required string CertifyingDoctor1Name { get; set; }

		[Required]
		public required string CertifyingDoctor1Address { get; set; }

		[Required]
		public required string CertifyingDoctor2Name { get; set; }

		[Required]
		public required string CertifyingDoctor2Address { get; set; }

		public bool PerformingDoctorWasSignatory { get; set; }
	}

	// ------------------------------------------------------------------------
	// 3. PatientDetailsDto
	// ------------------------------------------------------------------------
	/// <summary>
	/// Patient's Details - Section 3
	/// Required information:
	/// - Patient's hospital number and NHS number (if available).
	/// - Full name, date of birth, address, and postcode.
	/// - Country of residence, ethnic group, and marital status.
	/// - Number of previous live births over 24 weeks, miscarriages, and terminations.
	/// For further details, see: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3)
	/// </summary>
	public class PatientDetailsDto
	{
		public string HospitalNumber { get; set; }
		public string NHSNumber { get; set; }
		public string FullName { get; set; }

		[Required]
		public required DateTime DateOfBirth { get; set; }

		public string Postcode { get; set; }
		public string Address { get; set; }

		[Required]
		public required string CountryOfResidence { get; set; }

		[Required]
		public required Ethnicity EthnicGroup { get; set; }

		[Required]
		public required MaritalStatus MaritalStatus { get; set; }

		[Required]
		public required int PreviousLiveBirthsOver24Weeks { get; set; }

		[Required]
		public required int PreviousMiscarriages { get; set; }

		[Required]
		public required int PreviousTerminations { get; set; }
	}

	// ------------------------------------------------------------------------
	// 4. TreatmentDetailsDto
	// ------------------------------------------------------------------------
	/// <summary>
	/// Treatment Details - Section 4
	/// Required information:
	/// - Treatment location, dates of termination, admission, and discharge.
	/// - Type of procedure performed (medical or surgical).
	/// - Funding type (NHS, Private).
	/// For further details, see: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4)
	/// </summary>
	public class TreatmentDetailsDto
	{
		public string PlaceOfTerminationName { get; set; }
		public string PlaceOfTerminationAddress { get; set; }
		public FundingType Funding { get; set; }

		public DateTime? FeticideDate { get; set; }
		public string FeticideMethod { get; set; }

		public DateTime? TerminationDate { get; set; }
		public DateTime? AdmissionDate { get; set; }
		public DateTime? DischargeDate { get; set; }
		public string SurgicalMethod { get; set; }

		/// <summary>
		/// How the procedure was administered (AllAtHome, PartiallyAtHome, or InClinic).
		/// </summary>
		public AdministrationSetting AdministrationSetting { get; set; }

		/// <summary>
		/// If partial or all medicines are administered off-site, specify the provider's organisation.
		/// </summary>
		public string ServiceProviderOrganisation { get; set; }
	}

	// ------------------------------------------------------------------------
	// 5. PregnancyDetailsDto
	// ------------------------------------------------------------------------
	/// <summary>
	/// Pregnancy Details - Sections 5 & 6
	/// Required information:
	/// - Gestation period in weeks and days if applicable.
	/// - Grounds for termination and reasons (medical reasons if applicable).
	/// For further details, see: [Pregnancy Details - Sections 5 & 6](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5)
	/// </summary>
	public class PregnancyDetailsDto
	{
		[Required, Range(4, 40)]
		public required int GestationWeeks { get; set; }

		public int? GestationDays { get; set; }

		[Required]
		public required List<AbortionGround> Grounds { get; set; }

		public string MainConditionForGroundsAorBorForG { get; set; }
		public bool? GroundC_RiskToMentalHealth { get; set; }
		public string GroundC_PhysicalCondition { get; set; }
	}

	// ------------------------------------------------------------------------
	// 6. SelectiveTerminationInfoDto
	// ------------------------------------------------------------------------
	/// <summary>
	/// Selective Termination - Section 7
	/// Required Information:
	/// - Original number of fetuses before selective termination.
	/// - Number of fetuses remaining after the procedure.
	/// For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
	/// </summary>
	public class SelectiveTerminationInfoDto
	{
		public int OriginalFetusCount { get; set; }
		public int RemainingFetusCount { get; set; }
	}

	// ------------------------------------------------------------------------
	// 7. ChlamydiaInfoDto
	// ------------------------------------------------------------------------
	/// <summary>
	/// Chlamydia Screening - Section 8
	/// Required Information:
	/// - Indication if screening for chlamydia was offered.
	/// - Response is mandatory for all cases.
	/// For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
	/// </summary>
	public class ChlamydiaInfoDto
	{
		[Required]
		public required bool ScreeningOffered { get; set; }
	}

	// ------------------------------------------------------------------------
	// 8. ComplicationsInfoDto
	// ------------------------------------------------------------------------
	/// <summary>
	/// Complications - Section 9
	/// Required Information:
	/// - List of complications experienced, if any.
	/// - Additional details if complications are not listed.
	/// For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9)
	/// </summary>
	public class ComplicationsInfoDto
	{
		public List<Complication> Complications { get; set; }
		public string OtherComplicationDetails { get; set; }
	}

	// ------------------------------------------------------------------------
	// 9. MaternalDeathInfoDto
	// ------------------------------------------------------------------------
	/// <summary>
	/// Death of Woman - Section 10
	/// Required Information:
	/// - Indicate if a maternal death occurred.
	/// - Date and cause of death if applicable.
	/// For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
	/// </summary>
	public class MaternalDeathInfoDto
	{
		public bool MaternalDeathOccurred { get; set; }
		public DateTime? DateOfDeath { get; set; }
		public string CauseOfDeath { get; set; }
	}
}
