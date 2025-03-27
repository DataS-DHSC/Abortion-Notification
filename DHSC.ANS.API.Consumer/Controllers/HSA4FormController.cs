using Microsoft.AspNetCore.Mvc;
using DHSC.ANS.API.Consumer.DTOs;
using DHSC.ANS.API.Consumer.Services;
using DHSC.ANS.API.Consumer.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using FluentValidation;
using FVValidationResult = FluentValidation.Results.ValidationResult; // Alias to avoid conflicts

namespace DHSC.ANS.API.Consumer.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HSA4FormController : ControllerBase
	{
		private readonly IValidator<HSA4FormDto> _validator;
		private readonly IHSA4FormService _hsa4FormService;

		public HSA4FormController(IValidator<HSA4FormDto> validator, IHSA4FormService hsa4FormService)
		{
			_validator = validator;
			_hsa4FormService = hsa4FormService;
		}

		/// <summary>
		/// Submit a new HSA4 abortion notification form.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This endpoint accepts a JSON payload representing the HSA4 form. All required fields as per the Abortion Act 1967 notification requirements must be provided.
		/// </para>
		/// <para>
		/// Refer to the guidance document: [Guidance note for completing HSA4 paper forms](https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms) for detailed information on how to complete the form correctly.
		/// </para>
		/// </remarks>
		/// <seealso href="https://www.gov.uk/government/publications/abortion-notification-forms-for-england-and-wales/guidance-notes-for-completing-hsa4-paper-forms#introduction"/>
		[HttpPost]
		[SwaggerResponse(201, "Form successfully submitted.")]
		[SwaggerResponse(400, "Validation failed.")]
		[Produces("application/json")]
		public async Task<ActionResult> SubmitHsa4Form([FromBody] HSA4FormDto form)
		{
			// Use the FluentValidation type explicitly (aliased as FVValidationResult)
			FVValidationResult validationResult = _validator.Validate(form);

			if (!validationResult.IsValid)
			{
				var errors = validationResult.Errors
					.Select(x => new { Field = x.PropertyName, Error = x.ErrorMessage });
				return BadRequest(new { Message = "Validation failed", Errors = errors });
			}

			var newId = await _hsa4FormService.SubmitFormAsync(form);

			return null;
		}
	}
}
