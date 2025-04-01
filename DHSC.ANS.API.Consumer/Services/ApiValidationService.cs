using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using DHSC.ANS.API.Consumer.Interfaces;
using DHSC.ANS.API.Consumer.Models;
using DHSC.ANS.API.Consumer.Utilities;
using FluentValidation;


namespace DHSC.ANS.API.Consumer.Services;

public class ApiValidationService<T> : IValidationService<T>
{
    private readonly IValidator<T> _fluentValidator;

    public ApiValidationService(IValidator<T> fluentValidator)
    {
        _fluentValidator = fluentValidator;
    }

    public ValidationOutcome Validate(T instance)
    {
        // DataAnnotations
        var context = new ValidationContext(instance);
        var annotationsResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
        bool isAnnotationsValid = Validator.TryValidateObject(instance, context, annotationsResults, true);

        // FluentValidation
        var fluentResult = _fluentValidator.Validate(instance);

        var outcome = new ValidationOutcome
        {
            IsValid = isAnnotationsValid && fluentResult.IsValid
        };

        // Merge DataAnnotations errors
        foreach (var error in annotationsResults)
        {
            var fieldNames = error.MemberNames.Any() ? error.MemberNames : new[] { "UnknownProperty" };
            foreach (var member in fieldNames)
            {
                if (!outcome.Errors.ContainsKey(member))
                {
                    outcome.Errors[member] = new[] { error.ErrorMessage };
                }
                else
                {
                    outcome.Errors[member] = outcome.Errors[member].Concat(new[] { error.ErrorMessage }).ToArray();
                }
            }
        }

        // Merge FluentValidation errors
        foreach (var error in fluentResult.Errors)
        {
            var member = string.IsNullOrWhiteSpace(error.PropertyName) ? "UnknownProperty" : error.PropertyName;
            if (!outcome.Errors.ContainsKey(member))
            {
                outcome.Errors[member] = new[] { error.ErrorMessage };
            }
            else
            {
                outcome.Errors[member] = outcome.Errors[member].Concat(new[] { error.ErrorMessage }).ToArray();
            }
        }

        // Append x-restrictions text if the property has a [RestrictionsAttribute]
        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in props)
        {
            if (outcome.Errors.ContainsKey(prop.Name))
            {
                var restrictions = prop.GetCustomAttribute<RestrictionsAttribute>();
                if (restrictions != null)
                {
                    // Append a new message like "Expected format: {restrictions.Text}"
                    var oldMessages = outcome.Errors[prop.Name];
                    var newMessages = oldMessages.Concat(new[]
                    {
                            $"Hint: {restrictions.Value}"
                        }).ToArray();

                    outcome.Errors[prop.Name] = newMessages;
                }
            }
        }

        return outcome;
    }
}