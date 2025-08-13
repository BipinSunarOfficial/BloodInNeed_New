namespace BloodInNeed.UI.Models.ViewModels
{
    public class EditProfileViewModel
    {
        public IEnumerable<Country> CountryList { get; set; }
        public UserInfo UserInfo { get; set; }

        public IEnumerable<BloodGroups> bloodGroups { get; set; }
        public IEnumerable<Cities> Cities { get; set; }
    }
}
