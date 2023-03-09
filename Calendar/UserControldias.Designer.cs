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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novoEventoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarEventoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbdia
            // 
            this.lbdia.AutoSize = true;
            this.lbdia.BackColor = System.Drawing.Color.Transparent;
            this.lbdia.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdia.ForeColor = System.Drawing.Color.Black;
            this.lbdia.Location = new System.Drawing.Point(3, 4);
            this.lbdia.Name = "lbdia";
            this.lbdia.Size = new System.Drawing.Size(32, 22);
            this.lbdia.TabIndex = 0;
            this.lbdia.Text = "00";
            // 
            // lblAgenda
            // 
            this.lblAgenda.AutoSize = true;
            this.lblAgenda.ForeColor = System.Drawing.Color.Black;
            this.lblAgenda.Location = new System.Drawing.Point(11, 36);
            this.lblAgenda.Name = "lblAgenda";
            this.lblAgenda.Size = new System.Drawing.Size(24, 13);
            this.lblAgenda.TabIndex = 1;
            this.lblAgenda.Text = "text";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoEventoToolStripMenuItem,
            this.visualizarEventoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 48);
            // 
            // novoEventoToolStripMenuItem
            // 
            this.novoEventoToolStripMenuItem.Name = "novoEventoToolStripMenuItem";
            this.novoEventoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.novoEventoToolStripMenuItem.Text = "Novo evento";
            this.novoEventoToolStripMenuItem.Click += new System.EventHandler(this.novoEventoToolStripMenuItem_Click);
            // 
            // visualizarEventoToolStripMenuItem
            // 
            this.visualizarEventoToolStripMenuItem.Name = "visualizarEventoToolStripMenuItem";
            this.visualizarEventoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.visualizarEventoToolStripMenuItem.Text = "Visualizar evento";
            this.visualizarEventoToolStripMenuItem.Click += new System.EventHandler(this.visualizarEventoToolStripMenuItem_Click);
            // 
            // UserControldias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(212)))));
            this.Controls.Add(this.lblAgenda);
            this.Controls.Add(this.lbdia);
            this.Name = "UserControldias";
            this.Size = new System.Drawing.Size(110, 62);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControldias_MouseClick);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbdia;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblAgenda;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoEventoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarEventoToolStripMenuItem;
    }
}
