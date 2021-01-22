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
    public partial class Luotthich : DevExpress.XtraEditors.XtraUserControl
    {
        private static Luotthich _instance;
        public static Luotthich Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Luotthich();
                return _instance;
            }
        }
        public Luotthich()
        {
            InitializeComponent();
        }
    }
}
