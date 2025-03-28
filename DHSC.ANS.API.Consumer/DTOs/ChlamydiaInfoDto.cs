using System.ComponentModel.DataAnnotations;

namespace DHSC.ANS.API.Consumer.DTOs
{
    /// <summary>
    /// Chlamydia Screening - Section 8
    /// Required Information:
    /// - Indication if screening for chlamydia was offered.
    /// - Response is mandatory for all cases.
    /// For further details, see: [Chlamydia Screening - Section 8](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales)
    /// </summary>
    /// <remarks>
    /// This section must be completed for all cases. Indicate if screening for chlamydia was offered or if screening and prophylactic antibiotic treatment were offered.
    /// The 'Yes' box should not be ticked if prophylactic treatment alone was offered without screening.
    /// </remarks>
    public class ChlamydiaInfoDto
    {
        /// <summary>
        /// Indicates whether chlamydia screening or screening and prophylactic antibiotic treatment was offered.
        /// </summary>
        [Required]
        public required bool ScreeningOffered { get; set; }
    }
}
