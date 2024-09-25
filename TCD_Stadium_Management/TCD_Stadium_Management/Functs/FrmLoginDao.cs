using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCD_Stadium_Management.Models;

namespace TCD_Stadium_Management.Functs
{
    public class FrmLoginDao
    {
        private readonly TCD_Stadium_ManagementEntities _db;
        public FrmLoginDao()
        {
            _db = new TCD_Stadium_ManagementEntities();
        }
        public bool checkLogin(string username, string password)
        {
            try
            {
                var _user = _db.Users.SingleOrDefault(u=>u.Username == username && u.Password == password);
                if (_user != null)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi truy cập cơ sở dữ liệu:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

    }
}
