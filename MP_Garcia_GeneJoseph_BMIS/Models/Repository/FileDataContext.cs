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

        // Constant txt file names
        private const string ACCOUNTS = "accounts.txt";
        private const string RESIDENTS = "residents.txt";
        private const string FAMILIES = "families.txt";
        private const string SUMMON = "summons.txt";
        private const string AUDIT_TRAILS = "audit_trails.txt";

        // -1- Start Account Operations

        public List<Account> ReadAccounts()
        {
            List<Account> accounts = new List<Account>();

            // does not need to display anything, the program would only show empty list in views
            if (!File.Exists(ACCOUNTS))
                return accounts;

            bool errorEncountered = false;
            string errMessage = "";

            try
            {
                using (StreamReader reader = new StreamReader(ACCOUNTS))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // txt file contains:id, uname, pword, resId, date
                        string[] data = line.Split(new[] { "%20" }, StringSplitOptions.None);

                        // temp model
                        Account account = new Account();
                        account.AccountId = int.Parse(data[0]);
                        account.Username = data[1];
                        account.Password = data[2];
                        account.ResidentId = int.Parse(data[3]);
                        account.RegisteredDate = Convert.ToDateTime(data[4]);

                        accounts.Add(account);
                    }
                }
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
                errMessage = "Something went wrong. Unable to retrieve records. Please contact the IT immediately.";
            }

            if (errorEncountered)
                MessageBox.Show(errMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            return accounts;
        }

        public bool SaveAccounts(List<Account> accounts)
        {
            bool errorEncountered = false;
            string errMessage = "";

            if (accounts == null)
                return false;
            if (accounts.Count() < 1)
                return false;

            try
            {
                // writing the model to the text file
                StreamWriter writer = new StreamWriter(ACCOUNTS);
                string line;

                foreach (var account in accounts)
                {
                    line = account.AccountId + "%20";
                    line += account.Username + "%20";
                    line += account.Password + "%20";
                    line += account.ResidentId + "%20";
                    line += account.RegisteredDate;
                    writer.WriteLine(line);
                }
                writer.Close();
            }
            catch (UnauthorizedAccessException e)
            {
                errorEncountered = true;
                errMessage = "Database access not granted. Please contact the IT immediately.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                errorEncountered = true;
                errMessage = "Something went wrong. Unable to retrieve records. Please contact the IT immediately.";
            }

            if (errorEncountered)
                MessageBox.Show(errMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return !errorEncountered;
        }
        // End Account Operations

        // -2- Start Resident Operations
        /// <summary>
        /// Reads the Resident.txt and adds it to a list object of Resident
        /// </summary>
        /// <returns>Returns a list of Resident model that contains the record of the text file. If there are no record, an empty List of Resident object is returned.</returns>
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
                        resident.Sex = data[3];
                        resident.Birthdate = Convert.ToDateTime(data[4]);
                        resident.Status = data[5];
                        resident.Address = data[6];

                        residents.Add(resident);
                    }
                }
            }
            //catch (UnauthorizedAccessException e)
            //{
            //    errorEncountered = true;
            //    errMessage = "Database access not granted. Please contact the IT immediately.";
            //}
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
                errMessage = "Something went wrong. Unable to retrieve records. Please contact the IT immediately.";
            }

            if (errorEncountered)
                MessageBox.Show(errMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return residents;
        }
        
        /// <summary>
        /// Writes to Resident.txt using the list of Resident models
        /// </summary>
        /// <param name="residents">Holds the record of all resident. The program could either have added, edited or removed a record.</param>
        /// <returns>A successfull write action returns true, otherwise, false,</returns>
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
                errMessage = "Database access not granted. Please contact the IT immediately.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                errorEncountered = true;
                errMessage = "Something went wrong. Unable to retrieve records. Please contact the IT immediately.";
            }

            if (errorEncountered)
                MessageBox.Show(errMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return !errorEncountered;
        }
        // End Resident Operations

        // -3- Start Families Operations

        // End Families Operations

        // -4- Start Summon Operations

        // End Summon Opeartions

        // -5- Start Audit Trails Operations

        // End Audit Trails Operations
    }
}
