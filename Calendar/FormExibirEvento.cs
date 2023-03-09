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
    public partial class FormExibirEvento : Form
    {
        string date= null;
        public FormExibirEvento(string data)
        {
            InitializeComponent();
            date = data;
        }

        private void FormExibirEvento_Load(object sender, EventArgs e)
        {
            exibirEventos();
        }
        private void exibirEventos()
        {
            string lido = "";
            String connString = "server=localhost;user id=root;database=leather;sslmode=none; password=0000";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "SELECT COUNT(id_evento)quantidade from tab_agenda_cadastro where data_inicio like ?";
            String sql2 = "SELECT * from tab_agenda_cadastro where data_inicio like ?";
            MySqlCommand cmd = conn.CreateCommand();
            MySqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = sql;
            cmd2.Parameters.AddWithValue("data_inicio", date);
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            listEvents[] listEvents = new listEvents[5];
            if (reader2.Read())
            {
                lido= reader2["quantidade"].ToString();
                listEvents = new listEvents[Convert.ToInt32(lido)];
            }
            reader2.Dispose();
            cmd2.Dispose();

            cmd.CommandText = sql2;
            cmd.Parameters.AddWithValue("data_inicio", date);
            MySqlDataReader reader = cmd.ExecuteReader();
            for (int i = 0; i < listEvents.Length; i++)
            {
                if (reader.Read())
                {

                    listEvents listEvents2 = new listEvents();
                    listEvents2.Titulo = reader["titulo"].ToString(); ;
                    listEvents2.Data = reader["data_inicio"].ToString().Remove(10);
                    listEvents2.Horario = reader["data_inicio"].ToString().Remove(0,11);
                    listEvents2.HorarioFinal = reader["data_final"].ToString().Remove(0,11);
                    listEvents2.Responsavel = reader["responsavel"].ToString();
                    if (flowLayoutPanel1.Controls.Count < 0)
                    {
                        flowLayoutPanel1.Controls.Clear();
                    }
                    else
                        flowLayoutPanel1.Controls.Add(listEvents2);

                }
            }
            

            reader.Dispose();
            cmd.Dispose();
            conn.Close();
            
            

        }

       

        private void calendárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
