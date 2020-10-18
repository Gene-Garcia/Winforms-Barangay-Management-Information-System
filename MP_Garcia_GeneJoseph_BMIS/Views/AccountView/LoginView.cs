using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Presenters;
using System;
using System.Collections.Generic;
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
        public List<Account> Accounts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            this.dsnBox         = new PictureBox();
            this.dsnLine = new PictureBox();
            this.dsnLine1 = new PictureBox();

            this.lblLogin       = new Label();
            this.lblUsername    = new Label();
            this.txtUsername    = new TextBox();
            this.lblPassword    = new Label();
            this.txtPassword    = new TextBox();
            this.btnLogin       = new Button();

            // Main Label
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Trebuchet MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblLogin.Location = new System.Drawing.Point(126, 31);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(115, 27);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "User Login";

            // Label for Username
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblUsername.Location = new System.Drawing.Point(33, 123);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(84, 22);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";

            // Textboc for Username
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Trebuchet MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(32, 158);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(320, 20);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // Label for Password
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblPassword.Location = new System.Drawing.Point(33, 242);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(75, 22);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";

            // Textbox for Password
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Trebuchet MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(32, 277);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(320, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;


            // Button for Login
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnLogin.Location = new System.Drawing.Point(32, 355);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(97, 37);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.LoginClick);

            // Components for Aesthetics
            this.dsnBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnBox.Location = new System.Drawing.Point(384, 1);
            this.dsnBox.Name = "dsnBox";
            this.dsnBox.Size = new System.Drawing.Size(400, 460);
            this.dsnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine.Location = new System.Drawing.Point(32, 182);
            this.dsnLine.Name = "dsnLine";
            this.dsnLine.Size = new System.Drawing.Size(320, 3);
            this.dsnLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine1.Location = new System.Drawing.Point(32, 301);
            this.dsnLine1.Name = "dsnLine1";
            this.dsnLine1.Size = new System.Drawing.Size(320, 3);

            // Actual Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "LoginView";
            this.Text = "Login";

            // Load Components to Form
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.dsnLine1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.dsnLine);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.dsnBox);
        }

        /* Components */
        private Label lblLogin;
        private Label lblUsername;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnLogin;

        private PictureBox dsnBox;
        private PictureBox dsnLine;
        private PictureBox dsnLine1;
    }
}
