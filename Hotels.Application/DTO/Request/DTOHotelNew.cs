using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hotels.Application.DTO.Request
{
    public class DTOHotelNew
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Stars is required")]
        [Range(1, 5)]
        [Display(Name = "Stars")]
        public byte Stars { get; init; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; init; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; init; }
    }
}
