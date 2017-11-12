using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    public static class BoathouseManager
    {
        private static BoathouseModel db = new BoathouseModel();  // this opens connection to our db

        // only an admin/coach should be able to add a boat to the fleet
        public static void AddBoatToFleet(string name, BoatType type, WeightClass weightClass = WeightClass.Lightweight, SkillLevel minSkillLevel = SkillLevel.ExpertSingleSkill)
        {
            var boat = new Boat();
            boat.Name = name;
            boat.Type = type;
            boat.MinSkillLevelRequired = minSkillLevel;
            boat.WeightClass = weightClass;
            boat.isActive = true;
            //boat.Rowers = null;
            boat.Reservations = null;

            // add boat to fleet
            db.Boats.Add(boat);
            db.SaveChanges();

        }

        public static List<Boat> GetAllActiveBoats()
        {
            return db.Boats.Where(b => b.isActive == true).ToList();
        }

        public static List<Boat>GetAllActiveBoatsForSkillLevel(SkillLevel skillLevel)
        {
            return db.Boats.Where(b => b.isActive == true).Where(b => b.MinSkillLevelRequired <= skillLevel).ToList();
        }

        public static Boat GetBoatById(int id)
        {
            return db.Boats.Where(b => b.Id == id).FirstOrDefault();
        }

        public static string GetBoatNameById(int id)
        {
            return db.Boats.Where(b => b.Id == id).FirstOrDefault().Name;
        }

    }
}
