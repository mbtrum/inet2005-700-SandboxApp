using Microsoft.AspNetCore.Mvc;
using SandboxApp.Models;

namespace SandboxApp.Controllers
{
    public class FormsController : Controller
    {
        
        // GET request
        public IActionResult ContactForm()
        {
            return View();
        }

        //
        // Example 1
        //

        // POST request
        //[HttpPost]
        //public IActionResult ContactForm(string FirstName, string LastName)
        //{
        //    string message = $"Welcome to my web app {FirstName} {LastName}!";

        //    // Pass message into the view
        //    ViewData["Message"] = message;

        //    return View();
        //}

        //
        // Example 2
        //

        //[HttpPost]
        //public IActionResult ContactForm(Person person)
        //{
        //    string message = $"Welcome to my web app {person.FirstName} {person.LastName}!";

        //    // Pass message into the view
        //    ViewData["Message"] = message;

        //    return View();
        //}

        //
        // Example 3
        //

        [HttpPost]
        public IActionResult ContactForm([Bind("FirstName,LastName")] Person person) // Bind[] helps prevent overposting attacks
        {
            string message = $"Welcome to my web app {person.FirstName} {person.LastName}!";

            // Pass message into the view
            ViewData["Message"] = message;

            return View();
        }

    }
}
