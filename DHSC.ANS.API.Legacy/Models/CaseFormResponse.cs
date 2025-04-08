// Models/ProcessNewCaseFormResponse.cs
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DHSC.ANS.API.Legacy.Models
{
    [DataContract(Namespace = "http://schemas.doh.com/ans/api/services")]
    public class ProcessNewCaseFormResponse
    {
        [DataMember(Name = "ProcessNewCaseFormResult")]
        public ProcessNewCaseFormResult Result { get; set; }
    }

    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/DH.ANS.ServiceInterface.Models")]
    public class ProcessNewCaseFormResult
    {
        [DataMember]
        public Control Control { get; set; } = new();

        [DataMember]
        public Section Section1 { get; set; } = new();
        [DataMember]
        public Section Section2 { get; set; } = new();
        [DataMember]
        public Section Section3 { get; set; } = new();
        [DataMember]
        public Section Section4 { get; set; } = new();
        [DataMember]
        public Section Section5 { get; set; } = new();
        [DataMember]
        public Section Section6 { get; set; } = new();
        [DataMember]
        public Section Section7 { get; set; } = new();
        [DataMember]
        public Section Section8 { get; set; } = new();
        [DataMember]
        public Section Section9 { get; set; } = new();
    }

    [DataContract]
    public class Control
    {
        [DataMember] public string Authentication { get; set; }
        [DataMember] public int ErrorCountTotal { get; set; } = 0;
        [DataMember] public string FormID { get; set; }
        [DataMember] public string FormUserId { get; set; }
        [DataMember] public bool FormValid { get; set; } = true;
        [DataMember] public string GUID { get; set; }
        [DataMember] public string HospitalCode { get; set; }
        [DataMember] public int PopupCountTotal { get; set; } = 0;
        [DataMember] public string ServerVersion { get; set; } = "1.2.2";
        [DataMember] public int WarningCountTotal { get; set; } = 0;
    }

    [DataContract]
    public class Section
    {
        [DataMember] public int ErrorMessageCount { get; set; } = 0;
        [DataMember] public string ErrorMessages { get; set; } = string.Empty;
        [DataMember] public string PopupMessage { get; set; } = string.Empty;
        [DataMember] public int PopupMessageCount { get; set; } = 0;
        [DataMember] public bool SectionValid { get; set; } = true;
        [DataMember] public string WarningMessage { get; set; } = string.Empty;
        [DataMember] public int WarningMessageCount { get; set; } = 0;
    }
}