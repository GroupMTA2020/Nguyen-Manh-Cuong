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
        public Frmdantoc()
        {
            InitializeComponent();
        }
      
       
       
        private void dgvthongtin_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvthongtin12_SelectionChanged(object sender, EventArgs e)
        {
            UpdateDetail();
        }
        private void UpdateDetail()
        {
            ClearControl();
            try
            {
                DANTOC tg = getnhanvienByID();

                if (tg == null || tg.ID == 0) return;

                // cập nhật trên giao diện
                txtten.Text = tg.TEN;
                txtghichu.Text = tg.GHICHU;
                index1 = index;
                index = dgvthongtin.SelectedRows[0].Index;
            }
            catch { }

        }
        private DANTOC getnhanvienByID()
        {
            try
            {
                int id = (int)dgvthongtin.SelectedRows[0].Cells["ID"].Value;
                DANTOC x = db.DANTOCs.Where(p => p.ID == id).FirstOrDefault();
                return (x != null) ? x : new DANTOC();
            }
            catch
            {
                return new DANTOC();
            }
        }
        private void ClearControl()
        {
            try
            {
                txtten.Text = "";
                txtghichu.Text = "";

            }
            catch { }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {

                btnThem.Text = "Lưu";
                btnSua.Enabled = false;
                btnXoa.Text = "Hủy";

                groupthongtin.Enabled = true;
                txtghichu.Enabled = true;
                txtten.Enabled = true;
                dgvthongtin.Enabled = false;

                btntimkiem.Enabled = false;
                txtTimKiem.Enabled = false;

                ClearControl();

                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if (Check())
                {

                    btnThem.Text = "Thêm";
                    btnSua.Enabled = true;
                    btnXoa.Text = "Xóa";

                    groupthongtin.Enabled = false;
                    dgvthongtin.Enabled = true;

                    btntimkiem.Enabled = false;
                    txtTimKiem.Enabled = false;

                    try
                    {
                        DANTOC tg = getnhanvienByForm();
                        db.DANTOCs.Add(tg);
                        db.SaveChanges();



                        MessageBox.Show("Thêm  thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm  thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    Loadthongtin();
                }

                return;
            }
        }
        private DANTOC getnhanvienByForm()
        {
            DANTOC ans = new DANTOC();
            ans.TEN = txtten.Text;
            ans.GHICHU = txtghichu.Text;


            return ans;
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
        private bool Check()
        {
            if (txtten.Text == "")
            {
                MessageBox.Show("Tên không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int cnt = db.DANTOCs.Where(p => p.TEN == txtten.Text).ToList().Count;
            if (cnt > 0)
            {
                bool ok = false;
                if (btnSua.Text == "Lưu")
                {
                    // Nếu là sửa
                    DANTOC tg = getnhanvienByID();
                    if (tg.TEN == txtten.Text) ok = true;
                }

                if (!ok)
                {
                    MessageBox.Show("Tên đã được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            if (txtghichu.Text == "")
            {
                MessageBox.Show("Ghi chú không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }




            return true;

        }
    }
}
