using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Presenters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Views.ResidentView
{
    class SearchResidentView : Form, IResident
    {
        public SearchResidentView()
        {
            this.InitComponents();
        }

        private List<Resident> residents = new List<Resident>();
        public List<Resident> Residents { get { return residents; } set { residents = value; } }

        private Resident resident = new Resident();
        public Resident Resident { get { return resident; } set { resident = value; } }

        public bool FieldsToModel()
        {
            bool valid = true;

            string firstName = this.txtFirstName.Text;
            string middleName = this.txtMiddleName.Text;
            string lastName = this.txtLastName.Text;

            if (firstName == null || firstName == "")
                valid = false;
            if (middleName == null || middleName == "")
                valid = false;
            if (lastName == null || lastName == "")
                valid = false;

            if (valid)
            {
                this.resident.FirstName = firstName;
                this.resident.MiddleName = middleName;
                this.resident.LastName = lastName;
            }

            return valid;
        }

        // listeners
        private void SearchOnClick(object sender, EventArgs e)
        {
            if (this.FieldsToModel())
                new ResidentPresenter().PostSearchResident(this);
            else MessageBox.Show("Search fields cannot be empty.", "Search Resident", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void InitComponents()
        {
            // Component initialization
            this.dsnLlbl = new Label();
            this.dsnBox = new PictureBox();
            this.lblSearch = new Label();
            this.dsnLine = new PictureBox();
            this.txtFirstName = new TextBox();
            this.lblFirstName = new Label();
            this.dsnLine1 = new PictureBox();
            this.txtMiddleName = new TextBox();
            this.lblMiddleName = new Label();
            this.dsnLine2 = new PictureBox();
            this.txtLastName = new TextBox();
            this.lblLastName = new Label();
            this.btnSearch = new Button();

            // Label : Search
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblSearch.Location = new Point(69, 97);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new Size(144, 24);
            this.lblSearch.TabIndex = 8;
            this.lblSearch.Text = "Search Resident";

            // Label : First name
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblFirstName.Location = new Point(107, 153);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new Size(86, 22);
            this.lblFirstName.TabIndex = 10;
            this.lblFirstName.Text = "First Name";

            // TextBox : First name
            this.txtFirstName.BackColor = Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtFirstName.BorderStyle = BorderStyle.None;
            this.txtFirstName.Font = new Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new Point(105, 188);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new Size(275, 21);
            this.txtFirstName.TabIndex = 11;

            // Label : Middle Name
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleName.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblMiddleName.Location = new Point(111, 265);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new Size(102, 22);
            this.lblMiddleName.TabIndex = 13;
            this.lblMiddleName.Text = "Middle Name";

            // TextBox : Middle name
            this.txtMiddleName.BackColor = Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtMiddleName.BorderStyle = BorderStyle.None;
            this.txtMiddleName.Font = new Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleName.Location = new Point(109, 300);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new Size(275, 21);
            this.txtMiddleName.TabIndex = 14;

            // Label : Last name
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblLastName.Location = new Point(111, 374);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new Size(83, 22);
            this.lblLastName.TabIndex = 16;
            this.lblLastName.Text = "Last Name";

            // Textbox : Last name
            this.txtLastName.BackColor = Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtLastName.BorderStyle = BorderStyle.None;
            this.txtLastName.Font = new Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new Point(109, 409);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new Size(275, 21);
            this.txtLastName.TabIndex = 17;

            // Button
            this.btnSearch.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Font = new Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnSearch.Location = new Point(111, 487);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(97, 37);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new EventHandler(this.SearchOnClick);

            // Design components
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsnLlbl.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dsnLlbl.Location = new Point(12, 13);
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.Text = "Barangay Management Information System";
            this.dsnBox.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnBox.Location = new Point(0, 0);
            this.dsnBox.Name = "dsnBox";
            this.dsnBox.Size = new Size(507, 51);
            this.dsnLine.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine.Location = new Point(105, 213);
            this.dsnLine.Name = "dsnLine";
            this.dsnLine.Size = new Size(275, 3);
            this.dsnLine1.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine1.Location = new Point(109, 325);
            this.dsnLine1.Name = "dsnLine1";
            this.dsnLine1.Size = new Size(275, 3);
            this.dsnLine2.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine2.Location = new Point(109, 434);
            this.dsnLine2.Name = "dsnLine2";
            this.dsnLine2.Size = new Size(275, 3);

            // Actual form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new Size(506, 561);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Name = "SearchResidentView";
            this.Text = "Search Resident";

            // load controls to form
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dsnLine2);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.dsnLine1);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.dsnLine);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        private Label dsnLlbl;
        private PictureBox dsnBox;
        private Label lblSearch;
        private PictureBox dsnLine;
        private TextBox txtFirstName;
        private Label lblFirstName;
        private PictureBox dsnLine1;
        private TextBox txtMiddleName;
        private Label lblMiddleName;
        private PictureBox dsnLine2;
        private TextBox txtLastName;
        private Label lblLastName;
        private Button btnSearch;

    }
}
