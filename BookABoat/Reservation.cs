using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    /// <summary>
    /// A reservation is for a boat and one or more rowers for a particular time period
    /// </summary>
    public class Reservation
    {

        private static int lastReservationId = 0;

        #region Public Properties
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BoatId { get; set; }
        public List<Rower> ResponsibleRowers { get; set; }
        #endregion

        #region constructors
        public Reservation(int boatId, DateTime start, int numHours, Rower rower)
        {
            Id = ++lastReservationId;
            BoatId = boatId;
            StartTime = start;
            EndTime = start.AddHours(numHours);
            ResponsibleRowers = new List<Rower>();
            ResponsibleRowers.Add(rower);
        }

        public Reservation(Boat boat, DateTime start, DateTime end, List<Rower> rowers)
        {
            Id = ++lastReservationId;
            BoatId = boat.Id;
            StartTime = start;
            EndTime = end;
            ResponsibleRowers = new List<Rower>();
            ResponsibleRowers = rowers;
        }
        #endregion

        #region Public Methods
        public void AddRowerToReservation(Rower rower)
        {
            ResponsibleRowers.Add(rower);
            Console.WriteLine($"Rower {rower.FirstName} added to reservation for the boat {BoathouseManager.GetBoatNameById(BoatId)}");
        }

        public void RemoveRowerFromReservation(Rower rower)
        {
            ResponsibleRowers.Remove(rower);
            Console.WriteLine($"Rower {rower.FirstName} removed from reservation for the boat {BoathouseManager.GetBoatNameById(BoatId)}");

        }
        #endregion


    }
}
