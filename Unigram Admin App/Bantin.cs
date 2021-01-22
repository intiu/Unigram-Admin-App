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
    public partial class Bantin : DevExpress.XtraEditors.XtraUserControl
    {
        private static Bantin _instance;
        public static Bantin Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Bantin();
                return _instance;
            }
        }
        public Bantin()
        {
            InitializeComponent();
        }
    }
}
