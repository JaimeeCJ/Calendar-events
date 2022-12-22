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
        private bool validaEventos(string data, string horainicio, string horafinal)
        {
            try
            {

                
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                string horafint = horafinal.Replace(":", "").Replace(" ", "");
                string horaini = horainicio.Replace(":", "").Replace(" ", "");
                List<int> date = new List<int>();
                string datatratar = null;
                String sql = "SELECT data_inicio, data_final from tab_agenda_cadastro where data_inicio like ? order by data_inicio";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("data_inicio", data);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    datatratar = reader["data_inicio"].ToString().Replace(":", "").Replace(" ", "");
                    datatratar = datatratar.Remove(0, 10).Remove(4);
                    date.Add(Convert.ToInt32(datatratar));
                    datatratar = reader["data_final"].ToString().Replace(":", "").Replace(" ", "");
                    datatratar = datatratar.Remove(0, 10).Remove(4);
                    date.Add(Convert.ToInt32(datatratar));
                }
                int t = date[0];
                int t2 = date[1];
                for (int i = 1; i <= date.Count; i++)
                {
                    if (Convert.ToInt32(horaini) >= date[0] && Convert.ToInt32(horafint) <= date[1])
                    {
                        return false;
                    }
                    date.RemoveRange(0, 1);
                }
                reader.Dispose();
                cmd.Dispose();
                conn.Close();
                          
                return true;
                               
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo inesperado ocorreu, por favor informe a TI " +e);
                return false;
            }                        
            
        }
        private bool validaForm()
        {
            if (txtResp.Text.Equals(""))
            {
                MessageBox.Show("Preencha o campo Responsável!", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtResp.Focus();
                return false;
            }
            else if (txtHoraInicio.Text.Replace(":", "").Replace(" ", "").Equals(""))
            {
                MessageBox.Show("Preencha o campo Hora Saída!", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtHoraInicio.Focus();
                return false;
            }
            else if (Convert.ToInt32(txtHoraInicio.Text.Replace(":", "")) > 2359 )
            {
                MessageBox.Show("Horário em formato chegada errado!", "Valide o campo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtHoraInicio.Focus();
                return false;
            }            
            else if (txtHoraFinal.Text.Replace(":", "").Replace(" ", "").Equals(""))
            {
                MessageBox.Show("Preencha o campo Hora Retorno!", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtHoraFinal.Focus();
                return false;
            }
            else if (Convert.ToInt32(txtHoraFinal.Text.Replace(":", "")) > 2359)
            {
                MessageBox.Show("Horário retorno em formato errado!", "Valide o campo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtHoraFinal.Focus();
                return false;
            }
            else if (txtEvent.Text.Equals(""))
            {
                MessageBox.Show("Preencha o campo Destino!", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEvent.Focus();
                return false;
            }
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string data = Form1.static_ano + "-" + Form1.static_mes + "-" + UserControldias.static_dias;
            if (validaEventos(data + "%", txtHoraInicio.Text, txtHoraFinal.Text))
            {
                if (validaForm())
                {
                    MySqlConnection conn = new MySqlConnection(connString);
                    conn.Open();
                    String sql = "INSERT INTO tab_agenda_cadastro(titulo,data_inicio,data_final,responsavel)values(?, ?, ?, ? ) ";
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("titulo", txtEvent.Text);
                    cmd.Parameters.AddWithValue("data_inicio", data + " " + txtHoraInicio.Text);
                    cmd.Parameters.AddWithValue("data_final", data + " " + txtHoraFinal.Text);
                    cmd.Parameters.AddWithValue("responsavel", txtResp.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Salvado");
                }
            }
            else
                MessageBox.Show("Já existe um evento nesse horário, por favor escolher outro!");
           
        }
    }
}
