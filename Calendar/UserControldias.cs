using MySqlConnector;
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
    public partial class UserControldias : UserControl
    {
        String connString = "server=localhost;user id=root;database=leather;sslmode=none; password=0000";
        public static string static_dias;
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
            lblAgenda.Text = evento;
        }

        private void UserControldias_Click(object sender, EventArgs e)
        {
            static_dias = lbdia.Text;
            timer1.Start();
            EventForm eventForm = new EventForm();
            eventForm.Show();
        }
        private void displayEvent()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "SELECT * from tab_ps_calendar where date = ?";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date", lbdia.Text + "/" + Form1.static_mes + "/" + Form1.static_ano);
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                
                lblAgenda.Text = reader["evento"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();

        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }
    }
}
