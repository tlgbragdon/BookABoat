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
    public class Program
    {
        public enum UserRole
        {
            Rower,
            Coach
        }

        static void Main(string[] args)
        {
            // instantiate objects for testing
            // setup a few boats - this would actually be done by admin/coach user
            InitBoatInventoryForTesting();

            // setup rower info - this would actually be done by admin/registrar
            InitRowersForTesting();


            Console.WriteLine("*******************************************");
            Console.WriteLine("*** Welcome To the C-Sharp Rowing Club  ***");
            Console.WriteLine("***        Boat Reservation System      ***");
            Console.WriteLine("*******************************************");

            while (true)
            {
                Console.WriteLine("Please choose an option below:");
                Console.WriteLine("    0 if you are a Rower");
                Console.WriteLine("    1 if you are a Coach");
                Console.WriteLine("    Press any other key to exit");

                var userRole = Console.ReadLine();

                switch (userRole)
                {
                    case "0":
                        showRowerOptions();
                        break;
                    case "1":
                        showCoachOptions();
                        break;
                    default:
                        return;

                }
            }
        }

        private static void showRowerOptions()
        {
            // prompt for rower email address
            Console.Write("Your Email Address: ");
            var emailAddress = Console.ReadLine();
            var rower = BoathouseManager.GetRowerByEmailAddress(emailAddress);

            if (rower == null)
            {
                Console.WriteLine("Sorry, there is no rower available with that email address.");
                return;
            }

            while (true)
            {
                Console.WriteLine("Please choose an option below:");
                Console.WriteLine("    0 to Reserve A Boat");
                Console.WriteLine("    1 to View Boats Available To You for Reservation");
                Console.WriteLine("    Press return to go back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        getBoatReservation(rower);
                        break;
                    case "1":
                        displayBoats(rower.ApprovedSkillLevel);
                        break;
                    default:
                        return;
                }
            }
        }

        private static void showCoachOptions()
        {
            while (true)
            {
                Console.WriteLine("Please choose an option below:");
                Console.WriteLine("    0 Show All Boats");
                Console.WriteLine("    1 to Reserve A Boat");
                Console.WriteLine("    2 to Add a Boat to the Fleet");
                Console.WriteLine("    3 to Add a new Rower");
                Console.WriteLine("    Press return to go back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                       displayBoats();
                        break;
                    case "1":
                        // TODO: should the coach be able to make a reservation for someone else?
                        //getBoatReservation(needRowerHere);
                        Console.WriteLine(" Not Yet Implemented: Coach making a reservation for someone else. ");
                        break;
                    case "2":
                        Console.WriteLine(" Not Yet Implemented: adding a boat to fleet ");
                        break;
                    case "3":
                        Console.WriteLine(" Not Yet Implemented: adding a Rower to team ");
                        break;

                    default:
                        return;


                }
            }
        }

        private static void InitBoatInventoryForTesting()
        {
            // setup a few boats - this would actually be done by admin/coach user
            var boatRelentless = BoathouseManager.AddBoatToFleet("Relentless", BoatType.QuadShell, WeightClass.Midweight, SkillLevel.QuadSkill);
            Console.WriteLine($"{boatRelentless.Name} added to Fleet");
            var boatStoudt = BoathouseManager.AddBoatToFleet("The Stoudt", BoatType.EightShell, WeightClass.Heavyweight, SkillLevel.NoviceSkill);
            Console.WriteLine($"{boatStoudt.Name} added to Fleet");
            var boatMahalo = BoathouseManager.AddBoatToFleet("Mahalo", BoatType.DoubleShell, WeightClass.Heavyweight, SkillLevel.DoubleSkill);
            Console.WriteLine($"{boatMahalo.Name} added to Fleet");
            var boatWintech21 = BoathouseManager.AddBoatToFleet("Wintech 21", BoatType.SingleShell, WeightClass.Heavyweight, SkillLevel.SingleSkill);
            Console.WriteLine($"{boatWintech21.Name} added to Fleet");
        }

        private static void InitRowersForTesting()
        {
            // setup rower info - this would actually be done by admin/registrar
            var rower = new Rower("Port", "Starboard", "test@test.com", "555555555", SkillLevel.DoubleSkill, DateTime.Parse("12-31-2017"));
            BoathouseManager.Rowers.Add(rower);

            rower = new Rower("Shelly", "Crewmate", "shelly@email.com", "555555555", SkillLevel.NoviceSkill, DateTime.Parse("12-31-2017"));
            BoathouseManager.Rowers.Add(rower);
        }

        /// <summary>
        /// Display all boats in fleet 
        /// </summary>
        private static void displayBoats()
        {
            if (BoathouseManager.Fleet.Count == 0)
            {
                Console.WriteLine("There are no boats.");
            }

            Console.WriteLine("Boats available in fleet:");
            foreach (var boat in BoathouseManager.Fleet)
            {
                Console.WriteLine($"    {boat.Id} : { boat.Name} has Required (min) Skill Level: {boat.MinSkillLevelRequired}");

            }

        }

        /// <summary>
        /// Display boats in fleet at specified skill level (and below)
        /// </summary>
        /// <param name="minSkillLevel">minimum required skill level</param>
        private static void displayBoats(SkillLevel minSkillLevel)
        {
            bool boatFound = false;
            Console.WriteLine("Boats available for you to reserve:");

            foreach (var boat in BoathouseManager.Fleet)
            {
                if (boat.MinSkillLevelRequired <= minSkillLevel)
                {
                    boatFound = true;
                    Console.WriteLine($"    {boat.Id} : { boat.Name} has Required (min) Skill Level: {boat.MinSkillLevelRequired}");
                }
            }
            if (!boatFound)
            {
                Console.WriteLine("There are no boats available at your skill level.");
            }
        }

        /// <summary>
        /// prompt rower for boat reservation
        /// </summary>
        /// <param name="rower"></param>
        private static void getBoatReservation(Rower rower)
        {
            // display boats that this rower is allowed to reserve (based on skill level)
            displayBoats(rower.ApprovedSkillLevel);

            // prompt for boat id to Reserve
            Console.Write("Boat Number To Reserve: ");
            var boatId = int.Parse(Console.ReadLine());

            // TODO: need to validate input here

            //show boat availability for next 7 days
            var now = DateTime.Now;
            var today = now.Date;
            var bookedReservations = BoathouseManager.GetReservations(boatId, today, today.AddDays(7));
            for (var day = today; day <= today.AddDays(7); day = day.AddDays(1))
            {
                // if not already booked, it is available, so show the date
                if (!bookedReservations.Any(r => r.StartTime.Date == day))
                {
                    Console.WriteLine(day.ToString("d"));
                    // day = day.AddDays(1);
                }
            }

            // prompt for day to reserve boat
            Console.Write("Enter day desired: ");
            var dayToReserve = Console.ReadLine();
            DateTime reserveDate = DateTime.Parse(dayToReserve);

            // prompt for length of time of reservation (in hours)
            Console.Write("Enter time in hours to reserve: ");
            var hours = Console.ReadLine();
            var reserveLength = int.Parse(hours);


            var startTime = DateTime.Now.AddDays(1);
            var endTime = startTime.AddHours(4);
            var reservation = new Reservation(boatId, reserveDate, reserveLength, rower);
            BoathouseManager.Reservations.Add(reservation);
            Console.WriteLine($"Rower {rower.FirstName} has reservered boat {BoathouseManager.GetBoatNameById(reservation.BoatId)}");

        }
    }
}
