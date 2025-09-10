using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MuniServicesApp.Models;
using MuniServicesApp.Services;

namespace MuniServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        private List<string> attachedFiles;
        private string[] encouragingMessages = {
            "Great job reporting this! 🌟",
            "You're making your community better! 💪",
            "Thanks for being awesome! 😊",
            "Your voice matters! 🗣️",
            "Keep up the good work! 👍"
        };

        public ReportIssuesForm()
        {
            InitializeComponent();
            attachedFiles = new List<string>();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.AddRange(new string[]
            {
                "Potholes & Road Issues 🛣️",
                "Water Problems 💧",
                "Electricity Issues ⚡",
                "Garbage Collection 🗑️",
                "Street Lights 💡",
                "Parks & Recreation 🌳",
                "Noise Complaints 🔊",
                "Other Stuff 🤷"
            });
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*|Images (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|Documents (*.pdf;*.doc;*.docx;*.txt)|*.pdf;*.doc;*.docx;*.txt";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Pick some files to attach";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        if (!attachedFiles.Contains(fileName))
                        {
                            attachedFiles.Add(fileName);
                        }
                    }
                    UpdateAttachedFilesList();
                }
            }
        }

        private void UpdateAttachedFilesList()
        {
            lstAttachedFiles.Items.Clear();
            foreach (string file in attachedFiles)
            {
                lstAttachedFiles.Items.Add(Path.GetFileName(file));
            }
            lblFileCount.Text = $"📎 {attachedFiles.Count} file(s) attached";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                progressBar.Visible = true;
                lblProgress.Visible = true;
                
                // Simulate progress
                for (int i = 0; i <= 100; i += 20)
                {
                    progressBar.Value = i;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(200);
                }

                // Create and save the issue
                Issue newIssue = new Issue
                {
                    Location = txtLocation.Text.Trim(),
                    Category = cmbCategory.SelectedItem.ToString(),
                    Description = rtbDescription.Text.Trim(),
                    AttachedFiles = new List<string>(attachedFiles)
                };

                IssueManager.Instance.AddIssue(newIssue);

                // Show encouraging message
                Random rand = new Random();
                string message = encouragingMessages[rand.Next(encouragingMessages.Length)];
                
                MessageBox.Show($"{message}\n\nYour issue has been reported successfully!\nIssue ID: #{newIssue.Id}", 
                    "Success! 🎉", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                progressBar.Visible = false;
                lblProgress.Visible = false;
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Oops! Please tell us where the issue is located! 📍", 
                    "Missing Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return false;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please pick a category for your issue! 📋", 
                    "Missing Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Don't forget to describe the issue! We need the details! 📝", 
                    "Missing Description", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            attachedFiles.Clear();
            UpdateAttachedFilesList();
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lstAttachedFiles.SelectedIndex >= 0)
            {
                attachedFiles.RemoveAt(lstAttachedFiles.SelectedIndex);
                UpdateAttachedFilesList();
            }
            else
            {
                MessageBox.Show("Select a file to remove first! 😅", "No File Selected", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
