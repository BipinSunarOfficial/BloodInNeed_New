using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodInNeed.Data.Models
{
    public class SeekerUsers
    {
        public required string Name { get; set; }
    }

    public class DonorUsers
    {
        public required string FirstName { get; set; }
        public  string MiddleName { get; set; }
        public  string LastName { get; set; }
        public  string UserName { get; set; }
        public  string EmailAddress { get; set; }
        public  string ContactNumber { get; set; }
        public  string LoginPassword { get; set; }
        public  int CountryId { get; set; }
        public  int IsActive { get; set; }
        public  int IsDeleted { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedDevice { get; set; }
        public string CreatedIp { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedOn { get; set; }
        public string DeletedReason { get; set; }
        public int IsDonor { get; set; }
        public int IsSeeker { get; set; }

    }
}
