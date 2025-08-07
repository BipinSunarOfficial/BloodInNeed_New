namespace BloodInNeed.UI.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class VerifyEmail
    {
        public string Email { get; set; }

        public int Code { get; set; }
    }

}
