using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Unigram_Admin_App
{
    public partial class Lichsu : DevExpress.XtraEditors.XtraUserControl
    {
        private static Lichsu _instance;
        public static Lichsu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Lichsu();
                return _instance;
            }
        }
        public Lichsu()
        {
            InitializeComponent();
        }
    }
}
