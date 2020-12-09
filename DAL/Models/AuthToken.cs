using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class AuthToken
    {
        public int Id { get; set; }
        public string Val { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
