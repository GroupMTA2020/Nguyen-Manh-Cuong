using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanSu.DAO;
using QuanLyNhanSu.DATAHA;

namespace QuanLyNhanSu.GUI
{
    public partial class Frmdantoc : Form
    {
        private QuanLyNhanSuDbContext db = DBService.db;
        private int index = 0, index1 = 0;


        private void Frmdantoc_Load(object sender, EventArgs e)
        {
            txtghichu.Enabled = false;
            txtten.Enabled = false;
            Loadthongtin();
        }

        public Frmdantoc()
        {
            InitializeComponent();
        }

        private void Loadthongtin()
        {
            int i = 0;
            string keyword = txtTimKiem.Text;
            var dbNV = db.DANTOCs.ToList()
                       .Select(p => new
                       {

                           STT = ++i,
                           ID = p.ID,
                           Ten = p.TEN,
                           Ghichu = p.GHICHU,

                       }).ToList()

                       ;

            dgvthongtin.DataSource = dbNV.Where(p => p.Ten.Contains(keyword)).ToList();

            // cập nhật index 
            index = index1;
            try
            {
                dgvthongtin.Rows[index].Cells["STT"].Selected = true;
                dgvthongtin.Select();
            }
            catch { }
        }

        private void dgvthongtin_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvthongtin12_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
        }

       

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
