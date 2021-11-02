using AdvertApp.Entities.Abstract;
using System.Collections.Generic;

namespace AdvertApp.Entities.Concrete
{
    public class MilitaryStatus : BaseEntity
    {
        public string Definition { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
