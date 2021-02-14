using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace TamagotchiClient.DataTransferObjects
{
   
    public partial class LifeStageDTO
    {
        public int StageId { get; set; }
        public string Stage { get; set; }
        public int StageDuration { get; set; }
    }
}
