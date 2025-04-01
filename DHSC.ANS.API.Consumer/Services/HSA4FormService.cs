using DHSC.ANS.API.Consumer.DTOs;
using DHSC.ANS.API.Consumer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DHSC.ANS.API.Consumer.Services;

public class HSA4FormService : IHSA4FormService
{
	private readonly Dictionary<string, HSA4Form> _formStorage = new(); // Temporary in-memory storage for demonstration

	public async Task<string> SubmitFormAsync(HSA4Form form)
	{
		var formId = Guid.NewGuid().ToString();
		_formStorage[formId] = form;
		return await Task.FromResult(formId);
	}

	public async Task<HSA4Form> GetFormByIdAsync(string id)
	{
		_formStorage.TryGetValue(id, out var form);
		return await Task.FromResult(form);
	}

    public Task<HSA4Form> UpdateFormAsync(string id, HSA4Form form)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteFormByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<HSA4Form> MergeFormsAsync(HSA4Form formA, HSA4Form formB)
    {
        throw new NotImplementedException();
    }
}
