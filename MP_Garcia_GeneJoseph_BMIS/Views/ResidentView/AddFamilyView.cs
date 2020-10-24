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
    class AddFamilyView : Form, IResident
    {
        public AddFamilyView()
        {
            this.InitComponents();
        }

        private List<Resident> residents = new List<Resident>();
        public List<Resident> Residents { get { return residents; } set { residents = value; } }

        private Resident resident = new Resident();
        public Resident Resident { get { return resident; } set { resident = value; } }

        private int parentOneId;
        private int parentTwoId;

        public void PopulateFirstDataList()
        {
            this.dataListPrnt1.DataSource = this.residents;
            this.dataListPrnt1.Columns["ResidentId"].Visible = false;
            this.dataListPrnt1.Columns["Sex"].Visible = false;
            this.dataListPrnt1.Columns["Birthdate"].Visible = false;
            this.dataListPrnt1.Columns["Address"].Visible = false;
            this.dataListPrnt1.Columns["Status"].Visible = false;
        }

        public void PopulateSecondDataList(int toExclude)
        {

            this.dataListPrnt2.DataSource = this.residents.Where(m=>m.ResidentId != toExclude).ToList();
            this.dataListPrnt2.Columns["ResidentId"].Visible = false;
            this.dataListPrnt2.Columns["Sex"].Visible = false;
            this.dataListPrnt2.Columns["Birthdate"].Visible = false;
            this.dataListPrnt2.Columns["Address"].Visible = false;
            this.dataListPrnt2.Columns["Status"].Visible = false;
        }

        // listeners
        private void DataListOnSelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataListPrnt1.SelectedRows)
            {
                string strId = row.Cells[0].Value.ToString();
                int id = int.Parse(strId);
                this.PopulateSecondDataList(id);

            }
        }
        private void CreateOnClick(object sender, EventArgs e)
        {
            int familyMembers = 0;
            bool valid = true;

            if (this.dataListPrnt1.SelectedRows.Count == 1)
                foreach (DataGridViewRow row in this.dataListPrnt1.SelectedRows)
                {
                    string strId = row.Cells[0].Value.ToString();
                    parentOneId = int.Parse(strId);
                }
            else
                valid = false;

            if (valid)
                if (this.dataListPrnt2.SelectedRows.Count == 1)
                    foreach (DataGridViewRow row in this.dataListPrnt2.SelectedRows)
                    {
                        string strId = row.Cells[0].Value.ToString();
                        parentTwoId = int.Parse(strId);
                    }

            familyMembers = int.Parse(this.numFamilyMember.Value.ToString());

            if (valid)
            {
                new ResidentPresenter().PostSaveFamily(parentOneId, parentTwoId, familyMembers);
            }
            else
            {
                MessageBox.Show("First parent is required, and the second parent is optional for single-parents.", "Add Family", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitComponents()
        {
            // component initialization
            this.lblResidents = new Label();
            this.lblParent1 = new Label();
            this.lblParent2 = new Label();
            this.dataListPrnt1 = new DataGridView();
            this.dataListPrnt2 = new DataGridView();
            this.dsnLine = new PictureBox();
            this.lblFamilyMembers = new Label();
            this.numFamilyMember = new NumericUpDown();
            this.btnCreate = new Button();
            this.dsnLlbl = new Label();
            this.dsnBox = new PictureBox();

            // Label : Resident
            this.lblResidents.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblResidents.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblResidents.Location = new Point(39, 80);
            this.lblResidents.Size = new Size(90, 24);
            this.lblResidents.AutoSize = true;
            this.lblResidents.Name = "lblResidents";
            this.lblResidents.Text = "Residents";

            // Label : First Parent
            this.lblParent1.Font = new Font("Trebuchet MS", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblParent1.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblParent1.Location = new Point(40, 136);
            this.lblParent1.Size = new Size(83, 20);
            this.lblParent1.AutoSize = true;
            this.lblParent1.Name = "lblParent1";
            this.lblParent1.Text = "Parent One";

            // DataGridView: First set of residents
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
            this.dataListPrnt1.RowHeadersDefaultCellStyle = dgvcs4;
            this.dataListPrnt1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataListPrnt1.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataListPrnt1.RowTemplate.Height = 40;
            this.dataListPrnt1.RowTemplate.Resizable = DataGridViewTriState.False;
            this.dataListPrnt1.Size = new Size(376, 423);
            this.dataListPrnt1.DefaultCellStyle = dgvcs3;
            this.dataListPrnt1.GridColor = Color.Black;
            this.dataListPrnt1.Location = new Point(37, 162);
            this.dataListPrnt1.ColumnHeadersDefaultCellStyle = dgvcs2;
            this.dataListPrnt1.ColumnHeadersHeight = 40;
            this.dataListPrnt1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataListPrnt1.AlternatingRowsDefaultCellStyle = dgvcs1;
            this.dataListPrnt1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataListPrnt1.BackgroundColor = Color.FromArgb(241, 246, 249);
            this.dataListPrnt1.BorderStyle = BorderStyle.None;
            this.dataListPrnt1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataListPrnt1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            this.dataListPrnt1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataListPrnt1.AllowUserToAddRows = false;
            this.dataListPrnt1.AllowUserToDeleteRows = false;
            this.dataListPrnt1.AllowUserToResizeColumns = false;
            this.dataListPrnt1.AllowUserToResizeRows = false;
            this.dataListPrnt1.MultiSelect = false;
            this.dataListPrnt1.ReadOnly = true;
            this.dataListPrnt1.RowTemplate.ReadOnly = true;
            this.dataListPrnt1.Name = "dataListPrnt1";
            this.dataListPrnt1.SelectionChanged += new EventHandler(this.DataListOnSelectionChanged);

            // Label : Second Parent
            this.lblParent2.Font = new Font("Trebuchet MS", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblParent2.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblParent2.Location = new Point(466, 136);
            this.lblParent2.Size = new Size(173, 20);
            this.lblParent2.AutoSize = true;
            this.lblParent2.Name = "lblParent2";
            this.lblParent2.Text = "Second Parent (optional)";

            // DataGridView : Second set of residents
            DataGridViewCellStyle dgvcs5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvcs8 = new DataGridViewCellStyle();
            dgvcs5.BackColor = Color.FromArgb(244, 244, 244);
            dgvcs5.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvcs5.ForeColor = Color.Black;
            dgvcs6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs6.BackColor = Color.FromArgb(20, 39, 78);
            dgvcs6.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvcs6.ForeColor = Color.FromArgb(241, 246, 249);
            dgvcs6.SelectionBackColor = Color.FromArgb(217, 236, 242);
            dgvcs6.SelectionForeColor = SystemColors.Desktop;
            dgvcs6.WrapMode = DataGridViewTriState.True;
            dgvcs7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs7.BackColor = Color.White;
            dgvcs7.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvcs7.ForeColor = Color.Black;
            dgvcs7.SelectionBackColor = Color.FromArgb(235, 236, 241);
            dgvcs7.SelectionForeColor = Color.Black;
            dgvcs7.WrapMode = DataGridViewTriState.False;
            dgvcs8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcs8.BackColor = Color.FromArgb(155, 164, 180);
            dgvcs8.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvcs8.ForeColor = SystemColors.WindowText;
            dgvcs8.SelectionBackColor = Color.FromArgb(20, 39, 78);
            dgvcs8.SelectionForeColor = SystemColors.HighlightText;
            dgvcs8.WrapMode = DataGridViewTriState.True;
            this.dataListPrnt2.RowHeadersDefaultCellStyle = dgvcs8;
            this.dataListPrnt2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataListPrnt2.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataListPrnt2.RowTemplate.Height = 40;
            this.dataListPrnt2.RowTemplate.Resizable = DataGridViewTriState.False;
            this.dataListPrnt2.Size = new Size(376, 423);
            this.dataListPrnt2.ColumnHeadersDefaultCellStyle = dgvcs6;
            this.dataListPrnt2.ColumnHeadersHeight = 40;
            this.dataListPrnt2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataListPrnt2.AlternatingRowsDefaultCellStyle = dgvcs5;
            this.dataListPrnt2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataListPrnt2.BackgroundColor = Color.FromArgb(241, 246, 249);
            this.dataListPrnt2.BorderStyle = BorderStyle.None;
            this.dataListPrnt2.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataListPrnt2.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            this.dataListPrnt2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataListPrnt2.DefaultCellStyle = dgvcs7;
            this.dataListPrnt2.GridColor = Color.Black;
            this.dataListPrnt2.Location = new Point(466, 162);
            this.dataListPrnt2.RowTemplate.ReadOnly = true;
            this.dataListPrnt2.AllowUserToAddRows = false;
            this.dataListPrnt2.AllowUserToDeleteRows = false;
            this.dataListPrnt2.AllowUserToResizeColumns = false;
            this.dataListPrnt2.AllowUserToResizeRows = false;
            this.dataListPrnt2.ReadOnly = true;
            this.dataListPrnt2.MultiSelect = false;
            this.dataListPrnt2.Name = "dataListPrnt2";

            // Label : Family Members
            this.lblFamilyMembers.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblFamilyMembers.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblFamilyMembers.Location = new Point(49, 626);
            this.lblFamilyMembers.Size = new Size(124, 22);
            this.lblFamilyMembers.AutoSize = true;
            this.lblFamilyMembers.Name = "lblFirstName";
            this.lblFamilyMembers.Text = "Family Members";

            // Number : Family Members 
            this.numFamilyMember.BackColor = Color.FromArgb(250, 250, 250);
            this.numFamilyMember.BorderStyle = BorderStyle.None;
            this.numFamilyMember.Font = new Font("Calibri", 12.75F, FontStyle.Bold);
            this.numFamilyMember.Location = new Point(183, 627);
            this.numFamilyMember.Size = new Size(156, 24);
            this.numFamilyMember.TabIndex = 1;
            this.numFamilyMember.Value = 0;
            this.numFamilyMember.Name = "numFamilyMember";

            // Button
            this.btnCreate.BackColor = Color.FromArgb(2, 117, 216);
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnCreate.ForeColor = Color.FromArgb(247, 247, 247);
            this.btnCreate.Location = new Point(745, 618);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new Size(97, 37);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new EventHandler(this.CreateOnClick);

            // Design Components
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dsnLlbl.ForeColor = Color.FromArgb(241, 246, 249);
            this.dsnLlbl.Location = new Point(9, 12);
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.Text = "Barangay Management Information System";
            this.dsnBox.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnBox.Location = new Point(-3, -1);
            this.dsnBox.Name = "dsnBox";
            this.dsnBox.Size = new Size(888, 51);
            this.dsnLine.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLine.Location = new Point(183, 652);
            this.dsnLine.Name = "dsnLine";
            this.dsnLine.Size = new Size(156, 3);

            // Actual Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 246, 249);
            this.ClientSize = new Size(884, 713);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "AddFamilyView";
            this.Text = "AddFamilyView";
            this.MaximizeBox = false;
            this.FormClosed += new FormClosedEventHandler(ViewContext.FormOnClose);

            // Load Control into Form
            this.Controls.Add(this.lblResidents);

            this.Controls.Add(this.lblParent1);
            this.Controls.Add(this.dataListPrnt1);

            this.Controls.Add(this.lblParent2);
            this.Controls.Add(this.dataListPrnt2);

            this.Controls.Add(this.lblFamilyMembers);
            this.Controls.Add(this.numFamilyMember);

            this.Controls.Add(this.btnCreate);

            this.Controls.Add(this.dsnLine);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        /* Components */
        private Label dsnLlbl;
        private PictureBox dsnBox;

        private Label lblResidents;
        private Label lblParent1;
        private DataGridView dataListPrnt1;
        private Label lblParent2;
        private DataGridView dataListPrnt2;
        private Label lblFamilyMembers;
        private NumericUpDown numFamilyMember;
        private PictureBox dsnLine;
        private Button btnCreate;
    }
}
