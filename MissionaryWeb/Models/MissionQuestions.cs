using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionaryWeb.Models
{
    [Table("MissionQuestions")]
    public class MissionQuestions
    {
        [Key]
        [DisplayName("Question ID")]
        public int missionQuestionID { get; set; }


        [DisplayName("MissionID")]
        public int missionID { get; set; }


        [DisplayName("UserID")]
        public int userID { get; set; }


        [DisplayName("Question")]
        public string question { get; set; }


        [DisplayName("Answer")]
        public string answer { get; set; }


        public object missionName { get; set; }
    }
}