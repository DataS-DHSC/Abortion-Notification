using DHSC.ANS.API.Consumer.DTOs;
using DHSC.ANS.API.Consumer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DHSC.ANS.API.Consumer.Interfaces;

public interface IValidationResponseService
{
    IActionResult CreateValidationErrorResponse(ValidationOutcome outcome);
}
