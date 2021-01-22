using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unigram_Admin_App
{
    class MyPresident
    {
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }

        private static string error = "Tên đăng nhập của giám đốc không tồn tại !";

        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool IsEqual(MyPresident president1, MyPresident president2)
        {
            if (president1 == null || president2 == null) { return false; }

            if (president1.Taikhoan != president2.Taikhoan)
            {
                error = "Tên đăng nhập của giám đốc không tồn tại !";
                return false;
            }

            else if (president1.Matkhau != president2.Matkhau)
            {
                error = "Mật khẩu của giám đốc không hợp lệ !";
                return false;
            }

            return true;
        }
    }
}
