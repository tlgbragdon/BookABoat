using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    /// <summary>
    /// A boat is a rowing shell available for reservation
    /// A boat has a unique name, type (single, double, etc), a weightclass rating (light, mid, heavy) and a required skill level
    /// One or more reservations may be made for any boat
    /// One or more rowers (depending on boat size) are associated with the boat for a particular reservation
    /// </summary>
    public class Boat
    {
 
        #region public properties

        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public BoatType Type { get; set; }
        public WeightClass WeightClass { get; set; }
        public SkillLevel MinSkillLevelRequired { get; set; }
        public bool isActive = true;
        //public virtual ICollection<Rower> Rowers { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        #endregion

 
        #region constructors

        public Boat()
        {
            //Rowers = new List<Rower>();
            //Reservations = new List<Reservation>();
            isActive = true;
        }

        #endregion

        #region Public Methods

        // only an admin/coach should be able to update boat info
        public void UpdateBoat(string name, BoatType type, WeightClass weightClass, SkillLevel minSkillLevel, bool active)
        {
            // setup boat info - this would actually be done by admin/coach user
            Name = name;
            Type = type;
            MinSkillLevelRequired = minSkillLevel;
            WeightClass = weightClass;
            isActive = active;
        }

        // only an admin/coach should be able to update boat info
        public void RemoveBoat()
        {
            // TODO: make sure there are no future reservations

            // make boat inactive rather than do hard delete
            isActive = false;
        }

        #endregion

    }
    public enum BoatType
    {
        Eight,
        FourWith,
        FourWithout,
        Quad,
        Double,
        Pair,
        Single
    }

    public enum WeightClass
    {
        Lightweight,
        Midweight,
        Heavyweight
    }

    public enum SkillLevel
    {
        NoviceSkill = 0,
        QuadSkill = 10,
        DoubleSkill = 20,
        BeginnerSingleSkill = 25,
        PairSkill = 30,
        ExpertSingleSkill = 40
        
    }
}
