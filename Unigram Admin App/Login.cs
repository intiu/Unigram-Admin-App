using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Diagnostics;

namespace Unigram_Admin_App
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "AH6MOR5nj3YzwUvOvfHqkZ92FINoI7TZ9GS0Hphj",
            BasePath = "https://um-clone-app.firebaseio.com/"
        };

        IFirebaseClient client;

        private void Login_Load(object sender, EventArgs e)
        {           
            try
            {              
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("Không có kết nối Internet");
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            #region Condition
            if (string.IsNullOrWhiteSpace(username.Text) &&
               string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Hãy nhập hết các nội dung trên");
                return;
            }
            #endregion

            FirebaseResponse res1 = client.Get(@"Admin/" + username.Text);
            
            MyUser ResUser = res1.ResultAs<MyUser>();// database result
            

            MyUser CurUser = new MyUser() // USER GIVEN INFO
            {
                Taikhoan = username.Text,
                Matkhau = password.Text
            };
            

            if (MyUser.IsEqual(ResUser, CurUser))
            {
                Loading loading = new Loading();
                loading.Show();
                this.Hide();
            }
            
            else
            {
                MyUser.ShowError();              
            }





        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            var a1 = new ProcessStartInfo("msedge.exe");
            a1.Arguments = "https://intiu.github.io";
            Process.Start(a1);
        }

        private void gunaImageButton3_Click(object sender, EventArgs e)
        {
            Chatbot chatbot = new Chatbot();
            //this.Hide();
            chatbot.Show();
            this.Show();
        }
    }
}
