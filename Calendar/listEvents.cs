using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class listEvents : UserControl
    {
        public listEvents()
        {
            InitializeComponent();
        }
        #region Propiedade
        private string _titulo;
        private string _data;
        private string _horario;
        private string _reponsavel;


        [Category("Custom props")]
        public string Titulo { 
            get { return _titulo; }
            set { _titulo = value; lbltitulo.Text = value; }
        }
        [Category("Custom props")]
        public string Data
        {
            get { return _data; }
            set { _data = value; lbldata.Text = value; }
        }

        [Category("Custom props")]
        public string Responsavel
        {
            get { return _reponsavel; }
            set { _reponsavel = value; lblresp.Text = value;  }
        }

        [Category("Custom props")]
        public string Horario
        {
            get { return _horario; }
            set { _horario = value; lblhorario.Text = value; }
        }

        #endregion

        private void listEvents_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
            
        }

        private void listEvents_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
