using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exceptions.User;
using Microsoft.AspNetCore.Mvc;
using WedstrijdSysteem.Models;
using Logic;
using Microsoft.AspNetCore.Http;

namespace WedstrijdSysteem.Controllers
{
    public class UserController : Controller
    {
        private UserCollection UserCollection { get; } = new UserCollection();
        private User User { get; } = new User();

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.Session.SetString("username", string.Empty);
            HttpContext.Session.SetInt32("userid", 0);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignInViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                User auth = UserCollection.SignIn(user.Username, user.Password);
                HttpContext.Session.SetInt32("userid", auth.Id);
                HttpContext.Session.SetString("username", auth.Username);
                return RedirectToAction("Index", "Home");
            }
            catch (AuthenticationFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                UserCollection.SignUp(user.Username, user.Password, user.Email);
                return SignIn();
            }
            catch (SignUpFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        //UPDATE
        [HttpPost]
        public IActionResult UpdateName(SetNameViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                User.SetName(user.Username);
                return RedirectToAction("Info", "User");
            }
            catch (SetFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdatePassword(SetPasswordViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                User.SetPassword(user.Password);
                return RedirectToAction("Info", "User");
            }
            catch (SetFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdateEmail(SetEmailViewModel user)
        {
            if (!ModelState.IsValid)
            {
                 return View();
            }

            try
            {
                User.SetEmail(user.Email);
                return RedirectToAction("Info", "User");
            }
            catch (SetFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
