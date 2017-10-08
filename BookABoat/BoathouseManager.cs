using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    public static class BoathouseManager
    {
        public static List<Boat> Fleet = new List<Boat>();
        public static List<Rower> Rowers = new List<Rower>();
        public static List<Reservation> Reservations = new List<Reservation>();

        // only an admin/coach should be able to add a boat to the fleet
        public static Boat AddBoatToFleet(string name, BoatType type, WeightClass weightClass = WeightClass.Lightweight, SkillLevel minSkillLevel = SkillLevel.ExpertSingleSkill)
        {
            var boat = new Boat();
            boat.Name = name;
            boat.Type = type;
            boat.MinSkillLevelRequired = minSkillLevel;
            boat.WeightClass = weightClass;

            // add to fleet
            Fleet.Add(boat);

            return boat;
        }

        public static string GetBoatNameById(int id)
        {
            var boat = Fleet.Find(b => b.Id == id);
            return boat.Name;
        }

        public static Rower GetRowerByEmailAddress(string email)
        {
            var rower = Rowers.Find(r => r.EmailAddress.Equals(email));
            return rower;
        }

        public static IEnumerable<Reservation> GetReservations(int boatId, DateTime startDate, DateTime endDate)
        {
            var reservations = Reservations.Where(r => r.BoatId == boatId && 
                                                 r.StartTime.Date >= startDate && 
                                                 r.EndTime.Date <= endDate);
            return reservations;
        }

    }
}
