using DHSC.ANS.API.Consumer.Enums;

namespace DHSC.ANS.API.Consumer.DTOs
{
    /// <summary>
    /// Complications - Section 9
    /// Required Information:
    /// - List of complications experienced, if any.
    /// - Additional details if complications are not listed.
    /// For further details, see: [Complications - Section 9](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#section-9)
    /// </summary>
    /// <remarks>
    /// This section should be completed if any complications occurred up until the time of discharge from the place of termination.
    /// Note: Do not include evacuations of retained products of conception or failed terminations as complications.
    /// A medical practitioner scrutinises all complications listed under ‘other’ and additional information may be requested as needed.
    /// </remarks>
    public class ComplicationsInfoDto
    {
        /// <summary>
        /// The list of complications experienced during or after the procedure.
        /// </summary>
        public List<Complication> Complications { get; set; }

        /// <summary>
        /// Details of any other complications not listed above.
        /// </summary>
        public string OtherComplicationDetails { get; set; }
    }
}
