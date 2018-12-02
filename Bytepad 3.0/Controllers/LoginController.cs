using Bytepad_3._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Bytepad_3._0.Services;

namespace Bytepad_3._0.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _login = null;
        public LoginController(ILogin login)
        {
            _login = login;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                return RedirectToAction("Upload", "Addpapers");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(Login user)
        {
            ViewBag.ErrorMessage = null;
            if (_login.isValidCredentials(user))
            {
                var ticket = new FormsAuthenticationTicket("admin", true, 200);
                var encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = DateTime.Now.AddMinutes(200);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Upload", "Addpapers");
            }
            else
            {
                ViewBag.ErrorMessage = "Wrong Credentials";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}