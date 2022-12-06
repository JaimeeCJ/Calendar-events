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
    public partial class UserControlBlank : UserControl
    {

        public UserControlBlank()
        {
            InitializeComponent();
        }
        public void dias(int numdia)
        {
            lblAnterior.Text = numdia + "";            
        }
        private void UserControlBlank_Load(object sender, EventArgs e)
        {

        }
    }
}
