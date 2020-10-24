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
    class LoginView : Form, IAccount
    {
        public LoginView()
        {
            InitComponents();
        }

        private Account account = new Account();
        public Account Account { get { return account; } set { account = value; } }
        private List<Account> accounts = new List<Account>();
        public List<Account> Accounts { get { return accounts; } set { accounts = value; } }

        private void TextToModel()
        {
            this.account.Username = this.txtUsername.Text;
            this.account.Password = this.txtPassword.Text;
        }

        private bool ValidateFields()
        {
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Text;
            if (username == null || username == "" || password == null || username == "")
            {
                MessageBox.Show("Username and password cannot be empty.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Listeners
        private void LoginClick(object sender, EventArgs e)
        {
            if (this.ValidateFields())
            {
                this.TextToModel();
                new AccountPresenter().PostLogin(this);
            }
        }

        private void InitComponents()
        {
            // Instantiate components
            this.lblLogin = new Label();

            this.lblUsername = new Label();
            this.txtUsername = new TextBox();

            this.lblPassword = new Label();
            this.txtPassword = new TextBox();

            this.btnLogin = new Button();

            this.dsnBox = new PictureBox();
            this.dsnLine = new PictureBox();
            this.dsnLine1 = new PictureBox();

            // Main Label
            this.lblLogin.Font = new Font("Trebuchet MS", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblLogin.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblLogin.Location = new Point(126, 31);
            this.lblLogin.Size = new Size(115, 27);
            this.lblLogin.AutoSize = true;
            this.lblLogin.Text = "User Login";
            this.lblLogin.Name = "lblLogin";

            // Label for Username
            this.lblUsername.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblUsername.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblUsername.Location = new Point(33, 123);
            this.lblUsername.Size = new Size(84, 22);
            this.lblUsername.AutoSize = true;
            this.lblUsername.Text = "Username";
            this.lblUsername.Name = "lblUsername";

            // Textbox for Username
            this.txtUsername.BackColor = Color.FromArgb(234, 245, 255);
            this.txtUsername.BorderStyle = BorderStyle.None;
            this.txtUsername.Font = new Font("Trebuchet MS", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtUsername.ForeColor = Color.Black;
            this.txtUsername.Location = new Point(32, 158);
            this.txtUsername.Margin = new Padding(5);
            this.txtUsername.Size = new Size(320, 20);
            this.txtUsername.TextAlign = HorizontalAlignment.Center;
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Name = "txtUsername";

            // Label for Password
            this.lblPassword.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblPassword.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblPassword.Location = new Point(33, 242);
            this.lblPassword.Size = new Size(75, 22);
            this.lblPassword.AutoSize = true;
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Password";

            // Textbox for Password
            this.txtPassword.BackColor = Color.FromArgb(234, 245, 255);
            this.txtPassword.BorderStyle = BorderStyle.None;
            this.txtPassword.Font = new Font("Trebuchet MS", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtPassword.ForeColor = Color.Black;
            this.txtPassword.Location = new Point(32, 277);
            this.txtPassword.Margin = new Padding(5);
            this.txtPassword.Size = new Size(320, 20);
            this.txtPassword.TextAlign = HorizontalAlignment.Center;
            this.txtPassword.TabIndex = 2;
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Name = "txtPassword";


            // Button for Login
            this.btnLogin.BackColor = Color.FromArgb(2, 117, 216);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnLogin.ForeColor = Color.FromArgb(247, 247, 247);
            this.btnLogin.Location = new Point(32, 355);
            this.btnLogin.Size = new Size(97, 37);
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new EventHandler(this.LoginClick);

            // Design
            this.dsnBox.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnBox.Location = new Point(384, 1);
            this.dsnBox.Size = new Size(400, 460);
            this.dsnBox.Name = "dsnBox";
            this.dsnLine.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine.Location = new Point(32, 182);
            this.dsnLine.Size = new Size(320, 3);
            this.dsnLine.Name = "dsnLine";
            this.dsnLine1.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine1.Location = new Point(32, 301);
            this.dsnLine1.Size = new Size(320, 3);
            this.dsnLine1.Name = "dsnLine1";

            // Actual Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(234, 245, 255);
            this.ClientSize = new Size(784, 461);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Name = "LoginView";
            this.Text = "Login";

            // Load Components to Form
            this.Controls.Add(this.lblLogin);

            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);

            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);

            this.Controls.Add(this.btnLogin);

            this.Controls.Add(this.dsnLine);
            this.Controls.Add(this.dsnLine1);
            this.Controls.Add(this.dsnBox);
        }

        /* Components */
        private Label lblLogin;

        private Label lblUsername;
        private TextBox txtUsername;

        private Label lblPassword;
        private TextBox txtPassword;

        private Button btnLogin;

        private PictureBox dsnBox;
        private PictureBox dsnLine;
        private PictureBox dsnLine1;
    }
}
