using AdvertApp.Common.ResponseObjects;
using FluentValidation.Results;
using System.Collections.Generic;

namespace AdvertApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static IEnumerable<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                });
            }
            return errors;
        }
    }
}
