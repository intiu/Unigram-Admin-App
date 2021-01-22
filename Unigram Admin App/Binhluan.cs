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
    public partial class Binhluan : DevExpress.XtraEditors.XtraUserControl
    {
        private static Binhluan _instance;
        public static Binhluan Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Binhluan();
                return _instance;
            }
        }
        public Binhluan()
        {
            InitializeComponent();
        }
    }
}
