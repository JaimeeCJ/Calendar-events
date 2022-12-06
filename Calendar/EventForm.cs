using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            String sql = "INSERT INTO tab_ps_calendar(date,evento)values(?, ? ) ";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date", txtData.Text);
            cmd.Parameters.AddWithValue("evento", txtEvent.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            MessageBox.Show("Saved");
           
        }
    }
}
