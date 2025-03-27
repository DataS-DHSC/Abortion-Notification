namespace DHSC.ANS.API.Consumer.Enums;

/// <summary>
/// Enumeration representing the patient's ethnic group. Valid values are defined by the HSA4 Guidance Notes.
/// Refer to guidance: [Patient's Details - Section 3](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-3-patients-details)
/// </summary>
public enum Ethnicity
{
	/// <summary>White ethnic group.</summary>
	White,
	/// <summary>Mixed ethnic group.</summary>
	Mixed,
	/// <summary>Asian or Asian British ethnic group.</summary>
	AsianOrAsianBritish,
	/// <summary>Black or Black British ethnic group.</summary>
	BlackOrBlackBritish,
	/// <summary>Other ethnic group.</summary>
	Other
}
