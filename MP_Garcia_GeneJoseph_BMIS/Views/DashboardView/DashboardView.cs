using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Views.DashboardView
{
    class DashboardView : Form, IDashboard
    {
        public DashboardView()
        {
            this.InitComponents();
        }

        private Dashboard dashboard = new Dashboard();
        public Dashboard Dashboard { get { return this.dashboard; }  set { this.dashboard = value; } }

        public void PopulateBoxes()
        {

        }

        private void InitComponents()
        {
            // Initialize Components
            this.dsnLlbl = new Label();
            this.dsnBox = new PictureBox();

            this.lblDashboard = new Label();
            this.lblResident = new Label();
            this.lblResidentsAge = new Label();
            this.lblRegisteredFamilies = new Label();

            this.lblTotalResData = new Label();
            this.lblTotalRes = new Label();
            this.boxTotalResidents = new PictureBox();
            this.lblMaleData = new Label();
            this.lblMale = new Label();
            this.boxMale = new PictureBox();
            this.boxFemale = new PictureBox();
            this.lblFemale = new Label();
            this.lblFemaleData = new Label();
            this.lblAliveData = new Label();
            this.lblAlive = new Label();
            this.boxAlive = new PictureBox();
            this.lblDeceasedData = new Label();
            this.lblDeceased = new Label();
            this.boxDeceased = new PictureBox();

            this.lblAverageAgeData = new Label();
            this.lblAverageAge = new Label();
            this.boxAverageAge = new PictureBox();
            this.lblAgeCateg1Data = new Label();
            this.lblAgeCateg1 = new Label();
            this.boxAgeCateg1 = new PictureBox();
            this.lblAgeCateg2Data = new Label();
            this.lblAgeCateg2 = new Label();
            this.boxAgeCateg2 = new PictureBox();
            this.lblAgeCateg3Data = new Label();
            this.lblAgeCateg3 = new Label();
            this.boxAgeCateg3 = new PictureBox();
            this.lblAgeCateg4Data = new Label();
            this.lblAgeCateg4 = new Label();
            this.boxAgeCateg4 = new PictureBox();

            this.lblFamiliesData = new Label();
            this.lblFamilies = new Label();
            this.boxFamilies = new PictureBox();
            this.lblFamCateg1Data = new Label();
            this.lblFamCateg1 = new Label();
            this.boxFamCateg1 = new PictureBox();
            this.lblFamCateg2Data = new Label();
            this.lblFamCateg2 = new Label();
            this.boxFamCateg2 = new PictureBox();
            this.lblFamCateg3Data = new Label();
            this.lblFamCateg3 = new Label();
            this.boxFamCateg3 = new PictureBox();
            this.lblFamCateg4Data = new Label();
            this.lblFamCateg4 = new Label();
            this.boxFamCateg4 = new PictureBox();          

            // Label : Dashboard
            this.lblDashboard.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblDashboard.Location = new Point(27, 79);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new Size(99, 24);
            this.lblDashboard.Text = "Dashboard";

            // Label : Residents
            this.lblResident.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblResident.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblResident.Location = new Point(30, 128);
            this.lblResident.Name = "lblResident";
            this.lblResident.Size = new Size(156, 22);
            this.lblResident.Text = "Registered Residents";

            // Data 1 : Total Residents
            this.lblTotalRes.BackColor = Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lblTotalRes.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRes.ForeColor = Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.lblTotalRes.Location = new Point(42, 185);
            this.lblTotalRes.Name = "lblTotalRes";
            this.lblTotalRes.Size = new Size(123, 22);
            this.lblTotalRes.Text = "Total Residents";
            this.boxTotalResidents.BackColor = Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.boxTotalResidents.Location = new Point(31, 172);
            this.boxTotalResidents.Name = "boxTotalResidents";
            this.boxTotalResidents.Size = new Size(175, 111);
            this.lblTotalResData.BackColor = Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lblTotalResData.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalResData.ForeColor = Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.lblTotalResData.Location = new Point(153, 223);
            this.lblTotalResData.Name = "lblTotalResData";
            this.lblTotalResData.Size = new Size(40, 43);

            // Data 2: Male
            this.lblMaleData.BackColor = Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(199)))), ((int)(((byte)(236)))));
            this.lblMaleData.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblMaleData.ForeColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(37)))), ((int)(((byte)(76)))));
            this.lblMaleData.Location = new Point(356, 223);
            this.lblMaleData.Name = "lblMaleData";
            this.lblMaleData.Size = new Size(40, 43);
            this.lblMaleData.Text = "0";
            this.lblMale.BackColor = Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(199)))), ((int)(((byte)(236)))));
            this.lblMale.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblMale.ForeColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(37)))), ((int)(((byte)(76)))));
            this.lblMale.Location = new Point(245, 185);
            this.lblMale.Name = "lblMale";
            this.lblMale.Size = new Size(44, 22);
            this.lblMale.Text = "Male"; 
            this.boxMale.BackColor = Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(199)))), ((int)(((byte)(236)))));
            this.boxMale.Location = new Point(234, 172);
            this.boxMale.Name = "boxMale";
            this.boxMale.Size = new Size(175, 111);

            // Date 3: Female
            this.boxFemale.BackColor = Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(123)))), ((int)(((byte)(205)))));
            this.boxFemale.Location = new Point(441, 172);
            this.boxFemale.Name = "boxFemale";
            this.boxFemale.Size = new Size(175, 111);
            this.lblFemale.BackColor = Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(123)))), ((int)(((byte)(205)))));
            this.lblFemale.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFemale.ForeColor = Color.White;
            this.lblFemale.Location = new Point(452, 185);
            this.lblFemale.Name = "lblFemale";
            this.lblFemale.Size = new Size(63, 22);
            this.lblFemale.Text = "Female";
            this.lblFemaleData.BackColor = Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(123)))), ((int)(((byte)(205)))));
            this.lblFemaleData.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFemaleData.ForeColor = Color.White;
            this.lblFemaleData.Location = new Point(563, 223);
            this.lblFemaleData.Name = "lblFemaleData";
            this.lblFemaleData.Size = new Size(40, 43);
            this.lblFemaleData.Text = "0";

            // Data 4: Alive
            this.lblAliveData.BackColor = Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(103)))), ((int)(((byte)(177)))));
            this.lblAliveData.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAliveData.ForeColor = Color.White;
            this.lblAliveData.Location = new Point(770, 223);
            this.lblAliveData.Name = "lblAliveData";
            this.lblAliveData.Size = new Size(40, 43);
            this.lblAliveData.Text = "0";
            this.lblAlive.BackColor = Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(103)))), ((int)(((byte)(177)))));
            this.lblAlive.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAlive.ForeColor = Color.White;
            this.lblAlive.Location = new Point(659, 185);
            this.lblAlive.Name = "lblAlive";
            this.lblAlive.Size = new Size(47, 22);
            this.lblAlive.Text = "Alive";
            this.boxAlive.BackColor = Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(103)))), ((int)(((byte)(177)))));
            this.boxAlive.Location = new Point(648, 172);
            this.boxAlive.Name = "boxAlive";
            this.boxAlive.Size = new Size(175, 111);

            // Data 5: Deceased
            this.lblDeceasedData.AutoSize = true;
            this.lblDeceasedData.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(37)))), ((int)(((byte)(76)))));
            this.lblDeceasedData.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblDeceasedData.ForeColor = Color.White;
            this.lblDeceasedData.Location = new Point(979, 223);
            this.lblDeceasedData.Name = "lblDeceasedData";
            this.lblDeceasedData.Size = new Size(40, 43);
            this.lblDeceasedData.Text = "0";
            this.lblDeceased.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(37)))), ((int)(((byte)(76)))));
            this.lblDeceased.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblDeceased.ForeColor = Color.White;
            this.lblDeceased.Location = new Point(868, 185);
            this.lblDeceased.Name = "lblDeceased";
            this.lblDeceased.Size = new Size(81, 22);
            this.lblDeceased.Text = "Deceased";
            this.boxDeceased.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(37)))), ((int)(((byte)(76)))));
            this.boxDeceased.Location = new Point(857, 172);
            this.boxDeceased.Name = "boxDeceased";
            this.boxDeceased.Size = new Size(175, 111);

            // Label : Resident Age
            this.lblResidentsAge.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblResidentsAge.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblResidentsAge.Location = new Point(30, 313);
            this.lblResidentsAge.Name = "lblResidentsAge";
            this.lblResidentsAge.Size = new Size(100, 22);
            this.lblResidentsAge.Text = "Resident Age";

            // Data 1 : Average age
            this.lblAverageAgeData.AutoSize = true;
            this.lblAverageAgeData.BackColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblAverageAgeData.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageAgeData.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.lblAverageAgeData.Location = new Point(153, 408);
            this.lblAverageAgeData.Name = "lblAverageAgeData";
            this.lblAverageAgeData.Size = new Size(40, 43);
            this.lblAverageAgeData.Text = "0";
            this.lblAverageAge.BackColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblAverageAge.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageAge.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.lblAverageAge.Location = new Point(42, 370);
            this.lblAverageAge.Name = "lblAverageAge";
            this.lblAverageAge.Size = new Size(105, 22);
            this.lblAverageAge.Text = "Average Age";
            this.boxAverageAge.BackColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.boxAverageAge.Location = new Point(31, 357);
            this.boxAverageAge.Name = "boxAverageAge";
            this.boxAverageAge.Size = new Size(175, 111);

            // Data 2 : 0 - 16
            this.lblAgeCateg1Data.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.lblAgeCateg1Data.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeCateg1Data.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.lblAgeCateg1Data.Location = new Point(356, 408);
            this.lblAgeCateg1Data.Name = "lblAgeCateg1Data";
            this.lblAgeCateg1Data.Size = new Size(40, 43);
            this.lblAgeCateg1Data.TabIndex = 40;
            this.lblAgeCateg1Data.Text = "0";
            this.lblAgeCateg1.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.lblAgeCateg1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeCateg1.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.lblAgeCateg1.Location = new Point(245, 370);
            this.lblAgeCateg1.Name = "lblAgeCateg1";
            this.lblAgeCateg1.Size = new Size(136, 22);
            this.lblAgeCateg1.Text = "0 to 16 years old";
            this.boxAgeCateg1.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.boxAgeCateg1.Location = new Point(234, 357);
            this.boxAgeCateg1.Name = "boxCateg1";
            this.boxAgeCateg1.Size = new Size(175, 111);

            // Data 3 : 17 - 21
            this.lblAgeCateg2Data.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(122)))));
            this.lblAgeCateg2Data.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeCateg2Data.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.lblAgeCateg2Data.Location = new Point(563, 408);
            this.lblAgeCateg2Data.Name = "lblAgeCateg2Data";
            this.lblAgeCateg2Data.Size = new Size(40, 43);
            this.lblAgeCateg2Data.Text = "0";
            this.lblAgeCateg2.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(122)))));
            this.lblAgeCateg2.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeCateg2.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.lblAgeCateg2.Location = new Point(452, 370);
            this.lblAgeCateg2.Name = "lblAgeCateg2";
            this.lblAgeCateg2.Size = new Size(135, 22);
            this.lblAgeCateg2.Text = "17 - 21 years old";
            this.boxAgeCateg2.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(122)))));
            this.boxAgeCateg2.Location = new Point(441, 357);
            this.boxAgeCateg2.Name = "boxAgeCateg2";
            this.boxAgeCateg2.Size = new Size(175, 111);

            // Data 4 : 22 - 59
            this.lblAgeCateg3Data.BackColor = Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(130)))), ((int)(((byte)(184)))));
            this.lblAgeCateg3Data.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeCateg3Data.ForeColor = Color.White;
            this.lblAgeCateg3Data.Location = new Point(770, 408);
            this.lblAgeCateg3Data.Name = "lblAgeCateg3Data";
            this.lblAgeCateg3Data.Size = new Size(40, 43);
            this.lblAgeCateg3Data.TabIndex = 31;
            this.lblAgeCateg3Data.Text = "0";
            this.lblAgeCateg3.BackColor = Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(130)))), ((int)(((byte)(184)))));
            this.lblAgeCateg3.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeCateg3.ForeColor = Color.White;
            this.lblAgeCateg3.Location = new Point(659, 370);
            this.lblAgeCateg3.Name = "lblAgeCateg3";
            this.lblAgeCateg3.Size = new Size(135, 22);
            this.lblAgeCateg3.Text = "22 - 59 years old";
            this.boxAgeCateg3.BackColor = Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(130)))), ((int)(((byte)(184)))));
            this.boxAgeCateg3.Location = new Point(648, 357);
            this.boxAgeCateg3.Name = "boxAgeCateg3";
            this.boxAgeCateg3.Size = new Size(175, 111);

            // Data 5 : 60 >
            this.lblAgeCateg4Data.BackColor = Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(225)))), ((int)(((byte)(250)))));
            this.lblAgeCateg4Data.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeCateg4Data.ForeColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.lblAgeCateg4Data.Location = new Point(979, 408);
            this.lblAgeCateg4Data.Name = "lblAgeCateg4Data";
            this.lblAgeCateg4Data.Size = new Size(40, 43);
            this.lblAgeCateg4Data.Text = "0";
            this.lblAgeCateg4.BackColor = Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(225)))), ((int)(((byte)(250)))));
            this.lblAgeCateg4.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeCateg4.ForeColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.lblAgeCateg4.Location = new Point(868, 370);
            this.lblAgeCateg4.Name = "lblAgeCateg4";
            this.lblAgeCateg4.Size = new Size(123, 22);
            this.lblAgeCateg4.Text = "Senior Citizens";
            this.boxAgeCateg4.BackColor = Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(225)))), ((int)(((byte)(250)))));
            this.boxAgeCateg4.Location = new Point(857, 357);
            this.boxAgeCateg4.Name = "boxAgeCateg4";
            this.boxAgeCateg4.Size = new Size(175, 111);

            // Label : Register Families
            this.lblRegisteredFamilies.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisteredFamilies.ForeColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(78)))));
            this.lblRegisteredFamilies.Location = new Point(30, 513);
            this.lblRegisteredFamilies.Name = "lblRegisteredFamilies";
            this.lblRegisteredFamilies.Size = new Size(148, 22);
            this.lblRegisteredFamilies.Text = "Registered Families";

            // Data 1 : Registered families
            this.lblFamiliesData.BackColor = Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(199)))), ((int)(((byte)(236)))));
            this.lblFamiliesData.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamiliesData.ForeColor = Color.White;
            this.lblFamiliesData.Location = new Point(153, 608);
            this.lblFamiliesData.Name = "lblFamiliesData";
            this.lblFamiliesData.Size = new Size(40, 43);
            this.lblFamiliesData.Text = "0";
            this.lblFamilies.BackColor = Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(199)))), ((int)(((byte)(236)))));
            this.lblFamilies.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamilies.ForeColor = Color.White;
            this.lblFamilies.Location = new Point(42, 570);
            this.lblFamilies.Name = "lblFamilies";
            this.lblFamilies.Size = new Size(156, 22);
            this.lblFamilies.Text = "Registered Families";
            this.boxFamilies.BackColor = Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(199)))), ((int)(((byte)(236)))));
            this.boxFamilies.Location = new Point(31, 557);
            this.boxFamilies.Name = "boxFamilies";
            this.boxFamilies.Size = new Size(175, 111);

            // Data 2 : 2
            this.lblFamCateg1Data.BackColor = Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(187)))), ((int)(((byte)(215)))));
            this.lblFamCateg1Data.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamCateg1Data.ForeColor = Color.White;
            this.lblFamCateg1Data.Location = new Point(356, 608);
            this.lblFamCateg1Data.Name = "lblFamCateg1Data";
            this.lblFamCateg1Data.Size = new Size(40, 43);
            this.lblFamCateg1Data.Text = "0";
            this.lblFamCateg1.BackColor = Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(187)))), ((int)(((byte)(215)))));
            this.lblFamCateg1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamCateg1.ForeColor = Color.White;
            this.lblFamCateg1.Location = new Point(245, 570);
            this.lblFamCateg1.Name = "lblFamCateg1";
            this.lblFamCateg1.Size = new Size(129, 22);
            this.lblFamCateg1.Text = "Less than 2";
            this.boxFamCateg1.BackColor = Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(187)))), ((int)(((byte)(215)))));
            this.boxFamCateg1.Location = new Point(234, 557);
            this.boxFamCateg1.Name = "boxFamCateg1";
            this.boxFamCateg1.Size = new Size(175, 111);

            // Data 3 : 3 - 4
            this.lblFamCateg2Data.BackColor = Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.lblFamCateg2Data.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamCateg2Data.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.lblFamCateg2Data.Location = new Point(563, 608);
            this.lblFamCateg2Data.Name = "lblFamCateg2Data";
            this.lblFamCateg2Data.Size = new Size(40, 43);
            this.lblFamCateg2Data.Text = "0";
            this.lblFamCateg2.BackColor = Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.lblFamCateg2.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamCateg2.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.lblFamCateg2.Location = new Point(452, 570);
            this.lblFamCateg2.Name = "lblFamCateg2";
            this.lblFamCateg2.Size = new Size(154, 22);
            this.lblFamCateg2.Text = "Family Size of 3 - 4";
            this.boxFamCateg2.BackColor = Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.boxFamCateg2.Location = new Point(441, 557);
            this.boxFamCateg2.Name = "boxFamCateg2";
            this.boxFamCateg2.Size = new Size(175, 111);

            // Data 4 : 5 - 6
            this.lblFamCateg3Data.BackColor = Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(125)))), ((int)(((byte)(172)))));
            this.lblFamCateg3Data.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamCateg3Data.ForeColor = Color.White;
            this.lblFamCateg3Data.Location = new Point(770, 608);
            this.lblFamCateg3Data.Name = "lblFamCateg3Data";
            this.lblFamCateg3Data.Size = new Size(40, 43);
            this.lblFamCateg3Data.Text = "0";
            this.lblFamCateg3.BackColor = Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(125)))), ((int)(((byte)(172)))));
            this.lblFamCateg3.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamCateg3.ForeColor = Color.White;
            this.lblFamCateg3.Location = new Point(659, 570);
            this.lblFamCateg3.Name = "lblFamCateg3";
            this.lblFamCateg3.Size = new Size(154, 22);
            this.lblFamCateg3.Text = "Family Size of 5 - 6";
            this.boxFamCateg3.BackColor = Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(125)))), ((int)(((byte)(172)))));
            this.boxFamCateg3.Location = new Point(648, 557);
            this.boxFamCateg3.Name = "boxFamCateg3";
            this.boxFamCateg3.Size = new Size(175, 111);

            // Data 5 : 6
            this.lblFamCateg4Data.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(115)))));
            this.lblFamCateg4Data.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamCateg4Data.ForeColor = Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
            this.lblFamCateg4Data.Location = new Point(979, 608);
            this.lblFamCateg4Data.Name = "lblFamCateg4Data";
            this.lblFamCateg4Data.Size = new Size(40, 43);
            this.lblFamCateg4Data.Text = "0";
            this.lblFamCateg4.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(115)))));
            this.lblFamCateg4.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblFamCateg4.ForeColor = Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
            this.lblFamCateg4.Location = new Point(868, 570);
            this.lblFamCateg4.Name = "lblFamCateg4";
            this.lblFamCateg4.Size = new Size(100, 22);
            this.lblFamCateg4.Text = "More than 6";
            this.boxFamCateg4.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(115)))));
            this.boxFamCateg4.Location = new Point(857, 557);
            this.boxFamCateg4.Name = "boxFamCateg4";
            this.boxFamCateg4.Size = new Size(175, 111);

            // Design Components
            this.dsnLlbl.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnLlbl.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.dsnLlbl.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dsnLlbl.Location = new Point(12, 13);
            this.dsnLlbl.Size = new Size(372, 24);
            this.dsnLlbl.Name = "dsnLlbl";
            this.dsnLlbl.Text = "Barangay Management Information System";
            this.dsnBox.BackColor = Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.dsnBox.Location = new Point(0, 0);
            this.dsnBox.Size = new Size(1060, 51);
            this.dsnBox.Name = "dsnBox";

            // Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new Size(1060, 717);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Name = "DashboardView";
            this.Text = "Dashboard";

            // Load control to form
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.dsnLlbl);
            this.Controls.Add(this.dsnBox);

            this.Controls.Add(this.lblRegisteredFamilies);
            this.Controls.Add(this.lblResidentsAge);
            this.Controls.Add(this.lblResident);

            this.Controls.Add(this.lblFamiliesData);
            this.Controls.Add(this.lblFamilies);
            this.Controls.Add(this.boxFamilies);
            this.Controls.Add(this.lblFamCateg1Data);
            this.Controls.Add(this.lblFamCateg1);
            this.Controls.Add(this.boxFamCateg1);
            this.Controls.Add(this.lblFamCateg2Data);
            this.Controls.Add(this.lblFamCateg2);
            this.Controls.Add(this.boxFamCateg2);
            this.Controls.Add(this.lblFamCateg3Data);
            this.Controls.Add(this.lblFamCateg3);
            this.Controls.Add(this.boxFamCateg3);
            this.Controls.Add(this.lblFamCateg4Data);
            this.Controls.Add(this.lblFamCateg4);
            this.Controls.Add(this.boxFamCateg4);

            this.Controls.Add(this.lblAverageAgeData);
            this.Controls.Add(this.lblAverageAge);
            this.Controls.Add(this.boxAverageAge);
            this.Controls.Add(this.lblAgeCateg1Data);
            this.Controls.Add(this.lblAgeCateg1);
            this.Controls.Add(this.boxAgeCateg1);
            this.Controls.Add(this.lblAgeCateg2Data);
            this.Controls.Add(this.lblAgeCateg2);
            this.Controls.Add(this.boxAgeCateg2);
            this.Controls.Add(this.lblAgeCateg3Data);
            this.Controls.Add(this.lblAgeCateg3);
            this.Controls.Add(this.boxAgeCateg3);
            this.Controls.Add(this.lblAgeCateg4Data);
            this.Controls.Add(this.lblAgeCateg4);
            this.Controls.Add(this.boxAgeCateg4);

            this.Controls.Add(this.lblTotalResData);
            this.Controls.Add(this.lblTotalRes);
            this.Controls.Add(this.boxTotalResidents);
            this.Controls.Add(this.lblMaleData);
            this.Controls.Add(this.lblMale);
            this.Controls.Add(this.boxMale);
            this.Controls.Add(this.lblFemaleData);
            this.Controls.Add(this.lblFemale);
            this.Controls.Add(this.boxFemale);            
            this.Controls.Add(this.lblAliveData);
            this.Controls.Add(this.lblAlive);
            this.Controls.Add(this.boxAlive);
            this.Controls.Add(this.lblDeceasedData);
            this.Controls.Add(this.lblDeceased);
            this.Controls.Add(this.boxDeceased);
        }

        private Label dsnLlbl;
        private PictureBox dsnBox;

        private Label lblDashboard;
        private Label lblResidentsAge;
        private Label lblResident;
        private Label lblRegisteredFamilies;

        private Label lblTotalResData;
        private Label lblTotalRes;
        private PictureBox boxTotalResidents;
        private Label lblMaleData;
        private Label lblMale;
        private PictureBox boxMale;
        private PictureBox boxFemale;
        private Label lblFemale;
        private Label lblFemaleData;
        private Label lblAliveData;
        private Label lblAlive;
        private PictureBox boxAlive;
        private Label lblDeceasedData;
        private Label lblDeceased;
        private PictureBox boxDeceased;

        private Label lblAverageAgeData;
        private Label lblAverageAge;
        private PictureBox boxAverageAge;
        private Label lblAgeCateg1Data;
        private Label lblAgeCateg1;
        private PictureBox boxAgeCateg1;
        private Label lblAgeCateg2Data;
        private Label lblAgeCateg2;
        private PictureBox boxAgeCateg2;
        private Label lblAgeCateg3Data;
        private Label lblAgeCateg3;
        private PictureBox boxAgeCateg3;
        private Label lblAgeCateg4Data;
        private Label lblAgeCateg4;
        private PictureBox boxAgeCateg4;

        private Label lblFamiliesData;
        private Label lblFamilies;
        private PictureBox boxFamilies;
        private Label lblFamCateg1Data;
        private Label lblFamCateg1;
        private PictureBox boxFamCateg1;
        private Label lblFamCateg2Data;
        private Label lblFamCateg2;
        private PictureBox boxFamCateg2;
        private Label lblFamCateg3Data;
        private Label lblFamCateg3;
        private PictureBox boxFamCateg3;
        private Label lblFamCateg4Data;
        private Label lblFamCateg4;
        private PictureBox boxFamCateg4;
        
        
    }
}
