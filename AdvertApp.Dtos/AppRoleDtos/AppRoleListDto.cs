using AdvertApp.Dtos.Interfaces;
using System;

namespace AdvertApp.Dtos.AppRoleDtos
{
    public class AppRoleListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
