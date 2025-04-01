using System.ComponentModel.DataAnnotations;
using DHSC.ANS.API.Consumer.Utilities;

namespace DHSC.ANS.API.Consumer.DTOs;

/// <summary>
/// Death of Woman - Section 10
/// Required Information:
/// - Indicate if a maternal death occurred.
/// - Date and cause of death if applicable.
/// For further details, see: [Death of Woman - Section 10](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
/// </summary>
/// <remarks>
/// <para>
/// <strong>Section 10: Maternal Death</strong>
/// </para>
/// <para>
/// If a maternal death occurs as a result of the termination, you must state the date and the cause of death. This section will be scrutinised by a medical practitioner, and additional information may be requested.
/// </para>
/// </remarks>
public class MaternalDeathInfo
{
    /// <summary>
    /// Indicates whether a maternal death occurred as a result of the termination.
    /// </summary>
    [Required]
    public required bool MaternalDeathOccurred { get; set; }

    /// <summary>
    /// The date of death, if applicable.
    /// </summary>
    [RestrictionsAttribute("YYYY-MM-DDTHH:MM:SSZ (UTC time)")]
    public DateTime? DateOfDeath { get; set; }

    /// <summary>
    /// The cause of death, if applicable.
    /// </summary>
    public string CauseOfDeath { get; set; }
}