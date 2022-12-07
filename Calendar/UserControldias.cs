using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class UserControldias : UserControl
    {
        String connString = "server=localhost;user id=root;database=leather;sslmode=none; password=0000";
        public static string static_dias;
        public static string diaconvert;
        public static string diaconverttocontrol;
        public UserControldias()
        {
            InitializeComponent();
            
        }

        private void UserControldias_Load(object sender, EventArgs e)
        {
            

        }
        public void dias(int numdia, string evento)
        {
            lbdia.Text = numdia + "";
            lblAgenda.Text = "Eventos: "+evento;
        }

        
        private void displayEvent()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "SELECT COUNT(id_evento)quantidade from tab_agenda_cadastro where data_inicio like ?";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;            
            cmd.Parameters.AddWithValue("date_inicio", Form1.static_ano + "-" + Form1.static_mes + "-" + diaconvert+"%"); 
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {                
                lblAgenda.Text = reader["quantidade"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();

        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }

        private void UserControldias_MouseClick(object sender, MouseEventArgs e)
        {
            Form1 form1 = new Form1();
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
            diaconvert = lbdia.Text;
            if (Convert.ToInt16(lbdia.Text) < 9)
            {
                diaconvert = "0" + lbdia.Text;
            }
            diaconverttocontrol = Form1.static_ano + "-" + Form1.static_mes + "-" + diaconvert + "%";
        }

        private void novoEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            static_dias = lbdia.Text;
            timer1.Start();
            EventForm eventForm = new EventForm();
            eventForm.Show();
        }

        private void visualizarEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExibirEvento formExibirEvento = new FormExibirEvento(diaconverttocontrol);
            formExibirEvento.Show();
        }
    }
}
