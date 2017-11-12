using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    public static class Registrar

    {
        //public static List<Rower> Rowers = new List<Rower>();
        private static BoathouseModel db = new BoathouseModel();  // this opens connection to our db

        public static Rower AddRower(string firstName, string lastName, string emailAddress, string phoneNumber, DateTime joinDate, DateTime expirationDate, SkillLevel skillLevel = SkillLevel.NoviceSkill)
        {
            var rower = new Rower();
            rower.FirstName = firstName;
            rower.LastName = lastName;
            rower.EmailAddress = emailAddress;
            rower.MobilePhone = phoneNumber;
            rower.JoinDate = joinDate;
            rower.ValidUntil = expirationDate;

            rower.ApprovedSkillLevel = skillLevel;  // setup at lowest skill level by default

            // add to roster
            db.Rowers.Add(rower);
            db.SaveChanges();

            return rower;
        }

        public static void InactivateRower(int rowerId, DateTime expirationDate)
        {
            var rower = db.Rowers.Where(r => r.Id == rowerId).FirstOrDefault();
            rower.ValidUntil = expirationDate;
            db.SaveChanges();
        }

        public static string GetRowerNameById(int id)
        {
            var rower = db.Rowers.Where(r => r.Id == id).FirstOrDefault();
            return $"{rower.FirstName} {rower.LastName}";
        }

        public static Rower GetRowerByEmailAddress(string email)
        {
            var rower = db.Rowers.Where(r => r.EmailAddress.Equals(email)).FirstOrDefault();
            return rower;
        }

        public static void UpdateRowerSkillLevel(int rowerId, SkillLevel skillLevel)
        {
            var rower = db.Rowers.Where(r => r.Id == rowerId).FirstOrDefault();
            rower.ApprovedSkillLevel = skillLevel;
            db.SaveChanges();
            Console.WriteLine($"Skill level for Rower {rower.FirstName} changed to:  {skillLevel}");

        }

        // only an admin/coach/registrar should be able to update rower expiration dates
        public static void UpdateRowerExpirationDate(int rowerId, DateTime expireDate)
        {
            var rower = db.Rowers.Where(r => r.Id == rowerId).FirstOrDefault();
            rower.ValidUntil = expireDate;
            db.SaveChanges();
            Console.WriteLine($"Rower {rower.FirstName} able to reserve boats until:  {expireDate.ToShortDateString()}");

        }

    }
}
