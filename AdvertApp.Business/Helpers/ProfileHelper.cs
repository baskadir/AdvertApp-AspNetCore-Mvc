using AdvertApp.Business.Mappings.AutoMapper;
using AutoMapper;
using System.Collections.Generic;

namespace AdvertApp.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new()
            {
                new AboutProfile(),
                new AdvertisementProfile(),
                new ApplicationProfile(),
                new ApplicationStatusProfile(),
                new AppRoleProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new MilitaryStatusProfile()
            };
        }
    }
}
