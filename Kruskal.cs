using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthCreator
{
    static class Kruskal
    {
        public delegate void SendNextStep(object sender, StepInfo stepinfo);
        public static event SendNextStep SendStepInfo;

        //Create
        public static Labyrinth Create(Cell[][] cells)
        {
            if (cells.Length > 50 || cells.Length < 5 || cells[0].Length < 5 || cells[0].Length > 50)
                throw new SizeOutOfRange("Kruskal.SizeOutOfRange: Size of labyrinth out of range");

            Labyrinth labyrinth = new Labyrinth(cells);
            labyrinth.SetOutsideWalls(false);
            Random random = new Random();
            int Sets = labyrinth.Rows * labyrinth.Columns;

            Cell CurrentCell;
            int row, col, NextId = 1;
            while (Sets > 1)
            {
                row = random.Next(0, labyrinth.Rows);
                col = random.Next(0, labyrinth.Columns);
                CurrentCell = labyrinth[row, col];
                if (CurrentCell.IsWall())
                {
                    int WallId;
                    do
                    {
                        WallId = random.Next(0, 4);
                        if (CurrentCell.Walls[WallId]) break;
                    } while (true);
                    int NextRow = row, NextCol = col;
                    GetNextCell(ref labyrinth, ref NextRow, ref NextCol, WallId, out bool Correct);
                    if (!Correct) continue;
                    UniteCells(ref labyrinth, new CellPoint(row, col), new CellPoint(NextRow, NextCol), ref NextId);
                    --Sets;
                }
                else continue;
            }
            SendStepInfo?.Invoke(labyrinth, new StepInfo(new CellPoint(-1, -1), new CellPoint(-1, -1)));
            return labyrinth;
        }

        //Methods
        private static void UniteCells(ref Labyrinth labyrinth, CellPoint first, CellPoint second, ref int NextId)
        {
            int Id1 = labyrinth[first.Row, first.Col].Id;
            int Id2 = labyrinth[second.Row, second.Col].Id;

            if (Id1 != 0 && Id2 != 0)
                for (int i = 0; i < labyrinth.Rows; ++i)
                    for (int j = 0; j < labyrinth.Columns; ++j)
                        if (labyrinth[i, j].Id == Id2) labyrinth[i, j].Id = Id1;

            if (Id1 == 0 && Id2 == 0)
            {
                labyrinth[first.Row, first.Col].Id = NextId;
                labyrinth[second.Row, second.Col].Id = NextId;
                ++NextId;
            }
            else if (Id1 == 0)
                labyrinth[first.Row, first.Col].Id = Id2;
            else if (Id2 == 0)
                labyrinth[second.Row, second.Col].Id = Id1;
        }
        private static void GetNextCell(ref Labyrinth labyrinth, ref int row, ref int col, int WallId, out bool Correct)
        {
            Correct = true;
            int LastRow = row;
            int LastCol = col;
            int LastId = WallId;

            if (WallId == 0) { --row; WallId = 2; }
            else if (WallId == 1) { ++col; WallId = 3; }
            else if (WallId == 2) { ++row; WallId = 0; }
            else if (WallId == 3) { --col; WallId = 1; }

            if (labyrinth[LastRow, LastCol].Id == labyrinth[row, col].Id)
                if (labyrinth[row, col].Id != 0) Correct = false;

            if (Correct)
            {
                Cell cell = labyrinth[row, col];
                cell.Walls[WallId] = false;
                cell = labyrinth[LastRow, LastCol];
                cell.Walls[LastId] = false;
                SendStepInfo?.Invoke(labyrinth, new StepInfo(new CellPoint(row, col), new CellPoint(LastRow, LastCol)));
            }
        }

        //Exceptions
        public class SizeOutOfRange : Exception
        {
            public SizeOutOfRange(string messege) : base(messege) { }
        }
    }
}