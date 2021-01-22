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
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.XtraBars.Helpers;
using System.Diagnostics;
using DevExpress.LookAndFeel;
using FireSharp.Response;
using Newtonsoft.Json;
using FireSharp.Interfaces;
using FireSharp.Config;

namespace Unigram_Admin_App
{
    public partial class Nguoiquanly : DevExpress.XtraEditors.XtraUserControl
    {
        private static Nguoiquanly _instance;

        IFirebaseClient client;

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "AH6MOR5nj3YzwUvOvfHqkZ92FINoI7TZ9GS0Hphj",
            BasePath = "https://um-clone-app.firebaseio.com/"
        };
        public static Nguoiquanly Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Nguoiquanly();
                return _instance;
            }
        }
        public Nguoiquanly()
        {
            InitializeComponent();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pass;
            pass = passwordcode.Text;
            if (pass == "123456")
            {
                MessageBox.Show("Mã bạn nhập thành công");
                FirebaseResponse res = client.Get(@"Admin");
                Dictionary<string, MyUser> data = JsonConvert.DeserializeObject<Dictionary<string, MyUser>>(res.Body.ToString());
                PopulateDataGrid(data);
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mã");
            }
            
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pass;
            pass = passwordcode.Text;
            if (pass == "123456")
            {
                MessageBox.Show("Mã bạn nhập thành công");
                FirebaseResponse res = client.Get(@"Admin");
                Dictionary<string, MyUser> data = JsonConvert.DeserializeObject<Dictionary<string, MyUser>>(res.Body.ToString());
                PopulateRTB(data);
                MessageBox.Show("Máy chủ đã load xong hãy nhấn hiển thị");
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mã");
            }
            
        }

        void PopulateRTB(Dictionary<string, MyUser> record)
        {
            richTextBox1.Clear();
            foreach (var item in record)
            {
                richTextBox1.Text += item.Key + "\n";
                richTextBox1.Text += "Tài khoản" + item.Value.Taikhoan + "\n";
                richTextBox1.Text += "Mật khẩu" + item.Value.Matkhau + "\n";
            }
        }

        void PopulateDataGrid(Dictionary<string, MyUser> record)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Tài khoản", "Mã bài đăng");
            dataGridView1.Columns.Add("Mật khẩu", "Mật khẩu");
            foreach (var item in record)
            {
                dataGridView1.Rows.Add(item.Value.Taikhoan, item.Value.Matkhau);
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pass;
            pass = passwordcode.Text;
            if (pass == "123456")
            {
                MessageBox.Show("Mã bạn nhập thành công");
                #region add
                string str = txtTaikhoan.Text.Replace('.', ',');

                MyUser std = new MyUser()
                {
                    Taikhoan = str,
                    Matkhau = txtMatkhau.Text
                };
                var set = client.Set(@"Admin/" + str, std);
                #endregion
                FirebaseResponse res = client.Get(@"Total");
                int Counter = int.Parse(res.ResultAs<string>());

                MyUser MyUser = new MyUser()
                {
                    Taikhoan = txtTaikhoan.Text,
                    Matkhau = txtMatkhau.Text
                };

                var set2 = client.Set(@"Total", ++Counter);
                var set3 = client.Set("History/" + Counter, MyUser);

                MessageBox.Show("Dữ liệu được lưu trữ thành công!");
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mã");
            }
            
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pass;
            pass = passwordcode.Text;
            if (pass == "123456")
            {
                MessageBox.Show("Mã bạn nhập thành công");
                MyUser std = new MyUser()
                {
                    Taikhoan = txtTaikhoan.Text,
                    Matkhau = txtMatkhau.Text
                };

                var set = client.Update(@"Admin/" + txtTaikhoan.Text, std);

                MessageBox.Show("Dữ liệu được cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mã");
            }
            
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pass;
            pass = passwordcode.Text;
            if (pass == "123456")
            {
                MessageBox.Show("Mã bạn nhập thành công");
                var set = client.Delete(@"Admin/" + txtTaikhoan.Text);
                MessageBox.Show("Dữ liệu đã được xóa thành công!");
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mã");
            }          
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Nguoiquanly";
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "Nguoiquanly";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a1 = new ProcessStartInfo("msedge.exe");
            a1.Arguments = "https://www.facebook.com/phuong.lethimage.3158";
            Process.Start(a1);
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            About about = new About();
            //this.Hide();
            about.Show();
            this.Show();
        }

        private void Nguoiquanly_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(barLinkContainerItem1);
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("Không có kết nối Internet");
            }
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Scheduler scheduler = new Scheduler();
            //this.Hide();
            scheduler.Show();
            this.Show();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PDF pdf = new PDF();
            //this.Hide();
            pdf.Show();
            this.Show();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditText edittext = new EditText();
            //this.Hide();
            edittext.Show();
            this.Show();
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SpreadSheet spreadsheet = new SpreadSheet();
            //this.Hide();
            spreadsheet.Show();
            this.Show();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Diagram diagram = new Diagram();
            //this.Hide();
            diagram.Show();
            this.Show();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("calc");
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Gmail gmail = new Gmail();
            //this.Hide();
            gmail.Show();
            this.Show();
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChatServer chatserver = new ChatServer();
            //this.Hide();
            chatserver.Show();
            this.Show();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChatClient chatclient = new ChatClient();
            //this.Hide();
            chatclient.Show();
            this.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Chatbot chatbot = new Chatbot();
            //this.Hide();
            chatbot.Show();
            this.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTaikhoan.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTaikhoan.Cut();
            if (txtMatkhau.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMatkhau.Cut();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTaikhoan.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTaikhoan.Copy();
            if (txtMatkhau.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMatkhau.Copy();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtTaikhoan.Font = fd.Font;
                txtMatkhau.Font = fd.Font;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtTaikhoan.BackColor = fd.Color;
                txtMatkhau.BackColor = fd.Color;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTaikhoan.Undo();
            txtMatkhau.Undo();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTaikhoan == null)
                return;
            txtTaikhoan.SelectAll();
            if (txtMatkhau == null)
                return;
            txtMatkhau.SelectAll();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtTaikhoan.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTaikhoan.SelectionStart = txtTaikhoan.SelectionStart + txtTaikhoan.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTaikhoan.Paste();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtMatkhau.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtMatkhau.SelectionStart = txtMatkhau.SelectionStart + txtMatkhau.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtMatkhau.Paste();
            }
        }
    }
}
