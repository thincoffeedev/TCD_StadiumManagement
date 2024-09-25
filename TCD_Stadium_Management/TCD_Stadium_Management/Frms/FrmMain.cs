using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCD_Stadium_Management.Frms
{
    public partial class FrmMain : Form
    {
        public bool isExist = true;
        public EventHandler eLogout { get; set; }
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMainClose(object sender, FormClosedEventArgs e)
        {
            if (isExist)
            {
                Application.Exit();
            }
        }

        private void FrmMainClosing(object sender, FormClosingEventArgs e)
        {
            if (isExist)
            {
                if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình", "Cảnh báo?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            eLogout(this, new EventArgs());
        }
    }
}
