using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookABoat
{
    public class Boat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BoatType Type { get; set; }
        public WeightClass WeightClass { get; set; }
        public SkillLevel MinSkillLevelRequired { get; set; }
        public List<Rower>Rowers { get; set; }
    }


    public enum BoatType
    {
        FourShell,
        QuadShell,
        DoubleShell,
        PairShell,
        SingleShell
    }

    public enum WeightClass
    {
        Lightweight,
        Midweight,
        Heavyweight
    }

    public enum SkillLevel
    {
        NoviceSkill = 0,
        QuadSkill = 10,
        DoubleSkill = 20,
        PairSkill = 25,
        SingleSkill = 30,
        ExpertSingleSkill = 40
        
    }
}
