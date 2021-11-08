using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace AdvertApp.UI.Models
{
    public class UserCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string School { get; set; }
        public string City { get; set; }
        public int GenderId { get; set; }
        public SelectList Genders { get; set; }
    }
}
