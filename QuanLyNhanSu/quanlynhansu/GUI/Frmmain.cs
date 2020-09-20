
using QuanLyNhanSu.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class FrmMain : Form
    {
        public static string IDNV;
        public FrmMain()
        {
            InitializeComponent();
            hideBtn();
        }
        private void hideBtn()
        {
            btn_nhansu.Visible = false;
            btn_phongban.Visible = false;
            btn_tongiao.Visible = false;
            btn_thongke.Visible = false;
            btn_taikhoan.Visible = false;
            btn_trinhdohocvan.Visible = false;
            btn_ngoaingu.Visible = false;
            btn_thannhan.Visible = false;
            btn_dantoc.Visible = false;
            panel1.Visible = false;
        }
        private void showBtn()
        {
            btn_nhansu.Visible = true;
            btn_phongban.Visible = true;
            btn_tongiao.Visible = true;
            btn_thongke.Visible = true;
            btn_taikhoan.Visible = true;
            btn_trinhdohocvan.Visible = true;
            btn_ngoaingu.Visible = true;
            btn_thannhan.Visible = true;
            btn_dantoc.Visible = true;
        }
        private void btn_tools_Click(object sender, EventArgs e)
        {
            if (btn_nhansu.Visible == true)
            {
                hideBtn();
            }
            else
            {
                showBtn();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            FrmThongke frmThongke = new FrmThongke();
            frmThongke.ShowDialog();
        }

        private void btn_nhansu_Click(object sender, EventArgs e)
        {
            Frmthannhannhanvien nhanvien_thannhan = new Frmthannhannhanvien();
            nhanvien_thannhan.ShowDialog();
           
        }

        private void btn_phongban_Click(object sender, EventArgs e)
        {
            Frmphongban frmphongban = new Frmphongban();
            frmphongban.ShowDialog();
        }

        private void btn_tongiao_Click(object sender, EventArgs e)
        {
            Frmtongiao frmtongiao = new Frmtongiao();
            frmtongiao.ShowDialog();
        }

        private void btn_trinhdohocvan_Click(object sender, EventArgs e)
        {
            Frmtrinhdohocvan frmtrinhdohocvan = new Frmtrinhdohocvan();
            frmtrinhdohocvan.ShowDialog();
        }

        private void btn_taikhoan_Click(object sender, EventArgs e)
        {
            FrmTaikhoancanhan frmTaikhoancanhan = new FrmTaikhoancanhan();
            frmTaikhoancanhan.ShowDialog();
        }

        private void btn_ngoaingu_Click(object sender, EventArgs e)
        {
            Frmngoaingu frmngoaingu = new Frmngoaingu();
            frmngoaingu.ShowDialog();
        }

        private void btn_thannhan_Click(object sender, EventArgs e)
        {
            Frmthannhannhanvien frmthannhannhanvien = new Frmthannhannhanvien();
            frmthannhannhanvien.ShowDialog();
        }

        private void btn_dantoc_Click(object sender, EventArgs e)
        {
            Frmdantoc frmdantoc = new Frmdantoc();
            frmdantoc.ShowDialog();
        }
    }
}
