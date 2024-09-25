using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCD_Stadium_Management.Functs;

namespace TCD_Stadium_Management.Frms
{
    public partial class FrmLogin : Form
    {
        private FrmLoginDao _dao;
        public FrmLogin()
        {
            InitializeComponent();
            _dao = new FrmLoginDao();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //Validate:
            errorProvider1.SetError(txtUsername, "");
            errorProvider1.SetError(txtPassword, "");
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                errorProvider1.SetError(txtUsername, "Tên đăng nhập không được bỏ trống!");
                errorProvider1.SetError(txtPassword, "Mật khẩu không được bỏ trống!");
            }
            else
            {
                // Kiểm tra đăng nhập
                if (_dao.checkLogin(txtUsername.Text, txtPassword.Text))
                {
                    //đúng
                    //hiển thị form Main
                    FrmMain frmMain = new FrmMain();
                    frmMain.Show();
                    this.Hide();
                    frmMain.eLogout += F_Logout;
                }
                else
                {
                    //sai => thông báo
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác", "Thông tin đăng nhập", MessageBoxButtons.OK);
                }

            }


        }

        private void F_Logout(object sender, EventArgs e)
        {
            (sender as FrmMain).isExist = false;
            (sender as FrmMain).Close();
            this.Show();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void chkNhoThongTin_CheckedChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                if (chkNhoThongTin.Checked == true)
                {
                    Properties.Settings.Default.username = txtUsername.Text;
                    Properties.Settings.Default.password = txtPassword.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Properties.Settings.Default.username;
            txtPassword.Text = Properties.Settings.Default.password;

            if (Properties.Settings.Default.username != "")
            {
                chkNhoThongTin.Checked = true;
            }
        }
    }
}
