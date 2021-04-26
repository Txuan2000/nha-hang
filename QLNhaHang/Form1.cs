using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaHang
{
    public partial class Form1 : Form
    {
        Utilities data = new Utilities();
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void DisplayHoadon()
        {
            dgvDSHoaDon.DataSource = data.hienthiHD();
        }
        public void DisplayctHoadon(string mahd)
        {
            dgvChiTietHD.DataSource = data.hienthichitietHD(mahd);
        }

        private void getHD(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            try
            {
                txtMaHD.Text = dgvDSHoaDon.Rows[index].Cells[0].Value.ToString();
                txtNgayLap.Text = dgvDSHoaDon.Rows[index].Cells[1].Value.ToString();
                txtNguoiLap.Text = dgvDSHoaDon.Rows[index].Cells[2].Value.ToString();
                txtKhach.Text = dgvDSHoaDon.Rows[index].Cells[3].Value.ToString();
                DisplayctHoadon(txtMaHD.Text);
            }
            catch(Exception ex)
            {

            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void laphoadon()
        {
            cbxBanan.DataSource = data.danhsachban();
            cbxBanan.DisplayMember = "mabanan";
            cbxBanan.ValueMember = "mabanan";
        }

        private void tabcontrol_click(object sender, EventArgs e)
        {
            check_tab();
        }
        private void check_tab()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                   
                    break;
                case 2:
                    laphoadon();
                    break;
                case 3:
                    
                    DisplayHoadon();
                    break;
            }
        }
    }
}
