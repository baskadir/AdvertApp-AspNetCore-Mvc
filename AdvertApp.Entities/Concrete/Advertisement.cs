using AdvertApp.Entities.Abstract;
using System.Collections.Generic;

namespace AdvertApp.Entities.Concrete
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
