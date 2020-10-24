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

namespace MP_Garcia_GeneJoseph_BMIS.Views.AccountView
{
    class MyAccountView : Form, IAccount
    {
        public MyAccountView()
        {
            this.InitComponents();
        }

        private Account account = new Account();
        public Account Account { get { return account; } set { account = value; } }
        private List<Account> accounts = new List<Account>();
        public List<Account> Accounts { get { return accounts; } set { accounts = value; } }

        public void ModelToFields()
        {
            this.txtFirstName.Text = this.account.Resident.FirstName;
            this.txtMiddleName.Text = this.account.Resident.MiddleName;
            this.txtLastName.Text = this.account.Resident.LastName;

            this.txtUsername.Text = this.account.Username;
        }

        //listeners
        private void ChangePasswordOnclick(object sender, EventArgs e)
        {
            string oldPass = this.txtOldPassword.Text;
            string newPass = this.txtNewPassword.Text;

            if (oldPass != null && oldPass != "" && newPass != null && newPass != "")
                if (oldPass == newPass)
                    new AccountPresenter().PostUpdatePassword(newPass);
                else MessageBox.Show("Old password and new password does not match.", "My Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else MessageBox.Show("Fill out password fields.", "My Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void InitComponents()
        {
            // Initialize Components
            this.lblMyAccount = new Label();
            this.dsnLlbl = new Label();
            this.dsnBox = new PictureBox();
            this.lblFirstName = new Label();
            this.txtFirstName = new TextBox();
            this.dsnLine = new PictureBox();
            this.dsnLine1 = new PictureBox();
            this.txtMiddleName = new TextBox();
            this.lblMiddleName = new Label();
            this.dsnLine2 = new PictureBox();
            this.txtLastName = new TextBox();
            this.lblLastName = new Label();
            this.dsnLine3 = new PictureBox();
            this.txtUsername = new TextBox();
            this.lblUsername = new Label();
            this.btnChangePassword = new Button();
            this.dsnLine4 = new PictureBox();
            this.txtOldPassword = new TextBox();
            this.lblOldPassword = new Label();
            this.dsnLine5 = new PictureBox();
            this.txtNewPassword = new TextBox();
            this.lblNewPassword = new Label();

            // Label My Account
            this.lblMyAccount.AutoSize = true;
            this.lblMyAccount.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblMyAccount.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblMyAccount.Location = new Point(59, 83);
            this.lblMyAccount.Name = "lblMyAccount";
            this.lblMyAccount.Size = new Size(105, 24);
            this.lblMyAccount.Text = "My Account";

            // Label First Name
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblFirstName.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblFirstName.Location = new Point(60, 146);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new Size(86, 22);
            this.lblFirstName.Text = "First Name";

            // Textbox First Name
            this.txtFirstName.BackColor = Color.FromArgb(250, 250, 250);
            this.txtFirstName.BorderStyle = BorderStyle.None;
            this.txtFirstName.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtFirstName.Location = new Point(60, 182);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new Size(175, 21);
            this.txtFirstName.TabIndex = 1;

            // Label Middle Name
            this.txtMiddleName.BackColor = Color.FromArgb(250, 250, 250);
            this.txtMiddleName.BorderStyle = BorderStyle.None;
            this.txtMiddleName.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtMiddleName.Location = new Point(256, 182);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new Size(175, 21);

            // Textbox Middle Name
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblMiddleName.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblMiddleName.Location = new Point(256, 146);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new Size(102, 22);
            this.lblMiddleName.TabIndex = 2;
            this.lblMiddleName.Text = "Middle Name";

            // Label Last Name
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblLastName.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblLastName.Location = new Point(451, 146);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new Size(83, 22);
            this.lblLastName.Text = "Last Name";

            // Textbox Last Name
            this.txtLastName.BackColor = Color.FromArgb(250, 250, 250);
            this.txtLastName.BorderStyle = BorderStyle.None;
            this.txtLastName.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtLastName.Location = new Point(451, 182);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new Size(175, 21);
            this.txtLastName.TabIndex = 3;

            // Label Username
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblUsername.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblUsername.Location = new Point(60, 258);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(79, 22);
            this.lblUsername.Text = "Username";

            // Textbox Username
            this.txtUsername.BackColor = Color.FromArgb(250, 250, 250);
            this.txtUsername.BorderStyle = BorderStyle.None;
            this.txtUsername.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtUsername.Location = new Point(60, 294);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(566, 21);
            this.txtUsername.TabIndex = 4;

            // Label Old Pass
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblOldPassword.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblOldPassword.Location = new Point(56, 388);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new Size(104, 22);
            this.lblOldPassword.Text = "Old Password";

            // Textbox Old Pass
            this.txtOldPassword.BackColor = Color.FromArgb(250, 250, 250);
            this.txtOldPassword.BorderStyle = BorderStyle.None;
            this.txtOldPassword.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtOldPassword.Location = new Point(60, 424);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '•';
            this.txtOldPassword.Size = new Size(263, 21);
            this.txtOldPassword.TabIndex = 5;

            // Label New Pass
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblNewPassword.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblNewPassword.Location = new Point(359, 388);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new Size(112, 22);
            this.lblNewPassword.Text = "New Password";

            // Textbox New Pass
            this.txtNewPassword.BackColor = Color.FromArgb(250, 250, 250);
            this.txtNewPassword.BorderStyle = BorderStyle.None;
            this.txtNewPassword.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtNewPassword.Location = new Point(363, 424);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.Size = new Size(263, 21);
            this.txtNewPassword.TabIndex = 6;

            // Button Change Pass
            this.btnChangePassword.BackColor = Color.FromArgb(2, 117, 216);
            this.btnChangePassword.FlatStyle = FlatStyle.Flat;
            this.btnChangePassword.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnChangePassword.ForeColor = Color.FromArgb(247, 247, 247);
            this.btnChangePassword.Location = new Point(455, 501);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new Size(171, 37);
            this.btnChangePassword.TabIndex = 7;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new EventHandler(this.ChangePasswordOnclick);

            // Design Components
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
            this.dsnLine.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine.Location = new Point(60, 207);
            this.dsnLine.Name = "dsnLine";
            this.dsnLine.Size = new Size(175, 3);
            this.dsnLine1.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine1.Location = new Point(256, 207);
            this.dsnLine1.Name = "dsnLine1";
            this.dsnLine1.Size = new Size(175, 3);
            this.dsnLine2.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine2.Location = new Point(451, 207);
            this.dsnLine2.Name = "dsnLine2";
            this.dsnLine2.Size = new Size(175, 3);
            this.dsnLine3.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine3.Location = new Point(60, 319);
            this.dsnLine3.Name = "dsnLine3";
            this.dsnLine3.Size = new Size(566, 3);
            this.dsnLine4.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine4.Location = new Point(60, 449);
            this.dsnLine4.Name = "dsnLine4";
            this.dsnLine4.Size = new Size(263, 3);
            this.dsnLine5.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine5.Location = new Point(363, 449);
            this.dsnLine5.Name = "dsnLine5";
            this.dsnLine5.Size = new Size(263, 3);

            // Forms
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 246, 249);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.ClientSize = new Size(672, 569);
            this.Name = "MyAccountView";
            this.Text = "My Account";
            this.FormClosed += new FormClosedEventHandler(ViewContext.FormOnClose);

            // Load controls
            this.Controls.Add(this.lblMyAccount);

            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);

            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.btnChangePassword);

            this.Controls.Add(this.dsnLine);
            this.Controls.Add(this.dsnLine1);
            this.Controls.Add(this.dsnLine2);
            this.Controls.Add(this.dsnLine3);
            this.Controls.Add(this.dsnLine4);
            this.Controls.Add(this.dsnLine5);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        /* Components */
        private Label lblMyAccount;

        private Label lblFirstName;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private Label lblMiddleName;
        private TextBox txtLastName;
        private Label lblLastName;

        private TextBox txtUsername;
        private Label lblUsername;

        private TextBox txtOldPassword;
        private Label lblOldPassword;
        private TextBox txtNewPassword;
        private Label lblNewPassword;
        private Button btnChangePassword;

        private PictureBox dsnLine5;
        private PictureBox dsnLine4;
        private PictureBox dsnLine;
        private Label dsnLlbl;
        private PictureBox dsnLine1;
        private PictureBox dsnLine2;
        private PictureBox dsnLine3;
        private PictureBox dsnBox;

    }
}
