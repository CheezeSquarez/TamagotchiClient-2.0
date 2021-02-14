using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace TamagotchiClient.DataTransferObjects
{
    public partial class FunctionDTO
    { 
        public int FunctionId { get; set; }
        public string FunctionName { get; set; }
        public int HungerImpact { get; set; }
        public int HygieneImpact { get; set; }
        public int HappinessImpact { get; set; }
        public int? FunctionTypeId { get; set; }

    }
}
