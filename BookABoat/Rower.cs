using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    /// <summary>
    /// A rower is a single user that may reserve a boat
    /// A rower has a skill level defined by the coach (admin) and 
    /// can only reserve boats at their skill level or below
    /// </summary>
    public class Rower
    {

        private static int lastRowerId = 0;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public SkillLevel ApprovedSkillLevel { get; set; }
        public DateTime ValidUntil { get; set; }

        #region constructors
        public Rower()
        {
            Id = ++lastRowerId;
        }

        public Rower(string firstName, string lastName, string email, string mobile, SkillLevel skillLevel, DateTime expireDate)
        {
            Id = ++lastRowerId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            MobilePhone = mobile;
            ApprovedSkillLevel = skillLevel;
        }
        #endregion

        // only an admin/coach should be able to update skill levels
        public void UpdateRowerSkillLevel(SkillLevel skillLevel)
        {
            ApprovedSkillLevel = skillLevel;
            Console.WriteLine($"Skill level for Rower {FirstName} changed to:  {skillLevel}");

        }

        // only an admin/coach/registrar should be able to update rower expiration dates
        public void UpdateRowerExpiration(DateTime expireDate)
        {
            ValidUntil = expireDate;
            Console.WriteLine($"Rower {FirstName} able to reserve boats until:  {expireDate.ToShortDateString()}");

        }

    }
}
