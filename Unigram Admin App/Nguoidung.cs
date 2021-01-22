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
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Unigram_Admin_App
{
    public partial class Nguoidung : DevExpress.XtraEditors.XtraUserControl
    {
        private static Nguoidung _instance;

        IFirebaseClient client;

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "AH6MOR5nj3YzwUvOvfHqkZ92FINoI7TZ9GS0Hphj",
            BasePath = "https://um-clone-app.firebaseio.com/"
        };
        //![](E271D4B21CDB0FDDAC430F0915457BF5.png;;;0.03851,0.02246)

        public Nguoidung() { InitializeComponent(); }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if(txtMND.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if(MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtMND.SelectionStart = txtMND.SelectionStart + txtMND.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtMND.Paste();
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            Process.Start("calc"); 
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Chatbot chatbot = new Chatbot();
            //this.Hide();
            chatbot.Show();
            this.Show();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Users");
            Dictionary<string, Users> data = JsonConvert.DeserializeObject<Dictionary<string, Users>>(res.Body.ToString());
            PopulateDataGrid(data);
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region add
            string str = txtMND.Text.Replace('.', ',');

            Users std = new Users()
            {
                uid = str,
                fullname = txtHVT.Text,
                username = txtTND.Text,
                email = txtemail.Text,
                password = txtMK.Text,
                bio = txtTT.Text,
                image = txtsearch.Text
            };
            var set = client.Set(@"Users/" + str, std);
            #endregion
            FirebaseResponse res = client.Get(@"Total");
            int Counter = int.Parse(res.ResultAs<string>());

            Users users = new Users()
            {
                uid = txtMND.Text,
                fullname = txtHVT.Text,
                username = txtTND.Text,
                email = txtemail.Text,
                password = txtMK.Text,
                bio = txtTT.Text,
                image = txtsearch.Text
            };

            var set2 = client.Set(@"Total", ++Counter);
            var set3 = client.Set("History/" + Counter, users);

            MessageBox.Show("Dữ liệu được lưu trữ thành công!");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Users std = new Users()
            {
                uid = txtMND.Text,
                fullname = txtHVT.Text,
                username = txtTND.Text,
                email = txtemail.Text,
                password = txtMK.Text,
                bio = txtTT.Text,
                image = txtsearch.Text
            };

            var set = client.Update(@"Users/" + txtMND.Text, std);

            MessageBox.Show("Dữ liệu được cập nhật thành công!");
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var set = client.Delete(@"Users/" + txtMND.Text);
            MessageBox.Show("Dữ liệu đã được xóa thành công!");
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

        private void barButtonItem19_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Scheduler scheduler = new Scheduler();
            //this.Hide();
            scheduler.Show();
            this.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtMND.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMND.Cut();
            if(txtHVT.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtHVT.Cut();
            if(txtTND.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTND.Cut();
            if(txtemail.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtemail.Cut();
            if(txtMK.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMK.Cut();
            if(txtTT.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTT.Cut();
            if (txtsearch.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtsearch.Cut();
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

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Diagram diagram = new Diagram();
            //this.Hide();
            diagram.Show();
            this.Show();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if(txtTND.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if(MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTND.SelectionStart = txtTND.SelectionStart + txtTND.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTND.Paste();
            }
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if(txtemail.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if(MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtemail.SelectionStart = txtemail.SelectionStart + txtemail.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtemail.Paste();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if(txtMK.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if(MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtMK.SelectionStart = txtMK.SelectionStart + txtMK.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtMK.Paste();
            }
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if(txtTT.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if(MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTT.SelectionStart = txtTT.SelectionStart + txtTT.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTT.Paste();
            }
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Gmail gmail = new Gmail();
            //this.Hide();
            gmail.Show();
            this.Show();
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SpreadSheet spreadsheet = new SpreadSheet();
            //this.Hide();
            spreadsheet.Show();
            this.Show();
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChatServer chatserver = new ChatServer();
            //this.Hide();
            chatserver.Show();
            this.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtMND.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMND.Copy();
            if(txtHVT.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtHVT.Copy();
            if(txtTND.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTND.Copy();
            if(txtemail.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtemail.Copy();
            if(txtMK.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMK.Copy();
            if(txtTT.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTT.Copy();
            if (txtsearch.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtsearch.Copy();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChatClient chatclient = new ChatClient();
            //this.Hide();
            chatclient.Show();
            this.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                txtMND.Font = fd.Font;
                txtHVT.Font = fd.Font;
                txtTND.Font = fd.Font;
                txtemail.Font = fd.Font;
                txtMK.Font = fd.Font;
                txtTT.Font = fd.Font;
                txtsearch.Font = fd.Font;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                txtMND.BackColor = fd.Color;
                txtHVT.BackColor = fd.Color;
                txtTND.BackColor = fd.Color;
                txtemail.BackColor = fd.Color;
                txtMK.BackColor = fd.Color;
                txtTT.BackColor = fd.Color;
                txtsearch.BackColor = fd.Color;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMND.Undo();
            txtHVT.Undo();
            txtTND.Undo();
            txtemail.Undo();
            txtMK.Undo();
            txtTT.Undo();
            txtsearch.Undo();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtMND == null)
                return;
            txtMND.SelectAll();
            if(txtHVT == null)
                return;
            txtHVT.SelectAll();
            if(txtTND == null)
                return;
            txtTND.SelectAll();
            if(txtemail == null)
                return;
            txtemail.SelectAll();
            if(txtMK == null)
                return;
            txtMK.SelectAll();
            if(txtTT == null)
                return;
            txtTT.SelectAll();
            if (txtsearch == null)
                return;
            txtsearch.SelectAll();
        }

        private void barButtonItem9_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if(txtHVT.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if(MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtHVT.SelectionStart = txtHVT.SelectionStart + txtHVT.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtHVT.Paste();
            }
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtsearch.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
        }

        private void Nguoidung_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(barLinkContainerItem1);
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            } catch
            {
                MessageBox.Show("Không có kết nối Internet");
            }
        }


        private void resourcesTree1_FocusedNodeChanged(
            object sender,
            DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
        }

        public static Nguoidung Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Nguoidung();
                return _instance;
            }
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Users");
            Dictionary<string, Users> data = JsonConvert.DeserializeObject<Dictionary<string, Users>>(res.Body.ToString());
            PopulateRTB(data);
            MessageBox.Show("Máy chủ đã load xong hãy nhấn hiển thị");
        }

        void PopulateRTB(Dictionary<string, Users> record)
        {
            richTextBox1.Clear();
            foreach (var item in record)
            {
                richTextBox1.Text += item.Key + "\n";
                richTextBox1.Text += "Mã người dùng" + item.Value.uid + "\n";
                richTextBox1.Text += "Họ và tên" + item.Value.fullname + "\n";
                richTextBox1.Text += "Tên người dùng" + item.Value.username + "\n";
                richTextBox1.Text += "email" + item.Value.email + "\n";
                richTextBox1.Text += "Mật khẩu" + item.Value.password + "\n";
                richTextBox1.Text += "Thông tin" + item.Value.bio + "\n";
                richTextBox1.Text += "Ảnh" + item.Value.image + "\n";
            }
        }

        void PopulateDataGrid(Dictionary<string, Users> record)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Mã người dùng", "Mã người dùng");
            dataGridView1.Columns.Add("Họ và tên", "Họ và tên");
            dataGridView1.Columns.Add("Tên người dùng", "Tên người dùng");
            dataGridView1.Columns.Add("email", "email");
            dataGridView1.Columns.Add("Mật khẩu", "Mật khẩu");
            dataGridView1.Columns.Add("Thông tin", "Thông tin");
            dataGridView1.Columns.Add("Ảnh", "Ảnh");
            foreach (var item in record)
            {
                dataGridView1.Rows.Add(item.Value.uid, item.Value.fullname, item.Value.username, item.Value.email, item.Value.password, item.Value.bio, item.Value.image);
            }
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Nguoidung";
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
            saveFileDialoge.FileName = "Nguoidung";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog()== DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
            
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtsearch.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtsearch.SelectionStart = txtsearch.SelectionStart + txtsearch.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtsearch.Paste();
            }
        }
    }
}
