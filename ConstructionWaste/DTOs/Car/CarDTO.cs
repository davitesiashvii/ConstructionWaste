using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionWaste.DTOs.Car
{
    public class CarDTO
    {
        
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public double? Capacity { get; set; }

        public string MarkName { get; set; }
        [Required]
        public string Number1 { get; set; }
        [Required]
        public string Number2 { get; set; }
    }
}
