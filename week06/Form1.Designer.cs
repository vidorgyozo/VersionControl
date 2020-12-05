namespace week06
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ratesDataGrid = new System.Windows.Forms.DataGridView();
            this.ratesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ratesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(871, 564);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(115, 16);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // ratesDataGrid
            // 
            this.ratesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ratesDataGrid.Location = new System.Drawing.Point(13, 46);
            this.ratesDataGrid.Name = "ratesDataGrid";
            this.ratesDataGrid.Size = new System.Drawing.Size(280, 512);
            this.ratesDataGrid.TabIndex = 1;
            // 
            // ratesChart
            // 
            chartArea8.Name = "ChartArea1";
            this.ratesChart.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.ratesChart.Legends.Add(legend8);
            this.ratesChart.Location = new System.Drawing.Point(299, 46);
            this.ratesChart.Name = "ratesChart";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.ratesChart.Series.Add(series8);
            this.ratesChart.Size = new System.Drawing.Size(687, 512);
            this.ratesChart.TabIndex = 2;
            this.ratesChart.Text = "chart1";
            // 
            // startTimePicker
            // 
            this.startTimePicker.Location = new System.Drawing.Point(13, 20);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startTimePicker.TabIndex = 3;
            this.startTimePicker.ValueChanged += new System.EventHandler(this.startTimePicker_ValueChanged);
            // 
            // endTimePicker
            // 
            this.endTimePicker.Location = new System.Drawing.Point(220, 20);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endTimePicker.TabIndex = 4;
            this.endTimePicker.ValueChanged += new System.EventHandler(this.endTimePicker_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "EUR"});
            this.comboBox1.Location = new System.Drawing.Point(427, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "EUR";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 588);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.ratesChart);
            this.Controls.Add(this.ratesDataGrid);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ratesDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratesChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView ratesDataGrid;
        private System.Windows.Forms.DataVisualization.Charting.Chart ratesChart;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

