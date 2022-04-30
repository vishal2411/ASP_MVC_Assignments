using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assignment1.Models
{
    // Mapping of FootballLeague Table to Class with all its properties
    [Table("FootballLeague")]
    public class FootBallLeague
    {
        [Key]
        [Required]
        public int MatchId { get; set; }

        [Required]
        public string TeamName1 { get; set; }

        [Required]
        public string TeamName2 { get; set; }

        [Required]
        public string MatchStatus { get; set; }

        public string WinningTeam { get; set; }

        [Required]
        public int Points { get; set; }
    }
         
 }