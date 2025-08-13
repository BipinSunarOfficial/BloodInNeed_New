namespace BloodInNeed.UI.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DonorSeeker { get; set; }
        public DateTime DOB { get; set; }
        public string Occupation { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }


        public int Country { get; set; }

        public int City { get; set; }
        public string Contact { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }



        public int BloodGroup { get; set; }
        public int DonatedBefore { get; set; }

        public int DonationCount { get; set; }

        public DateTime DonationDateRecent { get; set; }
        public string Inspiration { get; set; }


    }
}
