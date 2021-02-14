using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TamagotchiClient.DataTransferObjects
{
    
    public partial class FunctionsTypeDTO
    {
        
        public int FunctionTypeId { get; set; }
        public string FunctionType { get; set; }
    }
}
