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

        public IActionResult DisplayPhoto()
        {
            // Create a Photo object and pass into View.
            Photo photo = new Photo();
            photo.Id = 1;
            photo.Title = "My cat Penny";
            photo.Description = "A picture of my cat named Penny.";
            photo.ImageFilename = "cat.jpg";
            photo.CreatedDate = DateTime.Now;

            // Pass the photo object into the view, so the view can display it
            return View(photo);
        }

        public IActionResult DisplayPhotosList()
        {
            // Create a Photo list object and pass into View.
            List<Photo> photosList = new List<Photo>();

            Photo photo1 = new Photo();
            photo1.Id = 1;
            photo1.Title = "My cat Penny";
            photo1.Description = "A picture of my cat named Penny.";
            photo1.ImageFilename = "cat.jpg";
            photo1.CreatedDate = DateTime.Now;

            Photo photo2 = new Photo();
            photo2.Id = 2;
            photo2.Title = "My dog Audrey";
            photo2.Description = "A picture of my dog named Audrey. She is a pug.";
            photo2.ImageFilename = "dog.jpg";
            photo2.CreatedDate = DateTime.Now;

            photosList.Add(photo1);
            photosList.Add(photo2);

            return View(photosList);
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
