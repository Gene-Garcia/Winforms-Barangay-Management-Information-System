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
            
            if (input == "A")
            {
                new AccountPresenter().GetRegisterAccount();
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
            string[] options = { "" };

            do
            {
                Console.WriteLine("\n\t\tAccount Menu");
                Console.WriteLine("\t R. Resident Module");

                Console.Write("\tSelection >>");
                input = Console.ReadLine().Trim();

                if (options.Contains(input))
                    break;
                Console.WriteLine("\tInvalid input selection.");
            } while (true);

            if (input == " ")
            {

            }
            else if (input == "")
            {

            }
        }

        private static void SummonMenu()
        {
            string input;
            string[] options = { "" };

            do
            {
                Console.WriteLine("\n\t\tSummon Menu");
                Console.WriteLine("\t R. Resident Module");

                Console.Write("\tSelection >>");
                input = Console.ReadLine().Trim();

                if (options.Contains(input))
                    break;
                Console.WriteLine("\tInvalid input selection.");
            } while (true);

            if (input == " ")
            {

            }
            else if (input == "")
            {

            }
        }

        private static void AuditTrailMenu()
        {
            string input;
            string[] options = { "" };

            do
            {
                Console.WriteLine("\n\t\tAudit Trail Menu");
                Console.WriteLine("\t R. Resident Module");

                Console.Write("\tSelection >>");
                input = Console.ReadLine().Trim();

                if (options.Contains(input))
                    break;
                Console.WriteLine("\tInvalid input selection.");
            } while (true);

            if (input == " ")
            {

            }
            else if (input == "")
            {

            }
        }

    }
}
