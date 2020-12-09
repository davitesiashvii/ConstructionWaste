
using System.ComponentModel.DataAnnotations;


namespace ConstructionWaste.DTOs.Registration
{
    public class RegistrerUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        
    }
}
