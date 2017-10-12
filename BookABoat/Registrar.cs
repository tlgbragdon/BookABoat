using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    public static class Registrar

    {
        public static List<Rower> Rowers = new List<Rower>();

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
            Rowers.Add(rower);

            return rower;
        }

        public static void InactivateRower(int rowerId, DateTime expirationDate)
        {
            var rower = Rowers.Find(r => r.Id == rowerId);
            rower.ValidUntil = expirationDate;
         }

        public static string GetRowerNameById(int id)
        {
            var rower = Rowers.Find(r => r.Id == id);
            return $"{rower.FirstName} {rower.LastName}";
        }

        public static Rower GetRowerByEmailAddress(string email)
        {
            var rower = Rowers.Find(r => r.EmailAddress.Equals(email));
            return rower;
        }

 

    }
}
