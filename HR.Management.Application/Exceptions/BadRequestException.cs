using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base()
        {
        }
        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            foreach (var error in validationResult.Errors)
            {
                if (ValidationErrors.ContainsKey(error.PropertyName))
                {
                    ValidationErrors[error.PropertyName].Add(error.ErrorMessage);
                }
                else
                {
                    ValidationErrors[error.PropertyName] = new List<string> { error.ErrorMessage };
                }
            }
        }
        public IDictionary<string, List<string>> ValidationErrors { get; set; } = new Dictionary<string, List<string>>();
    }
}
