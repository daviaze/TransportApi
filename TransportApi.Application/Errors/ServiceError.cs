using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApi.Application.Errors
{
    public record ServiceError(string Description, string CodeError, string NameError)
    {

    }

    public enum ServiceErrorType
    {
        Validation,
        NotExpected,
    }
}
