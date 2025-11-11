using System;
using System.Collections.Generic;

namespace MuniServicesApp.Models
{
    public class ServiceRequest : IComparable<ServiceRequest>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string AssignedDepartment { get; set; }
        public List<int> Dependencies { get; set; }
        public double EstimatedCost { get; set; }
        public int EstimatedDays { get; set; }

        public ServiceRequest()
        {
            RequestDate = DateTime.Now;
            Status = "Pending";
            Priority = 5;
            Dependencies = new List<int>();
            EstimatedCost = 0;
            EstimatedDays = 0;
        }

        public int CompareTo(ServiceRequest other)
        {
            if (other == null) return 1;
            
            int priorityComparison = other.Priority.CompareTo(this.Priority);
            if (priorityComparison != 0)
                return priorityComparison;
            
            return this.RequestDate.CompareTo(other.RequestDate);
        }

        public override bool Equals(object obj)
        {
            if (obj is ServiceRequest other)
            {
                return Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"SR-{Id}: {Title} [{Status}] (Priority: {Priority})";
        }
    }
}
