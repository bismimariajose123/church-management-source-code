using church_management_system.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace church_management_system.Controllers
{
    public class HomeController : Controller
    {
        ChurchDbEntities dbobj = new ChurchDbEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            login_regtbl tbl = new login_regtbl();
            return View(tbl);

           
        }
        [HttpPost]
        public ActionResult Login(login_regtbl tbl)
        {

             using (ChurchDbEntities dbobj = new ChurchDbEntities())
                {
                    var log= dbobj.login_regtbl.Where(x => x.username.Equals(tbl.username) && x.password.Equals(tbl.password)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["username"] =log.username;
                        ViewBag.login = "successfully logged";
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.login = " login faled";
                    }
                    
            }
           
            //ViewBag.message = "registration successful";
            return View();
        }
        public ActionResult Savedata()
        {
            login_regtbl tbl = new login_regtbl();
            return View(tbl);
        }
        [HttpPost]

        public ActionResult Savedata(login_regtbl tbl)
        {
             if (ModelState.IsValid)
                {
                    using (ChurchDbEntities dbobj = new ChurchDbEntities())
                    {
                    if(dbobj.login_regtbl.Any(x=>x.username==tbl.username))
                        {
                        ViewBag.duplicate = "user alresdy exists";
                        return View("Savedata",tbl);
                        }
                        
                        dbobj.login_regtbl.Add(tbl);
                        dbobj.SaveChanges();
                      
                    }
               
                }
            ModelState.Clear();
            ViewBag.message = "registration successful";
            return View("Savedata");
        }
    }
}