namespace DHSC.ANS.API.Consumer.Enums;

/// <summary>
/// Enumeration representing the administration setting of the treatment.
/// Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
/// </summary>
public enum AdministrationSetting
{
	/// <summary>All treatment conducted at home.</summary>
	AllAtHome,
	/// <summary>Treatment partially conducted at home.</summary>
	PartiallyAtHome,
	/// <summary>Treatment conducted in a clinic.</summary>
	InClinic
}
