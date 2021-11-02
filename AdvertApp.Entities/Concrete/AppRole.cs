using AdvertApp.Entities.Abstract;
using System.Collections.Generic;

namespace AdvertApp.Entities.Concrete
{
    public class AppRole : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
