namespace Snake
{
    partial class Gra
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.przyciskStart = new System.Windows.Forms.Button();
            this.przyciskScreen = new System.Windows.Forms.Button();
            this.oknoGry = new System.Windows.Forms.PictureBox();
            this.wynikGry = new System.Windows.Forms.Label();
            this.rekordGry = new System.Windows.Forms.Label();
            this.czasGry = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.oknoGry)).BeginInit();
            this.SuspendLayout();
            // 
            // przyciskStart
            // 
            this.przyciskStart.BackColor = System.Drawing.Color.PaleGreen;
            this.przyciskStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.przyciskStart.Location = new System.Drawing.Point(632, 12);
            this.przyciskStart.Name = "przyciskStart";
            this.przyciskStart.Size = new System.Drawing.Size(92, 52);
            this.przyciskStart.TabIndex = 0;
            this.przyciskStart.Text = "Start";
            this.przyciskStart.UseVisualStyleBackColor = false;
            this.przyciskStart.Click += new System.EventHandler(this.zacznijGre);
            // 
            // przyciskScreen
            // 
            this.przyciskScreen.BackColor = System.Drawing.Color.Turquoise;
            this.przyciskScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.przyciskScreen.Location = new System.Drawing.Point(632, 70);
            this.przyciskScreen.Name = "przyciskScreen";
            this.przyciskScreen.Size = new System.Drawing.Size(92, 52);
            this.przyciskScreen.TabIndex = 0;
            this.przyciskScreen.Text = "Screen";
            this.przyciskScreen.UseVisualStyleBackColor = false;
            this.przyciskScreen.Click += new System.EventHandler(this.zrobScreena);
            // 
            // oknoGry
            // 
            this.oknoGry.BackColor = System.Drawing.Color.LightCoral;
            this.oknoGry.Location = new System.Drawing.Point(32, 29);
            this.oknoGry.Name = "oknoGry";
            this.oknoGry.Size = new System.Drawing.Size(580, 680);
            this.oknoGry.TabIndex = 1;
            this.oknoGry.TabStop = false;
            this.oknoGry.Paint += new System.Windows.Forms.PaintEventHandler(this.rysuj);
            // 
            // wynikGry
            // 
            this.wynikGry.AutoSize = true;
            this.wynikGry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wynikGry.Location = new System.Drawing.Point(632, 209);
            this.wynikGry.Name = "wynikGry";
            this.wynikGry.Size = new System.Drawing.Size(76, 20);
            this.wynikGry.TabIndex = 2;
            this.wynikGry.Text = "Wynik: 0";
            // 
            // rekordGry
            // 
            this.rekordGry.AutoSize = true;
            this.rekordGry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rekordGry.Location = new System.Drawing.Point(632, 243);
            this.rekordGry.Name = "rekordGry";
            this.rekordGry.Size = new System.Drawing.Size(67, 20);
            this.rekordGry.TabIndex = 2;
            this.rekordGry.Text = "Rekord";
            // 
            // czasGry
            // 
            this.czasGry.Interval = 40;
            this.czasGry.Tick += new System.EventHandler(this.liczCzas);
            // 
            // Gra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(748, 725);
            this.Controls.Add(this.rekordGry);
            this.Controls.Add(this.wynikGry);
            this.Controls.Add(this.oknoGry);
            this.Controls.Add(this.przyciskScreen);
            this.Controls.Add(this.przyciskStart);
            this.Name = "Gra";
            this.Text = "Gra Snake - Kacper Krupa";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wcisnijPrzycisk);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.puscPrzycisk);
            ((System.ComponentModel.ISupportInitialize)(this.oknoGry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button przyciskStart;
        private System.Windows.Forms.Button przyciskScreen;
        private System.Windows.Forms.PictureBox oknoGry;
        private System.Windows.Forms.Label wynikGry;
        private System.Windows.Forms.Label rekordGry;
        private System.Windows.Forms.Timer czasGry;
    }
}

