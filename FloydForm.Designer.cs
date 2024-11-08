namespace Floyd
{
    partial class FloydForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.Button_SelectFile = new System.Windows.Forms.Button();
            this.Button_GO = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_SelectFile
            // 
            this.Button_SelectFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_SelectFile.Location = new System.Drawing.Point(0, 0);
            this.Button_SelectFile.Name = "Button_SelectFile";
            this.Button_SelectFile.Size = new System.Drawing.Size(1187, 30);
            this.Button_SelectFile.TabIndex = 0;
            this.Button_SelectFile.Text = "Select File";
            this.Button_SelectFile.UseVisualStyleBackColor = true;
            this.Button_SelectFile.Click += new System.EventHandler(this.Button_SelectFile_Click);
            // 
            // Button_GO
            // 
            this.Button_GO.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button_GO.Location = new System.Drawing.Point(258, 0);
            this.Button_GO.Name = "Button_GO";
            this.Button_GO.Size = new System.Drawing.Size(929, 46);
            this.Button_GO.TabIndex = 2;
            this.Button_GO.Text = "Show All Paths";
            this.Button_GO.UseVisualStyleBackColor = true;
            this.Button_GO.Click += new System.EventHandler(this.Button_GO_Click);
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1187, 680);
            this.chart.TabIndex = 3;
            this.chart.Text = "chart";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox);
            this.panel1.Controls.Add(this.Button_GO);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 715);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 46);
            this.panel1.TabIndex = 4;
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(12, 14);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(240, 21);
            this.comboBox.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chart);
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1187, 680);
            this.panel2.TabIndex = 5;
            // 
            // FloydForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Button_SelectFile);
            this.MinimumSize = new System.Drawing.Size(1203, 800);
            this.Name = "FloydForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Floyd";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_SelectFile;
        private System.Windows.Forms.Button Button_GO;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox;
    }
}

