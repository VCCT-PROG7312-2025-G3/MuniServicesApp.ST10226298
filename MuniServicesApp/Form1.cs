using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuniServicesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportForm = new ReportIssuesForm();
            reportForm.Show();
            this.Hide();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            ViewReportsForm viewReportsForm = new ViewReportsForm();
            viewReportsForm.Show();
            this.Hide();
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            LocalEventsForm localEventsForm = new LocalEventsForm();
            localEventsForm.Show();
            this.Hide();
        }
    }
}
