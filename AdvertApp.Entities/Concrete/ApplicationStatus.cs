using AdvertApp.Entities.Abstract;
using System.Collections.Generic;

namespace AdvertApp.Entities.Concrete
{
    public class ApplicationStatus : BaseEntity
    {
        public string Definition { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
