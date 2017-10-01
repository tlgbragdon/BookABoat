using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    /// <summary>
    /// A boat is a rowing shell available for reservation
    /// A boat has a unique name, type (single, double, etc), a weightclass rating (light, mid, heavy) and a required skill level
    /// One or more rowers (depending on boat size) are associated with the boat for a particular time period
    /// </summary>
    public class Boat
    {
        private static int lastBoatId = 0;

        #region public properties

        public int Id { get; private set; }
        public string Name { get; set; }
        public BoatType Type { get; set; }
        public WeightClass WeightClass { get; set; }
        public SkillLevel MinSkillLevelRequired { get; set; }
        public List<Rower> Rowers { get; set; }
        public List<Reservation> Reservations { get; set; }
        #endregion

        private bool isActive = true;

        #region constructors

        public Boat()
        {
            Id = ++lastBoatId;   
            Rowers = new List<Rower>();
            Reservations = new List<Reservation>();
            isActive = true;
        }



        #endregion

        #region Public Methods

        // only an admin/coach should be able to update boat info
        public void UpdateBoat(string name, BoatType type, WeightClass weightClass, SkillLevel minSkillLevel)
        {
            // setup boat info - this would actually be done by admin/coach user
            Name = name;
            Type = type;
            MinSkillLevelRequired = minSkillLevel;
            WeightClass = weightClass;
        }

        // only an admin/coach should be able to update boat info
        public void RemoveBoat()
        {
            // make sure there are no future reservations

            // make boat inactive rather than do hard delete
            isActive = false;
        }

        #endregion

    }
    public enum BoatType
    {
        EightShell,
        FourShell,
        QuadShell,
        DoubleShell,
        PairShell,
        SingleShell
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
        PairSkill = 25,
        SingleSkill = 30,
        ExpertSingleSkill = 40
        
    }
}
