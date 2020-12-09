using DAL.Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICarDriverRepository : IRepositoryBase<CarDriver>
    {
        IEnumerable<CarDriver> GetAllCarDriver();
        CarDriver GetCarDriver(int id);
        CarDriver GetCarDriverByCar(int id);
        int AddId();
    }
}
