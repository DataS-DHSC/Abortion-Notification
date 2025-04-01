using DHSC.ANS.API.Consumer.DTOs;

namespace DHSC.ANS.API.Consumer.Interfaces;

public interface IHSA4FormService
{
	Task<string> SubmitFormAsync(HSA4Form form);
    Task<HSA4Form> UpdateFormAsync(string id, HSA4Form form);
    Task<HSA4Form> GetFormByIdAsync(string id);
    
    Task<bool> DeleteFormByIdAsync(string id);

    Task<HSA4Form> MergeFormsAsync(HSA4Form formA, HSA4Form formB);
}
