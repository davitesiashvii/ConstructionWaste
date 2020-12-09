using DAL.Models;
using Services.JoinClasses;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        IEnumerable<Car> GetAllCar();
        Car GetCar(int id); 
        int AddId();
    }
}
