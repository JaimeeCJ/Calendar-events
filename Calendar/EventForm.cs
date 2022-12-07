using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
namespace Calendar
{
    public partial class EventForm : Form
    {
        String connString = "server=localhost;user id=root;database=leather;sslmode=none; password=0000";
        public EventForm()
        {
            InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            txtData.Text =   UserControldias.static_dias + "/" + Form1.static_mes+ "/" + Form1.static_ano;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "INSERT INTO tab_agenda_cadastro(titulo,data_inicio,data_final,responsavel)values(?, ?, ?, ? ) ";
            MySqlCommand cmd = conn.CreateCommand();
            string data = Form1.static_ano + "/" + Form1.static_mes + "/" + UserControldias.static_dias;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("titulo", txtEvent.Text);
            cmd.Parameters.AddWithValue("data_inicio", data +" "+ txtHoraInicio.Text);
            cmd.Parameters.AddWithValue("data_final", data + " " + txtHoraFinal.Text);
            cmd.Parameters.AddWithValue("responsavel", txtResp.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            MessageBox.Show("Saved");
           
        }
    }
}
