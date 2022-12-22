using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        }
        private static Thread _splashThread;
        private static Form1 _splashForm;

 

        private void timer1_Tick(object sender, EventArgs e)
        {

            progressBar1.Value += 1;
            
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                ShowSplash();
            }
        }
        public static void ShowSplash()
        {
            if (_splashThread == null)
            {
                // show the form in a new thread
                _splashThread = new Thread(new ThreadStart(DoShowSplash));
                _splashThread.IsBackground = true;
                _splashThread.Start();
            }
        }

        // called by the thread
        private static void DoShowSplash()
        {
            if (_splashForm == null)
                _splashForm = new Form1();

            // create a new message pump on this thread (started from ShowSplash)
            Application.Run(_splashForm);
        }

        /// <summary>
        /// Close the splash (Loading...) screen
        /// </summary>
        public static void CloseSplash()
        {
            // need to call on the thread that launched this splash
            if (_splashForm.InvokeRequired)
                _splashForm.Invoke(new MethodInvoker(CloseSplash));

            else
                Application.ExitThread();
        }
        
    }
}
