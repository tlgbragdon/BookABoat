using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    public static class BoathouseManager
    {
        // only an admin/coach should be able to add a boat to the fleet
        public static Boat AddBoatToFleet(string name, BoatType type, WeightClass weightClass, SkillLevel minSkillLevel)
        {
            var boat = new Boat();
            boat.Name = name;
            boat.Type = type;
            boat.MinSkillLevelRequired = minSkillLevel;
            boat.WeightClass = weightClass;

            return boat;
        }

    }
}
