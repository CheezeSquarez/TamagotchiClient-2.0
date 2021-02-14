using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace TamagotchiClient.DataTransferObjects
{
    
    public partial class AnimalStatusDTO
    {
        
        public int StatusId { get; set; }
        
        public string AnimalStatus1 { get; set; }
    }
}
