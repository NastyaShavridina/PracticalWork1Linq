using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalWork1Linq
{
    class ComparerTechniqueByCost : IComparer<ComputingTechnics>
    {
        public int Compare(ComputingTechnics p1, ComputingTechnics p2)
        {
            if (p1.Cost > p2.Cost)
                return 1;
            else if (p1.Cost < p2.Cost)
                return -1;
            else
                return 0;
        }
    }
}
