using ADMS.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADMS.Controllers
{
    public class BaseController : Controller
    {
        public ApplicationUser CurrentUser { get; set; }

        public BaseController()
        {
            
        }

        protected ApplicationUser GetUserFromUserName(string username)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            return userManager.Users.FirstOrDefault(x => x.UserName == username);
        }
    }
}