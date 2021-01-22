using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Unigram_Admin_App
{
    public partial class Dangtai : SplashScreen
    {
        public Dangtai()
        {
            InitializeComponent();
            this.label.Text = "Phiên bản " + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion


        private void peImage_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if(panel2.Width >= 918)
            {
                timer1.Stop();
                MainForm mainform = new MainForm();
                mainform.Show();
                this.Hide();
            }    
        }
    }
}