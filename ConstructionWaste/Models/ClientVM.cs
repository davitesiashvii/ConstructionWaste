using ConstructionWaste.DTOs.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionWaste.Models
{
    public class ClientVM
    {
       // public IEnumerable<ClientsDTO> Clients { get; set; }
       public ClientTypeDTO ClientType { get; set; }

        public IEnumerable<ClientTypeDTO> ClientTypeList { get; set; }

        public CreateClient Client { get; set; }


    }
}
