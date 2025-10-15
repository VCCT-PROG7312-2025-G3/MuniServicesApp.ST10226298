using System;

namespace MuniServicesApp.Models
{
    /// <summary>
    /// Represents a local event or announcement
    /// </summary>
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        public bool IsFeatured { get; set; }
        public int Priority { get; set; }

        public Event()
        {
            IsFeatured = false;
            Priority = 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is Event other)
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
            return $"{Title} - {EventDate:d} ({Category})";
        }
    }
}
