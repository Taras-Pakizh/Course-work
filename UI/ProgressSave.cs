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

namespace LabyrinthCreator
{
    public partial class ProgressSave : MetroForm
    {
        public ProgressSave()
        {
            InitializeComponent();
        }
        private void ProgressSave_Load(object sender, EventArgs e)
        {
            TimerStop.Enabled = true;   
        }

        private void TimerStop_Tick(object sender, EventArgs e)
        {
            TimerStop.Enabled = false;
            this.Close();
        }
    }
}
