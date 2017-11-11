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
    /// A rower has a skill level defined by the coach (admin) and 
    /// can only reserve boats at their skill level or below
    /// </summary>
    public class Rower
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "First name is limited to 30 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Last name is limited to 30 characters")]
        public string LastName { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Email Address is limited to 30 characters")]
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public SkillLevel ApprovedSkillLevel { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ValidUntil { get; set; }

        #region constructors
        public Rower()
        {
        }

        #endregion

        // 
        public void UpdateProfile(string emailAddress, string phone, string lastName, string firstName )
        {
            if (emailAddress != null)
                EmailAddress = emailAddress;
            if (phone != null)
                MobilePhone = phone;
            if (lastName != null)
                LastName = lastName;
            if (firstName != null)
                FirstName = firstName;
            Console.WriteLine($"Profile Updated: {FirstName} {LastName} : {MobilePhone}, {EmailAddress}");

        }

    }
}
