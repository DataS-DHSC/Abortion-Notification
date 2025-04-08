// Interfaces/ISoapMessageService.cs
using System.ServiceModel;
using System.Threading.Tasks;
using DHSC.ANS.API.Legacy.Models;

namespace DHSC.ANS.API.Legacy.Interfaces
{
    [ServiceContract(Namespace = "http://schemas.doh.com/ans/api/services")]
    public interface ISoapMessageService
    {
        [OperationContract]
        Task<ProcessNewCaseFormResponse> ProcessNewCaseForm(CaseFormRequest caseFormRequest);
    }
}
