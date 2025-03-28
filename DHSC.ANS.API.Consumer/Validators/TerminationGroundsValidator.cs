using DHSC.ANS.API.Consumer.DTOs;
using FluentValidation;

namespace DHSC.ANS.API.Consumer.Validators;

public class TerminationGroundsValidator : AbstractValidator<TerminationGroundsDto>
{
    public TerminationGroundsValidator()
    {
        RuleFor(x => x.Grounds).NotEmpty();
        RuleFor(x => x.Grounds).Must(grounds => grounds.Any());
    }
}
