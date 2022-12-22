namespace Calendar
{
    partial class Form1
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnprox = new System.Windows.Forms.Button();
            this.btnanterior = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbmes = new System.Windows.Forms.Label();
            this.daycontainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnprox
            // 
            this.btnprox.Location = new System.Drawing.Point(763, 531);
            this.btnprox.Name = "btnprox";
            this.btnprox.Size = new System.Drawing.Size(75, 23);
            this.btnprox.TabIndex = 1;
            this.btnprox.Text = "Proximo";
            this.btnprox.UseVisualStyleBackColor = true;
            this.btnprox.Click += new System.EventHandler(this.btnprox_Click);
            // 
            // btnanterior
            // 
            this.btnanterior.Location = new System.Drawing.Point(669, 531);
            this.btnanterior.Name = "btnanterior";
            this.btnanterior.Size = new System.Drawing.Size(75, 23);
            this.btnanterior.TabIndex = 2;
            this.btnanterior.Text = "Anterior";
            this.btnanterior.UseVisualStyleBackColor = true;
            this.btnanterior.Click += new System.EventHandler(this.btnanterior_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Montserrat Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(957, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sabádo";
            // 
            // lbmes
            // 
            this.lbmes.AutoSize = true;
            this.lbmes.BackColor = System.Drawing.Color.Transparent;
            this.lbmes.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmes.ForeColor = System.Drawing.Color.Transparent;
            this.lbmes.Location = new System.Drawing.Point(363, 29);
            this.lbmes.Name = "lbmes";
            this.lbmes.Size = new System.Drawing.Size(116, 29);
            this.lbmes.TabIndex = 10;
            this.lbmes.Text = "MÊS ANO";
            // 
            // daycontainer
            // 
            this.daycontainer.BackColor = System.Drawing.Color.Transparent;
            this.daycontainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.daycontainer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.daycontainer.Location = new System.Drawing.Point(16, 137);
            this.daycontainer.Name = "daycontainer";
            this.daycontainer.Size = new System.Drawing.Size(816, 381);
            this.daycontainer.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(850, 568);
            this.Controls.Add(this.btnprox);
            this.Controls.Add(this.btnanterior);
            this.Controls.Add(this.lbmes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.daycontainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnprox;
        private System.Windows.Forms.Button btnanterior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel daycontainer;
        private System.Windows.Forms.Label lbmes;
    }
}

