using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Domain.Entities
{
    public class Hotel
    {
        public Hotel()
        {
            Id = Guid.NewGuid();
            Rooms = new HashSet<Room>(); 
        }

        public Guid Id { get; init; }

        public string Name { get; set; }

        public byte Stars { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Room> Rooms { get;}
    }
}
