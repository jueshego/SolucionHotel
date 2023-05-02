using Hotels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.DTO.Response
{
    public class DTORoomGet
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public byte MaxGuests { get; init; }

        public Guid HotelId { get; init; }

        public DTOHotelGet Hotel { get; set; }
    }
}
