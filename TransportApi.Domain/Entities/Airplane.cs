﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApi.Domain.Dtos;

namespace TransportApi.Domain.Entities
{
    public sealed class Airplane : Transport
    {
        public static class Factories
        {
            public static Airplane Create(TransportPostDTO transportDTO)
            {
                return new Airplane()
                {
                    Model = transportDTO.Model,
                    TypeTransport = TypeTransport.Airplane
                };
            }
        }
    }
}