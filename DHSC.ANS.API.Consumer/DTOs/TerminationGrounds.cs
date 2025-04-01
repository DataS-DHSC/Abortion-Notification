using System.ComponentModel.DataAnnotations;
using DHSC.ANS.API.Consumer.Enums;

namespace DHSC.ANS.API.Consumer.DTOs;

/// <summary>
/// Termination Grounds - Section 6
/// Required information:
/// <list type="bullet">
///   <item>
///     <description>Grounds for termination as stated on HSA1 or HSA2 form.</description>
///   </item>
///   <item>
///     <description>Additional conditions or reasons as applicable.</description>
///   </item>
/// </list>
/// For further details, see: <see href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-6">Termination Grounds - Section 6</see>
/// </summary>
/// <remarks>
/// <para>
/// <strong>Section 6: Grounds for Termination</strong>
/// </para>
/// <para>
/// Grounds for termination must be selected as stated on the HSA1 or HSA2 form. The available grounds are:
/// <list type="bullet">
///   <item>
///     <description>Risk to the life of the pregnant woman.</description>
///   </item>
///   <item>
///     <description>To prevent grave permanent injury to the physical or mental health of the pregnant woman.</description>
///   </item>
///   <item>
///     <description>Risk of injury to the physical or mental health of the pregnant woman (up to 24 weeks).</description>
///   </item>
///   <item>
///     <description>Risk of injury to the physical or mental health of any existing children of the family of the pregnant woman (up to 24 weeks).</description>
///   </item>
///   <item>
///     <description>Substantial risk that if the child were born, they would suffer from such physical or mental abnormalities as to be seriously handicapped.</description>
///   </item>
///   <item>
///     <description>To save the life of the pregnant woman in an emergency.</description>
///   </item>
///   <item>
///     <description>To prevent grave permanent injury to the physical or mental health of the pregnant woman in an emergency.</description>
///   </item>
/// </list>
/// </para>
/// <para>
/// For applicable grounds, further details should be provided. If the pregnancy was terminated after exceeding the 24th week, provide a full statement of the medical condition.
/// </para>
/// </remarks>

public class TerminationGrounds
{
    /// <summary>
    /// Grounds for termination selected from HSA1 or HSA2 form.
    /// </summary>
    [Required]
    public required List<AbortionGround> Grounds { get; set; }

    /// <summary>
    /// The main condition relevant to grounds concerning the health or life of the pregnant woman or fetus.
    /// </summary>
    public string MainCondition { get; set; }

    /// <summary>
    /// Specifies if the risk to mental health was the reason for termination.
    /// </summary>
    public bool? RiskToMentalHealth { get; set; }

    /// <summary>
    /// The physical condition that warranted termination under the specified grounds.
    /// </summary>
    public string PhysicalCondition { get; set; }
}
