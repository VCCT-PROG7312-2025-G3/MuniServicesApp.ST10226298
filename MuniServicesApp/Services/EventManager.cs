using System;
using System.Collections.Generic;
using System.Linq;
using MuniServicesApp.Models;

namespace MuniServicesApp.Services
{
    /// <summary>
    /// Manages events using advanced data structures
    /// </summary>
    public class EventManager
    {
        private static EventManager _instance;
        private static readonly object _lock = new object();

        private int _nextId;
        
        // SortedDictionary for events organized by date
        private SortedDictionary<DateTime, List<Event>> _eventsByDate;
        
        // Dictionary with HashSet for events by category
        private Dictionary<string, HashSet<Event>> _eventsByCategory;
        
        // HashSet for unique categories
        private HashSet<string> _categories;
        
        // Queue for search history
        private Queue<string> _searchHistory;
        
        // Stack for recently viewed events
        private Stack<Event> _recentlyViewed;
        
        // Priority queue simulation using SortedSet
        private SortedSet<Event> _featuredEvents;

        private EventManager()
        {
            _nextId = 1;
            _eventsByDate = new SortedDictionary<DateTime, List<Event>>();
            _eventsByCategory = new Dictionary<string, HashSet<Event>>();
            _categories = new HashSet<string>();
            _searchHistory = new Queue<string>(20);
            _recentlyViewed = new Stack<Event>();
            _featuredEvents = new SortedSet<Event>(new EventPriorityComparer());
            
            InitializeSampleData();
        }

        public static EventManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new EventManager();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Adds a new event to all data structures
        /// </summary>
        public void AddEvent(Event evt)
        {
            evt.Id = _nextId++;
            
            // Add to sorted dictionary by date
            DateTime dateKey = evt.EventDate.Date;
            if (!_eventsByDate.ContainsKey(dateKey))
            {
                _eventsByDate[dateKey] = new List<Event>();
            }
            _eventsByDate[dateKey].Add(evt);
            
            // Add to category dictionary
            if (!_eventsByCategory.ContainsKey(evt.Category))
            {
                _eventsByCategory[evt.Category] = new HashSet<Event>();
            }
            _eventsByCategory[evt.Category].Add(evt);
            
            // Add category to set
            _categories.Add(evt.Category);
            
            // Add to featured events if applicable
            if (evt.IsFeatured)
            {
                _featuredEvents.Add(evt);
            }
        }

        /// <summary>
        /// Gets all events as a list
        /// </summary>
        public List<Event> GetAllEvents()
        {
            List<Event> allEvents = new List<Event>();
            foreach (var dateEvents in _eventsByDate.Values)
            {
                allEvents.AddRange(dateEvents);
            }
            return allEvents;
        }

        /// <summary>
        /// Gets events by category using hash-based lookup
        /// </summary>
        public List<Event> GetEventsByCategory(string category)
        {
            if (_eventsByCategory.ContainsKey(category))
            {
                return _eventsByCategory[category].ToList();
            }
            return new List<Event>();
        }

        /// <summary>
        /// Gets events by date range using sorted dictionary
        /// </summary>
        public List<Event> GetEventsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Event> events = new List<Event>();
            
            foreach (var kvp in _eventsByDate)
            {
                if (kvp.Key >= startDate.Date && kvp.Key <= endDate.Date)
                {
                    events.AddRange(kvp.Value);
                }
            }
            
            return events;
        }

        /// <summary>
        /// Gets all unique categories using HashSet
        /// </summary>
        public HashSet<string> GetAllCategories()
        {
            return new HashSet<string>(_categories);
        }

        /// <summary>
        /// Adds search term to history queue
        /// </summary>
        public void RecordSearch(string searchTerm)
        {
            if (_searchHistory.Count >= 20)
            {
                _searchHistory.Dequeue();
            }
            _searchHistory.Enqueue(searchTerm);
        }

        /// <summary>
        /// Gets recent search history
        /// </summary>
        public List<string> GetSearchHistory()
        {
            return _searchHistory.ToList();
        }

        /// <summary>
        /// Adds event to recently viewed stack
        /// </summary>
        public void AddToRecentlyViewed(Event evt)
        {
            if (_recentlyViewed.Count >= 10)
            {
                var tempStack = new Stack<Event>();
                for (int i = 0; i < 9; i++)
                {
                    tempStack.Push(_recentlyViewed.Pop());
                }
                _recentlyViewed.Clear();
                while (tempStack.Count > 0)
                {
                    _recentlyViewed.Push(tempStack.Pop());
                }
            }
            _recentlyViewed.Push(evt);
        }

        /// <summary>
        /// Gets recently viewed events from stack
        /// </summary>
        public List<Event> GetRecentlyViewed()
        {
            return _recentlyViewed.ToList();
        }

        /// <summary>
        /// Gets featured events using priority queue
        /// </summary>
        public List<Event> GetFeaturedEvents()
        {
            return _featuredEvents.ToList();
        }

        /// <summary>
        /// Searches events by keyword
        /// </summary>
        public List<Event> SearchEvents(string keyword)
        {
            RecordSearch(keyword);
            
            List<Event> results = new List<Event>();
            foreach (var evt in GetAllEvents())
            {
                if (evt.Title.ToLower().Contains(keyword.ToLower()) ||
                    evt.Description.ToLower().Contains(keyword.ToLower()) ||
                    evt.Category.ToLower().Contains(keyword.ToLower()))
                {
                    results.Add(evt);
                }
            }
            return results;
        }

        /// <summary>
        /// Gets recommended events based on search patterns
        /// </summary>
        public List<Event> GetRecommendedEvents()
        {
            Dictionary<string, int> categoryFrequency = new Dictionary<string, int>();
            
            // Analyze search history
            foreach (string search in _searchHistory)
            {
                foreach (string category in _categories)
                {
                    if (search.ToLower().Contains(category.ToLower()))
                    {
                        if (!categoryFrequency.ContainsKey(category))
                        {
                            categoryFrequency[category] = 0;
                        }
                        categoryFrequency[category]++;
                    }
                }
            }
            
            // Get events from most searched categories
            List<Event> recommended = new List<Event>();
            var topCategories = categoryFrequency.OrderByDescending(x => x.Value).Take(3);
            
            foreach (var cat in topCategories)
            {
                var categoryEvents = GetEventsByCategory(cat.Key);
                recommended.AddRange(categoryEvents.Take(3));
            }
            
            // If no recommendations from search, return featured events
            if (recommended.Count == 0)
            {
                recommended = GetFeaturedEvents().Take(5).ToList();
            }
            
            return recommended.Distinct().Take(10).ToList();
        }

        /// <summary>
        /// Initializes sample event data
        /// </summary>
        private void InitializeSampleData()
        {
            AddEvent(new Event
            {
                Title = "Community Clean-Up Day",
                Description = "Join us for a community clean-up initiative in the local park.",
                Category = "Community",
                EventDate = DateTime.Now.AddDays(5),
                Location = "Central Park",
                Organizer = "City Council",
                IsFeatured = true,
                Priority = 10
            });

            AddEvent(new Event
            {
                Title = "Water Maintenance Notice",
                Description = "Scheduled water maintenance in the northern suburbs.",
                Category = "Utilities",
                EventDate = DateTime.Now.AddDays(2),
                Location = "Northern Suburbs",
                Organizer = "Water Department",
                IsFeatured = true,
                Priority = 9
            });

            AddEvent(new Event
            {
                Title = "Town Hall Meeting",
                Description = "Monthly town hall meeting to discuss municipal matters.",
                Category = "Government",
                EventDate = DateTime.Now.AddDays(7),
                Location = "City Hall",
                Organizer = "Mayor's Office",
                IsFeatured = false,
                Priority = 5
            });

            AddEvent(new Event
            {
                Title = "Road Closure Alert",
                Description = "Main Street will be closed for repairs.",
                Category = "Infrastructure",
                EventDate = DateTime.Now.AddDays(1),
                Location = "Main Street",
                Organizer = "Public Works",
                IsFeatured = true,
                Priority = 8
            });

            AddEvent(new Event
            {
                Title = "Recycling Drive",
                Description = "Bring your recyclables to the community center.",
                Category = "Environment",
                EventDate = DateTime.Now.AddDays(10),
                Location = "Community Center",
                Organizer = "Environmental Services",
                IsFeatured = false,
                Priority = 3
            });

            AddEvent(new Event
            {
                Title = "Public Safety Workshop",
                Description = "Learn about emergency preparedness and safety.",
                Category = "Safety",
                EventDate = DateTime.Now.AddDays(14),
                Location = "Fire Station",
                Organizer = "Fire Department",
                IsFeatured = false,
                Priority = 6
            });

            AddEvent(new Event
            {
                Title = "Farmers Market",
                Description = "Weekly farmers market with local vendors.",
                Category = "Community",
                EventDate = DateTime.Now.AddDays(3),
                Location = "Market Square",
                Organizer = "Local Business Association",
                IsFeatured = true,
                Priority = 7
            });

            AddEvent(new Event
            {
                Title = "Library Book Sale",
                Description = "Annual book sale at the public library.",
                Category = "Culture",
                EventDate = DateTime.Now.AddDays(12),
                Location = "Public Library",
                Organizer = "Library Services",
                IsFeatured = false,
                Priority = 4
            });
        }
    }

    /// <summary>
    /// Comparer for priority queue implementation
    /// </summary>
    public class EventPriorityComparer : IComparer<Event>
    {
        public int Compare(Event x, Event y)
        {
            if (x == null || y == null) return 0;
            
            int priorityComparison = y.Priority.CompareTo(x.Priority);
            if (priorityComparison != 0)
                return priorityComparison;
            
            return x.Id.CompareTo(y.Id);
        }
    }
}
