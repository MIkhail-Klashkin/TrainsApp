using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainsApp.Models.DB
{
    public class Timetable
    {
        [Key]
        public int Id { get; set; }
        public int TrainNumber { get; set; }
        public int Way { get; set; }
        public int Platform { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Type { get; set; }
        public int WagonCount { get; set; }

    }
}