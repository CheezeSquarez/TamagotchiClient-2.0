using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TamagotchiClient.DataTransferObjects
{
    public partial class HistoryDTO
    {
        public DateTime FunctionTime { get; set; }
        public int AnimalWeight { get; set; }
        public int Age { get; set; }
        public int Hunger { get; set; }
        public int Hygiene { get; set; }
        public int Happiness { get; set; }
        public int AnimalId { get; set; }
        public int? FunctionId { get; set; }
        public int? LifeStageId { get; set; }
        public int? AnimalStatusId { get; set; }
    }
}
