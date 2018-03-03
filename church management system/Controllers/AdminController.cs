using church_management_system.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace church_management_system.Controllers
{

    public class AdminController : Controller
    {
        ChurchDbEntities1 db_obj = new ChurchDbEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //Addnew family view
        public ActionResult Addnewfamily()
        {
            return View("Addnewfamily");
        }

        [HttpPost]
        public ActionResult Addnewfamily(tbl_Reg tbl, FormCollection collection)
        {
            if (tbl.file.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(tbl.file.FileName);
                string extension = Path.GetExtension(tbl.file.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                tbl.Image = "~/App_file/images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/App_file/images/"), fileName);
                tbl.file.SaveAs(fileName);
            }
            var value = collection["Wardname"];
            var text = collection["hidText"];
            //  -----------            -----//
            //save values to table
            try
            {

                if (ModelState.IsValid)
                {
                   
                        db_obj.tbl_Reg.Add(new tbl_Reg()
                        {
                            WardName = text,
                            WardNumber = tbl.WardNumber,
                            FamilyName = tbl.FamilyName,
                            FamilyHead = tbl.FamilyHead,
                            H_father_name = tbl.H_father_name,
                            H_mother_name = tbl.H_mother_name,
                            H_wife_name = tbl.H_wife_name,
                            W_familyName = tbl.W_familyName,
                            W_place = tbl.W_place,
                            W_parish = tbl.W_parish,
                            Mob_nob = tbl.Mob_nob,
                            Landline = tbl.Landline,
                            City = tbl.City,
                            State = tbl.State,
                            Town = tbl.Town,
                            PO = tbl.PO,
                            Landmark = tbl.Landmark,
                            Prev_Parish = tbl.Prev_Parish,
                            Prev_Dioceses = tbl.Prev_Dioceses,
                            email = tbl.email,
                            Occupation = tbl.Occupation,
                            MonthlyIncome = tbl.MonthlyIncome,
                            Image = tbl.Image,
                            Time = DateTime.Now,
                        });

                        db_obj.SaveChanges();

                        return RedirectToAction("Addnewfamily");

                    
                }
                return View(tbl);
            }

            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public ActionResult Viewallfamily()
        {
                return View(db_obj.tbl_Reg.ToList());
           
        }
        //edit get
        //public ActionResult Editdetail(int? id)
        //{
        //    tbl_Reg tbl = db_obj.tbl_Reg.Find(id);
        //    var famid = db_obj.tbl_Reg.Where(x => x.FamilyNo == id).FirstOrDefault();

        //    if (tbl == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    if(famid!=null)
        //    {
        //        TempData["Familyid"] = id; //store family no into temp varia
        //        TempData.Keep();
        //        return View(famid);
        //    }
        //    return View(tbl);
        //}
        //[HttpPost]
        //public ActionResult Editdetail(tbl_Reg tbl, FormCollection collection)
        //{
        //    int famid = Convert.ToInt16(collection["FamilyNo"]);
        //    var familyno = db_obj.tbl_Reg.Where(x => x.FamilyNo == famid).FirstOrDefault();
        //    if (familyno != null)
        //    {

        //        var text = collection["hidText"];
        //        familyno.WardName = text;
        //        familyno.WardNumber = tbl.WardNumber;
        //        familyno.FamilyName = tbl.FamilyName;
        //        familyno.FamilyHead = tbl.FamilyHead;
        //        familyno.H_father_name = tbl.H_father_name;
        //        familyno.H_mother_name = tbl.H_mother_name;
        //        familyno.H_wife_name = tbl.H_wife_name;
        //        familyno.W_familyName = tbl.W_familyName;
        //        familyno.W_place = tbl.W_place;
        //        familyno.W_parish = tbl.W_parish;
        //        familyno.Mob_nob = tbl.Mob_nob;
        //        familyno.Landline = tbl.Landline;
        //        familyno.City = tbl.City;
        //        familyno.State = tbl.State;
        //        familyno.Town = tbl.Town;
        //        familyno.PO = tbl.PO;
        //        familyno.Landmark = tbl.Landmark;
        //        familyno.Prev_Parish = tbl.Prev_Parish;
        //        familyno.Prev_Dioceses = tbl.Prev_Dioceses;
        //        familyno.email = tbl.email;
        //        familyno.Occupation = tbl.Occupation;
        //        familyno.MonthlyIncome = tbl.MonthlyIncome;
        //        familyno.Image = tbl.Image;
        //        familyno.Time = DateTime.Now;
        //        //StudentData.IsActive = objStudnet.IsActive;
        //        db_obj.Entry(familyno).State = EntityState.Added;
        //        db_obj.SaveChanges();
        //    }
        //    //if (ModelState.IsValid)
        //    //{
        //    //    db_obj.Entry(tbl).State = EntityState.Added;
        //    //    db_obj.SaveChanges();
        //    //    return RedirectToAction("Viewallfamily");

        //    //}
        //    return RedirectToAction("Viewallfamily");
        //}
        public ActionResult Editdetail(int? id)
        {
            
                return View(db_obj.tbl_Reg.Find(id));
            
        }
        [HttpPost]
        public ActionResult Editdetail(tbl_Reg tbl)
        {
            
                db_obj.Entry(tbl).State = EntityState.Modified;
                db_obj.SaveChanges();
                return RedirectToAction("Viewallfamily");
            
        }
        public ActionResult MemberDetails(int id)
        {
            return View(db_obj.tbl_Reg.Where(x => x.FamilyNo == id).FirstOrDefault());
        }
        public ActionResult Deletedata(int ? id)
        {
           
                tbl_Reg tbl = db_obj.tbl_Reg.Find(id);
                if (tbl == null)
                {
                    return HttpNotFound();
                }
                return View(tbl);
           
        }
        [HttpPost, ActionName("Deletedata")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
                tbl_Reg tbl = db_obj.tbl_Reg.Find(id);
                db_obj.tbl_Reg.Remove(tbl);
                db_obj.SaveChanges();
                return RedirectToAction("Viewallfamily");
           
        }
        protected override void Dispose(bool disposing)
        {
            
                db_obj.Dispose();
                base.Dispose(disposing);
           
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
            
        }
        public ActionResult Resetpwd()
        {
            using (ChurchDbEntities dbobj = new ChurchDbEntities())
            {
                return View(dbobj.login_regtbl.ToList());
            }
            //login_regtbl logtbl = new login_regtbl();
            //return View(logtbl);
        }
    }
}