using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthCreator
{
    public class CellPoint
    {
        public int Row { get; }
        public int Col { get; }
        public CellPoint(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}