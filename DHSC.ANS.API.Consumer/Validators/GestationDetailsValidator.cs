using DHSC.ANS.API.Consumer.DTOs;
using FluentValidation;

namespace DHSC.ANS.API.Consumer.Validators;

public class GestationDetailsValidator : AbstractValidator<GestationDetails>
{
	public GestationDetailsValidator()
	{
		RuleFor(x => x.GestationWeeks).InclusiveBetween(4, 40);
	}
}
