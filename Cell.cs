using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthCreator
{
    [Serializable]
    class Cell
    {
        public int Id;
        public bool[] Walls;
        public Atributs Atribut;

        public bool Up { get { return Walls[0]; } set { Walls[0] = value; } }
        public bool Right { get { return Walls[1]; } set { Walls[1] = value; } }
        public bool Down { get { return Walls[2]; } set { Walls[2] = value; } }
        public bool Left { get { return Walls[3]; } set { Walls[3] = value; } }

        public Cell(int id)
        {
            Id = id;
            Walls = new bool[4];
            for (int i = 0; i < Walls.Length; ++i)
                Walls[i] = true;

            switch (Id)
            {
                case 0:
                    Atribut = Atributs.Outside;
                    break;
                case 1:
                    Atribut = Atributs.Border;
                    break;
                case 2:
                    Atribut = Atributs.Inside;
                    break;
                default:
                    Atribut = Atributs.Outside;
                    break;
            }
        } 
        public bool IsWall()
        {
            bool answer = false;
            for (int i = 0; i < Walls.Length; ++i)
                if (Walls[i]) answer = true;
            return answer;
        }
    }
}