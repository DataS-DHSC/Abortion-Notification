using DHSC.ANS.API.Consumer.DTOs;
using FluentValidation;

namespace DHSC.ANS.API.Consumer.Validators;

public class PatientDetailsValidator : AbstractValidator<PatientDetailsDto>
{
	public PatientDetailsValidator()
	{
		RuleFor(x => x.DateOfBirth).NotEmpty();
		RuleFor(x => x.EthnicGroup).IsInEnum();
		RuleFor(x => x.MaritalStatus).IsInEnum();
		RuleFor(x => x.CountryOfResidence).NotEmpty();
		RuleFor(x => x.PreviousLiveBirthsOver24Weeks).GreaterThanOrEqualTo(0);
		RuleFor(x => x.PreviousMiscarriages).GreaterThanOrEqualTo(0);
		RuleFor(x => x.PreviousTerminations).GreaterThanOrEqualTo(0);
	}
}
