﻿using DHSC.ANS.API.Consumer.DTOs;
using FluentValidation;

namespace DHSC.ANS.API.Consumer.Validators;

public class ChlamydiaInfoValidator : AbstractValidator<ChlamydiaInfo>
{
	public ChlamydiaInfoValidator()
	{
		RuleFor(x => x.ScreeningOffered).NotNull();
	}
}
