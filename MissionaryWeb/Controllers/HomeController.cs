using MissionaryWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MissionaryWeb.Controllers
{
    public class HomeController : Controller
    {
        NewMissionSiteContext db = new NewMissionSiteContext(); 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //created login action methods---------------------------------------------------------------------------------------
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MissionaryWeb.Models.Users account, FormCollection form, int? id, bool rememberMe = false)
        {
            Session["mission"] = id;
            //Session["userID"] = userid;

            using (NewMissionSiteContext db = new NewMissionSiteContext())
            {
                //var usr = db.user.Single(u => u.userEmail = account.userEmail && u.uPassword == account.uPassword).FirstOrDefault;
                var usr = db.User.Where(u => u.userEmail == account.userEmail && u.password == account.password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.userid.ToString();
                    Session["username"] = usr.userEmail.ToString();
                    FormsAuthentication.SetAuthCookie(usr.userEmail, rememberMe);
                    return RedirectToAction("SelectMission", "Home", new { id = Session["mission"], userid = Session["UserID"] });
                    // return RedirectToAction("Index", "MissionQuestions", new { id = Session["mission"] });

                }
                else
                {
                    ModelState.AddModelError(" ", "Username or password is wrong. ");
                    // return RedirectToAction("Index");
                }


            }
            return View();


        }


        //created register action methods------------------------------------------------------------------------------------
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(MissionaryWeb.Models.Users account, bool rememberMe = false) //account is the name of the Users object (Users is the model that we're dealing with) 
        {
            if (ModelState.IsValid)//this checks if all the fields that are required are filled 
            {
                db.User.Add(account);
                db.SaveChanges();

                ModelState.Clear();
                Session["UserID"] = account.userid;
                Session["username"] = account.userEmail;
                FormsAuthentication.SetAuthCookie(account.userEmail.ToString(), rememberMe);

                return RedirectToAction("SelectMission");

            }
            return View();

        }

        [Authorize]
        public ActionResult SelectMission()
        {
            return View(); 
        }
    }
}