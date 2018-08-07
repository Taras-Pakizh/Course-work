using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthCreator
{
    public class StepInfo
    {
        public CellPoint Item1 { get; }
        public CellPoint Item2 { get; }

        public StepInfo(CellPoint item1, CellPoint item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }
}
