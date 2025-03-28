using System.ComponentModel.DataAnnotations;
using DHSC.ANS.API.Consumer.Utilities;

namespace DHSC.ANS.API.Consumer.DTOs;

/// <summary>
/// Gestation Details - Section 5
/// Required information:
/// - Gestation period in weeks and days if applicable.
/// - Grounds for termination and reasons (medical reasons if applicable).
/// For further details, see: [Pregnancy Details - Sections 5 & 6](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-5)
/// </summary>
/// <remarks>
/// For abortions at less than 24 weeks, only completed weeks need to be specified. For exactly 24 weeks or more, the format should be "24 + 0", "24 + 3", etc. to indicate additional days. If gestation is above 24 weeks, additional information must be provided.
/// Forms will be returned if gestation is not provided, if it is less than 4 weeks, or if it is 24 weeks or over and additional details are not included.
/// </remarks>
public class GestationDetailsDto
{
    /// <summary>
    /// The gestation period in completed weeks.
    /// </summary>
    [Required, Range(4, 40)]
    [RestrictionsAttribute("Valid range: 4 - 40 weeks. Provide additional details if exactly 24 weeks or over.")]
    public required int GestationWeeks { get; set; }

    /// <summary>
    /// The additional days past the completed weeks (0 to 6 days).
    /// </summary>
    [Range(0, 6)]
    [RestrictionsAttribute("Valid range: 0 - 6 days. Only applicable when gestation is 24 weeks or more.")]
    public int? GestationDays { get; set; }
}
