using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Domain.Entities
{
    public class Room
    {
        public Room()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; init; }

        public string Name { get; set; }

        public byte MaxGuests { get; set; }

        public Guid HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}
