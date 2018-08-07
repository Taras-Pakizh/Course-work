using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework.Forms;
using MetroFramework.Components;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace LabyrinthCreator
{
    public partial class Form : MetroForm
    {
        //Vars
        private Queue<StepInfo> m_stQueue;
        private int m_DefaultGridWidth;
        private int m_SelectedRowCell = 1;
        private int m_SelectedColCell = 1;
        private Labyrinth labyrinth;
        private BinaryFormatter formatter = new BinaryFormatter();

        //Delegate
        private Algorithm Strategy = new Algorithm();

        //Load
        public Form()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Headers
            Grid.ColumnHeadersVisible = false;
            Grid.RowHeadersVisible = false;

            //Selection
            Grid.DefaultCellStyle.SelectionForeColor = Color.Plum;
            Grid.DefaultCellStyle.SelectionBackColor = Color.Plum;

            //Disenable
            Grid.ScrollBars = ScrollBars.None;
            Grid.Enabled = false;

            //Queue
            m_stQueue = new Queue<StepInfo>();
            Timer.Enabled = false;

            //Algorithm
            Kruskal.SendStepInfo += AddToQueue;
            Prim.SendStepInfo += AddToQueue;
            Prim.GetSelection += SendSeletion;

            m_DefaultGridWidth = Grid.Width;

            ViewLabyrinth.SetGrig(Grid, TrackRows.Value, TrackColumns.Value, out int _heigth);
            this.Height = _heigth;
        }

        //Create Labyrinth
        private void Create_Click(object sender, EventArgs e)
        {
            Timer.Enabled = false;
            m_stQueue.Clear();

            Grid.Width = m_DefaultGridWidth;
            ViewLabyrinth.SetGrig(Grid, TrackRows.Value, TrackColumns.Value, out int _heigth);
            this.Height = _heigth;

            ComboBox_SelectedIndexChanged(this, e);
            if(ComboBox.SelectedIndex == 1)
            {
                Grid.DefaultCellStyle.SelectionBackColor = Color.White;
                Grid.Enabled = false;
            }

            Cell[][] matrix = new Cell[TrackRows.Value][];
            for (int i = 0; i < matrix.Length; ++i)
                matrix[i] = new Cell[TrackColumns.Value];
            for (int i = 0; i < matrix.Length; ++i)
                for (int j = 0; j < matrix[i].Length; ++j)
                    matrix[i][j] = new Cell(0);

            if (Strategy.Create == null) return;
            try
            {
                labyrinth = Strategy.Create(matrix);
                if (CheckOutput.Checked) Timer.Enabled = true;
                else
                {
                    ViewLabyrinth.SetLabyrinth(Grid, labyrinth);
                    ViewLabyrinth.SetStartAndFinish(Grid, labyrinth, CheckWay.Checked);
                }
            }
            catch(Exception ex)
            {
                ShowException form = new ShowException(ex);
                form.Show();
            }
        }

        //Tracks
        private void TrackRows_ValueChanged(object sender, EventArgs e)
        {
            Rows.Text = "Rows: " + TrackRows.Value;
            Timer.Enabled = false;
            Grid.Width = m_DefaultGridWidth;
            Grid.DefaultCellStyle.SelectionBackColor = Color.Plum;
            ViewLabyrinth.SetGrig(Grid, TrackRows.Value, TrackColumns.Value, out int _heigth);
            this.Height = _heigth;
        }
        private void TrackColumns_ValueChanged(object sender, EventArgs e)
        {
            Columns.Text = "Columns: " + TrackColumns.Value;
            Timer.Enabled = false;
            Grid.Width = m_DefaultGridWidth;
            Grid.DefaultCellStyle.SelectionBackColor = Color.Plum;
            ViewLabyrinth.SetGrig(Grid, TrackRows.Value, TrackColumns.Value, out int _heigth);
            this.Height = _heigth;
        }

        //Step by Step Output
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (m_stQueue.Count == 0) return;
            StepInfo stepInfo = m_stQueue.Dequeue();
            if(stepInfo.Item1.Row == -1)
            {
                try { ViewLabyrinth.SetStartAndFinish(Grid, labyrinth, CheckWay.Checked); }
                catch(Exception ex)
                {
                    ShowException form = new ShowException(ex);
                    form.Show();
                }
                Timer.Enabled = false;
                return;
            }
            try { ViewLabyrinth.StepTick(stepInfo, Grid); }
            catch(ViewLabyrinth.GridCellIndexOutOfRange ex)
            {
                ShowException form = new ShowException(ex);
                form.Show();
                Timer.Enabled = false;
            }
        }
        private void AddToQueue(object sender, StepInfo stepInfo)
        {
            m_stQueue.Enqueue(stepInfo);
        }

        //Prim
        private void SendSeletion(out int row, out int col)
        {
            row = m_SelectedRowCell / 2;
            col = m_SelectedColCell / 2;
        }
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (Grid.DefaultCellStyle.SelectionBackColor != Color.Blue) Grid.DefaultCellStyle.SelectionBackColor = Color.Blue;
            Grid.Rows[m_SelectedRowCell].Cells[m_SelectedColCell].Selected = false;
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (m_SelectedRowCell != Grid.ColumnCount - 2)
                        m_SelectedRowCell += 2;
                    break;
                case Keys.Up:
                    if (m_SelectedRowCell != 1)
                        m_SelectedRowCell -= 2;
                    break;
                case Keys.Left:
                    if (m_SelectedColCell != 1)
                        m_SelectedColCell -= 2;
                    break;
                case Keys.Right:
                    if (m_SelectedColCell != Grid.RowCount - 2)
                        m_SelectedColCell += 2;
                    break;
                default: break;
            }
            Grid.Rows[m_SelectedRowCell].Cells[m_SelectedColCell].Selected = true;
        }

        //ComboBox
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox.SelectedIndex == 0)
            {
                Strategy.Create = Kruskal.Create;
                Grid.Rows[0].Cells[0].Selected = true;
                Grid.Enabled = false;
                Grid.DefaultCellStyle.SelectionForeColor = Color.Plum;
                Grid.DefaultCellStyle.SelectionBackColor = Color.Plum;
            }
            if (ComboBox.SelectedIndex == 1)
            {
                Strategy.Create = Prim.Create;
                Grid.DefaultCellStyle.SelectionForeColor = Color.Blue;
                Grid.DefaultCellStyle.SelectionBackColor = Color.Blue;
                Grid.Enabled = true;
                Grid.Select();
                Grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
                Grid.Rows[m_SelectedRowCell].Cells[m_SelectedColCell].Selected = true;
            }
        }

        //Menu
        private void MenuButton_Click(object sender, EventArgs e)
        {
            FileMenu.Show(this, new Point(MenuButton.Location.X + MenuButton.Width - FileMenu.Width, MenuButton.Location.Y + MenuButton.Height));
        }

        //Menu Controls
        private void Save_Click(object sender, EventArgs e)
        {
            if (labyrinth == null) return;
            if(SaveDialog.FileName.Length == 0)
                if (SaveDialog.ShowDialog() == DialogResult.Cancel) return;
            ProgressSave save = new ProgressSave();
            save.Show();
            using(FileStream fs = new FileStream(SaveDialog.FileName, FileMode.OpenOrCreate))
                formatter.Serialize(fs, labyrinth);
        }
        private void Open_Click(object sender, EventArgs e)
        {
            if (OpenDialog.ShowDialog() == DialogResult.Cancel) return;
            try
            {
                using (FileStream fs = new FileStream(OpenDialog.FileName, FileMode.Open))
                    labyrinth = (Labyrinth)formatter.Deserialize(fs);
                ShowSavedlabyrinth();
            }
            catch(System.Runtime.Serialization.SerializationException ex)
            {
                ShowException show = new ShowException(new Exception("Disable to open file"));
                show.Show();
            }
            catch(Exception ex)
            {
                ShowException show = new ShowException(ex);
                show.Show();
            }
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (labyrinth == null) return;
            if (SaveDialog.ShowDialog() == DialogResult.Cancel) return;
            ProgressSave save = new ProgressSave();
            save.Show();
            using (FileStream fs = new FileStream(SaveDialog.FileName, FileMode.OpenOrCreate))
                formatter.Serialize(fs, labyrinth);
        }
        private void Author_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Show();
        }
        private void ShowSavedlabyrinth()
        {
            Timer.Enabled = false;
            m_stQueue.Clear();

            Grid.Width = m_DefaultGridWidth;
            ViewLabyrinth.SetGrig(Grid, labyrinth.Rows, labyrinth.Columns, out int _heigth);
            this.Height = _heigth;

            ViewLabyrinth.SetLabyrinth(Grid, labyrinth);
            ViewLabyrinth.SetStartAndFinish(Grid, labyrinth, CheckWay.Checked);
        }
    }
}
