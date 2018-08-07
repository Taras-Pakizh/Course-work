namespace LabyrinthCreator
{
    partial class ProgressSave
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Spinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.TimerStop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Spinner
            // 
            this.Spinner.Location = new System.Drawing.Point(121, 28);
            this.Spinner.Maximum = 4;
            this.Spinner.Name = "Spinner";
            this.Spinner.Size = new System.Drawing.Size(30, 26);
            this.Spinner.TabIndex = 0;
            // 
            // TimerStop
            // 
            this.TimerStop.Interval = 1500;
            this.TimerStop.Tick += new System.EventHandler(this.TimerStop_Tick);
            // 
            // ProgressSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 80);
            this.ControlBox = false;
            this.Controls.Add(this.Spinner);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressSave";
            this.Resizable = false;
            this.Text = "Saving";
            this.Load += new System.EventHandler(this.ProgressSave_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroProgressSpinner Spinner;
        private System.Windows.Forms.Timer TimerStop;
    }
}