using System.ComponentModel.DataAnnotations;

namespace DHSC.ANS.API.Consumer.DTOs;

/// <summary>
/// Selective Termination - Section 7
/// Required Information:
/// - Original number of fetuses before selective termination.
/// - Number of fetuses remaining after the procedure.
/// For further details, see: [Selective Termination - Section 7](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
/// </summary>
/// <remarks>
/// This section should only be completed if the original number of fetuses was 2 or more and reduced to 1 or more. All other relevant sections of the form must be completed.
/// A medical practitioner will scrutinise all forms relating to selective terminations, and more information may be requested on a case-by-case basis.
/// </remarks>
public class SelectiveTerminationInfoDto
{
    /// <summary>
    /// The number of fetuses originally present before the selective termination.
    /// </summary>
    [Required]
    public required int OriginalFetusCount { get; set; }

    /// <summary>
    /// The number of fetuses remaining after the selective termination.
    /// </summary>
    [Required]
    public required int RemainingFetusCount { get; set; }
}
