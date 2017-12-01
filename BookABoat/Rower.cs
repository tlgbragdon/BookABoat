using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    /// <summary>
    /// A rower is a single user that may reserve a boat
    /// A rower has a skill level defined by the coach or registrar (admin) and 
    /// can only reserve boats at their skill level or below
    /// </summary>
    public class Rower
    {
        [Key]
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public SkillLevel ApprovedSkillLevel { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Username { get; set; }

        // navigational relationship 
        public virtual ICollection<Reservation> Reservations { get; set; }

        #region constructors
        public Rower(string emailAddress)
        {
            Username = emailAddress;
            ValidUntil = DateTime.UtcNow;
       }

        #endregion

       // 
        public void UpdateProfile(string emailAddress, string phone, string lastName, string firstName )
        {
            //if (emailAddress != null)
            //    EmailAddress = emailAddress;
            if (phone != null)
                MobilePhone = phone;
            if (lastName != null)
                LastName = lastName;
            if (firstName != null)
                FirstName = firstName;
            Console.WriteLine($"Profile Updated: {FirstName} {LastName} : {MobilePhone}");

        }

    }
}
