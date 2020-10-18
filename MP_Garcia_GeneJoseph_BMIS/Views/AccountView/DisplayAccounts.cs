using MP_Garcia_GeneJoseph_BMIS.Helpers;
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
    class DisplayAccounts : Form, IAccount
    {
        public DisplayAccounts()
        {
            this.InitComponents();
        }

        private Account account = new Account();
        public Account Account{ get { return account; } set { account = value; } }
        private List<Account> accounts = new List<Account>();
        public List<Account> Accounts { get { return accounts; } set { accounts = value; } }

        public void PopulateDataList()
        {
            this.dataList.DataSource = this.accounts;
            this.dataList.Columns["AccountId"].Visible = false;
            this.dataList.Columns["Password"].Visible = false;
            this.dataList.Columns["Resident"].Visible = false;
            this.dataList.Columns["ResidentId"].Visible = false;

            // button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            this.dataList.Columns.Add(btn);
            btn.HeaderText = "Delete Account";
            btn.Text = "Delete";
            btn.Name = "btnDelete";
            btn.UseColumnTextForButtonValue = true;
        }

        // Listeners
        private void DeleteAccountClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string strId = this.dataList.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = 0;

                if (int.TryParse(strId, out id))
                {
                    Account toDelete = this.accounts.Where(m => m.AccountId == id).FirstOrDefault();

                    if (toDelete != null)
                        if (toDelete.AccountStatus == SystemConstants.ACCOUNT_STATUS_ARCHIVED) MessageBox.Show("Account already archived, please see the status type.", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else new AccountPresenter().DeleteAccount(id);

                }
            }
        }

        private void InitComponents()
        {
            // init
            DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dsnBox         = new PictureBox();
            this.dsnLlbl        = new Label();
            this.lblAccounts    = new Label();
            this.dataList       = new DataGridView();

            // Label for Accounts
            this.lblAccounts.AutoSize = true;
            this.lblAccounts.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccounts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblAccounts.Location = new System.Drawing.Point(18, 79);
            this.lblAccounts.Name = "lblAccounts";
            this.lblAccounts.Size = new System.Drawing.Size(179, 24);
            this.lblAccounts.Text = "Registered Accounts";

            // DataGridView for Registered Accounts
            this.dataList.AllowUserToAddRows = false;
            this.dataList.AllowUserToDeleteRows = false;
            this.dataList.AllowUserToResizeColumns = false;
            this.dataList.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dataList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dataList.BorderStyle = BorderStyle.None;
            this.dataList.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataList.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            this.dataList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            this.dataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataList.ColumnHeadersHeight = 35;
            this.dataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(164)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            this.dataList.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dataList.Location = new System.Drawing.Point(15, 125);
            this.dataList.MultiSelect = false;
            this.dataList.Name = "dataList";
            this.dataList.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(164)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            this.dataList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataList.RowTemplate.Height = 35;
            this.dataList.RowTemplate.ReadOnly = true;
            this.dataList.RowTemplate.Resizable = DataGridViewTriState.False;
            this.dataList.Size = new System.Drawing.Size(857, 436);
            this.dataList.CellClick += new DataGridViewCellEventHandler(this.DeleteAccountClick);

            // Design Components
            this.dsnBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnBox.Location = new System.Drawing.Point(-2, 0);
            this.dsnBox.Name = "dsnBox";
            this.dsnBox.Size = new System.Drawing.Size(888, 51);
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLlbl.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsnLlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dsnLlbl.Location = new System.Drawing.Point(10, 13);
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Size = new System.Drawing.Size(372, 24);
            this.dsnLlbl.Text = "Barangay Management Information System";

            // Actual Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "RegisterAccountView";
            this.Text = "RegisterAccountView";

            // Load Components to Form
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.lblAccounts);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        private PictureBox dsnBox;
        private Label dsnLlbl;
        private Label lblAccounts;
        private DataGridView dataList;
    }
}
