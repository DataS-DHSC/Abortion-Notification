using DHSC.ANS.API.Consumer.DTOs;

namespace DHSC.ANS.API.Consumer.Interfaces;

public interface IHSA4FormService
{
	Task<string> SubmitFormAsync(HSA4FormDto form);
	Task<HSA4FormDto> GetFormByIdAsync(string id);
}
