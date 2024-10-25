using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApi.Application.Errors
{
    public record ValidationError : ServiceError
    {
        public ValidationError(string errorMessage)
            : base(errorMessage, "001", nameof(ServiceErrorType.Validation))
        {
        }

        public ValidationError(List<ValidationFailure> errors)
            : this(string.Join("; \n", errors.Select(error => error.ErrorMessage)))
        {
        }
    }
}
