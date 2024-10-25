using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApi.Domain.Entities
{
    public abstract class Transport
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        public string? Model { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public TypeTransport TypeTransport {get; init;} = TypeTransport.Car;
        public StatusTransport StatusTransport { get; private set; } = StatusTransport.Active;

        protected Transport()
        {

        }

        public void Inactive()
        {
            StatusTransport = StatusTransport.Inactive;
        }
    }

    public enum TypeTransport
    {
        Car = 1,
        Airplane = 2
    }

    public enum StatusTransport
    {
        Active = 1,
        Inactive = 2
    }
}
