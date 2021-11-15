namespace AdvertApp.UI.Models
{
    public class UserPasswordUpdateModel
    {
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
