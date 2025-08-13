using BloodInNeed.UI.Controllers;

namespace BloodInNeed.UI.Models
{
    public class BloodRequest
    {
        
        public int receipentId {get; set;}
        public string patientName {get; set;}
        public int bloodGroup {get; set;}
        public string bloodGroupSymbol {get; set;}
        public int requiredUnits {get; set;}
        public string urgencyLevel {get; set;}
        public string hospitalName {get; set;}
        public int bloodCity {get; set;}
        public DateTime dueDate {get; set;}
        public string contactNumber {get; set;}
        public string diagnosis {get; set;}
        public string notes {get; set;}
      

    }



    public class MyRequests
    {
        public int SN { get; set; }
        public int RequestId { get; set; }
        public int receipentId { get; set; }
        public string receipentName { get; set; }
        public string patientName { get; set; }
        public string bloodGroup { get; set; }
        public double requiredUnits { get; set; }
        public string urgencyLevel { get; set; }
        public string hospitalName { get; set; }
        public int bloodCity { get; set; }
        public string CityName { get; set; }
        public DateTime dueDate { get; set; }
        public string contactNumber { get; set; }
        public string diagnosis { get; set; }
        public string notes { get; set; }
        public string Status { get; set; }
        public DateTime RequestedOn { get; set; }
        public string AcceptedOn { get; set; }
        public DateTime CancelledOn { get; set; }
        public string Donor { get; set; }
        public string CancelledBy { get; set; }

        public string ReceipentContact { get; set; }
        public string DonorContact { get; set; }



    }

    public class ViewRequests
    {
        public int SN { get; set; }
        public int RequestId { get; set; }
        public string ReceipientName { get; set; }
        public string PatientName { get; set; }
        public string bloodGroup { get; set; }
        public double requiredUnits { get; set; }

        public string urgencyLevel { get; set; }
        public string hospitalName { get; set; }
        public int bloodCity { get; set; }
        public string CityName { get; set; }
        public DateTime dueDate { get; set; }
        public string contactNumber { get; set; }
        public string diagnosis { get; set; }
        public string notes { get; set; }
        public string Status { get; set; }
        public DateTime RequestedOn { get; set; }
        public DateTime AcceptedOn { get; set; }

        public int IsEligibleToDonate { get; set; }
        public string ReceipentContact { get; set; }
        public string DonorContact { get; set; }

    }


}
