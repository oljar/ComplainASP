using Complaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Complaint.Controllers
{
    public class HomeController : Controller
    {

        public readonly ComplaintEntities dbEntities = new ComplaintEntities();



        public ActionResult Index()
        {
            IEnumerable<Request> require = dbEntities.Requests;

            return View(require);
        }



        [HttpGet]
        public ActionResult AddComplaint()
        {
            Request require = new Request();

            return View(require);
        }



        [HttpPost]
        public ActionResult AddComplaint(Request request)
     
        {

            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            dbEntities.Requests.Add(request);
            dbEntities.SaveChanges();

            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult EditComplaint(int Id)
        {
            Request request = dbEntities.Requests.Find(Id);
            return View(request);

        }

        [HttpPost]

        public ActionResult EditComplaint(Request request)
        {

            Request existingrequest = dbEntities.Requests.Find(request.Id);


            existingrequest.Firm = request.Firm;
            existingrequest.Person= request.Person;
            existingrequest.Subject = request.Subject;
            dbEntities.SaveChanges();

            return RedirectToAction("Index");


        }




        public ActionResult DeleteComplaint(int Id)
        {
            Request request = dbEntities.Requests.Find(Id);
            dbEntities.Requests.Remove(request);
            dbEntities.SaveChanges();
            return RedirectToAction("Index");

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
    }
}