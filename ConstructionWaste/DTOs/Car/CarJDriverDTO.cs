using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionWaste.DTOs.Car
{
    public class CarJDriverDTO
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime CreatedAt { get; set; }

        public double? Capacity { get; set; }

        public string MarkName { get; set; }

        public string Number1 { get; set; }

        public string Number2 { get; set; }

        public string DriverName { get; set; }
    }
}
