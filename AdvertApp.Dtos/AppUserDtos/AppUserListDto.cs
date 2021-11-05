using AdvertApp.Dtos.Interfaces;
using System;

namespace AdvertApp.Dtos
{
    public class AppUserListDto : IDto
    {
        public int Id { get; set; }
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
        public GenderListDto Gender { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
