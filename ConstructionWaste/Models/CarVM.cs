using ConstructionWaste.DTOs.Car;
using System.Collections.Generic;

namespace ConstructionWaste.Models
{
    public class CarVM
    {
        public CarDTO Car { get; set; }
        public CarDriverDTO CarDriver { get; set; }
        //public IEnumerable<CarDTO> Cars { get; }
        //public IEnumerable<CarDriverDTO> CarDrivers { get; }

    }
}
