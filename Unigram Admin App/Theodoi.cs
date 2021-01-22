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
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using Newtonsoft.Json;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.LookAndFeel;
using System.Diagnostics;

namespace Unigram_Admin_App
{
    public partial class Theodoi : DevExpress.XtraEditors.XtraUserControl
    {
        IFirebaseClient client;

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "AH6MOR5nj3YzwUvOvfHqkZ92FINoI7TZ9GS0Hphj",
            BasePath = "https://um-clone-app.firebaseio.com/"
        };
        private static Theodoi _instance;
        public static Theodoi Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Theodoi();
                return _instance;
            }
        }
        public Theodoi()
        {
            InitializeComponent();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Follow/31KvRs6deKOZ4muwAdYzT48zaah2/Followers");
            FirebaseResponse res2 = client.Get(@"Follow/Sn8GVpxDVIWHMZ3008jxKitpMuy2/Followers");
            Dictionary<string, Follow> data = JsonConvert.DeserializeObject<Dictionary<string, Follow>>(res.Body.ToString());
            Dictionary<string, Follow> data2 = JsonConvert.DeserializeObject<Dictionary<string, Follow>>(res2.Body.ToString());
            PopulateRTB(data);
            PopulateRTB(data2);
            MessageBox.Show("Máy chủ đã load xong hãy nhấn hiển thị");
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Follow/31KvRs6deKOZ4muwAdYzT48zaah2/Followers");
            FirebaseResponse res2 = client.Get(@"Follow/Sn8GVpxDVIWHMZ3008jxKitpMuy2/Followers");
            Dictionary<string, Follow> data = JsonConvert.DeserializeObject<Dictionary<string, Follow>>(res.Body.ToString());
            Dictionary<string, Follow> data2 = JsonConvert.DeserializeObject<Dictionary<string, Follow>>(res2.Body.ToString());
            PopulateDataGrid(data);
            PopulateDataGrid(data2);
        }

        void PopulateRTB(Dictionary<string, Follow> record)
        {
            richTextBox1.Clear();
            foreach (var item in record)
            {
                richTextBox1.Text += item.Key + "\n";
                richTextBox1.Text += "Mã người theo dõi mình" + item.Value.Followers + "\n";
                richTextBox1.Text += "Mã người mình theo dõi " + item.Value.uidfollowing + "\n";
            }
        }

        void PopulateDataGrid(Dictionary<string, Follow> record)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Mã người theo dõi mình", "Mã người theo dõi mình");
            dataGridView1.Columns.Add("Mã người mình theo dõi ", "Mã người mình theo dõi ");
            foreach (var item in record)
            {
                dataGridView1.Rows.Add(item.Value.Followers, item.Value.uidfollowing);
            }
        }
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region add
            string str = txtFollowers.Text.Replace('.', ',');

            Follow std = new Follow()
            {
                Followers = str,
                uidfollowing = txtuidfollowing.Text
            };
            var set = client.Set(@"Follow/" + str, std);
            #endregion
            FirebaseResponse res = client.Get(@"Total");
            int Counter = int.Parse(res.ResultAs<string>());

            Follow Follow = new Follow()
            {
                Followers = txtFollowers.Text,
                uidfollowing = txtuidfollowing.Text
            };

            var set2 = client.Set(@"Total", ++Counter);
            var set3 = client.Set("History/" + Counter, Follow);

            MessageBox.Show("Dữ liệu được lưu trữ thành công!");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Follow std = new Follow()
            {
                Followers = txtFollowers.Text,
                uidfollowing = txtuidfollowing.Text
            };

            var set = client.Update(@"Follow/" + txtFollowers.Text, std);

            MessageBox.Show("Dữ liệu được cập nhật thành công!");
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var set = client.Delete(@"Follow/" + txtFollowers.Text);
            MessageBox.Show("Dữ liệu đã được xóa thành công!");
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Theodoi";
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
            saveFileDialoge.FileName = "Theodoi";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void Theodoi_Load(object sender, EventArgs e)
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
            if (txtFollowers.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtFollowers.Cut();
            if (txtuidfollowing.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtuidfollowing.Cut();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFollowers.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtFollowers.Copy();
            if (txtuidfollowing.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtuidfollowing.Copy();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtFollowers.Font = fd.Font;
                txtuidfollowing.Font = fd.Font;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtFollowers.BackColor = fd.Color;
                txtuidfollowing.BackColor = fd.Color;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtFollowers.Undo();
            txtuidfollowing.Undo();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFollowers == null)
                return;
            txtFollowers.SelectAll();
            if (txtuidfollowing == null)
                return;
            txtuidfollowing.SelectAll();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtFollowers.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtFollowers.SelectionStart = txtFollowers.SelectionStart + txtFollowers.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtFollowers.Paste();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtuidfollowing.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Do you want to paste over current selection?",
                            "Cut Example",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtuidfollowing.SelectionStart = txtuidfollowing.SelectionStart + txtuidfollowing.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtuidfollowing.Paste();
            }
        }
    }
}
