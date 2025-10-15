# Municipal Services Application

A C# .NET Framework Windows Forms application for South African municipal services that enables citizens to report issues, view submitted reports, and access local events and announcements.

## Features

- **Main Menu**: Navigation hub with Report Issues, View Reports, and Local Events functionality
- **Report Issues**: Complete issue reporting system with:
  - Location input field
  - Category selection dropdown
  - Rich text description editor
  - File attachment system (images, documents)
  - Progress tracking and user feedback
  - Form validation
- **View Reports**: Comprehensive reporting dashboard with:
  - DataGridView displaying all submitted issues
  - Search and filter functionality
  - Category-based filtering
  - Dashboard statistics panel
  - Issue detail viewer
- **Local Events and Announcements**: Event discovery platform with:
  - Event browsing with ListView display
  - Search functionality across events
  - Category-based filtering
  - Date range filtering
  - Event detail panel
  - Personalized recommendations based on search patterns
  - Featured events highlighting

## Technical Architecture

- **Framework**: .NET Framework 4.8
- **UI**: Windows Forms
- **Architecture**: 
  - Models: Issue and Event data models
  - Services: IssueManager and EventManager singleton patterns
  - DataStructures: Custom doubly linked list implementation
  - Forms: Main menu, Report Issues, View Reports, and Local Events
- **Data Storage**: Custom linked list and advanced data structures for in-memory storage
- **File Handling**: OpenFileDialog for multiple file attachments

### Advanced Data Structures (Part 2)

The Local Events and Announcements feature utilizes multiple advanced data structures:

- **SortedDictionary<DateTime, List<Event>>**: Events organized chronologically by date for efficient date-based queries
- **Dictionary<string, HashSet<Event>>**: Category-based event indexing using hash tables for O(1) category lookups
- **HashSet<string>**: Unique category storage ensuring no duplicates
- **Queue<string>**: Search history tracking (FIFO) - maintains last 20 searches for recommendation analysis
- **Stack<Event>**: Recently viewed events (LIFO) - tracks last 10 viewed events
- **SortedSet<Event>**: Priority queue implementation for featured events using custom comparer

## How to Compile and Run

### Using Visual Studio (Recommended)
1. Open `MuniServicesApp.sln` in Visual Studio
2. Ensure .NET Framework 4.8 is installed
3. Press `F5` or click "Start" to build and run
4. The main menu will appear with available options

### Using MSBuild (Command Line)
```bash
# Navigate to the project directory
cd MuniServicesApp

# Build the project
msbuild MuniServicesApp.csproj

# Run the executable
bin\Debug\MuniServicesApp.exe
```

## Usage Guide

### Main Menu
- **Report Issues**: Opens the issue reporting form
- **View Reports**: Opens the reports dashboard
- **Local Events**: Opens the events and announcements browser
- **Service Request Status**: Disabled (future implementation)

### Reporting Issues
1. **Location**: Enter the location of the issue
2. **Category**: Select from predefined categories:
   - Potholes & Road Issues
   - Water Problems
   - Electricity Issues
   - Garbage Collection
   - Street Lights
   - Parks & Recreation
   - Noise Complaints
   - Other
3. **Description**: Provide detailed description in the rich text box
4. **Attach Files**: Optionally attach images or documents
5. **Submit**: Click submit to save the issue

### Viewing Reports
- **Search**: Filter reports by location
- **Category Filter**: Filter by issue category
- **Dashboard**: View statistics including total issues, category breakdown, and recent reports
- **View Details**: Double-click a row or use the button to see full issue details
- **Refresh**: Update the report list with latest data

### Local Events and Announcements
1. **Browse Events**: View all upcoming events in the list view
2. **Search**: Enter keywords to find specific events
3. **Filter by Category**: Select a category from the dropdown
4. **Filter by Date Range**: Choose start and end dates to filter events
5. **View Details**: Click on an event to see full details in the side panel
6. **Featured Events**: Click the "Featured Events" button to see priority announcements
7. **Recommendations**: View personalized event suggestions based on your search history
8. **Double-click**: Double-click any event for a detailed popup view

## Project Structure

```
MuniServicesApp/
├── DataStructures/
│   └── CustomLinkedList.cs      # Custom doubly linked list implementation
├── Models/
│   ├── Event.cs                 # Event data model
│   └── Issue.cs                 # Issue data model
├── Services/
│   ├── EventManager.cs          # Singleton service for managing events with advanced data structures
│   └── IssueManager.cs          # Singleton service for managing issues
├── Form1.cs/.Designer.cs        # Main menu form
├── LocalEventsForm.cs/.Designer.cs   # Local events and announcements form
├── ReportIssuesForm.cs/.Designer.cs  # Issue reporting form
├── ViewReportsForm.cs/.Designer.cs   # Reports dashboard form
├── Program.cs                   # Application entry point
└── App.config                   # Configuration file
```

## Custom Data Structure

The application implements a custom doubly linked list (`CustomLinkedList<T>`) for storing issues. This demonstrates:

- **Node-based structure**: Each node contains data and pointers to previous/next nodes
- **Generic implementation**: Works with any data type
- **Core operations**:
  - Add: O(1) - Adds item to end of list
  - Remove: O(n) - Removes first occurrence of item
  - Find: O(n) - Searches for item matching predicate
  - FindAll: O(n) - Returns all items matching predicate
  - GetAt: O(n) - Retrieves item at specific index
- **IEnumerable support**: Enables foreach iteration

This custom data structure replaces the standard `List<T>` to demonstrate understanding of data structure concepts and implementation.

## Requirements Implemented

### Part 1
- Main menu with multiple navigation options
- Location input textbox
- Category selection dropdown
- Rich text description box
- File attachment with OpenFileDialog (multi-select)
- Submit button functionality
- User engagement features (progress bar, encouraging messages)
- Navigation between forms
- Form validation and error handling
- Custom doubly linked list data structure for storing issues
- Event handling for all user interactions
- Search and filter functionality
- Dashboard with statistics
- Issue detail viewer

### Part 2
- Local Events and Announcements page with aesthetic display
- Search functionality for events based on categories and dates
- Advanced data structures implementation:
  - **Stacks, Queues, Priority Queues**: Recently viewed stack, search history queue, featured events priority queue
  - **Hash Tables, Dictionaries, Sorted Dictionaries**: Category indexing, date-based organization
  - **Sets**: Unique category management
- Recommendation feature based on user search patterns:
  - Search pattern analysis using queue data structure
  - Category frequency tracking
  - Personalized event suggestions
  - User-friendly recommendation panel

## Recommendation Algorithm

The recommendation system analyzes user behavior through:

1. **Search History Tracking**: Queue stores last 20 searches
2. **Pattern Analysis**: Identifies frequently searched categories
3. **Frequency Scoring**: Counts category mentions in search history
4. **Event Selection**: Retrieves events from top 3 most-searched categories
5. **Fallback Strategy**: Shows featured events if no search history exists
6. **Presentation**: Displays up to 10 recommended events in dedicated panel

## Future Enhancements

- Service Request Status tracking (Part 3)
- Persistent database storage
- Email notifications
- Report export functionality
- Advanced analytics and reporting
- User accounts and authentication
