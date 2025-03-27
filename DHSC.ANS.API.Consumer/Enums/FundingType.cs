namespace DHSC.ANS.API.Consumer.Enums;

/// <summary>
/// Enumeration representing the funding type of the treatment.
/// Refer to guidance: [Treatment Details - Section 4](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-4-treatment-details)
/// </summary>
public enum FundingType
{
	/// <summary>Treatment funded by the NHS.</summary>
	NHS,
	/// <summary>Treatment funded privately.</summary>
	Private
}
