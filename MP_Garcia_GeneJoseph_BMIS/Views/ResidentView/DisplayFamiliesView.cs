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
    class DisplayFamiliesView : Form, IFamilies
    {
        public DisplayFamiliesView()
        {
            this.InitComponents();
        }

        private List<Family> families = new List<Family>();
        public List<Family> Families { get { return families; } set { families = value; } }

        private Family family = new Family();
        public Family Family { get { return family; } set { family = value; } }

        public void PopulateDataList()
        {
            this.dataList.ColumnCount = 4;
            this.dataList.Columns[0].Name = "FamilyId";
            this.dataList.Columns[0].Visible = false;
            this.dataList.Columns[1].Name = "First Parent";
            this.dataList.Columns[2].Name = "Second Parent";
            this.dataList.Columns[3].Name = "Family Members";

            string[] row;
            foreach (var family in this.families)
            {
                string parentOneName = family.ParentOne.LastName.ToUpper() + ", " + family.ParentOne.FirstName + ", " + family.ParentOne.MiddleName;
                
                string parentTwoName = "";
                if (family.ParentTwo != null)
                    parentTwoName = family.ParentTwo.LastName.ToUpper() + ", " + family.ParentTwo.FirstName + ", " + family.ParentTwo.MiddleName;

                row = new string[]
                {
                    family.FamilyId.ToString(),
                    parentOneName,
                    parentTwoName,
                    family.FamilyMembers.ToString()
                };
                this.dataList.Rows.Add(row);
            }

            DataGridViewButtonColumn viewEditBtn = new DataGridViewButtonColumn();

            this.dataList.Columns.Add(viewEditBtn);
            viewEditBtn.HeaderText = "Change Family Size";
            viewEditBtn.Text = "Select";
            viewEditBtn.Name = "btnSelect";
            viewEditBtn.UseColumnTextForButtonValue = true;
        }

        private int GetFamilySize()
        {
            int newFamSize;
            bool valid = false;

            MessageBox.Show("Enter new family size in the Command Line.");

            do
            {
                Console.Write("\n\tNew family size >>");
                valid = int.TryParse(Console.ReadLine(), out newFamSize);

                if (!valid)
                    Console.WriteLine("\tNumeric input only.");
            } while (!valid);         

            return newFamSize;
        }

        // listeners
        private void DataListOnClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                string strId = this.dataList.Rows[e.RowIndex].Cells[0].Value.ToString();
                int id = 0;

                if (int.TryParse(strId, out id))
                {
                    this.family = this.families.Where(m => m.FamilyId == id).FirstOrDefault();

                    if (this.family != null)
                    {
                        int famSize = this.GetFamilySize();
                        new ResidentPresenter().PostChangeFamilySize(family.FamilyId, famSize);
                    }
                }
            }
        }

        private void InitComponents()
        {
            // Initialize Components
            this.lblFamilies = new Label();
            this.dataList = new DataGridView();

            this.dsnBox = new PictureBox();
            this.dsnLlbl = new Label();

            // Label : Family Records
            this.lblFamilies.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblFamilies.ForeColor = Color.FromArgb(20, 39, 78);
            this.lblFamilies.Location = new Point(18, 79);
            this.lblFamilies.Size = new Size(137, 24);
            this.lblFamilies.AutoSize = true;
            this.lblFamilies.Name = "lblFamilies";
            this.lblFamilies.Text = "Family Records";

            // DataList : Families
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
            this.dataList.RowHeadersDefaultCellStyle = dgvcs4;
            this.dataList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataList.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataList.RowTemplate.Height = 40;
            this.dataList.RowTemplate.Resizable = DataGridViewTriState.False;
            this.dataList.Size = new Size(857, 436);
            this.dataList.DefaultCellStyle = dgvcs3;
            this.dataList.GridColor = Color.Black;
            this.dataList.Location = new Point(15, 129);
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
            this.dataList.MultiSelect = false;
            this.dataList.RowTemplate.ReadOnly = true;
            this.dataList.ReadOnly = true;
            this.dataList.AllowUserToAddRows = false;
            this.dataList.AllowUserToDeleteRows = false;
            this.dataList.AllowUserToResizeColumns = false;
            this.dataList.AllowUserToResizeRows = false;
            this.dataList.Name = "dataList";
            this.dataList.CellClick += new DataGridViewCellEventHandler(this.DataListOnClick);

            // Design Components
            this.dsnBox.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnBox.Location = new Point(-2, 0);
            this.dsnBox.Name = "dsnBox";
            this.dsnBox.Size = new Size(888, 51);
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.BackColor = Color.FromArgb(57, 72, 103);
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dsnLlbl.ForeColor = Color.FromArgb(241, 246, 249);
            this.dsnLlbl.Location = new Point(10, 13);
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.Text = "Barangay Management Information System";

            // Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 246, 249);
            this.ClientSize = new Size(884, 561);            
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Text = "Families";
            this.Name = "DisplayFamiliesView";
            this.FormClosed += new FormClosedEventHandler(ViewContext.FormOnClose);

            // Load controls to form
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.lblFamilies);

            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        /* Components */
        private Label lblFamilies;
        private DataGridView dataList;
        private PictureBox dsnBox;
        private Label dsnLlbl;
    }
}
