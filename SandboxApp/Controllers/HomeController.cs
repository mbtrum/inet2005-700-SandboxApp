using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SandboxApp.Models;

namespace SandboxApp.Controllers
{
    public class HomeController : Controller
    {
        // Constructor
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            // system automatically looks in View/Home/ for Index.cshtml
            return View();
        }

        public IActionResult Privacy()
        {
            // we can spell out the view to return
            return View("Privacy");
        }

        public ViewResult HelloWorld()
        {
            // we can return any view
            return View("Privacy");
        }

        public ContentResult PlainText()
        {
            return Content("Hello, this is plain text!");
        }

        public RedirectResult GoodbyeWorld()
        {
            return Redirect("https://nscc.ca");
        }
        public UnauthorizedResult SecureWebpage()
        {
            return new UnauthorizedResult();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void Test()
        {

        }
    }
}
