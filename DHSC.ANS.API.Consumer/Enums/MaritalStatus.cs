namespace DHSC.ANS.API.Consumer.Enums;

/// <summary>
/// Enumeration representing the patient's marital status.
/// Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
/// </summary>
public enum MaritalStatus
{
	/// <summary>Single marital status.</summary>
	Single,
	/// <summary>Married marital status.</summary>
	Married,
	/// <summary>Divorced marital status.</summary>
	Divorced,
	/// <summary>Widowed marital status.</summary>
	Widowed,
	/// <summary>Separated marital status.</summary>
	Separated,
	/// <summary>Civil partnership status.</summary>
	CivilPartnership
}
