using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApi.Domain.Dtos;

namespace TransportApi.Domain.Entities
{
    public sealed class Car : Transport
    {
        public static class Factories
        {
            public static Car Create(TransportPostDTO transportDTO)
            {
                return new Car()
                {
                    Model = transportDTO.Model,
                };
            }
        }
    }
}
