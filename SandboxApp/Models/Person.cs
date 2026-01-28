using System.ComponentModel.DataAnnotations;

namespace SandboxApp.Models
{
    public class Person
    {
        // unique ID
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
    }
}
