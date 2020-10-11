﻿using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Views.AccountView
{
    class RegisterAccountView : IResident
    {

        private List<Resident> residents = new List<Resident>();
        public List<Resident> Residents { get { return residents; } set { residents = value; } }

        private Resident resident = new Resident();
        public Resident Resident { get { return resident; } set { resident = value; } }

        public void RunView()
        {
            Console.WriteLine("\n\n\t\tREGISTER NEW ACCOUNT");
            foreach (var resident in residents)
            {
                Console.WriteLine("\tId: {0}", resident.ResidentId);
                Console.WriteLine("\tName: {0}", resident.FirstName + " " + resident.LastName);
                Console.WriteLine("\tSex: {0}", resident.Sex);
                Console.WriteLine("\tBirthday: {0}", resident.Birthdate.ToLongDateString());
                Console.WriteLine("\tAddress: {0}", resident.Address);
                Console.WriteLine("\tStatus: {0}\n", resident.Status);
            }

            do
            {
                Console.Write("\tSelect a Resident >>");
                int residentId = int.Parse(Console.ReadLine());

                // find the resident with the id from the list
                resident = residents.Where(m => m.ResidentId == residentId).FirstOrDefault();

                if (resident != null)
                    break;
                else
                    Console.WriteLine("\tResident Id not found.\n");

            } while (true);

            new AccountPresenter().PostRegisterAccount(this);
        }
    }
}
