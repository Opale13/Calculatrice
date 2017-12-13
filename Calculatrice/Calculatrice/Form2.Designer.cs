namespace Calculatrice
{
    partial class Form2
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
            this.display = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Calculatrice = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(7, 12);
            this.display.Multiline = true;
            this.display.Name = "display";
            this.display.ReadOnly = true;
            this.display.Size = new System.Drawing.Size(366, 155);
            this.display.TabIndex = 0;
            this.display.TextChanged += new System.EventHandler(this.display_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 174);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(366, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Calculatrice
            // 
            this.Calculatrice.Location = new System.Drawing.Point(393, 12);
            this.Calculatrice.Name = "Calculatrice";
            this.Calculatrice.Size = new System.Drawing.Size(98, 23);
            this.Calculatrice.TabIndex = 2;
            this.Calculatrice.Text = "Calculatrice";
            this.Calculatrice.UseVisualStyleBackColor = true;
            this.Calculatrice.Click += new System.EventHandler(this.Calculatrice_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(393, 174);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(98, 23);
            this.Search.TabIndex = 3;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 206);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Calculatrice);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.display);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox display;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Calculatrice;
        private System.Windows.Forms.Button Search;
    }
}