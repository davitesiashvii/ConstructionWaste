using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class CarDriver
    {
        public int Id { get; set; }
        public string LegalId { get; set; }
        public int? CarId { get; set; }
        public string Fullname { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
