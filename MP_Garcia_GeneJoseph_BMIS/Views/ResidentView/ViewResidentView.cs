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
                // model to fields
                this.ModelToFields();
            }
            else
            {
                // new resident, add a new resident
                this.btnAction.Text = "Record";
                this.Text = "Record New Resident";
            }
        }

        private void ModelToFields()
        {
            this.txtFirstName.Text = this.resident.FirstName;
            this.txtMiddleName.Text = this.resident.MiddleName;
            this.txtLastName.Text = this.resident.LastName;
            this.txtAddress.Text = this.resident.Address;
            this.pickerBirthdate.Value = this.resident.Birthdate;

            this.comboStatus.SelectedItem = this.resident.Status;
            this.comboSex.SelectedItem = this.resident.Sex;
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
                this.resident.MiddleName = mName;
                this.resident.LastName = lName;
                this.resident.Birthdate = birthdate;
                this.resident.Status = status;
                this.resident.Address = address;
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
                    new ResidentPresenter().PostUpdateResident(this);
                else
                    new ResidentPresenter().PostAddResident(this);
            else
                MessageBox.Show("Fields cannot be empty.", "Resident", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void InitComponents()
        {
            // Initialize components
            this.dsnLlbl = new Label();
            this.dsnBox = new PictureBox();
            this.dsnLine = new PictureBox();
            this.dsnLine1 = new PictureBox();
            this.dsnLine2 = new PictureBox();
            this.dsnLine6 = new PictureBox();
            this.dsnLine5 = new PictureBox();
            this.dsnLine4 = new PictureBox();
            this.dnsLine3 = new PictureBox();

            this.lblResidents = new Label();

            this.lblFirstName = new Label();
            this.txtFirstName = new TextBox();
            
            this.txtMiddleName = new TextBox();
            this.lblMiddleName = new Label();
            
            this.txtLastName = new TextBox();
            this.lblLastName = new Label();

            this.pickerBirthdate = new DateTimePicker();
            this.lblBirthdate = new Label();

            this.comboStatus = new ComboBox();
            this.lblStatus = new Label();

            this.txtAddress = new TextBox();
            this.lblAddress  = new Label();

            this.lblSex = new Label();
            this.comboSex = new ComboBox();

            this.btnAction = new Button();

            // Label Residents
            this.lblResidents.AutoSize = true;
            this.lblResidents.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblResidents.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblResidents.Location = new Point(54, 83);
            this.lblResidents.Size = new Size(173, 24);
            this.lblResidents.Name = "lblResidents";
            this.lblResidents.Text = "Barangay Residents";

            // Label : First name
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblFirstName.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblFirstName.Location = new Point(70, 146);
            this.lblFirstName.Size = new Size(86, 22);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Text = "First Name";

            // Textbox : First Name
            this.txtFirstName.BackColor = Color.FromArgb(250, 250, 250);
            this.txtFirstName.BorderStyle = BorderStyle.None;
            this.txtFirstName.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtFirstName.Location = new Point(70, 182);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Size = new Size(237, 21);
            this.txtFirstName.Name = "txtFirstName";

            // Label : Middle name
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblMiddleName.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblMiddleName.Location = new Point(361, 146);
            this.lblMiddleName.Size = new Size(102, 22);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Text = "Middle Name";

            // Textbox : Middle Name
            this.txtMiddleName.BackColor = Color.FromArgb(250, 250, 250);
            this.txtMiddleName.BorderStyle = BorderStyle.None;
            this.txtMiddleName.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtMiddleName.Location = new Point(361, 182);
            this.txtMiddleName.Size = new Size(237, 21);
            this.txtMiddleName.TabIndex = 2;
            this.txtMiddleName.Name = "txtMiddleName";

            // Label : Last name
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblLastName.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblLastName.Location = new Point(70, 249);
            this.lblLastName.Size = new Size(83, 22);
            this.lblLastName.Name = "lblLastName";    
            this.lblLastName.Text = "Last Name";

            // Textbox : Last Name
            this.txtLastName.BackColor = Color.FromArgb(250, 250, 250);
            this.txtLastName.BorderStyle = BorderStyle.None;
            this.txtLastName.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtLastName.Location = new Point(70, 285);
            this.txtLastName.Size = new Size(528, 21);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.Name = "txtLastName";

            // Label : Birthday
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblBirthdate.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblBirthdate.Location = new Point(73, 363);
            this.lblBirthdate.Size = new Size(77, 22);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Text = "Birthdate";

            // DatePicker : Birthday
            this.pickerBirthdate.CalendarMonthBackground = Color.FromArgb(250, 250, 250);
            this.pickerBirthdate.DropDownAlign = LeftRightAlignment.Right;
            this.pickerBirthdate.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.pickerBirthdate.Location = new Point(70, 397);
            this.pickerBirthdate.MaxDate = DateTime.Now;
            this.pickerBirthdate.Size = new Size(175, 27);
            this.pickerBirthdate.Format = DateTimePickerFormat.Short;
            this.pickerBirthdate.TabIndex = 4;
            this.pickerBirthdate.Name = "pickerBirthdate";
            this.pickerBirthdate.Value = new DateTime(2020, 10, 19, 0, 0, 0, 0);

            // Label : Status
            this.lblStatus.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblStatus.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblStatus.Location = new Point(264, 363);
            this.lblStatus.Size = new Size(52, 22);
            this.lblStatus.AutoSize = true;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status";

            // ComboBox : Status
            this.comboStatus.BackColor = Color.FromArgb(250, 250, 250);
            this.comboStatus.FlatStyle = FlatStyle.Flat;
            this.comboStatus.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.comboStatus.Items.AddRange(new object[] {
                                                    "ALIVE",
                                                    "DECEASED"});
            this.comboStatus.Location = new Point(268, 397);
            this.comboStatus.Size = new Size(170, 27);
            this.comboStatus.TabIndex = 5;
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Text = "Select status...";

            // Label : Sex
            this.lblSex.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblSex.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblSex.Location = new Point(457, 363);
            this.lblSex.Size = new Size(35, 22);
            this.lblSex.AutoSize = true;
            this.lblSex.Name = "lblSex";
            this.lblSex.Text = "Sex";

            // ComboBox : Sex
            this.comboSex.BackColor = Color.FromArgb(250, 250, 250);
            this.comboSex.FlatStyle = FlatStyle.Flat;
            this.comboSex.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.comboSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboSex.Location = new Point(461, 397);
            this.comboSex.Size = new Size(137, 27);
            this.comboSex.TabIndex = 6;
            this.comboSex.FormattingEnabled = true;
            this.comboSex.Name = "comboSex";
            this.comboSex.Text = "Select sex...";

            // Label : Address
            this.lblAddress.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblAddress.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblAddress.Location = new Point(74, 468);
            this.lblAddress.Size = new Size(83, 22);
            this.lblAddress.AutoSize = true;
            this.lblAddress.Text = "Address";
            this.lblAddress.Name = "lblAddress";

            // Textbox : Address
            this.txtAddress.BackColor = Color.FromArgb(250, 250, 250);
            this.txtAddress.BorderStyle = BorderStyle.None;
            this.txtAddress.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtAddress.Size = new Size(528, 21);
            this.txtAddress.Location = new Point(74, 504);
            this.txtAddress.TabIndex = 7;
            this.txtAddress.Name = "txtAddress";

            // Button
            this.btnAction.BackColor = Color.FromArgb(2, 117, 216);
            this.btnAction.FlatStyle = FlatStyle.Flat;
            this.btnAction.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnAction.ForeColor = Color.FromArgb(247, 247, 247);
            this.btnAction.Location = new Point(501, 575);
            this.btnAction.Size = new Size(97, 37);
            this.btnAction.TabIndex = 8;
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Name = "btnAction";
            this.btnAction.Text = "Action";
            this.btnAction.Click += new EventHandler(this.ActionOnClick);

            // designs
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dsnLlbl.ForeColor = Color.FromArgb(241, 246, 249);
            this.dsnLlbl.Location = new Point(10, 11);
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.Text = "Barangay Management Information System";
            this.dsnBox.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnBox.Location = new Point(-2, -2);
            this.dsnBox.Name = "dsnBox";
            this.dsnBox.Size = new Size(678, 51);
            this.dsnBox.TabStop = false;
            this.dsnLine.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine.Location = new Point(70, 207);
            this.dsnLine.Name = "dsnLine";
            this.dsnLine.Size = new Size(237, 3);
            this.dsnLine.TabStop = false;
            this.dsnLine1.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine1.Location = new Point(361, 207);
            this.dsnLine1.Name = "dsnLine1";
            this.dsnLine1.Size = new Size(237, 3);
            this.dsnLine1.TabStop = false;
            this.dsnLine2.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine2.Location = new Point(70, 310);
            this.dsnLine2.Name = "dsnLine2";
            this.dsnLine2.Size = new Size(528, 3);
            this.dsnLine2.TabStop = false;
            this.dnsLine3.BackColor = Color.FromArgb(57, 72, 103);
            this.dnsLine3.Location = new Point(70, 423);
            this.dnsLine3.Name = "dnsLine3";
            this.dnsLine3.Size = new Size(175, 3);
            this.dnsLine3.TabStop = false;
            this.dsnLine4.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine4.Location = new Point(268, 423);
            this.dsnLine4.Name = "dsnLine4";
            this.dsnLine4.Size = new Size(170, 3);
            this.dsnLine4.TabStop = false;
            this.dsnLine5.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine5.Location = new Point(74, 529);
            this.dsnLine5.Name = "dsnLine5";
            this.dsnLine5.Size = new Size(528, 3);
            this.dsnLine5.TabStop = false;
            this.dsnLine6.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine6.Location = new Point(461, 423);
            this.dsnLine6.Name = "dsnLine6";
            this.dsnLine6.Size = new Size(137, 3);
            this.dsnLine6.TabStop = false;


            // Actual Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 246, 249);
            this.BackgroundImageLayout = ImageLayout.None;
            this.ClientSize = new Size(672, 651);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "AddEditResident";
            this.Text = "Resident";
            this.Load += new EventHandler(this.FormLoad);
            this.FormClosed += new FormClosedEventHandler(ViewContext.FormOnClose);

            // Load Controls
            this.Controls.Add(this.lblResidents);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.lblBirthdate);
            this.Controls.Add(this.pickerBirthdate);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.comboSex);
            this.Controls.Add(this.btnAction);

            this.Controls.Add(this.dsnLine);
            this.Controls.Add(this.dsnLine1);
            this.Controls.Add(this.dsnLine2);
            this.Controls.Add(this.dnsLine3);
            this.Controls.Add(this.dsnLine4);
            this.Controls.Add(this.dsnLine5);
            this.Controls.Add(this.dsnLine6);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        /* Components */
        private Label lblResidents;
        
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblMiddleName;
        private TextBox txtMiddleName;
        private Label lblLastName;
        private TextBox txtLastName;

        private Label lblBirthdate;
        private DateTimePicker pickerBirthdate;

        private Label lblStatus;
        private ComboBox comboStatus;

        private Label lblAddress;
        private TextBox txtAddress;

        private Label lblSex;
        private ComboBox comboSex;

        private Button btnAction;

        private PictureBox dsnLine;
        private PictureBox dsnLine1;
        private PictureBox dsnLine2;
        private PictureBox dnsLine3;
        private PictureBox dsnLine4;
        private PictureBox dsnLine5;
        private PictureBox dsnLine6;
        private PictureBox dsnBox;
        private Label dsnLlbl;
    }
}
