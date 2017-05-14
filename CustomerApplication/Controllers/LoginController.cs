using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity.Validation;
using CustomerApplication.DataContexts.Admin;
using CustomerApplication.Models.Admin;

namespace CustomerApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Authenticate()
        {
            return View("Login");
        }

        public ActionResult Validate(User user)
        {
            List<User> users = null;
            if (ModelState.IsValid)
            {
                AdminDataContext adminContext = new AdminDataContext();
                 users = (from item in adminContext.Users
                          where (item.UserName.ToUpper() == user.UserName.ToUpper()) && (item.Password == user.Password)
                                    select item).ToList<User>();
            }
            if (users.Any() && users.Count == 1)
            {
                FormsAuthentication.SetAuthCookie("CustomerApp", true);
                return View("HomeView");
            }
            else
            {
                return View("Login");
            }
        }
    }
}