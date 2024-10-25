using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApi.Application.Errors;
using TransportApi.Domain.Dtos;
using TransportApi.Domain.Entities;

namespace TransportApi.Application.Services.Interfaces
{
    public interface ITransportService
    {
        public Task<OneOf<List<Transport>, ServiceError>> GetAll();
        public Task<OneOf<Transport, ServiceError>> Post(TransportPostDTO transportDTO);
    }
}
