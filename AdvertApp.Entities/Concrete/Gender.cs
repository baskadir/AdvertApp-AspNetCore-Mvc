using AdvertApp.Entities.Abstract;
using System.Collections.Generic;

namespace AdvertApp.Entities.Concrete
{
    public class Gender : BaseEntity
    {
        public string Definition { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
