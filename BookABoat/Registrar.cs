using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BookABoat
{
    public static class Registrar

    {
        //private static UserManager<ApplicationUser> UserManager { get; }

        //private static UserManager<ApplicationUser> userManager =
        //            new UserManager<ApplicationUser>(
        //                 new UserStore<ApplicationUser>(new BoathouseRowModel()));

        private static BoathouseRowModel db = new BoathouseRowModel();  // this opens connection to our db

        public static Rower AddRower(string firstName, string lastName, string emailAddress, string phoneNumber, DateTime? joinDate, DateTime? expirationDate, SkillLevel skillLevel = SkillLevel.NoviceSkill)
        {
            // TODO: make sure this is not a duplicate addition
            var rower = new Rower(emailAddress);
            rower.FirstName = firstName;
            rower.LastName = lastName;
            rower.MobilePhone = phoneNumber;

            rower.JoinDate = joinDate ?? DateTime.UtcNow;
            rower.ValidUntil = expirationDate ?? DateTime.UtcNow;

            rower.ApprovedSkillLevel = skillLevel;  // setup at lowest skill level by default

            // add to roster
            db.Rowers.Add(rower);
            // add to rowers for this account
            db.SaveChanges();

            return rower;
        }

        //public static bool RowerExists(string email)
        //{
        //    return db.Rowers.Any(r => r.EmailAddress == email);
        //}

        public static void InactivateRower(int rowerId, DateTime expirationDate)
        {
            var rower = db.Rowers.Where(r => r.Id == rowerId).FirstOrDefault();
            rower.ValidUntil = expirationDate;
            db.SaveChanges();
        }

        public static int GetUserByEmail(string emailAddress)
        {
            var users = Membership.FindUsersByEmail(emailAddress);
            //if (users.Count > 1)
            //    return users[0].
            //return;

            ////var resultList = new List<ApplicationUser>();
            ////var List = userManager.Users.ToList();
            ////foreach (var user in List)
            ////{
            ////    if (IsUserInRole(user.Id, roleName))
            ////        resultList.Add(user);
            ////}
            ////return resultList;
            return 1;
        }

        public static string GetRowerNameById(int id)
        {
            var rower = db.Rowers.Where(r => r.Id == id).FirstOrDefault();
            return $"{rower.FirstName} {rower.LastName}";
        }

        //public static Rower GetRowerByEmailAddress(string email)
        //{
        //    var rower = db.Rowers.Where(r => r.EmailAddress.Equals(email)).FirstOrDefault();
        //    return rower;
        //}

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
