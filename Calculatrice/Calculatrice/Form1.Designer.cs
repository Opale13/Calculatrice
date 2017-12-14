namespace Calculatrice
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.AvailableFonction = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveTrace = new System.Windows.Forms.Button();
            this.display = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AvailableFonction
            // 
            this.AvailableFonction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AvailableFonction.Location = new System.Drawing.Point(324, 12);
            this.AvailableFonction.Name = "AvailableFonction";
            this.AvailableFonction.Size = new System.Drawing.Size(97, 34);
            this.AvailableFonction.TabIndex = 0;
            this.AvailableFonction.Text = "What can I do?";
            this.AvailableFonction.UseVisualStyleBackColor = true;
            this.AvailableFonction.Click += new System.EventHandler(this.AvailableFonction_Click);
            // 
            // Help
            // 
            this.Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Help.Location = new System.Drawing.Point(324, 52);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(97, 34);
            this.Help.TabIndex = 1;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(324, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Compute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveTrace
            // 
            this.SaveTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveTrace.Location = new System.Drawing.Point(324, 327);
            this.SaveTrace.Name = "SaveTrace";
            this.SaveTrace.Size = new System.Drawing.Size(97, 20);
            this.SaveTrace.TabIndex = 3;
            this.SaveTrace.Text = "SaveText";
            this.SaveTrace.UseVisualStyleBackColor = true;
            this.SaveTrace.Click += new System.EventHandler(this.SaveTrace_Click);
            // 
            // display
            // 
            this.display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.display.Location = new System.Drawing.Point(10, 12);
            this.display.Multiline = true;
            this.display.Name = "display";
            this.display.ReadOnly = true;
            this.display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.display.Size = new System.Drawing.Size(308, 269);
            this.display.TabIndex = 4;
            this.display.TextChanged += new System.EventHandler(this.display_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(10, 287);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(308, 60);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 357);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.display);
            this.Controls.Add(this.SaveTrace);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.AvailableFonction);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculatrice";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AvailableFonction;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SaveTrace;
        private System.Windows.Forms.TextBox display;
        private System.Windows.Forms.TextBox textBox1;
    }
}

