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
        /// <returns></returns>
        public static string MenuInput()
        {
            do
            {
                Console.WriteLine("\n\t\tMENU");
                Console.WriteLine("A. Register New Account");
                Console.Write("Selection >>");
                string input = Console.ReadLine().Trim();

                string[] options = { "A" };

                if (options.Contains(input))
                    return input;
                Console.WriteLine("\tInvalid selection.");

            } while (true);            
        }
    }
}
