using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Presenters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Views.SummonView
{
    class CreateSummonView : Form, ISummon
    {
        public CreateSummonView()
        {
            this.InitComponents();
        }

        private Summon summon = new Summon();
        public Summon Summon { get { return this.summon; } set { this.summon = value; } }
        private List<Summon> summons = new List<Summon>();
        public List<Summon> Summons { get { return this.summons; } set { this.summons = value; } }

        private bool FieldsToModel()
        {
            bool valid = true;

            this.summon.IncidentDate = this.pickerIncidentDate.Value;
            this.summon.Summary = this.txtSummary.Text;

            if (this.summon.IncidentDate == null)
                valid = false;
            if (this.summon.Summary == "" || this.summon.Summary == null)
                valid = false;

            return valid;
        }

        // listeners
        private void CreateOnClick(object sender, EventArgs e)
        {
            if (this.FieldsToModel())
            {
                new SummonPresenter().PostCreateSummon(this);
            }
            else
            {
                MessageBox.Show("Fields cannot be empty.", "Create Summon Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitComponents()
        {
            // Initialize components
            this.lblSummons = new Label();

            this.lblIncidentDate = new Label();
            this.pickerIncidentDate = new DateTimePicker();

            this.txtSummary = new TextBox();
            this.lblSummary = new Label();
            this.btnCreate = new Button();

            this.dsnLine1 = new PictureBox();
            this.dsnLine2 = new PictureBox();
            this.dsnLlbl = new Label();
            this.dsnBox = new PictureBox();

            // Label : Create Summon Report
            this.lblSummons.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblSummons.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblSummons.Location = new Point(60, 90);
            this.lblSummons.Size = new Size(206, 24);
            this.lblSummons.AutoSize = true;
            this.lblSummons.Name = "lblSummons";
            this.lblSummons.Text = "Create Summon Report";

            // Label Incident Date
            this.lblIncidentDate.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblIncidentDate.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblIncidentDate.Location = new Point(67, 146);
            this.lblIncidentDate.Size = new Size(105, 22);
            this.lblIncidentDate.AutoSize = true;
            this.lblIncidentDate.Name = "lblIncidentDate";
            this.lblIncidentDate.Text = "Incident Date";

            // DatePicker : Incident Date
            this.pickerIncidentDate.CalendarMonthBackground = Color.FromArgb(250, 250, 250);
            this.pickerIncidentDate.DropDownAlign = LeftRightAlignment.Right;
            this.pickerIncidentDate.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.pickerIncidentDate.Format = DateTimePickerFormat.Short;
            this.pickerIncidentDate.Location = new Point(64, 180);
            this.pickerIncidentDate.Size = new Size(235, 27);
            this.pickerIncidentDate.Value = new DateTime(2020, 10, 19, 0, 0, 0, 0);
            this.pickerIncidentDate.TabIndex = 1;
            this.pickerIncidentDate.Name = "pickerIncidentDate";

            // Label : summary
            this.lblSummary.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblSummary.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblSummary.Location = new Point(60, 249);
            this.lblSummary.Size = new Size(156, 22);
            this.lblSummary.AutoSize = true;
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Text = "Summary of Incident";

            // Textbox : Summary
            this.txtSummary.BackColor = Color.FromArgb(250, 250, 250);
            this.txtSummary.BorderStyle = BorderStyle.None;
            this.txtSummary.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtSummary.Location = new Point(64, 283);
            this.txtSummary.Size = new Size(748, 167);
            this.txtSummary.TabIndex = 2;
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";

            // Button
            this.btnCreate.BackColor = Color.FromArgb(2, 117, 216);
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnCreate.ForeColor = Color.FromArgb(247, 247, 247);
            this.btnCreate.Location = new Point(715, 496);
            this.btnCreate.Size = new Size(97, 37);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Text = "Create";
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Click += new EventHandler(this.CreateOnClick);

            // Design Components
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dsnLlbl.ForeColor = Color.FromArgb(241, 246, 249);
            this.dsnLlbl.Location = new Point(8, 13);
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.Text = "Barangay Management Information System";
            this.dsnBox.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnBox.Location = new Point(-4, 0);
            this.dsnBox.Name = "dsnBox";
            this.dsnBox.Size = new Size(888, 51);
            this.dsnLine2.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine2.Location = new Point(64, 206);
            this.dsnLine2.Name = "dnsLine3";
            this.dsnLine2.Size = new Size(235, 3);
            this.dsnLine1.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine1.Location = new Point(64, 455);
            this.dsnLine1.Name = "dsnLine1";
            this.dsnLine1.Size = new Size(748, 3);

            // Forms
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 246, 249);
            this.ClientSize = new Size(884, 561);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Name = "CreateSummonView";
            this.Text = "Create Summon Report";
            this.FormClosed += new FormClosedEventHandler(ViewContext.FormOnClose);

            // Load control to form
            this.Controls.Add(this.lblSummons);

            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.txtSummary);

            this.Controls.Add(this.lblIncidentDate);
            this.Controls.Add(this.pickerIncidentDate);

            this.Controls.Add(this.btnCreate);

            this.Controls.Add(this.dsnLine1);
            this.Controls.Add(this.dsnLine2);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        /* Components */
        private Label lblSummons;

        private Label lblIncidentDate;
        private DateTimePicker pickerIncidentDate;

        private Label lblSummary;
        private TextBox txtSummary;

        private Button btnCreate;

        private PictureBox dsnLine1;
        private PictureBox dsnLine2;
        private Label dsnLlbl;
        private PictureBox dsnBox;

    }
}
