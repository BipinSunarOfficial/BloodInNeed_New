namespace BloodInNeed.UI.Models
{
    public class BloodGroups
    {
        public int Bid { get; set; }
        public string BloodGroup { get; set; }
        public string BGType { get; set; }
        public string Symbol { get; set; }
        public string CanGiveToGroups { get; set; }
        public string CanReceiveFromGroups { get; set; }
        public bool IsActive { get; set; }
    }
}
