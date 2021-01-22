using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unigram_Admin_App
{
    class MyUser
    {
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }

        private static string error = "Tên đăng nhập không tồn tại !";

        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool IsEqual(MyUser user1, MyUser user2)
        {
            if (user1 == null || user2 == null) { return false; }

            if (user1.Taikhoan != user2.Taikhoan)
            {
                error = "Tên đăng nhập không tồn tại !";
                return false;
            }

            else if (user1.Matkhau != user2.Matkhau)
            {
                error = "Mật khẩu không hợp lệ !";
                return false;
            }

            return true;
        }
    }
}
