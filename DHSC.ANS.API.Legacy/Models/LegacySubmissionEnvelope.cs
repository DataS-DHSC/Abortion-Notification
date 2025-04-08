using System;

namespace DHSC.ANS.API.Legacy.Models
{
    public class LegacySubmissionEnvelope
    {
        public string SubmissionId { get; set; }
        public string FormId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string RawXml { get; set; }
    }
}