using TransportApi.Domain.Entities;

namespace TransportApi.Domain.Dtos
{
    public record TransportDTO(Guid Id,
     string Mode,
     TypeTransport TypeTransport,
     StatusTransport StatusTransport)
    { 

    }
}
