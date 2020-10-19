using MP_Garcia_GeneJoseph_BMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Views.ResidentView
{
    class ViewResidentView : Form, IResident
    {
        public ViewResidentView()
        {
            this.InitComponents();
        }

        private List<Resident> residents = new List<Resident>();
        public List<Resident> Residents { get { return residents; } set { residents = value; } }

        private Resident resident = new Resident();
        public Resident Resident { get { return resident; } set { resident = value; } }


        /// <summary>
        /// Either Add or Edit/View a resident, using this.resident
        /// </summary>
        private void DetermineAction()
        {
            if (this.resident.ResidentId > 0)
            {
                // there is resident, which means action is to edit resident
                this.btnAction.Text = "Save";
                this.Text = "Edit Resident Record";
            }
            else
            {
                // new resident, add a new resident
                this.btnAction.Text = "Resident";
                this.Text = "Record New Resident";
            }
        }

        private bool FieldToModel()
        {
            bool valid = true;

            string fName, mName, lName;
            fName = this.txtFirstName.Text.Trim();
            mName = this.txtMiddleName.Text.Trim();
            lName = this.txtLastName.Text.Trim();
            DateTime birthdate = this.pickerBirthdate.Value;
            string address = this.txtAddress.Text.Trim();
            string sex = "";
            string status = "";

            if (this.comboSex.SelectedIndex >= 0)
                sex = this.comboSex.SelectedItem.ToString();
            if (this.comboStatus.SelectedIndex >= 0)
                status = this.comboStatus.SelectedItem.ToString();

            if (fName == null || fName == "")
                valid = false;
            else if (mName == null || mName == "")
                valid = false;
            else if (lName == null || lName == "")
                valid = false;
            else if (birthdate == null)
                valid = false;
            else if (status == "")
                valid = false;
            else if (sex == "")
                valid = false;
            else if (address == "" || address == null)
                valid = false;

            if (valid)
            {
                // append to model
                this.resident.FirstName = fName;
                this.resident.MiddleName = fName;
                this.resident.LastName = fName;
                this.resident.Birthdate = birthdate;
                this.resident.Status = fName;
                this.resident.Address = fName;
                this.resident.Sex = sex;
            }

            return valid;
        }

        // listeners
        private void FormLoad(object sender, EventArgs e)
        {
            this.DetermineAction();
        }
        private void ActionOnClick(object sender, EventArgs e)
        {
            if (this.FieldToModel())
                if (this.resident.ResidentId > 0)
                {
                    // edit/view

                }
                else
                {
                    // add
                }
            else
                MessageBox.Show("Fields cannot be empty.", "Resident", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void InitComponents()
        {
            // Initialize components
            this.lblResidents       = new Label();
            this.dsnLlbl            = new Label();
            this.dsnBox             = new PictureBox();
            this.lblFirstName       = new Label();
            this.txtFirstName       = new TextBox();
            this.dsnLine            = new PictureBox();
            this.dsnLine1           = new PictureBox();
            this.txtMiddleName      = new TextBox();
            this.lblMiddleName      = new Label();
            this.dsnLine2           = new PictureBox();
            this.txtLastName        = new TextBox();
            this.lblLastName        = new Label();
            this.pickerBirthdate    = new DateTimePicker();
            this.lblBirthdate       = new Label();
            this.dnsLine3           = new PictureBox();
            this.comboStatus        = new ComboBox();
            this.lblStatus          = new Label();
            this.dsnLine4           = new PictureBox();
            this.dsnLine5           = new PictureBox();
            this.txtAddress         = new TextBox();
            this.lblAddress         = new Label();
            this.btnAction          = new Button();
            this.dsnLine7           = new PictureBox();
            this.lblSex             = new Label();
            this.comboSex           = new ComboBox();

            // Label Residents
            this.lblResidents.AutoSize = true;
            this.lblResidents.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResidents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblResidents.Location = new System.Drawing.Point(54, 83);
            this.lblResidents.Name = "lblResidents";
            this.lblResidents.Size = new System.Drawing.Size(173, 24);
            this.lblResidents.Text = "Barangay Residents";

            // Label : First name
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblFirstName.Location = new System.Drawing.Point(70, 146);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(86, 22);
            this.lblFirstName.Text = "First Name";

            // Textbox : First Name
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(70, 182);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Size = new System.Drawing.Size(237, 21);

            // Label : Middle name
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblMiddleName.Location = new System.Drawing.Point(361, 146);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(102, 22);
            this.lblMiddleName.TabIndex = 10;
            this.lblMiddleName.Text = "Middle Name";

            // Textbox : Middle Name
            this.txtMiddleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMiddleName.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleName.Location = new System.Drawing.Point(361, 182);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(237, 21);
            this.txtMiddleName.TabIndex = 2;

            // Label : Last name
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(70, 285);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(528, 21);

            // Textbox : Last Name
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblLastName.Location = new System.Drawing.Point(70, 249);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(83, 22);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name";

            // Label : Birthday
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblBirthdate.Location = new System.Drawing.Point(73, 363);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(77, 22);
            this.lblBirthdate.Text = "Birthdate";

            // DatePicker : Birthday
            this.pickerBirthdate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pickerBirthdate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.pickerBirthdate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerBirthdate.Location = new System.Drawing.Point(70, 397);
            this.pickerBirthdate.MaxDate = System.DateTime.Now;
            this.pickerBirthdate.Name = "pickerBirthdate";
            this.pickerBirthdate.Size = new System.Drawing.Size(175, 27);
            this.pickerBirthdate.TabIndex = 4;
            this.pickerBirthdate.Value = new System.DateTime(2020, 10, 19, 0, 0, 0, 0);

            // Label : Status
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblStatus.Location = new System.Drawing.Point(264, 363);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 22);
            this.lblStatus.Text = "Status";

            // ComboBox : Status
            this.comboStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboStatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "ALIVE",
            "DECEASED"});
            this.comboStatus.Location = new System.Drawing.Point(268, 397);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(170, 27);
            this.comboStatus.TabIndex = 5;
            this.comboStatus.Text = "Select status...";

            // Label : Sex
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblSex.Location = new System.Drawing.Point(457, 363);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(35, 22);
            this.lblSex.TabIndex = 27;
            this.lblSex.Text = "Sex";

            // ComboBox : Sex
            this.comboSex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.comboSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboSex.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSex.FormattingEnabled = true;
            this.comboSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboSex.Location = new System.Drawing.Point(461, 397);
            this.comboSex.Name = "comboSex";
            this.comboSex.Size = new System.Drawing.Size(137, 27);
            this.comboSex.TabIndex = 26;
            this.comboSex.Text = "Select sex...";

            // Label : Address
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblAddress.Location = new System.Drawing.Point(74, 468);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(83, 22);
            this.lblAddress.Text = "Address";

            // Textbox : Address
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(74, 504);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(528, 21);
            this.txtAddress.TabIndex = 6;

            // Button
            this.btnAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnAction.Location = new System.Drawing.Point(501, 575);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(97, 37);
            this.btnAction.TabIndex = 7;
            this.btnAction.Text = "Action";
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Click += new EventHandler(this.ActionOnClick);

            // designs
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLlbl.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsnLlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dsnLlbl.Location = new System.Drawing.Point(10, 11);
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Size = new System.Drawing.Size(372, 24);
            this.dsnLlbl.TabIndex = 5;
            this.dsnLlbl.Text = "Barangay Management Information System";
            this.dsnBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnBox.Location = new System.Drawing.Point(-2, -2);
            this.dsnBox.Name = "dsnBox";
            this.dsnBox.Size = new System.Drawing.Size(678, 51);
            this.dsnBox.TabStop = false;
            this.dsnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine.Location = new System.Drawing.Point(70, 207);
            this.dsnLine.Name = "dsnLine";
            this.dsnLine.Size = new System.Drawing.Size(237, 3);
            this.dsnLine.TabStop = false;
            this.dsnLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine1.Location = new System.Drawing.Point(361, 207);
            this.dsnLine1.Name = "dsnLine1";
            this.dsnLine1.Size = new System.Drawing.Size(237, 3);
            this.dsnLine1.TabStop = false;
            this.dsnLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine2.Location = new System.Drawing.Point(70, 310);
            this.dsnLine2.Name = "dsnLine2";
            this.dsnLine2.Size = new System.Drawing.Size(528, 3);
            this.dsnLine2.TabStop = false;
            this.dnsLine3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dnsLine3.Location = new System.Drawing.Point(70, 423);
            this.dnsLine3.Name = "dnsLine3";
            this.dnsLine3.Size = new System.Drawing.Size(175, 3);
            this.dnsLine3.TabStop = false;
            this.dsnLine4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine4.Location = new System.Drawing.Point(268, 423);
            this.dsnLine4.Name = "dsnLine4";
            this.dsnLine4.Size = new System.Drawing.Size(170, 3);
            this.dsnLine4.TabStop = false;
            this.dsnLine5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine5.Location = new System.Drawing.Point(74, 529);
            this.dsnLine5.Name = "dsnLine5";
            this.dsnLine5.Size = new System.Drawing.Size(528, 3);
            this.dsnLine5.TabStop = false;
            this.dsnLine7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine7.Location = new System.Drawing.Point(461, 423);
            this.dsnLine7.Name = "dsnLine7";
            this.dsnLine7.Size = new System.Drawing.Size(137, 3);
            this.dsnLine7.TabIndex = 28;
            this.dsnLine7.TabStop = false;


            // Actual Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(672, 651);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditResident";
            this.Text = "Resident";
            this.Load += new System.EventHandler(this.FormLoad);

            // Load Controls
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.dsnLine5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.dsnLine4);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.dnsLine3);
            this.Controls.Add(this.lblBirthdate);
            this.Controls.Add(this.pickerBirthdate);
            this.Controls.Add(this.dsnLine2);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.dsnLine1);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.dsnLine);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblResidents);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.comboSex);
            this.Controls.Add(this.dsnLine7);
        }

        private Label lblResidents;
        private Label dsnLlbl;
        private PictureBox dsnBox;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private PictureBox dsnLine;
        private PictureBox dsnLine1;
        private TextBox txtMiddleName;
        private Label lblMiddleName;
        private PictureBox dsnLine2;
        private TextBox txtLastName;
        private Label lblLastName;
        private DateTimePicker pickerBirthdate;
        private Label lblBirthdate;
        private PictureBox dnsLine3;
        private ComboBox comboStatus;
        private Label lblStatus;
        private PictureBox dsnLine4;
        private PictureBox dsnLine5;
        private TextBox txtAddress;
        private Label lblAddress;
        private Button btnAction;
        private PictureBox dsnLine7;
        private Label lblSex;
        private ComboBox comboSex;
    }
}
