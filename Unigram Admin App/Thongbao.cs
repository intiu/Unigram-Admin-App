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
    public partial class Thongbao : DevExpress.XtraEditors.XtraUserControl
    {
        private static Thongbao _instance;
        public static Thongbao Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Thongbao();
                return _instance;
            }
        }
        public Thongbao()
        {
            InitializeComponent();
        }
    }
}
