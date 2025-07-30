using Azure.Core;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BloodInNeed.UI.Models
{
    public class HighlightDataCounts
    {
        public int RegisteredDonors { get; set; }
        public int BloodRequestsFulfilled { get; set; }
        public int ActiveDonors { get; set; }
    }


    public class StatByCountry
    {
        public string Flag { get; set; }
        public string Name { get; set; }
        public string Users { get; set; }
        public string Donors { get; set; }
        public string Requests { get; set; }
    }

}
