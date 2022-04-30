using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Assignment2.Models
{

    [Table("BusInformation")]
    public class BusInformation
    {
        [Required]
        [Key]
        public int BusID { get; set; } 

        [Required]
        public string BoardingPoint { get; set; }

        [Required]
        public DateTime TravelDate { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string DroppingPoint { get; set; }
    }
}