# Municipal Services Application 

A user-friendly C# .NET Framework Windows Forms application for South African municipal services that lets citizens report issues and request services in a casual, engaging way.

## Features 

- **Main Menu**: Three service options with only "Report Issues" currently active
- **Report Issues Form**: Complete issue reporting with:
  - Location input field 
  - Category dropdown with fun emojis 
  - Rich text description box 
  - File attachment system (images, documents) 
  - Progress bar with encouraging messages 
  - Form validation and user feedback 

## Technical Stuff 

- **Framework**: .NET Framework 4.8
- **UI**: Windows Forms with Comic Sans MS font for a casual feel
- **Architecture**: 
  - Models: Issue data structure
  - Services: IssueManager singleton for data management
  - Forms: Main menu and Report Issues forms
- **Data Storage**: In-memory storage using List<Issue>
- **File Handling**: OpenFileDialog for multiple file attachments

## How to Compile and Run 

### Using Visual Studio 
1. Open `MuniServicesApp.sln` in Visual Studio
2. Make sure you have .NET Framework 4.8 installed
3. Press `F5` or click "Start" to build and run
4. The main menu will appear - click "Report Issues" to get started!

### Using Command Line 
```bash
# Navigate to the project directory
cd MuniServicesApp

# Build the project
msbuild MuniServicesApp.csproj

# Run the executable
bin\Debug\MuniServicesApp.exe
```

## How to Use the App 

### Main Menu
- Click "Report Issues" to report a problem
- Other options are disabled for now (coming soon!)

### Reporting Issues
1. **Location**: Tell us where the problem is
2. **Category**: Pick from options like:
   - Potholes & Road Issues 
   - Water Problems 
   - Electricity Issues 
   - Garbage Collection 
   
3. **Description**: Write all the details about the issue
4. **Attach Files**: Add photos or documents (optional)
5. **Submit**: Hit the big green button and watch the progress bar!

### File Attachments
- Click " Add Files" to attach images or documents
- Supports all file types (images, PDFs, Word docs, etc.)
- Select multiple files at once
- Remove files by selecting them and clicking " Remove"

## Project Structure 

```
MuniServicesApp/
├── Models/
│   └── Issue.cs                 # Issue data model
├── Services/
│   └── IssueManager.cs          # Singleton service for managing issues
├── Form1.cs/.Designer.cs        # Main menu form
├── ReportIssuesForm.cs/.Designer.cs  # Issue reporting form
├── Program.cs                   # Application entry point
└── App.config                   # Configuration file
```

## Requirements Met 

- Main menu with three options (Report Issues active, others disabled)
- Location input textbox
- Category selection dropdown
- Rich text description box
- File attachment with OpenFileDialog
- Submit button functionality
- User engagement features (progress bar, encouraging messages)
- Navigation buttons (Back to Main Menu)
- Consistent casual design with fun colors and emojis
- Form validation and user feedback
- Data structures for storing issues
- Event handling for all interactions




ST10226298
Kyle Pillay
