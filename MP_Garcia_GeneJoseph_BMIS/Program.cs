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
                    Console.WriteLine("Status: {0}\n", resident.Status);
                }

            new Resident().SaveResidents(residents);

            Console.WriteLine("------------------------------------");

            List<Account> accounts = new Account().Accounts();

            if (accounts.Count < 1)
                Console.WriteLine("Empty");
            else
                foreach (var account in accounts)
                {
                    Console.WriteLine("Id: {0}", account.AccountId);
                    Console.WriteLine("Username: {0}", account.Username);
                    Console.WriteLine("Password: {0}", account.Password);
                    Console.WriteLine("Full Name: {0}", account.Resident.FirstName + " " + account.Resident.LastName);
                    Console.WriteLine("Date: {0}\n", account.RegisteredDate.ToLongDateString());
                }

            new Account().SaveAccounts(accounts);

            Console.WriteLine("------------------------------------");

            List<Family> families = new Family().Families();

            if (families.Count < 1)
                Console.WriteLine("Empty");
            else
                foreach (var family in families)
                {
                    Console.WriteLine("Id: {0}", family.FamilyId);
                    Console.WriteLine("Parent 1: {0}", family.ParentOneId);
                    Console.WriteLine("Parent 2: {0}", family.ParentTwoId);
                    Console.WriteLine("Family Members: {0}\n", family.FamilyMembers);
                }

            new Family().SaveFamilies(families);

            Console.WriteLine("------------------------------------");

            List<Summon> summons = new Summon().Summons();

            if (summons.Count < 1)
                Console.WriteLine("Empty");
            else
                foreach (var summon in summons)
                {
                    Console.WriteLine("Id: {0}", summon.SummonId);
                    Console.WriteLine("Incident: {0}", summon.IncidentDate.ToLongDateString());
                    Console.WriteLine("Reported: {0}", summon.ReportedDate.ToLongDateString());
                    Console.WriteLine("Summary: {0}", summon.Summary);
                    Console.WriteLine("Account Id: {0}\n", summon.AccountId);
                }

            new Summon().SaveSummons(summons);

            Console.WriteLine("------------------------------------");

            List<AuditTrail> auditTrails = new AuditTrail().AuditTrails();

            if (auditTrails.Count < 1)
                Console.WriteLine("Empty");
            else
                foreach (var auditTrail in auditTrails)
                {
                    Console.WriteLine("Id: {0}", auditTrail.TrailId);
                    Console.WriteLine("Message: {0}", auditTrail.Message);
                    Console.WriteLine("Date: {0}", auditTrail.ActionDate.ToLongDateString());
                    Console.WriteLine("Account Id: {0}\n", auditTrail.AccountId);
                }

            new AuditTrail().SaveAuditTrails(auditTrails);

            Console.ReadKey();
        }
    }
}
