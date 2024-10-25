using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OneOf;

using TransportApi.Application.Errors;
using TransportApi.Application.Services.Interfaces;
using TransportApi.Domain.Dtos;
using TransportApi.Domain.Entities;
using TransportApi.Infra.Context;

namespace TransportApi.Application.Services
{
    internal class TransportService : ITransportService
    {
        private readonly AppDbContext _context;
        private readonly IValidator<TransportPostDTO> _validator;

        public TransportService(AppDbContext contexto, IValidator<TransportPostDTO> validator)
        {
            _context = contexto;
            _validator = validator;
        }

        public async Task<OneOf<List<Transport>, ServiceError>> GetAll()
        {
            try
            {
                IEnumerable<Transport> transports = await _context.Transports.ToListAsync();

                foreach(var t in transports)
                {
                    if (t is Airplane)
                        Console.WriteLine($"The {t.Model} is a airplane!");                 
                    else
                        Console.WriteLine($"The {t.Model} is a car!");
                }

                return transports.ToList();
            }catch(Exception ex)
            {
                return new NotExpectedError(ex.Message);
            }
        }

        public async Task<OneOf<Transport, ServiceError>> Post(TransportPostDTO transportDTO)
        {
            try
            {
                var validate = _validator.Validate(transportDTO);
                if (!validate.IsValid)
                    return new ValidationError(validate.Errors);

                Transport? transport;

                if (transportDTO.TypeTransport == TypeTransport.Airplane)
                    transport = Airplane.Factories.Create(transportDTO);
                else
                    transport = Car.Factories.Create(transportDTO);

                _context.Transports.Add(transport);
                await _context.SaveChangesAsync();

                return transport;
            }
            catch (Exception ex)
            {
                return new NotExpectedError(ex.Message);
            }
        }
    }
}
