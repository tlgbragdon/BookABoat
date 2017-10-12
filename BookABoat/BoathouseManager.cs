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


        public static Boat GetBoatById(int id)
        {
            var boat = Fleet.Find(b => b.Id == id);
            return boat;
        }

        public static string GetBoatNameById(int id)
        {
            var boat = Fleet.Find(b => b.Id == id);
            return boat.Name;
        }

    }
}
