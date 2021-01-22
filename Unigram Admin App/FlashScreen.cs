using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unigram_Admin_App
{
    public partial class FlashScreen : Form
    {
        public FlashScreen()
        {
            InitializeComponent();           
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 503)
            {
                timer1.Stop();
                Login login = new Login();
                login.Show();
                this.Hide();
                MessageBox.Show("Vui lòng phải có Internet thì mới đăng nhập được!");
            }
        }
    }
}
