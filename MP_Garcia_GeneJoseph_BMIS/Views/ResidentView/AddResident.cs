using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Views.ResidentView
{
    class AddResident : IResident
    {
        private List<Resident> residents = new List<Resident>();
        public List<Resident> Residents { get { return residents; } set { residents = value; } }
        private Resident resident = new Resident();
        public Resident Resident { get { return resident; } set { resident = value; } }

        public void RunView()
        {
            Console.WriteLine("\n\n\t\tAdd New Resident Record");

            //id, fname, lname, sex, bdate, status, address

            Console.Write("First Name >>");
            string firstName = Console.ReadLine();

            Console.Write("Middle Name >>");
            string middleName = Console.ReadLine();

            Console.Write("Last Name >>");
            string lastName = Console.ReadLine();

            Console.Write("Sex Male-Female >>");
            string sex = Console.ReadLine();

            Console.Write("Birthdate MM/DD/YYYY >>");
            string bDate = Console.ReadLine();

            Console.Write("Status ALIVE-DECEASED >>");
            string status = Console.ReadLine();

            Console.Write("Address >>");
            string address = Console.ReadLine();

            resident.FirstName = firstName;
            resident.MiddleName = middleName;
            resident.LastName = lastName;
            resident.Sex = sex;
            resident.Birthdate = Convert.ToDateTime(bDate);
            resident.Status = status;
            resident.Address = address;

            new ResidentPresenter().PostAddResident(this);

        }
    }
}
