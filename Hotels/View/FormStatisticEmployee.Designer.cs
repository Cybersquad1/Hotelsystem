namespace Hotels.View
{
    partial class FormStatisticEmployee
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatisticEmployee));
            this.chartSalary = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAge = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAge)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSalary
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSalary.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSalary.Legends.Add(legend1);
            this.chartSalary.Location = new System.Drawing.Point(39, 98);
            this.chartSalary.Name = "chartSalary";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.LegendText = "Workers";
            series1.Name = "Salary";
            this.chartSalary.Series.Add(series1);
            this.chartSalary.Size = new System.Drawing.Size(334, 300);
            this.chartSalary.TabIndex = 0;
            this.chartSalary.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Salary";
            this.chartSalary.Titles.Add(title1);
            this.chartSalary.Click += new System.EventHandler(this.chartSalary_Click);
            // 
            // chartAge
            // 
            chartArea2.Name = "ChartArea1";
            this.chartAge.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartAge.Legends.Add(legend2);
            this.chartAge.Location = new System.Drawing.Point(410, 98);
            this.chartAge.Name = "chartAge";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.LegendText = "Workers";
            series2.Name = "Age";
            this.chartAge.Series.Add(series2);
            this.chartAge.Size = new System.Drawing.Size(334, 300);
            this.chartAge.TabIndex = 1;
            this.chartAge.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title2.Name = "Age";
            this.chartAge.Titles.Add(title2);
            this.chartAge.Click += new System.EventHandler(this.chartAge_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(186, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Statistics on employees of the hotel chain";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FormStatisticEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 428);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartSalary);
            this.Controls.Add(this.chartAge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStatisticEmployee";
            this.Text = "Employee Statistics";
            this.Load += new System.EventHandler(this.FormStatistic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalary;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAge;
        private System.Windows.Forms.Label label1;
    }
}