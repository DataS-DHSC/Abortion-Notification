using DHSC.ANS.API.Consumer.DTOs;
using FluentValidation;

namespace DHSC.ANS.API.Consumer.Validators;

public class MaternalDeathInfoValidator : AbstractValidator<MaternalDeathInfoDto>
{
	public MaternalDeathInfoValidator()
	{
		RuleFor(x => x.DateOfDeath).NotEmpty().When(x => x.MaternalDeathOccurred);
		RuleFor(x => x.CauseOfDeath).NotEmpty().When(x => x.MaternalDeathOccurred);
	}
}
