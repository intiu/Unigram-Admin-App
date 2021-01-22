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
    public partial class Luuanh : DevExpress.XtraEditors.XtraUserControl
    {
        private static Luuanh _instance;
        public static Luuanh Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Luuanh();
                return _instance;
            }
        }
        public Luuanh()
        {
            InitializeComponent();
        }
    }
}
