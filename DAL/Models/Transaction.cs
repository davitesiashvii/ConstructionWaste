using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public string IdentityCode { get; set; }
        public string TransactionId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string PayId { get; set; }
        public DateTime InsertTime { get; set; }
        public int Executed { get; set; }
    }
}
