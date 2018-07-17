using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthCreator
{
    class Algorithm
    {
        public delegate Labyrinth DelCreate(Cell[][] matrix);
        public DelCreate Create;

        public Algorithm(){}
    }
}
