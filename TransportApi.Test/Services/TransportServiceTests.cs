using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TransportApi.Application.Errors;
using TransportApi.Application.Services;
using TransportApi.Domain.Dtos;
using TransportApi.Domain.Entities;
using TransportApi.Domain.Validators;
using TransportApi.Infra.Context;

namespace TransportApi.Test.Services
{
    public class TransportServiceTests
    {
        //Faker for generate random names
        private readonly Faker _faker = new("pt_BR");
        private readonly TransportService _transportService;

        public TransportServiceTests()
        {
            //Using InMemory Database just for testes
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>();
            dbContextOptions.UseInMemoryDatabase("TransportsTestes");

            //DbContext not be mocked
            var dbContext = new AppDbContext(dbContextOptions.Options);
            var validator = new TransportValidator();

            _transportService = new (dbContext, validator);
        }

        [Fact]
        public async Task ShouldPostTransportAndReturnTransport()
        {
            //Arrage
            TransportPostDTO transportDTO = new(_faker.Vehicle.Model(), TypeTransport.Car);

            //Act
            var result = await _transportService.Post(transportDTO);

            //Assert
            result.IsT0.Should().BeTrue();
        }

        [Fact]
        public async Task ShouldPostTransportWithMustangModelAndReturnError()
        {
            //Arrage
            TransportPostDTO transportDTO = new("Mustang 66", TypeTransport.Car);

            //Act
            var result = await _transportService.Post(transportDTO);

            //Assert
            result.IsT1.Should().BeTrue();
            result.AsT1.Should().BeOfType<ValidationError>();
        }

        [Fact]
        public async Task ShouldPostTransportWithEmptyModelAndReturnError()
        {
            //Arrage
            TransportPostDTO transportDTO = new("", TypeTransport.Car);

            //Act
            var result = await _transportService.Post(transportDTO);

            //Assert
            result.IsT1.Should().BeTrue();
            result.AsT1.Should().BeOfType<ValidationError>();
        }
    }
}
