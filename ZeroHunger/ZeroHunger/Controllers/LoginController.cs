using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult NGO()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Ngo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new ZeroHungerEntities())
                    {
                        // Check if the username and password match a record in the 'Ngo' table
                        var user = db.Ngoes.FirstOrDefault(u => u.username == model.username && u.password == model.password);

                        if (user != null)
                        {
                            // Authentication successful, you can store user details in a session or cookie
                            // and redirect to the home page or wherever you need
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Invalid username or password.";
                            return View("NGO");
                        }
                    }
                }

                // Model state is not valid, return to the view with validation errors
                return View("NGO", model);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                ViewBag.ErrorMessage = "An error occurred while processing the login.";
                return View("Error");
            }
        }
    }
}


  


