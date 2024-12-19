using TransportApi.Domain.Entities;

namespace TransportApi.Domain.Dtos
{
    public sealed record TransportPostDTO(
     string Model,
     TypeTransport TypeTransport)
    {
    }
}
