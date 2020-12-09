using DAL.Context;
using Services.JoinClasses;
using System.Collections.Generic;
using System.Linq;

namespace Services.JoinTables
{
    public class JoinTables : IJoinTables
    {
        public readonly ConstructionWasteDBContext context;

        public JoinTables(ConstructionWasteDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<CarJDriver> CarJoinDrivers()
        {
            IEnumerable<CarJDriver> carJDrivers = context.Cars.Join(context.CarDrivers, c => c.Id, d => d.CarId, (c, d) => new CarJDriver
            {
                Id = c.Id,
                Number = c.Number,
                CreatedAt = c.CreatedAt,
                MarkName = c.MarkName,
                Number1 = c.Number1,
                Number2 = c.Number2,
                DriverName = d.Fullname
            });

            return carJDrivers;
        }

        public IEnumerable<ClientJ> ClientJoinClientTipe()
        {

            IEnumerable<ClientJ> clieent = context.Clients.Join(context.ClientTypes, c => c.TypeId, t => t.Id, (c, t) => new ClientJ
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
                Address = c.Address,
                Representative = c.Representative,
                InsertTime = c.InsertTime,
                TypeName = t.Name
            });
            return clieent;

        }


    }
}
