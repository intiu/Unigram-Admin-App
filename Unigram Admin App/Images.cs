using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace Unigram_Admin_App
{
    public partial class Images : Form
    {
        public Images()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "AH6MOR5nj3YzwUvOvfHqkZ92FINoI7TZ9GS0Hphj",
            BasePath = "https://um-clone-app.firebaseio.com/"
        };

        IFirebaseClient client;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Image files(*.jpg, *.jpeg, *.bmp, *.png) | *.jpg; *.jpeg; *.bmp; *.png|All files (*.*)|*.*";
            if (od.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(od.FileName);
            }
        }

        private void storeBtn_Click(object sender, EventArgs e)
        {
            Data data = new Data()
            {
                uid = IDtbox.Text,
                username = NameTbox.Text,
                image = ImageIntoBase64String(pictureBox1)
            };
            var set = client.Set("Users/" + IDtbox.Text, data);

           
        }

        private void retrieveBtn_Click(object sender, EventArgs e)
        {
            var res = client.Get("Users/" + IDtbox.Text);
            Data data = res.ResultAs<Data>();
            NameTbox.Text = data.username;
            IDtbox.Text = data.uid;
            pictureBox1.Image = Base64StringIntoImage(data.image);
        }

        public static string ImageIntoBase64String(PictureBox pbox)
        {
            MemoryStream ms = new MemoryStream();
            pbox.Image.Save(ms, pbox.Image.RawFormat);
            return Convert.ToBase64String(ms.ToArray());
        }

        public static Image Base64StringIntoImage(string str64)
        {
            byte[] img = Convert.FromBase64String(str64);
            MemoryStream ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }

        private void Images_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
