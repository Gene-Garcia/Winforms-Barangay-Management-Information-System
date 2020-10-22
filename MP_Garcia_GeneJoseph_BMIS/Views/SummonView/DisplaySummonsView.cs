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
    class DisplaySummonsView : Form, ISummon
    {
        public DisplaySummonsView()
        {
            this.InitComponents();
        }

        private Summon summon = new Summon();
        public Summon Summon { get { return this.summon; } set { this.summon = value; } }
        private List<Summon> summons = new List<Summon>();
        public List<Summon> Summons { get { return this.summons; } set { this.summons = value; } }

        public void PopulateDataList()
        {
            this.dataList.DataSource = this.summons;
            this.dataList.Columns["Summary"].Visible = false;
            this.dataList.Columns["Account"].Visible = false;
            this.dataList.Columns["AccountId"].Visible = false;

            DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();

            this.dataList.Columns.Add(viewBtn);
            viewBtn.HeaderText = "View Record";
            viewBtn.Text = "Select";
            viewBtn.Name = "btnSelect";
            viewBtn.UseColumnTextForButtonValue = true;
        }

        // listeners
        private void DataListOnClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                string strId = this.dataList.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = 0;

                if (int.TryParse(strId, out id))
                {
                    this.summon = this.summons.Where(m => m.SummonId == id).FirstOrDefault();

                    if (this.summon != null)
                        new SummonPresenter().GetDisplaySummon(this.summon.SummonId);

                }
            }
        }

        private void InitComponents()
        {
            // initialize components
            DataGridViewCellStyle dgvcs1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs4 = new DataGridViewCellStyle();
            this.dsnBox = new PictureBox();
            this.dsnLlbl = new Label();
            this.lblSummons = new Label();
            this.dataList = new DataGridView();

            // Label : Summons
            this.lblSummons.AutoSize = true;
            this.lblSummons.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblSummons.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblSummons.Location = new Point(18, 79);
            this.lblSummons.Name = "lblSummons";
            this.lblSummons.Size = new Size(137, 24);
            this.lblSummons.Text = "Summon Reports";

            // DataList : Summons
            this.dataList.AllowUserToAddRows = false;
            this.dataList.AllowUserToDeleteRows = false;
            this.dataList.AllowUserToResizeColumns = false;
            this.dataList.AllowUserToResizeRows = false;
            dgvcs1.BackColor = Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dgvcs1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dgvcs1.ForeColor = Color.Black;
            this.dataList.AlternatingRowsDefaultCellStyle = dgvcs1;
            this.dataList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataList.BackgroundColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dataList.BorderStyle = BorderStyle.None;
            this.dataList.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataList.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            this.dataList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvcs2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs2.BackColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            dgvcs2.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dgvcs2.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            dgvcs2.SelectionBackColor = Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            dgvcs2.SelectionForeColor = SystemColors.Desktop;
            dgvcs2.WrapMode = DataGridViewTriState.True;
            this.dataList.ColumnHeadersDefaultCellStyle = dgvcs2;
            this.dataList.ColumnHeadersHeight = 40;
            this.dataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvcs3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs3.BackColor = Color.White;
            dgvcs3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dgvcs3.ForeColor = Color.Black;
            dgvcs3.SelectionBackColor = Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dgvcs3.SelectionForeColor = Color.Black;
            dgvcs3.WrapMode = DataGridViewTriState.False;
            this.dataList.DefaultCellStyle = dgvcs3;
            this.dataList.GridColor = Color.Black;
            this.dataList.Location = new Point(15, 129);
            this.dataList.MultiSelect = false;
            this.dataList.Name = "dataList";
            this.dataList.ReadOnly = true;
            dgvcs4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs4.BackColor = Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(164)))), ((int)(((byte)(180)))));
            dgvcs4.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dgvcs4.ForeColor = SystemColors.WindowText;
            dgvcs4.SelectionBackColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            dgvcs4.SelectionForeColor = SystemColors.HighlightText;
            dgvcs4.WrapMode = DataGridViewTriState.True;
            this.dataList.RowHeadersDefaultCellStyle = dgvcs4;
            this.dataList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataList.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataList.RowTemplate.Height = 40;
            this.dataList.RowTemplate.ReadOnly = true;
            this.dataList.RowTemplate.Resizable = DataGridViewTriState.False;
            this.dataList.Size = new Size(857, 436);
            this.dataList.TabIndex = 4;
            this.dataList.CellClick += new DataGridViewCellEventHandler(this.DataListOnClick);

            // Design components
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
            this.Name = "SummonReportsView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Summon Reports";

            // Load controls to form
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.lblSummons);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        private PictureBox dsnBox;
        private Label dsnLlbl;
        private Label lblSummons;
        private DataGridView dataList;

    }
}
