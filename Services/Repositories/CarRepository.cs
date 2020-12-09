using DAL.Models;
using Services.Interfaces;
using DAL.Context;
using System.Collections.Generic;
using System.Linq;
using Services.JoinClasses;
using Services.JoinTables;

namespace Services.Repositories
{
    public class CarRepository : RepositoryBase<Car> ,ICarRepository
    {
        private readonly IJoinTables _joinTables;

        public CarRepository(ConstructionWasteDBContext context,IJoinTables joinTables) 
           : base(context)
        {
            _joinTables = joinTables;
        }

        public IEnumerable<Car> GetAllCar()
        {
            return Context.Cars;
        }

        public Car GetCar(int id)
        {
            return Context.Cars.Where(x => x.Id == id).FirstOrDefault();
        }

        public int AddId()
        {
            return Context.Cars.Max(x => x.Id) + 1;       
        }
    }
}
