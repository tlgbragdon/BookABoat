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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public SkillLevel ApprovedSkillLevel { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
