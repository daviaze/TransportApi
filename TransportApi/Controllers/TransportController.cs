using Microsoft.AspNetCore.Mvc;
using TransportApi.Application.Errors;
using TransportApi.Application.Services.Interfaces;
using TransportApi.Domain.Dtos;
using TransportApi.Domain.Entities;

namespace TransportApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _transportService;

        public TransportController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransports()
        {
            var result = await _transportService.GetAll();

            return result.Match<IActionResult>(
                (success) => Ok(success),
                failure => BadRequest(failure)
              );
        }

        [HttpPost]
        public async Task<IActionResult> PostTransport([FromBody] TransportPostDTO transportDTO)
        {
            var result = await _transportService.Post(transportDTO);

            return result.Match<IActionResult>(
                (success) =>
                {
                    var transport = success;
                    return Created($"/transport/{transport.Id}", transport);
                },
                failure => BadRequest(failure)
                );
            
        }
    }
}
