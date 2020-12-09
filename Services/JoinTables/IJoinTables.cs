using Services.JoinClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.JoinTables
{
    public interface IJoinTables
    {
        public IEnumerable<ClientJ> ClientJoinClientTipe();

        public IEnumerable<CarJDriver> CarJoinDrivers();
       
    }
}
