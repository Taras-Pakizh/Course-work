using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LabyrinthCreator
{
    static class ViewLabyrinth
    {
        //Create Grid
        public static void SetGrig(DataGridView Grid, int _row, int _col, out int _FormHeight)
        {
            //Create
            Grid.Columns.Clear();
            for (int i = 0; i < _col * 2 + 1; ++i)
                Grid.Columns.Add("", "");
            for (int i = 0; i < _row * 2; ++i)
                Grid.Rows.Add();

            //Color
            for (int i = 0; i < Grid.RowCount; ++i)
                for (int j = 0; j < Grid.ColumnCount; ++j)
                    Grid.Rows[i].Cells[j].Style.BackColor = Color.Plum;

            //Fill----------------------------------------

            //Count Width and Remainder
            int count = Grid.Columns.Count / 2;
            count = count * 3 + 1;
            int Width = Grid.Width / count;
            int Remainder = Grid.Width % count;

            //Columns Width
            int[] ColumnsWidths = new int[Grid.ColumnCount];
            for (int i = 0; i < Grid.ColumnCount; ++i)
                ColumnsWidths[i] = Width;
            for (int i = 1; i < Grid.ColumnCount; i += 2)
                ColumnsWidths[i] += Width;
            for (int i = 0, j = i; i < Remainder; ++i, ++j)
            {
                if (j == Grid.ColumnCount) j = 0;
                ++ColumnsWidths[j];
            }
            for (int i = 0; i < Grid.ColumnCount; ++i)
                Grid.Columns[i].Width = ColumnsWidths[i];

            //Rows Height
            int height = 0;
            for (int i = 0; i < Grid.RowCount; i += 2)
            {
                Grid.Rows[i].Height = Width;
                height += Grid.Rows[i].Height;
            }
            for (int i = 1; i < Grid.RowCount; i += 2)
            {
                Grid.Rows[i].Height = 2 * Width;
                height += Grid.Rows[i].Height;
            }
            if (height > 900)
            {
                double scale = (double)height / Grid.Width;
                Grid.Width = (int)(Grid.Width / scale);
                SetGrig(Grid, _row, _col, out _FormHeight);
                return;
            }
            Grid.Height = height;

            //Form
            _FormHeight = Grid.Height + 125;
        }
        //Create Labyrinth
        public static void SetLabyrinth(DataGridView Grid, Labyrinth labyrinth)
        {
            for (int row = 1; row < Grid.RowCount; row += 2)
                for (int col = 1; col < Grid.ColumnCount; col += 2)
                    Grid.Rows[row].Cells[col].Style.BackColor = Color.White;

            for (int row = 1, Row = 0; row < Grid.RowCount - 1; row += 2, ++Row)
                for (int col = 2, Col = 0; col < Grid.ColumnCount; col += 2, ++Col)
                {
                    if (!labyrinth[Row, Col].Right && col < Grid.ColumnCount - 1) Grid.Rows[row].Cells[col].Style.BackColor = Color.White;
                    if (!labyrinth[Row, Col].Down && row != Grid.RowCount - 2) Grid.Rows[row + 1].Cells[col - 1].Style.BackColor = Color.White;
                }
        }
        //Set Start and End Points, Create way
        public static void SetStartAndFinish(DataGridView Grid, Labyrinth labyrinth, bool CheckWay)
        {
            StepInfo stepInfo = labyrinth.MostDifficultWay();
            Grid.Rows[stepInfo.Item1.Row * 2 + 1].Cells[stepInfo.Item1.Col * 2 + 1].Style.BackColor = Color.Aqua;
            Grid.Rows[stepInfo.Item2.Row * 2 + 1].Cells[stepInfo.Item2.Col * 2 + 1].Style.BackColor = Color.Aqua;
            if (CheckWay)
            {
                labyrinth.SetOutsideWalls(true);
                for (int i = 0; i < labyrinth.Rows; ++i)
                    for (int j = 0; j < labyrinth.Columns; ++j)
                        labyrinth[i, j].Id = 0;
                //Find way
                labyrinth[stepInfo.Item1.Row, stepInfo.Item1.Col].Id = -1;
                labyrinth.SetWay(stepInfo.Item1.Row, stepInfo.Item1.Col, 1);
                labyrinth[stepInfo.Item1.Row, stepInfo.Item1.Col].Id = 1;

                Cell CurrentCell = labyrinth[stepInfo.Item2.Row, stepInfo.Item2.Col];
                int CRow = stepInfo.Item2.Row, CCol = stepInfo.Item2.Col, BridgeRow, BridgeCol;
                for (int MaxId = CurrentCell.Id; MaxId > 1; --MaxId)
                {
                    BridgeRow = 0; BridgeCol = 0;
                    if (!CurrentCell.Up && labyrinth[CRow - 1, CCol].Id == MaxId - 1) { --CRow; BridgeRow = 1; }
                    else if (!CurrentCell.Right && labyrinth[CRow, CCol + 1].Id == MaxId - 1) { ++CCol; BridgeCol = -1; }
                    else if (!CurrentCell.Down && labyrinth[CRow + 1, CCol].Id == MaxId - 1) { ++CRow; BridgeRow = -1; }
                    else if (!CurrentCell.Left && labyrinth[CRow, CCol - 1].Id == MaxId - 1) { --CCol; BridgeCol = 1; }
                    CurrentCell = labyrinth[CRow, CCol];
                    if (CurrentCell.Id != 1)
                        Grid.Rows[CRow * 2 + 1].Cells[CCol * 2 + 1].Style.BackColor = Color.Aquamarine;
                    Grid.Rows[CRow * 2 + 1 + BridgeRow].Cells[CCol * 2 + 1 + BridgeCol].Style.BackColor = Color.Aquamarine;
                }
            }
        }
        //Step by Step
        public static void StepTick(StepInfo stepInfo, DataGridView Grid)
        {
            int row1 = 1, col1 = 1, row2 = 1, col2 = 1;
            row1 += stepInfo.Item1.Row * 2;
            col1 += stepInfo.Item1.Col * 2;
            row2 += stepInfo.Item2.Row * 2;
            col2 += stepInfo.Item2.Col * 2;
            if (row1 < 0 || row1 >= Grid.RowCount || col1 < 0 || col1 >= Grid.ColumnCount)
                throw new GridCellIndexOutOfRange("Form1.GridCellIndexOutOfRange: called for inexistent cell");
            Grid.Rows[row1].Cells[col1].Style.BackColor = Color.White;
            if (row2 < 0 || row2 >= Grid.RowCount || col2 < 0 || col2 >= Grid.ColumnCount)
                throw new GridCellIndexOutOfRange("Form1.GridCellIndexOutOfRange: called for inexistent cell");
            Grid.Rows[row2].Cells[col2].Style.BackColor = Color.White;

            if (row1 == row2)
            {
                int col = col1 + 1;
                if (col1 > col2) col = col1 - 1;
                Grid.Rows[row1].Cells[col].Style.BackColor = Color.White;
            }
            else if (col1 == col2)
            {
                int row = row1 + 1;
                if (row1 > row2) row = row1 - 1;
                Grid.Rows[row].Cells[col1].Style.BackColor = Color.White;
            }
        }

        //Exception
        public class GridCellIndexOutOfRange : Exception
        {
            public GridCellIndexOutOfRange(string messege) : base(messege) { }
        }
    }
}