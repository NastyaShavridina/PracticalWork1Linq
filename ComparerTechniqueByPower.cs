using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalWork1Linq
{
    class ComparerTechniqueByPower : IComparer<ComputingTechnics>
    {
        public int Compare(ComputingTechnics p1, ComputingTechnics p2)
        {
            if (p1.ComputingPower > p2.ComputingPower)
                return 1;
            else if (p1.ComputingPower < p2.ComputingPower)
                return -1;
            else
                return 0;
        }
    }
}
