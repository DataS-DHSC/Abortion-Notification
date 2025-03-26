using DHSC.ANS.API.Consumer.DTOs;
using DHSC.ANS.API.Consumer.Enums;
using FluentValidation;

namespace DHSC.ANS.API.Consumer.Validators;

public class ComplicationsInfoValidator : AbstractValidator<ComplicationsInfoDto>
{
	public ComplicationsInfoValidator()
	{
		RuleFor(x => x.Complications).NotEmpty();
		RuleFor(x => x.OtherComplicationDetails)
			.NotEmpty().When(x => x.Complications != null && x.Complications.Contains(Complication.Other));
	}
}
