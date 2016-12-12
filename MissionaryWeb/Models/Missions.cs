using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionaryWeb.Models
{


    [Table("Missions")]
    public class Missions
    {
        [Key]
        [DisplayName("MissionID")]
        public int missionID { get; set; }


        [DisplayName("Mission Name")]
        public string missionName { get; set; }


        [DisplayName("President's Name")]
        public string presidentName { get; set; }


        [DisplayName("Mission Address")]
        public string address { get; set; }


        [DisplayName("Language")]
        public string language { get; set; }

        [DisplayName("Climate")]
        public string climate { get; set; }


        [DisplayName("Dominant Religion")]
        public string domReligion { get; set; }


        [DisplayName("Flag")]
        public string flag { get; set; }
    }
}