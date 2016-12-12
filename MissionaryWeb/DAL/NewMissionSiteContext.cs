using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MissionaryWeb.Models;
using System.Data.Entity;

namespace MissionaryWeb.DAL
{
    public class NewMissionSiteContext: DbContext
    {
        public NewMissionSiteContext(): base("NewMissionSiteContext")
        {

        }

        public DbSet<MissionQuestions> MissionQuestion { get; set; }
        public DbSet<Missions> Mission { get; set; }
        public DbSet<Users> User { get; set; }
    }
}