// Models/CaseFormRequest.cs
using System.Runtime.Serialization;

namespace DHSC.ANS.API.Legacy.Models
{
    [DataContract(Namespace = "http://schemas.doh.com/ans/api/services")]
    public class CaseFormRequest
    {
        [DataMember]
        public string CaseFormControl { get; set; }
    }
}