using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainsApp.Models.DB
{
    public class Train
    {
        [Key]
        public int Id { get; set; }
        public int TrainNumber { get; set; }
        public string Type { get; set; }
        public int WagonCount { get; set; }
    }
}