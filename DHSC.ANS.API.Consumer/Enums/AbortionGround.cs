namespace DHSC.ANS.API.Consumer.Enums;

/// <summary>
/// Enumeration representing the grounds for abortion, as specified by the HSA4 Guidance Notes.
/// Valid Grounds:
/// - Risk to the life of the pregnant woman.
/// - Preventing grave permanent injury to physical or mental health.
/// - Preventing injury to health of the woman or existing children under 24 weeks.
/// - Substantial risk of severe abnormality if the child were born.
/// - Emergency to save life or prevent grave permanent injury.
/// Refer to guidance: [Abortion Grounds - Section 5](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5-gestation)
/// </summary>
public enum AbortionGround
{
	/// <summary>Risk to the life of the pregnant woman (Ground A).</summary>
	RiskToLifeOfWoman,

	/// <summary>Preventing grave permanent injury to the physical or mental health of the pregnant woman (Ground B).</summary>
	GravePermanentInjury,

	/// <summary>Preventing injury to the physical or mental health of the woman, under 24 weeks (Ground C).</summary>
	RiskToMentalOrPhysicalHealthOfWoman,

	/// <summary>Preventing injury to the physical or mental health of existing children, under 24 weeks (Ground D).</summary>
	RiskToMentalOrPhysicalHealthOfExistingChildren,

	/// <summary>Substantial risk that if the child were born, it would suffer from serious abnormalities (Ground E).</summary>
	SubstantialRiskOfSevereAbnormality,

	/// <summary>Emergency only: To save the life of the pregnant woman (Ground F).</summary>
	EmergencyToSaveLife,

	/// <summary>Emergency only: To prevent grave permanent injury to the physical or mental health of the pregnant woman (Ground G).</summary>
	EmergencyToPreventGravePermanentInjury
}
