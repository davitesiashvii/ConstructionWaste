using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class ExecutionAct
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int DriverId { get; set; }
        public string Weight { get; set; }
        public string Price { get; set; }
        public int ContractId { get; set; }
        public string Receiver { get; set; }
        public string Representative { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DeletedFlag { get; set; }
        public int? ApprovedStatus { get; set; }
        public string ProjectCode { get; set; }
    }
}
