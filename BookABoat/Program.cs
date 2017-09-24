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
        static void Main(string[] args)
        {
            // instantiate objects for testing

            // setup boat info - this would actually be done by admin/coach user
            var boatToReserve = new Boat("Relentless", BoatType.QuadShell, WeightClass.Midweight, SkillLevel.NoviceSkill);

            // setup rower info - this would actually be done by admin/registrar
            var rower = new Rower("Shelly", "Crewmate", "shelly@email.com", "555555555", SkillLevel.NoviceSkill, DateTime.Parse("12-31-2017"));

            // make some dummy start/end times
            var startTime = DateTime.Now.AddDays(1);
            var endTime = startTime.AddHours(4);
            var reservation = new Reservation(boatToReserve, startTime, endTime, rower);

 

        }
    }
}
