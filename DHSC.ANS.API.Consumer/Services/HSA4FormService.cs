using DHSC.ANS.API.Consumer.DTOs;
using DHSC.ANS.API.Consumer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DHSC.ANS.API.Consumer.Services;

public class HSA4FormService : IHSA4FormService
{
	private readonly Dictionary<string, HSA4FormDto> _formStorage = new(); // Temporary in-memory storage for demonstration

	public async Task<string> SubmitFormAsync(HSA4FormDto form)
	{
		var formId = Guid.NewGuid().ToString();
		_formStorage[formId] = form;
		return await Task.FromResult(formId);
	}

	public async Task<HSA4FormDto> GetFormByIdAsync(string id)
	{
		_formStorage.TryGetValue(id, out var form);
		return await Task.FromResult(form);
	}
}
