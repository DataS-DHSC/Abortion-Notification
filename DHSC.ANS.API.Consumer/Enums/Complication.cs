namespace DHSC.ANS.API.Consumer.Enums;

/// <summary>
/// Enumeration representing possible complications of the treatment.
/// Refer to guidance: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9-complications)
/// </summary>
public enum Complication
{
	/// <summary>Haemorrhage complication.</summary>
	Haemorrhage,
	/// <summary>Uterine perforation complication.</summary>
	UterinePerforation,
	/// <summary>Cervical laceration complication.</summary>
	CervicalLaceration,
	/// <summary>Infection complication.</summary>
	Infection,
	/// <summary>Retained products complication.</summary>
	RetainedProducts,
	/// <summary>Psychological problems complication.</summary>
	PsychologicalProblems,
	/// <summary>Other complications not listed.</summary>
	Other
}
