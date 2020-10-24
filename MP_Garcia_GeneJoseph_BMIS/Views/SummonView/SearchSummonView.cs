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

namespace MP_Garcia_GeneJoseph_BMIS.Views.SummonView
{
    class SearchSummonView : Form, ISummon
    {
        public SearchSummonView()
        {
            this.InitComponents();
        }

        private Summon summon = new Summon();
        public Summon Summon { get { return this.summon; } set { this.summon = value; } }
        private List<Summon> summons = new List<Summon>();
        public List<Summon> Summons { get { return this.summons; } set { this.summons = value; } }

        private bool FieldToModel()
        {
            int summonId;

            if (int.TryParse(this.txtSummonId.Text, out summonId))
            {
                this.summon.SummonId = summonId;
                return true;
            }
            MessageBox.Show("Summon Ids are usually numeric values only", "Search Summon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // listeners
        private void SearchOnClick(object sender, EventArgs e)
        {
            if (this.FieldToModel())
                new SummonPresenter().GetDisplaySummon(this.summon.SummonId);
        }

        private void InitComponents()
        {
            // Init components
            this.lblSearchSummon = new Label();

            this.lblSearchId = new Label();
            this.txtSummonId = new TextBox();
            this.btnSearch = new Button();

            this.dsnLine = new PictureBox();
            this.dsnLlbl = new Label();
            this.dsnBox = new PictureBox();

            // Label : Search
            this.lblSearchSummon.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchSummon.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblSearchSummon.Location = new Point(73, 83);
            this.lblSearchSummon.Size = new Size(144, 24);
            this.lblSearchSummon.AutoSize = true;
            this.lblSearchSummon.Name = "lblSearchSummon";
            this.lblSearchSummon.Text = "Search Summon";

            // Lable : Summon id
            this.lblSearchId.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchId.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblSearchId.Location = new Point(73, 154);
            this.lblSearchId.Size = new Size(88, 22);
            this.lblSearchId.AutoSize = true;
            this.lblSearchId.Name = "lblSearchId";
            this.lblSearchId.Text = "Summon ID";

            // TextBox : Summon id
            this.txtSummonId.BackColor = Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtSummonId.BorderStyle = BorderStyle.None;
            this.txtSummonId.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.txtSummonId.Location = new Point(76, 190);
            this.txtSummonId.Size = new Size(344, 24);
            this.txtSummonId.Name = "txtFirstName";
            this.txtSummonId.TabIndex = 1;

            // Button : Search
            this.btnSearch.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnSearch.Location = new Point(323, 276);
            this.btnSearch.Size = new Size(97, 37);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new EventHandler(this.SearchOnClick);

            // Design
            this.dsnLlbl.AutoSize = true;
            this.dsnLlbl.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.dsnLlbl.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dsnLlbl.Location = new Point(13, 12);
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Text = "Barangay Management Information System";
            this.dsnLine.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLine.Location = new Point(75, 217);
            this.dsnLine.Size = new Size(344, 3);
            this.dsnLine.Name = "dsnLine";
            this.dsnBox.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnBox.Location = new Point(1, -1);
            this.dsnBox.Size = new Size(504, 51);
            this.dsnBox.Name = "dsnBox";

            // Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new Size(500, 350);            
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Name = "SearchSummonView";
            this.Text = "Search Summon";
            this.FormClosed += new FormClosedEventHandler(ViewContext.FormOnClose);

            // Load Controls
            this.Controls.Add(this.lblSearchSummon);

            this.Controls.Add(this.txtSummonId);
            this.Controls.Add(this.lblSearchId);
            this.Controls.Add(this.btnSearch);

            this.Controls.Add(this.dsnLine);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);
        }

        /* Components */
        private Label lblSearchSummon;

        private TextBox txtSummonId;
        private Label lblSearchId;
        private Button btnSearch;

        private PictureBox dsnLine;
        private Label dsnLlbl;
        private PictureBox dsnBox;
    }
}
