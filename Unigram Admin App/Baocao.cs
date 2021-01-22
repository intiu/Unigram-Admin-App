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
    public partial class Baocao : DevExpress.XtraEditors.XtraUserControl
    {
        private static Baocao _instance;
        public static Baocao Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Baocao();
                return _instance;
            }
        }
        public Baocao()
        {
            InitializeComponent();
        }
    }
}
