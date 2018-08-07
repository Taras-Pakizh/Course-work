namespace LabyrinthCreator
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.Grid = new System.Windows.Forms.DataGridView();
            this.TrackRows = new MetroFramework.Controls.MetroTrackBar();
            this.Create = new System.Windows.Forms.Button();
            this.TrackColumns = new MetroFramework.Controls.MetroTrackBar();
            this.Columns = new MetroFramework.Controls.MetroLabel();
            this.Rows = new MetroFramework.Controls.MetroLabel();
            this.ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.CheckOutput = new MetroFramework.Controls.MetroCheckBox();
            this.CheckWay = new MetroFramework.Controls.MetroCheckBox();
            this.MenuButton = new System.Windows.Forms.Button();
            this.FileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.Author = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.FileMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.AllowUserToOrderColumns = true;
            this.Grid.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid.DefaultCellStyle = dataGridViewCellStyle6;
            this.Grid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.Grid.Location = new System.Drawing.Point(23, 102);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid.RowTemplate.Height = 24;
            this.Grid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Grid.Size = new System.Drawing.Size(710, 700);
            this.Grid.TabIndex = 0;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyUp);
            // 
            // TrackRows
            // 
            this.TrackRows.BackColor = System.Drawing.Color.Transparent;
            this.TrackRows.Location = new System.Drawing.Point(260, 60);
            this.TrackRows.Maximum = 50;
            this.TrackRows.Minimum = 5;
            this.TrackRows.Name = "TrackRows";
            this.TrackRows.Size = new System.Drawing.Size(75, 23);
            this.TrackRows.TabIndex = 4;
            this.TrackRows.Text = "metroTrackBar1";
            this.TrackRows.Value = 25;
            this.TrackRows.ValueChanged += new System.EventHandler(this.TrackRows_ValueChanged);
            // 
            // Create
            // 
            this.Create.BackColor = System.Drawing.Color.LightGray;
            this.Create.FlatAppearance.BorderSize = 0;
            this.Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Create.Location = new System.Drawing.Point(23, 59);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 27);
            this.Create.TabIndex = 5;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = false;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // TrackColumns
            // 
            this.TrackColumns.BackColor = System.Drawing.Color.Transparent;
            this.TrackColumns.Location = new System.Drawing.Point(433, 60);
            this.TrackColumns.Maximum = 50;
            this.TrackColumns.Minimum = 5;
            this.TrackColumns.Name = "TrackColumns";
            this.TrackColumns.Size = new System.Drawing.Size(75, 23);
            this.TrackColumns.TabIndex = 6;
            this.TrackColumns.Text = "metroTrackBar2";
            this.TrackColumns.Value = 25;
            this.TrackColumns.ValueChanged += new System.EventHandler(this.TrackColumns_ValueChanged);
            // 
            // Columns
            // 
            this.Columns.AutoSize = true;
            this.Columns.Location = new System.Drawing.Point(341, 61);
            this.Columns.Name = "Columns";
            this.Columns.Size = new System.Drawing.Size(86, 20);
            this.Columns.TabIndex = 7;
            this.Columns.Text = "Columns: 25";
            // 
            // Rows
            // 
            this.Rows.AutoSize = true;
            this.Rows.Location = new System.Drawing.Point(190, 61);
            this.Rows.Name = "Rows";
            this.Rows.Size = new System.Drawing.Size(64, 20);
            this.Rows.TabIndex = 8;
            this.Rows.Text = "Rows: 25";
            // 
            // ComboBox
            // 
            this.ComboBox.FontSize = MetroFramework.MetroLinkSize.Small;
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.ItemHeight = 21;
            this.ComboBox.Items.AddRange(new object[] {
            "Kruskal",
            "Prim"});
            this.ComboBox.Location = new System.Drawing.Point(104, 59);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(80, 27);
            this.ComboBox.TabIndex = 9;
            this.ComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // Timer
            // 
            this.Timer.Interval = 50;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // CheckOutput
            // 
            this.CheckOutput.AutoSize = true;
            this.CheckOutput.Location = new System.Drawing.Point(521, 63);
            this.CheckOutput.Name = "CheckOutput";
            this.CheckOutput.Size = new System.Drawing.Size(98, 17);
            this.CheckOutput.TabIndex = 10;
            this.CheckOutput.Text = "Step by Step";
            this.CheckOutput.UseVisualStyleBackColor = true;
            // 
            // CheckWay
            // 
            this.CheckWay.AutoSize = true;
            this.CheckWay.Location = new System.Drawing.Point(630, 63);
            this.CheckWay.Name = "CheckWay";
            this.CheckWay.Size = new System.Drawing.Size(71, 17);
            this.CheckWay.TabIndex = 11;
            this.CheckWay.Text = "Solution";
            this.CheckWay.UseVisualStyleBackColor = true;
            // 
            // MenuButton
            // 
            this.MenuButton.BackColor = System.Drawing.Color.Transparent;
            this.MenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MenuButton.BackgroundImage")));
            this.MenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MenuButton.FlatAppearance.BorderSize = 0;
            this.MenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MenuButton.Location = new System.Drawing.Point(706, 59);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(27, 27);
            this.MenuButton.TabIndex = 13;
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // FileMenu
            // 
            this.FileMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.Save,
            this.SaveAs,
            this.Author});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FileMenu.Size = new System.Drawing.Size(130, 100);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(129, 24);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(129, 24);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(129, 24);
            this.SaveAs.Text = "Save As";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // Author
            // 
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(129, 24);
            this.Author.Text = "Author";
            this.Author.Click += new System.EventHandler(this.Author_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.Filter = "Text files (*.txt)|*.txt";
            // 
            // SaveDialog
            // 
            this.SaveDialog.Filter = "Text files (*.txt)|*.txt";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 833);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.CheckWay);
            this.Controls.Add(this.CheckOutput);
            this.Controls.Add(this.ComboBox);
            this.Controls.Add(this.Rows);
            this.Controls.Add(this.Columns);
            this.Controls.Add(this.TrackColumns);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.TrackRows);
            this.Controls.Add(this.Grid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Pink;
            this.Text = "Labyrinth";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.FileMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private MetroFramework.Controls.MetroTrackBar TrackRows;
        private System.Windows.Forms.Button Create;
        private MetroFramework.Controls.MetroTrackBar TrackColumns;
        private MetroFramework.Controls.MetroLabel Columns;
        private MetroFramework.Controls.MetroLabel Rows;
        private MetroFramework.Controls.MetroComboBox ComboBox;
        private System.Windows.Forms.Timer Timer;
        private MetroFramework.Controls.MetroCheckBox CheckOutput;
        private MetroFramework.Controls.MetroCheckBox CheckWay;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.ContextMenuStrip FileMenu;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.ToolStripMenuItem Author;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
    }
}

