using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Unigram_Admin_App
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Nguoidung.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Nguoidung.Instance);
                Nguoidung.Instance.Dock = DockStyle.Fill;
                Nguoidung.Instance.BringToFront();
            }
            Nguoidung.Instance.BringToFront();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Theodoi.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Theodoi.Instance);
                Theodoi.Instance.Dock = DockStyle.Fill;
                Theodoi.Instance.BringToFront();
            }
            Theodoi.Instance.BringToFront();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Baidang.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Baidang.Instance);
                Baidang.Instance.Dock = DockStyle.Fill;
                Baidang.Instance.BringToFront();
            }
            Baidang.Instance.BringToFront();
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Bantin.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Bantin.Instance);
                Bantin.Instance.Dock = DockStyle.Fill;
                Bantin.Instance.BringToFront();
            }
            Bantin.Instance.BringToFront();
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Thongbao.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Thongbao.Instance);
                Thongbao.Instance.Dock = DockStyle.Fill;
                Thongbao.Instance.BringToFront();
            }
            Thongbao.Instance.BringToFront();
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Luotthich.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Luotthich.Instance);
                Luotthich.Instance.Dock = DockStyle.Fill;
                Luotthich.Instance.BringToFront();
            }
            Luotthich.Instance.BringToFront();
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Binhluan.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Binhluan.Instance);
                Binhluan.Instance.Dock = DockStyle.Fill;
                Binhluan.Instance.BringToFront();
            }
            Binhluan.Instance.BringToFront();
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Luuanh.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Luuanh.Instance);
                Luuanh.Instance.Dock = DockStyle.Fill;
                Luuanh.Instance.BringToFront();
            }
            Luuanh.Instance.BringToFront();
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Nguoiquanly.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Nguoiquanly.Instance);
                Nguoiquanly.Instance.Dock = DockStyle.Fill;
                Nguoiquanly.Instance.BringToFront();
            }
            Nguoiquanly.Instance.BringToFront();
        }

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Lichsu.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Lichsu.Instance);
                Lichsu.Instance.Dock = DockStyle.Fill;
                Lichsu.Instance.BringToFront();
            }
            Lichsu.Instance.BringToFront();
        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Baocao.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Baocao.Instance);
                Baocao.Instance.Dock = DockStyle.Fill;
                Baocao.Instance.BringToFront();
            }
            Baocao.Instance.BringToFront();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(barLinkContainerItem1);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            /*label1.Text = DateTime.Now.ToLongTimeString(); 
            label2.Text = DateTime.Now.ToLongDateString();*/
        }


        private void accordionControlElement12_Click_2(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(MainContainer.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(MainContainer.Instance);
                MainContainer.Instance.Dock = DockStyle.Fill;
                MainContainer.Instance.BringToFront();
            }
            MainContainer.Instance.BringToFront();
        }

    }
}
