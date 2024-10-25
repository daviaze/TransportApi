using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApi.Domain.Entities;

namespace TransportApi.Domain.Dtos
{
    public record TransportPostDTO(
     string Model,
     TypeTransport TypeTransport)
    {
    }
}
