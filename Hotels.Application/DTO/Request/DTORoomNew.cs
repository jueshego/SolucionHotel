using Hotels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hotels.Application.DTO.Request
{
    public class DTORoomNew
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; init; }

        [Required(ErrorMessage = "MaxGuests is required")]
        [Range(2, 10)]
        [Display(Name = "Max Guests")]
        public byte MaxGuests { get; init; }

        public Guid HotelId { get; init; }
    }
}
