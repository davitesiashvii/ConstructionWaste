using System;
using System.ComponentModel.DataAnnotations;


namespace ConstructionWaste.DTOs.Clients
{
    public class CreateClient
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string IdentityCode { get; set; }

        [Required]
        public string Representative { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime InsertTime { get; set; }
    }
}
