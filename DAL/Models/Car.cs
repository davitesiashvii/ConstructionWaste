using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedAt { get; set; }
        public double? Capacity { get; set; }
        public string MarkName { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
    }
}
