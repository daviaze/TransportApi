using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OneOf.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApi.Application.Errors;

namespace TransportApi.Exceptions
{
    internal sealed class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var result = exception switch
            {
                KeyNotFoundException => new ServiceError("Key not found", "404", "KNF"),
                DbUpdateException => new ServiceError("Database update error", "400", "DBUE"),
                _ => new ServiceError("Internal server error", "500", "ISE")
            };

            httpContext.Response.StatusCode = int.Parse(result.CodeError);
            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);

            return true;
        }
    }
}
