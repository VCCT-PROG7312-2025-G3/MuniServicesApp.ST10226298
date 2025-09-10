using System;
using System.Collections.Generic;

namespace MuniServicesApp.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<string> AttachedFiles { get; set; }
        public DateTime ReportedDate { get; set; }
        public string Status { get; set; }

        public Issue()
        {
            AttachedFiles = new List<string>();
            ReportedDate = DateTime.Now;
            Status = "Reported";
        }
    }
}
