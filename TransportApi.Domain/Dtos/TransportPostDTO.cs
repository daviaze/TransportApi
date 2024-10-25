using TransportApi.Domain.Entities;

namespace TransportApi.Domain.Dtos
{
    public record TransportPostDTO(
     string Model,
     TypeTransport TypeTransport)
    {
    }
}
