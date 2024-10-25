

namespace TransportApi.Application.Errors
{
    public record NotExpectedError(string ErrorMessage) : ServiceError(ErrorMessage, "002",
        nameof(ServiceErrorType.NotExpected))
    {
    }
}
