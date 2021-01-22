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
using FireSharp.Response;
using Newtonsoft.Json;
using DevExpress.XtraBars.Helpers;
using FireSharp.Interfaces;
using FireSharp.Config;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.LookAndFeel;
using System.Diagnostics;

namespace Unigram_Admin_App
{
    public partial class Baidang : DevExpress.XtraEditors.XtraUserControl
    {
        private static Baidang _instance;

        IFirebaseClient client;

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "AH6MOR5nj3YzwUvOvfHqkZ92FINoI7TZ9GS0Hphj",
            BasePath = "https://um-clone-app.firebaseio.com/"
        };
        public static Baidang Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Baidang();
                return _instance;
            }
        }
        public Baidang()
        {
            InitializeComponent();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Posts");
            Dictionary<string, Posts> data = JsonConvert.DeserializeObject<Dictionary<string, Posts>>(res.Body.ToString());
            PopulateRTB(data);
            MessageBox.Show("Máy chủ đã load xong hãy nhấn hiển thị");
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Posts");
            Dictionary<string, Posts> data = JsonConvert.DeserializeObject<Dictionary<string, Posts>>(res.Body.ToString());
            PopulateDataGrid(data);
        }

        void PopulateRTB(Dictionary<string, Posts> record)
        {
            richTextBox1.Clear();
            foreach (var item in record)
            {
                richTextBox1.Text += item.Key + "\n";
                richTextBox1.Text += "Mã bài đăng" + item.Value.postid + "\n";
                richTextBox1.Text += "Thông tin" + item.Value.description + "\n";
                richTextBox1.Text += "Mã người dùng" + item.Value.publisher + "\n";
                richTextBox1.Text += "Ảnh bài đăng" + item.Value.postimage + "\n";
            }
        }

        void PopulateDataGrid(Dictionary<string, Posts> record)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Mã bài đăng", "Mã bài đăng");
            dataGridView1.Columns.Add("Thông tin", "Thông tin");
            dataGridView1.Columns.Add("Mã người dùng", "Mã người dùng");
            dataGridView1.Columns.Add("Ảnh bài đăng", "Ảnh bài đăng");
            foreach (var item in record)
            {
                dataGridView1.Rows.Add(item.Value.postid, item.Value.description, item.Value.publisher, item.Value.postimage);
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region add
            string str = txtpostid.Text.Replace('.', ',');

            Posts std = new Posts()
            {
                postid = str,
                description = txtdescription.Text,
                publisher = txtpublisher.Text,
                postimage = txtpostimage.Text
            };
            var set = client.Set(@"Posts/" + str, std);
            #endregion
            FirebaseResponse res = client.Get(@"Total");
            int Counter = int.Parse(res.ResultAs<string>());

            Posts Posts = new Posts()
            {
                postid = txtpostid.Text,
                description = txtdescription.Text,
                publisher = txtpublisher.Text,
                postimage = txtpostimage.Text
            };

            var set2 = client.Set(@"Total", ++Counter);
            var set3 = client.Set("History/" + Counter, Posts);

            MessageBox.Show("Dữ liệu được lưu trữ thành công!");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Posts std = new Posts()
            {
                postid = txtpostid.Text,
                description = txtdescription.Text,
                publisher = txtpublisher.Text,
                postimage = txtpostimage.Text
            };

            var set = client.Update(@"Posts/" + txtpostid.Text, std);

            MessageBox.Show("Dữ liệu được cập nhật thành công!");
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var set = client.Delete(@"Posts/" + txtpostid.Text);
            MessageBox.Show("Dữ liệu đã được xóa thành công!");
        }

        private void barButtonItem32_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Baidang";
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
            saveFileDialoge.FileName = "Baidang";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void Baidang_Load(object sender, EventArgs e)
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
            if (txtpostid.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtpostid.Cut();
            if (txtdescription.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtdescription.Cut();
            if (txtpublisher.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtpublisher.Cut();
            if (txtpostimage.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtpostimage.Cut();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtpostid.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtpostid.Copy();
            if (txtdescription.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtdescription.Copy();
            if (txtpublisher.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtpublisher.Copy();
            if (txtpostimage.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtpostimage.Copy();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtpostid.Font = fd.Font;
                txtdescription.Font = fd.Font;
                txtpublisher.Font = fd.Font;
                txtpostimage.Font = fd.Font;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtpostid.BackColor = fd.Color;
                txtdescription.BackColor = fd.Color;
                txtpublisher.BackColor = fd.Color;
                txtpostimage.BackColor = fd.Color;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtpostid.Undo();
            txtdescription.Undo();
            txtpublisher.Undo();
            txtpostimage.Undo();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtpostid == null)
                return;
            txtpostid.SelectAll();
            if (txtdescription == null)
                return;
            txtdescription.SelectAll();
            if (txtpublisher == null)
                return;
            txtpublisher.SelectAll();
            if (txtpostimage == null)
                return;
            txtpostimage.SelectAll();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtpostid.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtpostid.SelectionStart = txtpostid.SelectionStart + txtpostid.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtpostid.Paste();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtdescription.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtdescription.SelectionStart = txtdescription.SelectionStart + txtdescription.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtdescription.Paste();
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtpublisher.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtpublisher.SelectionStart = txtpublisher.SelectionStart + txtpublisher.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtpublisher.Paste();
            }
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtpostimage.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtpostimage.SelectionStart = txtpostimage.SelectionStart + txtpostimage.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtpostimage.Paste();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtpostimage.Text);
        }
    }
}
