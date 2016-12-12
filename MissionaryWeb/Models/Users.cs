using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionaryWeb.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [DisplayName("UserID")]
        public int userID { get; set; }


        [DisplayName("Email")]
        public string userEmail { get; set; }


        [DisplayName("Password")]
        public string password { get; set; }


        [DisplayName("First Name")]
        public string firstName { get; set; }


        [DisplayName("Last Name")]
        public string lastName { get; set; }

    }
}