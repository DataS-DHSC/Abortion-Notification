using DHSC.ANS.API.Consumer.DTOs;
using DHSC.ANS.API.Consumer.Interfaces;
using DHSC.ANS.API.Consumer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DHSC.ANS.API.Consumer.Services;

public class ValidationResponseService : IValidationResponseService
{
    public IActionResult CreateValidationErrorResponse(ValidationOutcome outcome)
    {
        var dto = new ValidationErrorResponse
        {
            Title = "Validation errors occurred.",
            Status = StatusCodes.Status400BadRequest,
            Detail = "Please review the 'Errors' property for a list of invalid fields."
        };

        // Convert from outcome.Errors (IDictionary<string, string[]>)
        dto.Errors = outcome.Errors.ToDictionary(e => e.Key, e => e.Value);

        return new BadRequestObjectResult(dto);
    }
}
