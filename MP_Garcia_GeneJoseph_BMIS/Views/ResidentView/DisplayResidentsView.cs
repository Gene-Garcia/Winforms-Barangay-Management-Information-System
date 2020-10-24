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
    class DisplayResidentsView : Form, IResident
    {
        public DisplayResidentsView()
        {
            this.InitComponents();
        }

        private List<Resident> residents = new List<Resident>();
        public List<Resident> Residents { get { return residents; } set { residents = value; } }

        private Resident resident = new Resident();
        public Resident Resident { get { return resident; } set { resident = value; } }

        public void PopulateDataList()
        {
            this.dataList.DataSource = this.residents;
            this.dataList.Columns["ResidentId"].Visible = false;
            this.dataList.Columns["Sex"].Visible = false;
            this.dataList.Columns["Birthdate"].Visible = false;
            this.dataList.Columns["Address"].Visible = false;

            // button view and edit
            DataGridViewButtonColumn viewEditBtn = new DataGridViewButtonColumn();

            this.dataList.Columns.Add(viewEditBtn);
            viewEditBtn.HeaderText = "View & Edit Record";
            viewEditBtn.Text = "Select";
            viewEditBtn.Name = "btnSelect";
            viewEditBtn.UseColumnTextForButtonValue = true;

            // set to deceased button
            DataGridViewButtonColumn setDeceasedBtn = new DataGridViewButtonColumn();

            this.dataList.Columns.Add(setDeceasedBtn);
            setDeceasedBtn.HeaderText = "Set as Deceased";
            setDeceasedBtn.Text = "Select";
            setDeceasedBtn.Name = "btnDeceased";
            setDeceasedBtn.UseColumnTextForButtonValue = true;
        }

        // Listeners
        private void RegisterResidentClick(object sender, DataGridViewCellEventArgs e)
        {
            // view and edit
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                string strId = this.dataList.Rows[e.RowIndex].Cells[2].Value.ToString();
                int id = 0;

                if (int.TryParse(strId, out id))
                {
                    this.resident = this.residents.Where(m => m.ResidentId == id).FirstOrDefault();

                    if (this.resident != null)
                        new ResidentPresenter().GetViewResident(resident.ResidentId);
                }
            }

            // set deceased
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                string strId = this.dataList.Rows[e.RowIndex].Cells[2].Value.ToString();
                int id = 0;

                if (int.TryParse(strId, out id))
                {
                    this.resident = this.residents.Where(m => m.ResidentId == id).FirstOrDefault();

                    if (this.resident != null)
                        new ResidentPresenter().PostToResidentDeceased(resident.ResidentId);
                }
            }
        }

        private void InitComponents()
        {
            // initialize components
            this.lblResidents = new Label();
            this.dataList = new DataGridView();

            this.dsnBox = new PictureBox();
            this.dsnLlbl = new Label();

            // Label for Accounts
            this.lblResidents.AutoSize = true;
            this.lblResidents.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblResidents.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblResidents.Location = new Point(18, 79);
            this.lblResidents.Name = "lblResidents";
            this.lblResidents.Size = new Size(179, 24);
            this.lblResidents.Text = "Barangay Residents";

            // DataGridView for Registered Accounts
            DataGridViewCellStyle dgvcs1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs4 = new DataGridViewCellStyle();
            dgvcs1.BackColor = Color.FromArgb(244, 244, 244);
            dgvcs1.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvcs1.ForeColor = Color.Black;            
            dgvcs2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs2.BackColor = Color.FromArgb(20, 39, 78);
            dgvcs2.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvcs2.ForeColor = Color.FromArgb(241, 246, 249);
            dgvcs2.SelectionBackColor = Color.FromArgb(217, 236, 242);
            dgvcs2.SelectionForeColor = SystemColors.Desktop;
            dgvcs2.WrapMode = DataGridViewTriState.True;            
            dgvcs3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs3.BackColor = Color.White;
            dgvcs3.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvcs3.ForeColor = Color.Black;
            dgvcs3.SelectionBackColor = Color.FromArgb(235, 236, 241);
            dgvcs3.SelectionForeColor = Color.Black;
            dgvcs3.WrapMode = DataGridViewTriState.False;            
            dgvcs4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs4.BackColor = Color.FromArgb(155, 164, 180);
            dgvcs4.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvcs4.ForeColor = SystemColors.WindowText;
            dgvcs4.SelectionBackColor = Color.FromArgb(20, 39, 78);
            dgvcs4.SelectionForeColor = SystemColors.HighlightText;
            dgvcs4.WrapMode = DataGridViewTriState.True;
            this.dataList.AlternatingRowsDefaultCellStyle = dgvcs1;
            this.dataList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataList.BackgroundColor = Color.FromArgb(241, 246, 249);
            this.dataList.BorderStyle = BorderStyle.None;
            this.dataList.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataList.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            this.dataList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataList.ColumnHeadersDefaultCellStyle = dgvcs2;
            this.dataList.ColumnHeadersHeight = 40;
            this.dataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataList.RowHeadersDefaultCellStyle = dgvcs4;
            this.dataList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataList.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataList.RowTemplate.DefaultCellStyle.BackColor = Color.Empty;
            this.dataList.RowTemplate.DefaultCellStyle.ForeColor = Color.Empty;
            this.dataList.RowTemplate.Height = 40;
            this.dataList.RowTemplate.Resizable = DataGridViewTriState.False;
            this.dataList.Size = new Size(857, 436);
            this.dataList.DefaultCellStyle = dgvcs3;
            this.dataList.GridColor = Color.Black;
            this.dataList.Location = new Point(15, 125);
            this.dataList.AllowUserToAddRows = false;
            this.dataList.AllowUserToDeleteRows = false;
            this.dataList.AllowUserToResizeColumns = false;
            this.dataList.AllowUserToResizeRows = false;
            this.dataList.RowTemplate.ReadOnly = true;
            this.dataList.MultiSelect = false;
            this.dataList.ReadOnly = true;
            this.dataList.Name = "dataList";
            this.dataList.CellClick += new DataGridViewCellEventHandler(this.RegisterResidentClick);

            // Design Components
            this.dsnBox.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnBox.Location = new Point(-2, 0);
            this.dsnBox.Name = "dsnBox";
            this.dsnBox.Size = new Size(888, 51);
            this.dsnLlbl.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dsnLlbl.ForeColor = Color.FromArgb(241, 246, 249);
            this.dsnLlbl.Location = new Point(10, 13);
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.Text = "Barangay Management Information System";
            this.dsnLlbl.Name = "dsnLlbl";

            // Actual Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 246, 249);
            this.ClientSize = new Size(884, 561);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Name = "DisplayResidentsView";
            this.Text = "Residents";
            this.FormClosed += new FormClosedEventHandler(ViewContext.FormOnClose);

            // Load Components to Form
            this.Controls.Add(this.lblResidents);
            this.Controls.Add(this.dataList);

            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        /* Components */
        private Label lblResidents;
        private DataGridView dataList;

        private PictureBox dsnBox;
        private Label dsnLlbl;
    }
}
