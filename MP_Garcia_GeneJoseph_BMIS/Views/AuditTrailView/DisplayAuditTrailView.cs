using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Views.AuditTrailView
{
    class DisplayAuditTrailView : Form, IAuditTrail
    {
        public DisplayAuditTrailView()
        {
            this.InitComponents();
        }

        private AuditTrail auditTrail = new AuditTrail();
        public AuditTrail AuditTrail { get { return this.auditTrail; } set { this.auditTrail = value; } }
        private List<AuditTrail> auditTrails = new List<AuditTrail>();
        public List<AuditTrail> AuditTrails { get { return this.auditTrails; } set { this.auditTrails = value; } }

        public void PopulateDataList()
        {
            this.dataList.ColumnCount = 3;
            this.dataList.Columns[0].Name = "Username";
            this.dataList.Columns[1].Name = "Action";
            this.dataList.Columns[2].Name = "Date Action";

            this.dataList.Columns[0].Width = 100;
            this.dataList.Columns[2].Width = 200;

            string[] row;
            foreach (var trail in this.auditTrails)
            {
                row = new string[]
                {
                    trail.Account.Username,
                    trail.Message,
                    trail.ActionDate.ToString()
                };
                this.dataList.Rows.Add(row);
            }
        }

        private void InitComponents()
        {
            // initialize components
            this.lblAuditTrails = new Label();
            this.dataList = new DataGridView();

            this.dsnBox = new PictureBox();
            this.dsnLlbl = new Label();

            // Label : Audit trail
            this.lblAuditTrails.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblAuditTrails.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblAuditTrails.Location = new Point(18, 79);
            this.lblAuditTrails.Size = new Size(106, 24);
            this.lblAuditTrails.AutoSize = true;
            this.lblAuditTrails.Name = "lblAuditTrails";
            this.lblAuditTrails.Text = "Audit Trails";

            // DataGridView : Audit Trails
            DataGridViewCellStyle dgvcs1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs4 = new DataGridViewCellStyle();
            dgvcs1.BackColor = Color.FromArgb(244, 244, 244);
            dgvcs1.Font = new Font("Calibri", 11.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvcs1.ForeColor = Color.Black;
            dgvcs2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs2.BackColor = Color.FromArgb(20, 39, 78);
            dgvcs2.Font = new Font("Calibri", 11.75F);
            dgvcs2.ForeColor = Color.FromArgb(241, 246, 249);
            dgvcs2.SelectionBackColor = Color.FromArgb(217, 236, 242);
            dgvcs2.SelectionForeColor = SystemColors.Desktop;
            dgvcs2.WrapMode = DataGridViewTriState.True;
            dgvcs3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs3.BackColor = Color.White;
            dgvcs3.Font = new Font("Calibri", 11.75F);
            dgvcs3.ForeColor = Color.Black;
            dgvcs3.SelectionBackColor = Color.FromArgb(235, 236, 241);
            dgvcs3.SelectionForeColor = Color.Black;
            dgvcs3.WrapMode = DataGridViewTriState.False;
            dgvcs4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs4.BackColor = Color.FromArgb(155, 164, 180);
            dgvcs4.Font = new Font("Calibri", 11.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvcs4.ForeColor = SystemColors.WindowText;
            dgvcs4.SelectionBackColor = Color.FromArgb(20, 39, 78);
            dgvcs4.SelectionForeColor = SystemColors.HighlightText;
            dgvcs4.WrapMode = DataGridViewTriState.True;
            this.dataList.RowHeadersDefaultCellStyle = dgvcs4;
            this.dataList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataList.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataList.RowTemplate.Height = 40;
            this.dataList.RowTemplate.Resizable = DataGridViewTriState.False;
            this.dataList.Size = new Size(857, 436);
            this.dataList.DefaultCellStyle = dgvcs3;
            this.dataList.GridColor = Color.Black;
            this.dataList.Location = new Point(15, 129);
            this.dataList.MultiSelect = false;
            this.dataList.ColumnHeadersDefaultCellStyle = dgvcs2;
            this.dataList.ColumnHeadersHeight = 40;
            this.dataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataList.AlternatingRowsDefaultCellStyle = dgvcs1;
            this.dataList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataList.BackgroundColor = Color.FromArgb(241, 246, 249);
            this.dataList.BorderStyle = BorderStyle.None;
            this.dataList.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataList.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            this.dataList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataList.RowTemplate.ReadOnly = true;
            this.dataList.AllowUserToAddRows = false;
            this.dataList.AllowUserToDeleteRows = false;
            this.dataList.AllowUserToResizeColumns = false;
            this.dataList.AllowUserToResizeRows = false;
            this.dataList.ReadOnly = true;
            this.dataList.Name = "dataList";

            // Design
            this.dsnBox.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnBox.Location = new Point(-2, 0);
            this.dsnBox.Size = new Size(888, 51);
            this.dsnBox.Name = "dsnBox";
            this.dsnLlbl.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dsnLlbl.ForeColor = Color.FromArgb(241, 246, 249);
            this.dsnLlbl.Location = new Point(10, 13);
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Text = "Barangay Management Information System";

            // Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 246, 249);
            this.ClientSize = new Size(884, 561);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Name = "DisplayAuditTrailView";
            this.Text = "Audit Trails";
            this.FormClosed += new FormClosedEventHandler(ViewContext.FormOnClose);

            // Load Controls
            this.Controls.Add(this.lblAuditTrails);
            this.Controls.Add(this.dataList);

            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        /* Components */
        private Label lblAuditTrails;
        private DataGridView dataList;

        private PictureBox dsnBox;
        private Label dsnLlbl;

    }
}
