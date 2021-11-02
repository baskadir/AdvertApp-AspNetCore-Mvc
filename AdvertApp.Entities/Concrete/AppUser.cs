using AdvertApp.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace AdvertApp.Entities.Concrete
{
    public class AppUser : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string School { get; set; }
        public string City { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public ICollection<AppUserRole> AppUserRoles { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
