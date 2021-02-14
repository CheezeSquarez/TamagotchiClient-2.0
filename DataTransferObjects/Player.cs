using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TamagotchiClient.DataTransferObjects
{
    
    public partial class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string PWord { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ActiveAnimal { get; set; }
    }
}
