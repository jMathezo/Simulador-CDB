﻿using FluentValidation.Results;

namespace SimuladorCDB.WebAPI.Models.Error
{
    public static class ValidationFailureExtension
    {
        public static IList<CustomValidationFailure> ToCustomValidationFailure(this IList<ValidationFailure> failures)
        {
            return failures.Select(f => new CustomValidationFailure(f.PropertyName, f.ErrorMessage)).ToList();
        }
    }
}
