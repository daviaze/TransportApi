using TransportApi.Domain.Entities;

namespace TransportApi.Domain.Dtos
{
    public sealed record TransportDTO(Guid Id,
     string Mode,
     TypeTransport TypeTransport,
     StatusTransport StatusTransport)
    { 

    }
}
