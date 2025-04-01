using FluentValidation;
using DHSC.ANS.API.Consumer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DHSC.ANS.API.Consumer.Validators;

public class HSA4FormValidator : AbstractValidator<HSA4Form>
{
    public HSA4FormValidator()
    {
        // Validate Practitioner only if it's not null
        When(x => x.Practitioner != null, () =>
        {
            RuleFor(x => x.Practitioner).SetValidator(new PractitionerInfoValidator());
        });

        // Same for Certification
        When(x => x.Certification != null, () =>
        {
            RuleFor(x => x.Certification).SetValidator(new CertificationInfoValidator());
        });

        // ... repeat for other sections
        When(x => x.Patient != null, () =>
        {
            RuleFor(x => x.Patient).SetValidator(new PatientDetailsValidator());
        });

        When(x => x.Treatment != null, () =>
        {
            RuleFor(x => x.Treatment).SetValidator(new TreatmentDetailsValidator());
        });

        When(x => x.Gestation != null, () =>
        {
            RuleFor(x => x.Gestation).SetValidator(new GestationDetailsValidator());
        });

        When(x => x.TerminationGroundsDto != null, () =>
        {
            RuleFor(x => x.TerminationGroundsDto).SetValidator(new TerminationGroundsValidator());
        });

        // If you want to ensure that at *least one* section is present, you could also add an additional custom rule:
        RuleFor(x => x)
            .Must(form =>
                form.Practitioner != null ||
                form.Certification != null ||
                form.Patient != null ||
                form.Treatment != null ||
                form.Gestation != null ||
                form.TerminationGroundsDto != null ||
                form.SelectiveTermination != null ||
                form.ChlamydiaScreening != null ||
                form.Complications != null ||
                form.MaternalDeath != null
            )
            .WithMessage("At least one section must be provided for a partial submission.");

        // If you want a fully blank partial submission to be valid, remove the above rule.
    }
}
