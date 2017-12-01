using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    public static class BoathouseManager
    {
        private static BoathouseModel db = new BoathouseModel();  // this opens connection to our db

        // only an admin/coach should be able to add a boat to the fleet
        public static void AddBoatToFleet(string name, BoatType type, string make, int year, DateTime dateAquired, WeightClass weightClass = WeightClass.Lightweight, SkillLevel minSkillLevel = SkillLevel.ExpertSingleSkill)
        {
            var boat = new Boat
            {
                Name = name,
                Type = type,
                MinSkillLevelRequired = minSkillLevel,
                WeightClass = weightClass,
                Make = make,
                YearOfManufacture = year,
                DateAquired = dateAquired,
                Reservations = null
            };

            // add boat to fleet
            db.Boats.Add(boat);
            db.SaveChanges();

        }

        public static List<Boat> GetAllActiveBoats()
        {
            return db.Boats.Where(b => b.IsActive == true).ToList();
        }

        public static List<Boat>GetAllActiveBoatsForSkillLevel(SkillLevel skillLevel)
        {
            return db.Boats.Where(b => b.IsActive == true).Where(b => b.MinSkillLevelRequired <= skillLevel).ToList();
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
