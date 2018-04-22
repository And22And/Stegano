namespace Stegano.Analisys
{
    partial class AnalisysForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.analisisHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.showButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.analisisHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // analisisHistogram
            // 
            chartArea.Name = "ChartArea";
            this.analisisHistogram.ChartAreas.Add(chartArea);
            legend2.Name = "Legend1";
            this.analisisHistogram.Legends.Add(legend2);
            this.analisisHistogram.Location = new System.Drawing.Point(0, 0);
            this.analisisHistogram.Name = "analisisHistogram";
            this.analisisHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.analisisHistogram.Size = new System.Drawing.Size(880, 559);
            this.analisisHistogram.TabIndex = 2;
            this.analisisHistogram.Text = "chart1";
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(888, 12);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(80, 23);
            this.showButton.TabIndex = 3;
            this.showButton.Text = "Show values";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // hideButton
            // 
            this.hideButton.Location = new System.Drawing.Point(888, 50);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(80, 23);
            this.hideButton.TabIndex = 4;
            this.hideButton.Text = "Hide values";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // AnalisysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 561);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.analisisHistogram);
            this.Name = "AnalisysForm";
            this.Text = "Analisis";
            ((System.ComponentModel.ISupportInitialize)(this.analisisHistogram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart analisisHistogram;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button hideButton;
    }
}