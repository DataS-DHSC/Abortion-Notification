using Microsoft.AspNetCore.Mvc;
using DHSC.ANS.API.Consumer.DTOs;
using DHSC.ANS.API.Consumer.Services;
using DHSC.ANS.API.Consumer.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using FluentValidation;
using FVValidationResult = FluentValidation.Results.ValidationResult;
using DHSC.ANS.API.Consumer.Models; // Alias to avoid conflicts

namespace DHSC.ANS.API.Consumer.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HSA4FormController : ControllerBase
	{
        private readonly IValidationService<HSA4Form> _validationService;
        private readonly IValidationResponseService _validationResponseService;
        private readonly IHSA4FormService _hsa4FormService;

        public HSA4FormController(
            IValidationService<HSA4Form> validationService,
            IValidationResponseService validationResponseService,
            IHSA4FormService hsa4FormService)
        {
            _validationService = validationService;
            _validationResponseService = validationResponseService;
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
		[SwaggerResponse(201, "Form successfully submitted.", typeof(Hsa4FormSubmissionResponse))]
        [SwaggerResponse(400, "Validation failed.", typeof(ValidationErrorResponse))]
        [Produces("application/json")]
		public async Task<IActionResult> SubmitHsa4Form([FromBody] HSA4Form form)
		{
            var outcome = _validationService.Validate(form);

            if (!outcome.IsValid)
            {
                return _validationResponseService.CreateValidationErrorResponse(outcome);
            }

            var newId = await _hsa4FormService.SubmitFormAsync(form);
            return CreatedAtAction(nameof(SubmitHsa4Form), new { id = newId }, form);
        }

        /// <summary>
        /// Retrieves the existing HSA4 form by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the form.</param>
        /// <returns>The HSA4 form if found.</returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Form retrieved successfully.", typeof(Hsa4FormSubmissionResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Form not found.")]
        public async Task<IActionResult> GetHsa4Form(string id)
        {
            var existingForm = await _hsa4FormService.GetFormByIdAsync(id);
            if (existingForm == null)
            {
                return NotFound();
            }

            // Build HATOAS response with the form data
            var response = new Hsa4FormSubmissionResponse
            {
                Id = id,
                Message = "Form retrieved successfully.",
                // This is the new part: embed the actual form data so the user can see it
                FormData = existingForm
            };

            // Add self/update links
            response.Links.Add(new Link
            {
                Rel = "self",
                Href = Url.Action(nameof(GetHsa4Form), new { id = id }),
                Method = "GET"
            });
            response.Links.Add(new Link
            {
                Rel = "update",
                Href = Url.Action(nameof(UpdateHsa4Form), new { id = id }),
                Method = "PUT"
            });

            return Ok(response);
        }

        /// <summary>
        /// Updates an existing HSA4 abortion notification form.
        /// </summary>
        /// <remarks>
        /// This endpoint accepts a JSON payload representing the updated form.  
        /// Only the sections provided will be validated; sections omitted remain unchanged.
        /// </remarks>
        /// <param name="id">The unique identifier of the form being updated.</param>
        /// <param name="form">The partial or full HSA4 form data.</param>
        /// <returns>A 200 OK with updated resource links or 400/404 as applicable.</returns>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Form successfully updated.", typeof(Hsa4FormSubmissionResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation failed.", typeof(ValidationErrorResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Form not found.")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateHsa4Form(string id, [FromBody] HSA4Form form)
        {
            // Check if the form with this ID exists
            var existingForm = await _hsa4FormService.GetFormByIdAsync(id);
            if (existingForm == null)
            {
                return NotFound();
            }

            // Merge existing data with partial update as you wish:
            // If you want to allow partial updates: 
            // For each property in 'form' that is non-null,
            // update the existingForm property. 
            // Or if you want a standard PUT (full replacement), skip merging and just do a direct replacement.

            existingForm = await _hsa4FormService.MergeFormsAsync(existingForm, form);

            // Validate using your combined validation approach
            var outcome = _validationService.Validate(existingForm);
            if (!outcome.IsValid)
            {
                return _validationResponseService.CreateValidationErrorResponse(outcome);
            }

            // Persist the updated form
            existingForm = await _hsa4FormService.UpdateFormAsync(id, existingForm);

            // 5. Build a success response with HATOAS links
            var response = new Hsa4FormSubmissionResponse
            {
                Id = id,
                Message = "Form updated successfully."
            };
            response.Links.Add(new Link
            {
                Rel = "self",
                Href = Url.Action(nameof(GetHsa4Form), new { id = id }),
                Method = "GET"
            });
            response.Links.Add(new Link
            {
                Rel = "update",
                Href = Url.Action(nameof(UpdateHsa4Form), new { id = id }),
                Method = "PUT"
            });

            // 6. Return 200 OK with the response
            return Ok(response);
        }

        /// <summary>
        /// Deletes an existing HSA4 abortion notification form by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the form to delete.</param>
        /// <returns>No content if deleted successfully; NotFound if the form does not exist.</returns>
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Form successfully deleted.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Form not found.")]
        public async Task<IActionResult> DeleteHsa4Form(string id)
        {
            var existingForm = await _hsa4FormService.GetFormByIdAsync(id);
            if (existingForm == null)
            {
                return NotFound();
            }

            await _hsa4FormService.DeleteFormByIdAsync(id);
            return NoContent();
        }
    }
}
