using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        int mes, ano;
        String connString = "server=localhost;user id=root;database=leather;sslmode=none; password=0000";
        public static int static_mes, static_ano;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {            
            displayDias();           
        }
        private string carregarDia(int dia)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT COUNT(id_evento) as quantidade ");
                sql.Append("FROM tab_agenda_cadastro ");
                sql.Append("WHERE data_inicio LIKE @data_inicio");

                using (MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn))
                {
                    string diaConvert = dia.ToString().PadLeft(2, '0');
                    string mesConvert = mes.ToString().PadLeft(2, '0');
                    cmd.Parameters.AddWithValue("@data_inicio", $"{Form1.static_ano}-{mesConvert}-{diaConvert}%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["quantidade"].ToString();
                        }
                    }
                }
            }

            return "";
        }
        private void displayDias()
        {
            DateTime now = DateTime.Now;
            mes = now.Month;
            ano = now.Year;

            string mesano = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);
            lbmes.Text = mesano + " "+ano;

            static_mes = mes;
            static_ano = ano;

            DateTime primeirodiames = new DateTime(ano, mes,1); //Primeiro dia do mês
            int dias = DateTime.DaysInMonth(ano, mes);
            int diadasemana = Convert.ToInt32(primeirodiames.DayOfWeek.ToString("d"))+1;
            int diascalc = DateTime.DaysInMonth(ano, (static_mes - 1));
            int calc = diascalc -(diadasemana - 2)  ;
            for(int i=1;i<diadasemana; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                ucblank.dias(calc);
                daycontainer.Controls.Add(ucblank);
                calc++;
            }
            for (int i = 1; i<=dias; i++)
            {
                UserControldias ucdias = new UserControldias();
                ucdias.dias(i, carregarDia(i));
                daycontainer.Controls.Add(ucdias);
                
            }
        }
        private void btnNav(bool opt)
        {
            int diascalc=0;
            daycontainer.Controls.Clear();
            
            if (opt){
                mes++;
            }
            else
            {
                mes--;
            }
            if (mes > 12)
            {
                ano++;
                mes = 1;
            }
            else if (mes<1)
            {
                ano--;
                mes = 12;
            }
            if (mes ==1)
            {
                diascalc = DateTime.DaysInMonth((ano-1), (mes));
            }
            else
            {
                diascalc = DateTime.DaysInMonth(ano, (mes - 1));
            }
            static_mes = mes;
            static_ano = ano;
            string mesano = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);
            lbmes.Text = mesano + " " + ano;

            DateTime primeirodiames = new DateTime(ano, mes, 1); //Primeiro dia do mês
            
            int dias = DateTime.DaysInMonth(ano, mes);//Qtd dias no mês
            int diadasemana = Convert.ToInt32(primeirodiames.DayOfWeek.ToString("d")) + 1;//Quando o mês inicia
            
            int calc = diascalc - (diadasemana - 2);//Calc. mês anterior em mês atual
            
            for (int i = 1; i < diadasemana; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                ucblank.dias(calc);
                daycontainer.Controls.Add(ucblank);
                calc++;
            }
            for (int i = 1; i <= dias; i++)
            {
                UserControldias ucdias = new UserControldias();
                ucdias.dias(i, carregarDia(i));
                daycontainer.Controls.Add(ucdias);
            }
        }

        private void novoEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void visualizarToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {

        }

        private void visualizarToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExibirEvento formExibirEvento = new FormExibirEvento("01");
            formExibirEvento.Show();
        }

        private void btnanterior_Click(object sender, EventArgs e)
        {
            btnNav(false);
        }

        private void btnprox_Click(object sender, EventArgs e)
        {
            btnNav(true);
        }
    }
}
