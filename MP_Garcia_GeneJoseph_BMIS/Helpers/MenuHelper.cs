using MP_Garcia_GeneJoseph_BMIS.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Helpers
{
    class MenuHelper
    {
        /// <summary>
        /// In the GUI, these menu are the side nav bar options
        /// </summary>
        public static void MenuInput()
        {
            string input;
            string[] options = { "R", "A", "S", "AT", "D", "L" };

            do
            {
                Console.WriteLine("\n\t\tMain Menu");
                Console.WriteLine("\t R. Resident Module");
                Console.WriteLine("\t A. Account Module");
                Console.WriteLine("\t S. Summon Module");
                Console.WriteLine("\tAT. Audit Trail Module");
                Console.WriteLine("\t D. Dashboard");
                Console.WriteLine("\t L. Logout");
                Console.Write("\tSelection >>");
                input = Console.ReadLine().Trim();

                if (options.Contains(input))
                    break;
                Console.WriteLine("\tInvalid input selection.");

            } while (true);   
            
            if (input == "R")
            {
                ResidentMenu();
            }
            else if (input == "A")
            {
                AccountMenu();
            }
            else if (input == "S")
            {
                SummonMenu();
            }
            else if (input == "AT")
            {
                AuditTrailMenu();
            }
            else if (input == "D")
            {
                new DashboardPresenter().Index();
            }
            else if (input == "L")
            {
                // clear session
                UserSession.LoggedIn = false;
                UserSession.User = null;

                /* Audit TRAIL RECORD and System PROMPT */

                new AccountPresenter().GetLogin();
            }
        }

        private static void ResidentMenu()
        {
            string input;
            string[] options = { "R1", "R2", "R3", "R4", "R5" };

            do
            {
                Console.WriteLine("\n\t\tResident Menu");
                Console.WriteLine("\tR1. Display Residents");
                Console.WriteLine("\tR2. Search A Resident");
                Console.WriteLine("\tR3. Record New Resident");
                Console.WriteLine("\tR4. Display Family Records");
                Console.WriteLine("\tR5. Create New Family Record");

                Console.Write("\tSelection >>");
                input = Console.ReadLine().Trim();

                if (options.Contains(input))
                    break;
                Console.WriteLine("\tInvalid input selection.");
            } while (true);

            if (input == "R1")
            {
                new ResidentPresenter().GetDisplayResidents();
            }
            else if (input == "R2")
            {
                new ResidentPresenter().GetSearchResident();
            }
            else if (input == "R3")
            {
                new ResidentPresenter().GetAddResident();
            }
            else if (input == "R4")
            {
                new ResidentPresenter().GetDisplayFamilies();
            }
            else if (input == "R5")
            {
                new ResidentPresenter().GetAddFamily();
            }
        }

        private static void AccountMenu()
        {
            string input;
            string[] options = { "A1", "A2" };

            do
            {
                Console.WriteLine("\n\t\tAccount Menu");
                Console.WriteLine("\tA1. Display Registered Accounts");
                Console.WriteLine("\tA2. Register New Account");

                Console.Write("\tSelection >>");
                input = Console.ReadLine().Trim();

                if (options.Contains(input))
                    break;
                Console.WriteLine("\tInvalid input selection.");
            } while (true);

            if (input == "A1")
            {
                new AccountPresenter().GetDisplayAccounts();
            }
            else if (input == "A2")
            {
                new AccountPresenter().GetRegisterAccount();
            }
        }

        private static void SummonMenu()
        {
            string input;
            string[] options = { "S1", "S2", "S3" };

            do
            {
                Console.WriteLine("\n\t\tSummon Menu");
                Console.WriteLine("\tS1. Create Summon Report");
                Console.WriteLine("\tS2. Display Summon Reports");
                Console.WriteLine("\tS3. Search Summon Reports");

                Console.Write("\tSelection >>");
                input = Console.ReadLine().Trim();

                if (options.Contains(input))
                    break;
                Console.WriteLine("\tInvalid input selection.");
            } while (true);

            if (input == "S1")
            {
                new SummonPresenter().GetCreateSummon();
            }
            else if (input == "S2")
            {
                new SummonPresenter().GetDisplaySummons();
            }
            else if (input == "S3")
            {
                new SummonPresenter().GetSearchSummon();
            }
        }

        private static void AuditTrailMenu()
        {
            string input;
            string[] options = { "A1" };

            do
            {
                Console.WriteLine("\n\t\tAudit Trail Menu");
                Console.WriteLine("\tA1. Display Audit Trail");

                Console.Write("\tSelection >>");
                input = Console.ReadLine().Trim();

                if (options.Contains(input))
                    break;
                Console.WriteLine("\tInvalid input selection.");
            } while (true);

            if (input == "A1")
            {
                new AuditTrailPresenter().DisplayAuditTrails();
            }
        }

    }
}
