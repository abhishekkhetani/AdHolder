using AdHolder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdHolder.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Registration/

        public ActionResult RegisterIndex()
        {
            return View("Register");
        }

        public ActionResult LoginIndex()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult AddRegister(Register register)
        {
            ModelState.Remove("RegisterId");
            if (ModelState.IsValid)
            {
                register.isAdmin = true;
                Register existRegister;
                using (var ctx = new EFCodeFirstContext())
                {
                    existRegister = ctx.Register.Where(s => s.Email == register.Email).FirstOrDefault<Register>();
                }

                if (existRegister == null)
                {
                    using (var context = new EFCodeFirstContext())
                    {
                        context.Register.Add(register);
                        context.SaveChanges();
                    }
                }
                else
                {
                    return Json("exist", JsonRequestBehavior.AllowGet);
                }
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            return Json("error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {

                using (var ctx = new EFCodeFirstContext())
                {
                    var exist = ctx.Register.Where(s => s.Email == login.Email && s.Password == login.Password).FirstOrDefault();

                    if (exist != null)
                    {
                        if (exist.isAdmin)
                            return Json("success", JsonRequestBehavior.AllowGet);
                        else
                            return Json("notAdmin", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("notAuth", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json("error", JsonRequestBehavior.AllowGet);
        }
    }
}
