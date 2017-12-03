using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    public static class ReservationManager
    {
        // public static List<Reservation> Reservations = new List<Reservation>();
        private static BoathouseRowModel db = new BoathouseRowModel();  // this opens connection to our db


        public static IEnumerable<Reservation> GetReservationsForBoat(int boatId, DateTime startDate, DateTime endDate)
        {
            var reservations = db.Reservations.Where(r => r.BoatId == boatId &&
                                                 r.StartTime.Date >= startDate &&
                                                 r.EndTime.Date <= endDate);
            return reservations;
        }

        public static Reservation MakeReservation(int boatId, DateTime startDate, int hoursToReserve, List<Rower> rowers)
        {
            DateTime endDate = startDate.AddHours(hoursToReserve);
            var boat = BoathouseManager.GetBoatById(boatId);
            var reservation = new Reservation(boatId, startDate, endDate, rowers);

            return reservation;
        }

        public static Reservation MakeReservation(int boatId, DateTime startDate, int hoursToReserve, Rower rower)
        {
            DateTime endDate = startDate.AddHours(hoursToReserve);
            var reservation = new Reservation(boatId, startDate, endDate, rower);

            return reservation;

        }
    }
}
