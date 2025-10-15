using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MuniServicesApp.Models;
using MuniServicesApp.Services;

namespace MuniServicesApp
{
    public partial class LocalEventsForm : Form
    {
        private List<Event> currentEvents;

        public LocalEventsForm()
        {
            InitializeComponent();
            LoadCategories();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(1);
            LoadAllEvents();
            LoadRecommendations();
            LoadRecentlyViewed();
        }

        /// <summary>
        /// Loads all categories into the filter dropdown
        /// </summary>
        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");
            
            foreach (string category in EventManager.Instance.GetAllCategories())
            {
                cmbCategory.Items.Add(category);
            }
            
            cmbCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads all events into the list view
        /// </summary>
        private void LoadAllEvents()
        {
            currentEvents = EventManager.Instance.GetAllEvents();
            DisplayEvents(currentEvents);
            UpdateEventCount();
        }

        /// <summary>
        /// Displays events in the list view
        /// </summary>
        private void DisplayEvents(List<Event> events)
        {
            lstEvents.Items.Clear();
            
            foreach (Event evt in events.OrderBy(e => e.EventDate))
            {
                ListViewItem item = new ListViewItem(evt.Title);
                item.SubItems.Add(evt.Category);
                item.SubItems.Add(evt.EventDate.ToString("dd MMM yyyy"));
                item.SubItems.Add(evt.Location);
                item.Tag = evt;
                
                if (evt.IsFeatured)
                {
                    item.BackColor = Color.LightYellow;
                    item.Font = new Font(item.Font, FontStyle.Bold);
                }
                
                lstEvents.Items.Add(item);
            }
        }

        /// <summary>
        /// Updates the event count label
        /// </summary>
        private void UpdateEventCount()
        {
            lblEventCount.Text = $"Showing {currentEvents.Count} event(s)";
        }

        /// <summary>
        /// Loads recommended events
        /// </summary>
        private void LoadRecommendations()
        {
            lstRecommendations.Items.Clear();
            List<Event> recommended = EventManager.Instance.GetRecommendedEvents();
            
            foreach (Event evt in recommended)
            {
                lstRecommendations.Items.Add($"⭐ {evt.Title} - {evt.EventDate:dd MMM}");
            }
            
            if (recommended.Count == 0)
            {
                lstRecommendations.Items.Add("Search for events to get personalized recommendations!");
            }
        }

        /// <summary>
        /// Loads recently viewed events
        /// </summary>
        private void LoadRecentlyViewed()
        {
            lstRecentlyViewed.Items.Clear();
            List<Event> recentlyViewed = EventManager.Instance.GetRecentlyViewed();
            
            foreach (Event evt in recentlyViewed)
            {
                lstRecentlyViewed.Items.Add($"🕒 {evt.Title} - {evt.EventDate:dd MMM}");
            }
            
            if (recentlyViewed.Count == 0)
            {
                lstRecentlyViewed.Items.Add("No recently viewed events");
            }
        }

        /// <summary>
        /// Handles search button click
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadAllEvents();
                return;
            }
            
            currentEvents = EventManager.Instance.SearchEvents(searchTerm);
            DisplayEvents(currentEvents);
            UpdateEventCount();
            LoadRecommendations();
        }

        /// <summary>
        /// Handles category filter change
        /// </summary>
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == 0)
            {
                LoadAllEvents();
            }
            else
            {
                string category = cmbCategory.SelectedItem.ToString();
                currentEvents = EventManager.Instance.GetEventsByCategory(category);
                DisplayEvents(currentEvents);
                UpdateEventCount();
                EventManager.Instance.RecordSearch(category);
                LoadRecommendations();
            }
        }

        /// <summary>
        /// Handles date range filter
        /// </summary>
        private void btnFilterByDate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;
                
                if (startDate > endDate)
                {
                    MessageBox.Show("Start date must be before end date!", "Invalid Date Range",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                currentEvents = EventManager.Instance.GetEventsByDateRange(startDate, endDate);
                DisplayEvents(currentEvents);
                UpdateEventCount();
                
                string searchTerm = $"Events from {startDate:dd MMM} to {endDate:dd MMM}";
                EventManager.Instance.RecordSearch(searchTerm);
                LoadRecommendations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering by date: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles clear filters button
        /// </summary>
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(1);
            LoadAllEvents();
        }

        /// <summary>
        /// Handles event selection to show details
        /// </summary>
        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedItems.Count > 0)
            {
                Event selectedEvent = (Event)lstEvents.SelectedItems[0].Tag;
                ShowEventDetails(selectedEvent);
                EventManager.Instance.AddToRecentlyViewed(selectedEvent);
                LoadRecentlyViewed();
            }
        }

        /// <summary>
        /// Displays event details
        /// </summary>
        private void ShowEventDetails(Event evt)
        {
            lblDetailTitle.Text = evt.Title;
            lblDetailCategory.Text = $"Category: {evt.Category}";
            lblDetailDate.Text = $"Date: {evt.EventDate:dddd, dd MMMM yyyy}";
            lblDetailLocation.Text = $"Location: {evt.Location}";
            lblDetailOrganizer.Text = $"Organizer: {evt.Organizer}";
            txtDetailDescription.Text = evt.Description;
            
            if (evt.IsFeatured)
            {
                lblFeatured.Visible = true;
            }
            else
            {
                lblFeatured.Visible = false;
            }
        }

        /// <summary>
        /// Shows featured events
        /// </summary>
        private void btnShowFeatured_Click(object sender, EventArgs e)
        {
            currentEvents = EventManager.Instance.GetFeaturedEvents();
            DisplayEvents(currentEvents);
            UpdateEventCount();
        }

        /// <summary>
        /// Returns to main menu
        /// </summary>
        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }

        /// <summary>
        /// Handles double-click to show full details
        /// </summary>
        private void lstEvents_DoubleClick(object sender, EventArgs e)
        {
            if (lstEvents.SelectedItems.Count > 0)
            {
                Event selectedEvent = (Event)lstEvents.SelectedItems[0].Tag;
                
                string details = $"Event: {selectedEvent.Title}\n\n" +
                               $"Category: {selectedEvent.Category}\n" +
                               $"Date: {selectedEvent.EventDate:F}\n" +
                               $"Location: {selectedEvent.Location}\n" +
                               $"Organizer: {selectedEvent.Organizer}\n\n" +
                               $"Description:\n{selectedEvent.Description}";
                
                MessageBox.Show(details, "Event Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
