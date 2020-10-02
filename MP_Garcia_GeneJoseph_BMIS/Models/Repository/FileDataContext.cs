using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Models.Repository
{
    class FileDataContext
    {

        private const string RESIDENTS = "residents.txt";
        private const string FAMILIES = "families.txt";
        private const string ACCOUNTS = "accounts.txt";
        private const string AUDIT_TRAILS = "audit_trails.txt";
        private const string SUMMON = "summons.txt";

        // Residents

        public List<Resident> ReadResidents()
        {
            List<Resident> residents = new List<Resident>();

            // does not need to display anything, the program would only show empty list in views
            if (!File.Exists(RESIDENTS))
                return residents;

            bool errorEncountered = false;
            string errMessage = "";

            try
            {
                using (StreamReader reader = new StreamReader(RESIDENTS))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // txt file contains:
                        string[] data = line.Split(new[] { "%20" }, StringSplitOptions.None);

                        // temp resident model
                        Resident resident = new Resident();
                        resident.ResidentId = int.Parse(data[0]);
                        resident.FirstName = data[1];
                        resident.LastName = data[2];
                        resident.Birthdate = Convert.ToDateTime(data[3]);
                        resident.Sex = data[4];
                        resident.Address = data[5];

                        residents.Add(resident);
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                errorEncountered = true;
                errMessage = "Cannot connect to database. Please contact the IT immediately.";
            }
            catch (FormatException e)
            {
                // for the contents of the text file, the data might be corrupted or invalid formats
                errorEncountered = true;
                errMessage = "Some data were not read succesfully. Report to the IT immediately.";
            }
            catch (IndexOutOfRangeException e)
            {
                // for the contents of the text file, the data might be corrupted or invalid formats
                errorEncountered = true;
                errMessage = "Some data were not read succesfully. Report to the IT immediately.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                errorEncountered = true;
                errMessage = "Something went wrong. Please contact the IT immediately.";
            }

            if (errorEncountered)
                MessageBox.Show(errMessage);
            return residents;
        }

        public bool SaveResidents(List<Resident> residents)
        {
            // residents may not be null, meaning it is initialized
            // but it does not contain anything.
            if (residents == null)
                return false;
            if (residents.Count() < 1)
                return false;

            bool errorEncountered = false;
            string errMessage = "";

            try
            {
                // writing the model to the text file
                StreamWriter writer = new StreamWriter(RESIDENTS);

                string line;

                foreach (var resident in residents)
                {
                    line = resident.ResidentId + "%20";
                    line += resident.FirstName + "%20";
                    line += resident.LastName + "%20";
                    line += resident.Sex + "%20";
                    line += resident.Birthdate + "%20";
                    line += resident.Status + "%20";
                    line += resident.Address;
                    writer.WriteLine(line);
                }

                writer.Close();

            }
            catch (UnauthorizedAccessException e)
            {
                errorEncountered = true;
                errMessage = "Cannot connect to database. Please contact the IT immediately.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                errorEncountered = true;
                errMessage = "Something went wrong. Please contact the IT immediately.";
            }

            if (errorEncountered)
                MessageBox.Show(errMessage);

            return !errorEncountered;
        }

        // End Residents
    }
}
