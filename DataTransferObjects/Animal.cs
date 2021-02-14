using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace TamagotchiClient.DataTransferObjects
{
    public partial class AnimalDTO
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AnimalWeight { get; set; }
        public int Age { get; set; }
        public int Hunger { get; set; }
        public int Hygiene { get; set; }
        public int Happiness { get; set; }
        public int? PlayerId { get; set; }
        public int? LifeStageId { get; set; }
        public int? AnimalStatusId { get; set; }
        public override string ToString()
        {
            string date = this.DateOfBirth.ToString("d");
            return ($"Name: {this.AnimalName}\n" +
                $"Date of Birth: {date}\n" +
                $"Age: {this.Age}\n" +
                $"Weight: {this.AnimalWeight}\n\n" +
                $"-Stats-\n" +
                $"Happiness: {this.Happiness}\n" +
                $"Hygiene: {this.Hygiene}\n" +
                $"Hunger: {this.Hunger}");
        }

    }
}
