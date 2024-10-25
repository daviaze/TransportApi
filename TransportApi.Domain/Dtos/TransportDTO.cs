using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
