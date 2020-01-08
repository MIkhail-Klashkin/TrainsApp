using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainsApp.Models.ViewModel
{
    public class TimetableViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Номер поезда")]
        [Range(0,4095)]
        public int TrainNumber { get; set; }
        [Display(Name = "Путь")]
        public int Way { get; set; }
        [Display(Name = "Платформа")]
        public int Platform { get; set; }
        [Display(Name = "Назначение/отбытие")]
        public string Destination { get; set; }
        [Display(Name = "Время прибытия")]
        public DateTime DepartureTime { get; set; }
        [Display(Name = "Вреия отправления")]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "Тип поезда")]
        public string Type { get; set; }
        [Display(Name = "Количество вагонов")]
        [Range(0, 20)]
        public int WagonCount { get; set; }
    }
}