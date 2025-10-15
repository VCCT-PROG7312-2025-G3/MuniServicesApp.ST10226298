namespace MuniServicesApp
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.btnFilterByDate = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lstEvents = new System.Windows.Forms.ListView();
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblEventCount = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.lblFeatured = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblDetailCategory = new System.Windows.Forms.Label();
            this.lblDetailDate = new System.Windows.Forms.Label();
            this.lblDetailLocation = new System.Windows.Forms.Label();
            this.lblDetailOrganizer = new System.Windows.Forms.Label();
            this.txtDetailDescription = new System.Windows.Forms.TextBox();
            this.panelRecommendations = new System.Windows.Forms.Panel();
            this.lblRecommendations = new System.Windows.Forms.Label();
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.panelRecentlyViewed = new System.Windows.Forms.Panel();
            this.lblRecentlyViewed = new System.Windows.Forms.Label();
            this.lstRecentlyViewed = new System.Windows.Forms.ListBox();
            this.btnShowFeatured = new System.Windows.Forms.Button();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.panelDetails.SuspendLayout();
            this.panelRecommendations.SuspendLayout();
            this.panelRecentlyViewed.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(16, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(419, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📅 Local Events && Announcements";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSearch.Location = new System.Drawing.Point(16, 70);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightBlue;
            this.btnSearch.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(275, 65);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(520, 70);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 28);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblCategory.Location = new System.Drawing.Point(430, 73);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(78, 20);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Category:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpStartDate.Location = new System.Drawing.Point(100, 110);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(166, 24);
            this.dtpStartDate.TabIndex = 5;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpEndDate.Location = new System.Drawing.Point(350, 110);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(166, 24);
            this.dtpEndDate.TabIndex = 6;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblStartDate.Location = new System.Drawing.Point(16, 113);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(54, 20);
            this.lblStartDate.TabIndex = 7;
            this.lblStartDate.Text = "From:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblEndDate.Location = new System.Drawing.Point(285, 113);
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(32, 20);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "To:";
            // 
            // btnFilterByDate
            // 
            this.btnFilterByDate.BackColor = System.Drawing.Color.LightGreen;
            this.btnFilterByDate.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilterByDate.Location = new System.Drawing.Point(530, 105);
            this.btnFilterByDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilterByDate.Name = "btnFilterByDate";
            this.btnFilterByDate.Size = new System.Drawing.Size(100, 35);
            this.btnFilterByDate.TabIndex = 9;
            this.btnFilterByDate.Text = "Filter";
            this.btnFilterByDate.UseVisualStyleBackColor = false;
            this.btnFilterByDate.Click += new System.EventHandler(this.btnFilterByDate_Click);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.LightCoral;
            this.btnClearFilters.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearFilters.Location = new System.Drawing.Point(640, 105);
            this.btnClearFilters.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(100, 35);
            this.btnClearFilters.TabIndex = 10;
            this.btnClearFilters.Text = "Clear";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // lstEvents
            // 
            this.lstEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colCategory,
            this.colDate,
            this.colLocation});
            this.lstEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lstEvents.FullRowSelect = true;
            this.lstEvents.GridLines = true;
            this.lstEvents.HideSelection = false;
            this.lstEvents.Location = new System.Drawing.Point(16, 180);
            this.lstEvents.Margin = new System.Windows.Forms.Padding(4);
            this.lstEvents.MultiSelect = false;
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(724, 350);
            this.lstEvents.TabIndex = 11;
            this.lstEvents.UseCompatibleStateImageBehavior = false;
            this.lstEvents.View = System.Windows.Forms.View.Details;
            this.lstEvents.SelectedIndexChanged += new System.EventHandler(this.lstEvents_SelectedIndexChanged);
            this.lstEvents.DoubleClick += new System.EventHandler(this.lstEvents_DoubleClick);
            // 
            // colTitle
            // 
            this.colTitle.Text = "Event Title";
            this.colTitle.Width = 250;
            // 
            // colCategory
            // 
            this.colCategory.Text = "Category";
            this.colCategory.Width = 120;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 120;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 200;
            // 
            // lblEventCount
            // 
            this.lblEventCount.AutoSize = true;
            this.lblEventCount.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.lblEventCount.Location = new System.Drawing.Point(16, 155);
            this.lblEventCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventCount.Name = "lblEventCount";
            this.lblEventCount.Size = new System.Drawing.Size(129, 21);
            this.lblEventCount.TabIndex = 12;
            this.lblEventCount.Text = "Showing 0 events";
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.LightYellow;
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetails.Controls.Add(this.lblFeatured);
            this.panelDetails.Controls.Add(this.txtDetailDescription);
            this.panelDetails.Controls.Add(this.lblDetailOrganizer);
            this.panelDetails.Controls.Add(this.lblDetailLocation);
            this.panelDetails.Controls.Add(this.lblDetailDate);
            this.panelDetails.Controls.Add(this.lblDetailCategory);
            this.panelDetails.Controls.Add(this.lblDetailTitle);
            this.panelDetails.Location = new System.Drawing.Point(750, 70);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(4);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(350, 300);
            this.panelDetails.TabIndex = 13;
            // 
            // lblFeatured
            // 
            this.lblFeatured.AutoSize = true;
            this.lblFeatured.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblFeatured.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblFeatured.Location = new System.Drawing.Point(15, 10);
            this.lblFeatured.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFeatured.Name = "lblFeatured";
            this.lblFeatured.Size = new System.Drawing.Size(155, 25);
            this.lblFeatured.TabIndex = 6;
            this.lblFeatured.Text = "⭐ FEATURED";
            this.lblFeatured.Visible = false;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDetailTitle.Location = new System.Drawing.Point(15, 40);
            this.lblDetailTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(320, 30);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "Select an event";
            // 
            // lblDetailCategory
            // 
            this.lblDetailCategory.AutoSize = true;
            this.lblDetailCategory.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblDetailCategory.Location = new System.Drawing.Point(15, 75);
            this.lblDetailCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetailCategory.Name = "lblDetailCategory";
            this.lblDetailCategory.Size = new System.Drawing.Size(78, 20);
            this.lblDetailCategory.TabIndex = 1;
            this.lblDetailCategory.Text = "Category:";
            // 
            // lblDetailDate
            // 
            this.lblDetailDate.AutoSize = true;
            this.lblDetailDate.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblDetailDate.Location = new System.Drawing.Point(15, 100);
            this.lblDetailDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetailDate.Name = "lblDetailDate";
            this.lblDetailDate.Size = new System.Drawing.Size(50, 20);
            this.lblDetailDate.TabIndex = 2;
            this.lblDetailDate.Text = "Date:";
            // 
            // lblDetailLocation
            // 
            this.lblDetailLocation.AutoSize = true;
            this.lblDetailLocation.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblDetailLocation.Location = new System.Drawing.Point(15, 125);
            this.lblDetailLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetailLocation.Name = "lblDetailLocation";
            this.lblDetailLocation.Size = new System.Drawing.Size(72, 20);
            this.lblDetailLocation.TabIndex = 3;
            this.lblDetailLocation.Text = "Location:";
            // 
            // lblDetailOrganizer
            // 
            this.lblDetailOrganizer.AutoSize = true;
            this.lblDetailOrganizer.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblDetailOrganizer.Location = new System.Drawing.Point(15, 150);
            this.lblDetailOrganizer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetailOrganizer.Name = "lblDetailOrganizer";
            this.lblDetailOrganizer.Size = new System.Drawing.Size(82, 20);
            this.lblDetailOrganizer.TabIndex = 4;
            this.lblDetailOrganizer.Text = "Organizer:";
            // 
            // txtDetailDescription
            // 
            this.txtDetailDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDetailDescription.Location = new System.Drawing.Point(15, 180);
            this.txtDetailDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDetailDescription.Multiline = true;
            this.txtDetailDescription.Name = "txtDetailDescription";
            this.txtDetailDescription.ReadOnly = true;
            this.txtDetailDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetailDescription.Size = new System.Drawing.Size(320, 100);
            this.txtDetailDescription.TabIndex = 5;
            // 
            // panelRecommendations
            // 
            this.panelRecommendations.BackColor = System.Drawing.Color.LightCyan;
            this.panelRecommendations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRecommendations.Controls.Add(this.lstRecommendations);
            this.panelRecommendations.Controls.Add(this.lblRecommendations);
            this.panelRecommendations.Location = new System.Drawing.Point(750, 380);
            this.panelRecommendations.Margin = new System.Windows.Forms.Padding(4);
            this.panelRecommendations.Name = "panelRecommendations";
            this.panelRecommendations.Size = new System.Drawing.Size(350, 130);
            this.panelRecommendations.TabIndex = 14;
            // 
            // lblRecommendations
            // 
            this.lblRecommendations.AutoSize = true;
            this.lblRecommendations.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecommendations.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblRecommendations.Location = new System.Drawing.Point(15, 10);
            this.lblRecommendations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecommendations.Name = "lblRecommendations";
            this.lblRecommendations.Size = new System.Drawing.Size(200, 25);
            this.lblRecommendations.TabIndex = 0;
            this.lblRecommendations.Text = "💡 Recommended for You";
            // 
            // lstRecommendations
            // 
            this.lstRecommendations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.ItemHeight = 18;
            this.lstRecommendations.Location = new System.Drawing.Point(15, 40);
            this.lstRecommendations.Margin = new System.Windows.Forms.Padding(4);
            this.lstRecommendations.Name = "lstRecommendations";
            this.lstRecommendations.Size = new System.Drawing.Size(320, 94);
            this.lstRecommendations.TabIndex = 1;
            // 
            // panelRecentlyViewed
            // 
            this.panelRecentlyViewed.BackColor = System.Drawing.Color.LavenderBlush;
            this.panelRecentlyViewed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRecentlyViewed.Controls.Add(this.lstRecentlyViewed);
            this.panelRecentlyViewed.Controls.Add(this.lblRecentlyViewed);
            this.panelRecentlyViewed.Location = new System.Drawing.Point(750, 520);
            this.panelRecentlyViewed.Margin = new System.Windows.Forms.Padding(4);
            this.panelRecentlyViewed.Name = "panelRecentlyViewed";
            this.panelRecentlyViewed.Size = new System.Drawing.Size(350, 130);
            this.panelRecentlyViewed.TabIndex = 17;
            // 
            // lblRecentlyViewed
            // 
            this.lblRecentlyViewed.AutoSize = true;
            this.lblRecentlyViewed.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecentlyViewed.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblRecentlyViewed.Location = new System.Drawing.Point(15, 10);
            this.lblRecentlyViewed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecentlyViewed.Name = "lblRecentlyViewed";
            this.lblRecentlyViewed.Size = new System.Drawing.Size(178, 25);
            this.lblRecentlyViewed.TabIndex = 0;
            this.lblRecentlyViewed.Text = "🕒 Recently Viewed";
            // 
            // lstRecentlyViewed
            // 
            this.lstRecentlyViewed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lstRecentlyViewed.FormattingEnabled = true;
            this.lstRecentlyViewed.ItemHeight = 18;
            this.lstRecentlyViewed.Location = new System.Drawing.Point(15, 40);
            this.lstRecentlyViewed.Margin = new System.Windows.Forms.Padding(4);
            this.lstRecentlyViewed.Name = "lstRecentlyViewed";
            this.lstRecentlyViewed.Size = new System.Drawing.Size(320, 76);
            this.lstRecentlyViewed.TabIndex = 1;
            // 
            // btnShowFeatured
            // 
            this.btnShowFeatured.BackColor = System.Drawing.Color.Gold;
            this.btnShowFeatured.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnShowFeatured.Location = new System.Drawing.Point(16, 540);
            this.btnShowFeatured.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowFeatured.Name = "btnShowFeatured";
            this.btnShowFeatured.Size = new System.Drawing.Size(180, 40);
            this.btnShowFeatured.TabIndex = 15;
            this.btnShowFeatured.Text = "⭐ Featured Events";
            this.btnShowFeatured.UseVisualStyleBackColor = false;
            this.btnShowFeatured.Click += new System.EventHandler(this.btnShowFeatured_Click);
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.BackColor = System.Drawing.Color.Orange;
            this.btnBackToMenu.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackToMenu.Location = new System.Drawing.Point(560, 540);
            this.btnBackToMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(180, 40);
            this.btnBackToMenu.TabIndex = 16;
            this.btnBackToMenu.Text = "🏠 Back to Menu";
            this.btnBackToMenu.UseVisualStyleBackColor = false;
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 665);
            this.Controls.Add(this.panelRecentlyViewed);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.btnShowFeatured);
            this.Controls.Add(this.panelRecommendations);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.lblEventCount);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.btnFilterByDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Events and Announcements";
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelRecommendations.ResumeLayout(false);
            this.panelRecommendations.PerformLayout();
            this.panelRecentlyViewed.ResumeLayout(false);
            this.panelRecentlyViewed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Button btnFilterByDate;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.ListView lstEvents;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.Label lblEventCount;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblDetailCategory;
        private System.Windows.Forms.Label lblDetailDate;
        private System.Windows.Forms.Label lblDetailLocation;
        private System.Windows.Forms.Label lblDetailOrganizer;
        private System.Windows.Forms.TextBox txtDetailDescription;
        private System.Windows.Forms.Label lblFeatured;
        private System.Windows.Forms.Panel panelRecommendations;
        private System.Windows.Forms.Label lblRecommendations;
        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.Panel panelRecentlyViewed;
        private System.Windows.Forms.Label lblRecentlyViewed;
        private System.Windows.Forms.ListBox lstRecentlyViewed;
        private System.Windows.Forms.Button btnShowFeatured;
        private System.Windows.Forms.Button btnBackToMenu;
    }
}
