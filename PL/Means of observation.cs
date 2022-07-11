using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class MeansOfObservation
    {
        public MeansOfObservation(int id, Types type, double range, double sight)
        {
            Id = id;
            Type = type;
            Range = range;
            Sight = sight;
        }

        public int Id { get; set; }
        public Types Type { get; set; }
        public double Range { get; set; }
        public double Sight { get; set; }

    }
}
