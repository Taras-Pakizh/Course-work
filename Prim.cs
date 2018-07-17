using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthCreator
{
    [Serializable]
    enum Atributs
    {
        Outside = 0,
        Border = 1,
        Inside = 2
    }

    static class Prim
    {
        public delegate void SendNextStep(object sender, StepInfo stepinfo);
        public delegate void SendSelection(out int row, out int col);
        public static event SendNextStep SendStepInfo;
        public static event SendSelection GetSelection;

        public static Labyrinth Create(Cell[][] cells)
        {
            if (cells.Length > 50 || cells.Length < 5 || cells[0].Length < 5 || cells[0].Length > 50)
                throw new SizeOutOfRange("Kruskal.SizeOutOfRange: Size of labyrinth out of range");
            Labyrinth labyrinth = new Labyrinth(cells);
            GetSelection(out int row, out int col);
            if (row < 0 || row >= cells.Length || col < 0 || col >= cells[0].Length)
                throw new CellOutOfRangeExeption("Prim.CellOutOfRangeException: Selected inexistent cell");
            labyrinth.ToInside(row, col);

            Random random = new Random();
            CellPoint cellPoint;
            while(labyrinth.BordersCount > 0)
            {
                int SomeBorder = random.Next(0, labyrinth.BordersCount);
                for(int irow = 0, k = 0; irow < labyrinth.Rows; ++irow)
                    for(int icol = 0; icol < labyrinth.Columns; ++icol)
                    {
                        if(labyrinth[irow, icol].Atribut == Atributs.Border)
                        {
                            if (k == SomeBorder)
                            {
                                labyrinth.ToInside(irow, icol);
                                cellPoint = labyrinth.ConnectToInside(irow, icol);
                                SendStepInfo?.Invoke(labyrinth, new StepInfo(cellPoint, new CellPoint(irow, icol)));
                                irow = labyrinth.Rows;
                                break;
                            }
                            else ++k;
                        }
                    }
            }
            SendStepInfo?.Invoke(cells, new StepInfo(new CellPoint(-1, -1), new CellPoint(-1, -1)));

            return labyrinth;
        }

        public class CellOutOfRangeExeption : Exception
        {
            public CellOutOfRangeExeption(string messege):base(messege){}
        }
        public class SizeOutOfRange : Exception
        {
            public SizeOutOfRange(string messege) : base(messege) { }
        }
    }
}