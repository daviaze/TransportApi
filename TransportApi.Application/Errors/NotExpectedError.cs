using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApi.Application.Errors
{
    public record NotExpectedError(string ErrorMessage) : ServiceError(ErrorMessage, "002",
        nameof(ServiceErrorType.NotExpected))
    {
    }
}
