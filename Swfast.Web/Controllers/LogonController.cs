using Swfast.Web.Models;
using Swfast.Web.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Swfast.Web.Controllers
{
    public class LogonController : Controller
    {

        public virtual ActionResult Index()
        {
            return View(new LogonModel());
        }

        [HttpPost]
        public virtual ActionResult Index(LogonModel model)
        {
            Authenticate(model);
            return View(model);
        }


        protected virtual bool Authenticate(LogonModel model, bool redirect = true)
        {
            bool authenticated = FormsAuthentication.Authenticate(model.UserName, model.Password);

            if (!authenticated)
            {
                return false;
            }

            var user = new GenericIdentity(model.UserName);
            var principal = new SimpleConfigurationPrincipal(user);
            SimpleConfigurationPrincipal.SetAuthenticatedPrincipal(principal);

            if (redirect)
            {
                FormsAuthentication.RedirectFromLoginPage(model.UserName, false);
            }

            return true;
        }

        public virtual ActionResult Logoff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("Index");
        }
    }
}