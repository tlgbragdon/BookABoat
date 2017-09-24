using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    /// <summary>
    /// The Book-A-Boat app allows rowing club members to reserve available boats for use
    /// Boats are classified by weight and skill level
    /// In order to reserve a boat, all rowers must be approved at that skill level or above (Coach determines rower's skill level)
    /// Date/Times of boats can also be blocked off by coaches for practices and/or regattas
    /// Future: provide means to send message to coach if crew finds any issues with boat
    /// </summary>
    class Program
    {
        public static List<Boat> Fleet = new List<Boat>();
 
        static void Main(string[] args)
        {
            // instantiate objects for testing
 
            // setup a few boats - this would actually be done by admin/coach user
            var boatRelentless = new Boat("Relentless", BoatType.QuadShell, WeightClass.Midweight, SkillLevel.QuadSkill);
            Fleet.Add(boatRelentless);
            Console.WriteLine($"{boatRelentless.Name} added to Fleet");
            var boatStoudt = new Boat("The Stoudt", BoatType.EightShell, WeightClass.Heavyweight, SkillLevel.NoviceSkill);
            Fleet.Add(boatStoudt);
            Console.WriteLine($"{boatStoudt.Name} added to Fleet");
            var boatMahalo = new Boat("Mahalo", BoatType.DoubleShell, WeightClass.Heavyweight, SkillLevel.DoubleSkill);
            Fleet.Add(boatMahalo);
            Console.WriteLine($"{boatMahalo.Name} added to Fleet");
            var boatWintech21 = new Boat("Wintech 21", BoatType.SingleShell, WeightClass.Heavyweight, SkillLevel.SingleSkill);
            Fleet.Add(boatWintech21);
            Console.WriteLine($"{boatWintech21.Name} added to Fleet");


            // setup rower info - this would actually be done by admin/registrar
            var rower = new Rower("Shelly", "Crewmate", "shelly@email.com", "555555555", SkillLevel.NoviceSkill, DateTime.Parse("12-31-2017"));

            // make some dummy start/end times
            var startTime = DateTime.Now.AddDays(1);
            var endTime = startTime.AddHours(4);
            var reservation = new Reservation(boatRelentless, startTime, endTime, rower);
            Console.WriteLine($"Rower {rower.FirstName} has reservered boat {GetBoatNameById(reservation.BoatId)}");


        }

        public static string GetBoatNameById(int id)
        {
            var boat = Fleet.Find(b => b.Id == id);
            return boat.Name;
        }
    }
}
