using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Views.SummonView
{
    class ViewSummonView : Form, ISummon
    {
        public ViewSummonView()
        {
            this.InitComponents();
        }

        private Summon summon = new Summon();
        public Summon Summon { get { return this.summon; } set { this.summon = value; } }
        private List<Summon> summons = new List<Summon>();
        public List<Summon> Summons { get { return this.summons; } set { this.summons = value; } }
        public void ModelToFields()
        {
            this.txtIncidentDate.Text = this.summon.IncidentDate.ToLongDateString();
            this.txtReportedDate.Text = this.summon.ReportedDate.ToLongDateString();
            this.txtSummary.Text = this.summon.Summary;
        }

        // listeners

        private void InitComponents()
        {
            // Initialize Components
            this.lblSummon = new Label();

            this.lblDateReported = new Label();
            this.txtReportedDate = new TextBox();

            this.lblIncidentDate = new Label();
            this.txtIncidentDate = new TextBox();

            this.lblSummary = new Label();
            this.txtSummary = new TextBox();

            this.dsnLine = new PictureBox();
            this.dsnLine1 = new PictureBox();
            this.dsnLine2 = new PictureBox();
            this.dsnLlbl = new Label();
            this.dsnBox = new PictureBox();

            // Label : Summon
            this.lblSummon.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblSummon.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblSummon.Location = new Point(43, 93);
            this.lblSummon.Name = "lblSummon";
            this.lblSummon.Size = new Size(209, 24);
            this.lblSummon.Text = "Summon Report Details";
            this.lblSummon.AutoSize = true;

            // Label : Incident Date
            this.lblIncidentDate.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblIncidentDate.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblIncidentDate.Location = new Point(47, 154);
            this.lblIncidentDate.Size = new Size(105, 22);
            this.lblIncidentDate.AutoSize = true;
            this.lblIncidentDate.Name = "lblIncidentDate";
            this.lblIncidentDate.Text = "Incident Date";

            // TextBox : Incident
            this.txtIncidentDate.BackColor = Color.FromArgb(250, 250, 250);
            this.txtIncidentDate.BorderStyle = BorderStyle.None;
            this.txtIncidentDate.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtIncidentDate.Location = new Point(47, 190);
            this.txtIncidentDate.Size = new Size(260, 21);
            this.txtIncidentDate.Name = "txtIncidentDate";

            // Label : Reported Date
            this.lblDateReported.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblDateReported.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblDateReported.Location = new Point(535, 154);
            this.lblDateReported.Size = new Size(113, 22);
            this.lblDateReported.AutoSize = true;
            this.lblDateReported.Name = "lblDateReported";
            this.lblDateReported.Text = "Reported Date";

            // TextBox : Reported Date
            this.txtReportedDate.BackColor = Color.FromArgb(250, 250, 250);
            this.txtReportedDate.BorderStyle = BorderStyle.None;
            this.txtReportedDate.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtReportedDate.Location = new Point(535, 190);
            this.txtReportedDate.Size = new Size(260, 21);
            this.txtReportedDate.Name = "txtReportedDate";

            // Label : Summary
            this.lblSummary.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblSummary.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblSummary.Location = new Point(43, 275);
            this.lblSummary.Size = new Size(156, 22);
            this.lblSummary.AutoSize = true;
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Text = "Summary of Incident";

            // Textbox : Summary
            this.txtSummary.BackColor = Color.FromArgb(250, 250, 250);
            this.txtSummary.BorderStyle = BorderStyle.None;
            this.txtSummary.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtSummary.Location = new Point(47, 319);
            this.txtSummary.Size = new Size(748, 167);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";

            // Design Components
            this.dsnLlbl.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dsnLlbl.ForeColor = Color.FromArgb(241, 246, 249);
            this.dsnLlbl.Location = new Point(10, 12);
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.Text = "Barangay Management Information System";
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnBox.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnBox.Location = new Point(-2, -1);
            this.dsnBox.Size = new Size(850, 51);
            this.dsnBox.Name = "dsnBox";
            this.dsnLine.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine.Location = new Point(47, 215);
            this.dsnLine.Size = new Size(260, 3);
            this.dsnLine.Name = "dsnLine";
            this.dsnLine2.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine2.Location = new Point(47, 491);
            this.dsnLine2.Size = new Size(748, 3);
            this.dsnLine2.Name = "pictureBox1";
            this.dsnLine1.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine1.Location = new Point(535, 215);
            this.dsnLine1.Size = new Size(260, 3);
            this.dsnLine1.Name = "dsnLine1";

            // Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 246, 249);
            this.ClientSize = new Size(846, 561);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.Name = "ViewSummonView";
            this.Text = "Summon Report Details";
            this.FormClosed += new FormClosedEventHandler(ViewContext.FormOnClose);

            // Load controls
            this.Controls.Add(this.lblSummon);

            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.txtReportedDate);
            this.Controls.Add(this.lblDateReported);
            this.Controls.Add(this.txtIncidentDate);
            this.Controls.Add(this.lblIncidentDate);

            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
            this.Controls.Add(this.dsnLine1);
            this.Controls.Add(this.dsnLine);
            this.Controls.Add(this.dsnLine2);
        }

        /* Components */
        private Label lblSummon;

        private TextBox txtReportedDate;
        private Label lblDateReported;

        private Label lblIncidentDate;
        private TextBox txtIncidentDate;

        private Label lblSummary;
        private TextBox txtSummary;

        private PictureBox dsnLine;
        private PictureBox dsnLine1;
        private PictureBox dsnLine2;
        private Label dsnLlbl;
        private PictureBox dsnBox;
    }
}
