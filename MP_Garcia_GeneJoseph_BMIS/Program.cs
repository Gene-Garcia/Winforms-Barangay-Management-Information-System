using MP_Garcia_GeneJoseph_BMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Resident> residents = new Resident().Residents();

            if (residents.Count < 1 || residents == null)
                Console.WriteLine("System records does not have resident records.");
            else
                foreach (var resident in residents)
                {
                    Console.WriteLine("Id: {0}", resident.ResidentId);
                    Console.WriteLine("Name: {0}", resident.FirstName + " " + resident.LastName);
                    Console.WriteLine("Sex: {0}", resident.Sex);
                    Console.WriteLine("Birthday: {0}", resident.Birthdate.ToLongDateString());
                    Console.WriteLine("Address: {0}", resident.Address);
                    Console.WriteLine("Status: {0}", resident.Status);
                }

            residents.Add(new Resident()
            {
                ResidentId = residents.Count() + 1,
                FirstName = "Gene",
                LastName = "Garcia",
                Birthdate = DateTime.Now,
                Sex = "Male",
                Status = "Alive",
                Address = "Batangas"
            }) ;

            new Resident().SaveResidents(residents);

            Console.ReadKey();
        }
    }
}
