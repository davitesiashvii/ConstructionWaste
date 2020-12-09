using System;

#nullable disable

namespace DAL.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string IdentityCode { get; set; }
        public string Representative { get; set; }
        public string Address { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
