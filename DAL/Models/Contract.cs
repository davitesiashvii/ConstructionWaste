using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Contract
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string IdentityCode { get; set; }
        public string Representative { get; set; }
        public string Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IsSpecific { get; set; }
        public int IsPaid { get; set; }
        public int TypeId { get; set; }
        public int? UserId { get; set; }
        public int PolygonTypeId { get; set; }
        public DateTime InsertTime { get; set; }
        public int DeletedFlag { get; set; }
    }
}
