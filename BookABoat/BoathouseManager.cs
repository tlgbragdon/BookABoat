using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    public static class BoathouseManager
    {
        private static BoathouseRowModel db = new BoathouseRowModel();  // this opens connection to our db

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
            //return db.Boats.Where(b => b.IsActive == true).ToList();
            return db.Boats.ToList();
        }

        public static List<Boat>GetAllActiveBoatsForSkillLevel(SkillLevel skillLevel)
        {
            //return db.Boats.Where(b => b.IsActive == true).Where(b => b.MinSkillLevelRequired <= skillLevel).ToList();
            return db.Boats.Where(b => b.MinSkillLevelRequired <= skillLevel).ToList();
        }

        public static Boat GetBoatById(int id)
        {
            return db.Boats.Where(b => b.Id == id).FirstOrDefault();
        }

        public static string GetBoatNameById(int id)
        {
            return db.Boats.Where(b => b.Id == id).FirstOrDefault().Name;
        }

        public static void EditBoat(Boat boat)
        {
            var oldBoat = GetBoatById(boat.Id);
            db.Entry(oldBoat).State = EntityState.Modified;
            oldBoat.Name = boat.Name;
            oldBoat.Type = boat.Type;
            oldBoat.WeightClass = boat.WeightClass;
            oldBoat.MinSkillLevelRequired = boat.MinSkillLevelRequired;
            oldBoat.DateAquired = boat.DateAquired;
            oldBoat.Make = boat.Make;
            oldBoat.YearOfManufacture = boat.YearOfManufacture;
            db.SaveChanges();

        }

        public static void RemoveBoat(int boatId)
        {

            // TODO: verify there are no active reservations
            var oldBoat = GetBoatById(boatId);
            db.Entry(oldBoat).State = EntityState.Modified;
            oldBoat.RemoveBoat();
            db.SaveChanges();
        }

        public static void ActivateBoat(int boatId)
        {
            var oldBoat = GetBoatById(boatId);
            db.Entry(oldBoat).State = EntityState.Modified;
            oldBoat.IsActive = true;
            db.SaveChanges();
        }

    }
}
