namespace BloodInNeed.UI.Models
{
    public class Country
    {
        public int Cid { get; set; }

        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string NiceName { get; set; }
        public string ISO3 { get; set; }
        public int NumCode { get; set; }
        public int PhoneCode { get; set; }
    }


    public class Cities
    {
        public int CityId { get; set; }
        public string City { get; set; }
        public string City_ASCII { get; set; }
        public string Country { get; set; }
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }

    }

}
