namespace HW5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.load = new System.Windows.Forms.Button();
            this.grayscale = new System.Windows.Forms.Button();
            this.grayscale_check = new System.Windows.Forms.CheckBox();
            this.original_check = new System.Windows.Forms.CheckBox();
            this.histogram = new System.Windows.Forms.Button();
            this.image = new System.Windows.Forms.PictureBox();
            this.close_results = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(12, 12);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(119, 23);
            this.load.TabIndex = 0;
            this.load.Text = "Load Image";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // grayscale
            // 
            this.grayscale.Location = new System.Drawing.Point(12, 41);
            this.grayscale.Name = "grayscale";
            this.grayscale.Size = new System.Drawing.Size(119, 23);
            this.grayscale.TabIndex = 1;
            this.grayscale.Text = "Grayscale";
            this.grayscale.UseVisualStyleBackColor = true;
            this.grayscale.Click += new System.EventHandler(this.grayscale_Click);
            // 
            // grayscale_check
            // 
            this.grayscale_check.AutoSize = true;
            this.grayscale_check.Location = new System.Drawing.Point(12, 70);
            this.grayscale_check.Name = "grayscale_check";
            this.grayscale_check.Size = new System.Drawing.Size(119, 19);
            this.grayscale_check.TabIndex = 3;
            this.grayscale_check.Text = "Process Grayscale";
            this.grayscale_check.UseVisualStyleBackColor = true;
            // 
            // original_check
            // 
            this.original_check.AutoSize = true;
            this.original_check.Location = new System.Drawing.Point(12, 95);
            this.original_check.Name = "original_check";
            this.original_check.Size = new System.Drawing.Size(111, 19);
            this.original_check.TabIndex = 4;
            this.original_check.Text = "Process Original";
            this.original_check.UseVisualStyleBackColor = true;
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point(12, 120);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(119, 38);
            this.histogram.TabIndex = 5;
            this.histogram.Text = "Histogram Equilization";
            this.histogram.UseVisualStyleBackColor = true;
            this.histogram.Click += new System.EventHandler(this.histogram_Click);
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(137, 14);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(0, 0);
            this.image.TabIndex = 6;
            this.image.TabStop = false;
            // 
            // close_results
            // 
            this.close_results.Location = new System.Drawing.Point(12, 164);
            this.close_results.Name = "close_results";
            this.close_results.Size = new System.Drawing.Size(119, 25);
            this.close_results.TabIndex = 7;
            this.close_results.Text = "Close All Results";
            this.close_results.UseVisualStyleBackColor = true;
            this.close_results.Click += new System.EventHandler(this.close_results_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(142, 201);
            this.Controls.Add(this.close_results);
            this.Controls.Add(this.image);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.original_check);
            this.Controls.Add(this.grayscale_check);
            this.Controls.Add(this.grayscale);
            this.Controls.Add(this.load);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Histogram Equilization";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button load;
        private Button grayscale;
        private CheckBox grayscale_check;
        private CheckBox original_check;
        private Button histogram;
        private PictureBox image;
        private Button close_results;
    }
}