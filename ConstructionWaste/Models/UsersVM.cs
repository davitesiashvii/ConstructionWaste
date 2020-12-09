using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionWaste.Models
{
    public class UsersVM
    {
        public IEnumerable<AppUser> Users { get; set; }
    }
}
