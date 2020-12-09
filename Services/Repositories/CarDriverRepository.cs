using DAL.Models;
using Services.Interfaces;
using DAL.Context;
using System.Collections.Generic;
using System.Linq;

namespace Services.Repositories
{
    public class CarDriverRepository : RepositoryBase<CarDriver>, ICarDriverRepository
    {
        public CarDriverRepository(ConstructionWasteDBContext context) : base(context) { }

        public IEnumerable<CarDriver> GetAllCarDriver()
        {
            return Context.CarDrivers;
        }

        public CarDriver GetCarDriver(int id)
        {
            return Context.CarDrivers.Find(id);
        }

        public CarDriver GetCarDriverByCar(int id)
        {
            return Context.CarDrivers.Where(x => x.CarId == id).FirstOrDefault();
        }

        public int AddId()
        {
            return Context.CarDrivers.Max(x => x.Id) + 1;
        }
    }
}
