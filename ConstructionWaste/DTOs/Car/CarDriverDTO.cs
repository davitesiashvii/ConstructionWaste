using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionWaste.DTOs.Car
{
    public class CarDriverDTO
    {
        public int Id { get; set; }

        public string LegalId { get; set; }

        public int? CarId { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
