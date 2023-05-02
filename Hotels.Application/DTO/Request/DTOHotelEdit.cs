using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.DTO.Request
{
    public class DTOHotelEdit
    {
        public Guid Id { get; set; }

        public string Name { get; init; }

        public byte Stars { get; init; }

        public string Address { get; init; }

        public string PhoneNumber { get; init; }
    }
}
