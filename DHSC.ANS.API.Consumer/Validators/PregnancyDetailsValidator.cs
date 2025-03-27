using DHSC.ANS.API.Consumer.DTOs;
using FluentValidation;

namespace DHSC.ANS.API.Consumer.Validators;

public class PregnancyDetailsValidator : AbstractValidator<PregnancyDetailsDto>
{
	public PregnancyDetailsValidator()
	{
		RuleFor(x => x.GestationWeeks).InclusiveBetween(4, 40);
		RuleFor(x => x.Grounds).NotEmpty();
		RuleFor(x => x.Grounds).Must(grounds => grounds.Any());
	}
}
