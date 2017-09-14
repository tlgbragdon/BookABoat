using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    class Reservations
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BoatId { get; set; }
        public List<Rower> ResponsibleRowers { get; set; }
       
    }
}
