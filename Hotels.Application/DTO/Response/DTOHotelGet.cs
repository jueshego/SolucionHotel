using Hotels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.DTO.Response
{
    public class DTOHotelGet
    {
        [Key]
        public Guid Id { get; init; }

        [Display(Name = "Name")]
        public string Name { get; init; }

        [Display(Name = "Stars")]
        public byte Stars { get; init; }

        [Display(Name = "Address")]
        public string Address { get; init; }

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; init; }
    }
}
