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

        }

        private void InitComponents()
        {
            // initialize components
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            this.dsnBox = new PictureBox();
            this.dsnLlbl = new Label();
            this.lblAuditTrails = new Label();
            this.dataList = new DataGridView();

            // Label : Audit trail
            this.lblAuditTrails.AutoSize = true;
            this.lblAuditTrails.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditTrails.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblAuditTrails.Location = new Point(18, 79);
            this.lblAuditTrails.Name = "lblAuditTrails";
            this.lblAuditTrails.Size = new Size(106, 24);
            this.lblAuditTrails.TabIndex = 3;
            this.lblAuditTrails.Text = "Audit Trails";

            // DataGridView : Audit Trails
            this.dataList.AllowUserToAddRows = false;
            this.dataList.AllowUserToDeleteRows = false;
            this.dataList.AllowUserToResizeColumns = false;
            this.dataList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = Color.Black;
            this.dataList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataList.BackgroundColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dataList.BorderStyle = BorderStyle.None;
            this.dataList.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataList.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            this.dataList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle2.Font = new Font("Calibri", 11.75F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            this.dataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataList.ColumnHeadersHeight = 40;
            this.dataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Calibri", 11.75F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            this.dataList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataList.GridColor = Color.Black;
            this.dataList.Location = new Point(15, 129);
            this.dataList.MultiSelect = false;
            this.dataList.Name = "dataList";
            this.dataList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(164)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            this.dataList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataList.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataList.RowTemplate.Height = 40;
            this.dataList.RowTemplate.ReadOnly = true;
            this.dataList.RowTemplate.Resizable = DataGridViewTriState.False;
            this.dataList.Size = new Size(857, 436);

            // Design
            this.dsnBox.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnBox.Location = new Point(-2, 0);
            this.dsnBox.Name = "dsnBox";
            this.dsnBox.Size = new Size(888, 51);
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.dsnLlbl.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dsnLlbl.Location = new Point(10, 13);
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.Text = "Barangay Management Information System";

            // Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new Size(884, 561);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "DisplayAuditTrailView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Audit Trails";

            // Load Controls
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.lblAuditTrails);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        private PictureBox dsnBox;
        private Label dsnLlbl;
        private Label lblAuditTrails;
        private DataGridView dataList;

    }
}
