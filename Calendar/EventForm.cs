using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        private bool validaEventos(string data, string horainicio, string horafinal, bool checkedFull)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string horafint = horafinal.Replace(":", "").Replace(" ", "");
                    string horaini = horainicio.Replace(":", "").Replace(" ", "");
                    List<int> date = new List<int>();
                    string datatratar = null;

                    MySqlCommand cmd = new MySqlCommand("SELECT data_inicio, data_final from tab_agenda_cadastro where data_inicio like @data_inicio order by data_inicio", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@data_inicio", data);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (checkedFull)
                            {
                                return false;
                            }
                            datatratar = reader.GetString(0).Replace(":", "").Replace(" ", "");
                            datatratar = datatratar.Remove(0, 10).Remove(4);
                            date.Add(reader.GetInt32(0));
                            datatratar = reader.GetString(1).Replace(":", "").Replace(" ", "");
                            datatratar = datatratar.Remove(0, 10).Remove(4);
                            date.Add(reader.GetInt32(1));
                        }
                    }

                    while (date.Count > 0)
                    {
                        int t = date[0];
                        int t2 = date[1];

                        if (Convert.ToInt32(horaini) >= date[0] && Convert.ToInt32(horafint) <= date[1])
                        {
                            return false;
                        }
                        else if (Convert.ToInt32(horaini) <= date[0] && Convert.ToInt32(horafint) >= date[1])
                        {
                            return false;
                        }
                        else if (Convert.ToInt32(horaini) <= date[0] && Convert.ToInt32(horafint) <= date[1] && Convert.ToInt32(horafint) >= date[0])
                        {
                            return false;
                        }
                        date.RemoveRange(0, 1);
                    }
                }
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
            if (txtEvent.Text.Equals(""))
            {
                MessageBox.Show("Preencha o campo Destino!", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtResp.Focus();
                return false;
            }
            else if (txtResp.Text.Equals(""))
            {
                MessageBox.Show("Preencha o campo Responsável !", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEvent.Focus();
                return false;
            }
            else if (checkDayFull.Checked)
            {
                return true;
            }
            else if (txtHoraInicio.Text.Replace(":", "").Replace(" ", "").Equals(""))
            {
                MessageBox.Show("Preencha o campo Hora Saída!", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtHoraInicio.Focus();
                return false;
            }
            else if (Convert.ToInt32(txtHoraInicio.Text.Replace(":", "")) >= Convert.ToInt32(txtHoraFinal.Text.Replace(":", ""))){
                MessageBox.Show("O horário inicial não pode ser maior/igual que o horário final!", "Valide o campo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strHoraInicio = txtHoraInicio.Text;
            string strHoraFinal = txtHoraFinal.Text;
            string dias = UserControldias.static_dias;
            string mes = Form1.static_mes.ToString();
            bool checkedFull = false;
            if (checkDayFull.Checked)
            {
                strHoraInicio = "00:01";
                strHoraFinal = "00:00";
                checkedFull = true;
            }
            if (Convert.ToInt16(UserControldias.static_dias)<10)
            {
                dias = "0" + UserControldias.static_dias;
            }
            if (Form1.static_mes < 10)
            {
                mes = "0" + Form1.static_mes;
            }
            string data = Form1.static_ano + "-" + mes + "-" + dias;
            if (validaEventos(data + "%", strHoraInicio, strHoraFinal, checkedFull))
            {
                if (validaForm())
                {
                    MySqlConnection conn = new MySqlConnection(connString);
                    conn.Open();
                    String sql = "INSERT INTO tab_agenda_cadastro(titulo,data_inicio,data_final,responsavel)values(?, ?, ?, ? ) ";
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("titulo", txtEvent.Text);
                    cmd.Parameters.AddWithValue("data_inicio", data + " " + strHoraInicio);
                    cmd.Parameters.AddWithValue("data_final", data + " " + strHoraFinal);
                    cmd.Parameters.AddWithValue("responsavel", txtResp.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Salvado");
                }
            }
            else
            {
                if (checkedFull)
                {
                    MessageBox.Show("Já existe um evento nesse dia, impossível escolher o dia inteiro!");
                }
                else
                    MessageBox.Show("Já existe um evento nesse horário, por favor escolher outro!");
            }
                
           
        }

        private void checkDayFull_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDayFull.Checked)
            {
                txtHoraInicio.ReadOnly = true;
                txtHoraFinal.ReadOnly = true;
                txtHoraInicio.Clear();
                txtHoraFinal.Clear();
            }
            else
            {
                txtHoraInicio.ReadOnly = false;
                txtHoraFinal.ReadOnly = false;

            }

        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExibirEvento formExibirEvento = new FormExibirEvento("01");
            formExibirEvento.Show();
        }

        private void calendárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
