namespace Calendar
{
    partial class UserControldias
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbdia = new System.Windows.Forms.Label();
            this.lblAgenda = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbdia
            // 
            this.lbdia.AutoSize = true;
            this.lbdia.BackColor = System.Drawing.Color.Gold;
            this.lbdia.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbdia.Location = new System.Drawing.Point(3, 4);
            this.lbdia.Name = "lbdia";
            this.lbdia.Size = new System.Drawing.Size(32, 22);
            this.lbdia.TabIndex = 0;
            this.lbdia.Text = "00";
            // 
            // lblAgenda
            // 
            this.lblAgenda.AutoSize = true;
            this.lblAgenda.Location = new System.Drawing.Point(13, 26);
            this.lblAgenda.Name = "lblAgenda";
            this.lblAgenda.Size = new System.Drawing.Size(0, 13);
            this.lblAgenda.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UserControldias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.Controls.Add(this.lblAgenda);
            this.Controls.Add(this.lbdia);
            this.Name = "UserControldias";
            this.Size = new System.Drawing.Size(110, 62);
            this.Load += new System.EventHandler(this.UserControldias_Load);
            this.Click += new System.EventHandler(this.UserControldias_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbdia;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblAgenda;
    }
}
