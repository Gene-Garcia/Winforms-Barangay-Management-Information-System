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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            this.dsnBox = new PictureBox();
            this.dsnLlbl = new Label();
            this.lblFamilies = new Label();
            this.dataList = new DataGridView();

            // Label : Family Records
            this.lblFamilies.AutoSize = true;
            this.lblFamilies.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamilies.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblFamilies.Location = new Point(18, 79);
            this.lblFamilies.Name = "lblFamilies";
            this.lblFamilies.Size = new Size(137, 24);
            this.lblFamilies.Text = "Family Records";

            // DataList : Families
            this.dataList.AllowUserToAddRows = false;
            this.dataList.AllowUserToDeleteRows = false;
            this.dataList.AllowUserToResizeColumns = false;
            this.dataList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.Font = new Font("Trebuchet MS", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle2.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            this.dataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataList.ColumnHeadersHeight = 40;
            this.dataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
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
            this.dataList.TabIndex = 1;
            this.dataList.CellClick += new DataGridViewCellEventHandler(this.DataListOnClick);

            // Design Components
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
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.lblFamilies);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "DisplayFamiliesView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Families";

            // Load controls to form
        }

        private PictureBox dsnBox;
        private Label dsnLlbl;
        private Label lblFamilies;
        private DataGridView dataList;

    }
}
