using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MissionaryWeb.Models;
using MissionaryWeb.DAL;

namespace MissionaryWeb.Controllers
{
    public class MissionsController : Controller
    {
        private NewMissionSiteContext db = new NewMissionSiteContext();

        // GET: Missions
        
        [Authorize]
        public ActionResult Index()
        {
            var listof = db.Mission.ToList();
            ViewBag.ListMissions = listof;
            return View();
        }
        
        public ActionResult MissionFAQ()
        {
            return View();
        }

        // GET: Missions/Details/5
        [Authorize]
        public ActionResult MissionFAQ(int? id)
        {
            Missions currentMission = db.Mission.Find(id);//the parameter received will be the id used to search in the mission table

            if (currentMission == null)
            {
                return HttpNotFound();
            }
            else
            {
                var currentMissionQuestions = db.MissionQuestion.Where(question => question.missionID == id);//the var currentMissionQuestions will store all the questions that belong to the missionID

                ViewBag.currentQuestions = currentMissionQuestions.ToList();//this viewbag will store the list of questions of missionID  
            }

            return View(currentMission);
        }

        public ActionResult currentMission()
        {
            return View(); 
        }

        // GET: Missions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Missions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult CreateQuestion([Bind(Include = "missionQuestionID,question,answer,missionID,userID")] MissionQuestions newQuestion, FormCollection form)
        {


            if (newQuestion != null)
            {
                string question = form["CreateQuestion"].ToString();
                var userEmail = User.Identity.Name;//this line of code will look at current user and find it's name
                var userObj = db.User.Where(m => m.userEmail == userEmail).FirstOrDefault();//After the user is found then will store it's object into the the userObj

                newQuestion.question = question;// now the  object question will be the form question
                newQuestion.answer = " ";
                newQuestion.userID = userObj.userID;//assigning a useriD to the newly created question
                db.MissionQuestion.Add(newQuestion);//addint the newQuestion object to the MissionQuestion table
                db.SaveChanges();// Saving new changes

                return RedirectToAction("MissionFAQ", "Missions", new { id = newQuestion.missionID });

            }

            return View(newQuestion);
        }

        // GET: Missions/Edit/5
        public ActionResult Edit(int? id, MissionQuestions missionQuestion)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestion.Find(id);


            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestion);
        }

        // POST: Missions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "missionQuestionID,missionID,userID,question,answer")] MissionQuestions missionQuestions, int? id)
        {
            if (missionQuestions != null)
            {

                var update = db.MissionQuestion.Find(id);//create a variable that is storing the question that it founds in the db

                update.answer = missionQuestions.answer;

                missionQuestions = update;

                db.Entry(missionQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MissionFAQ", "Missions", new { id = missionQuestions.missionQuestionID });
            }
            return View(missionQuestions);
        }

    
    }
}
