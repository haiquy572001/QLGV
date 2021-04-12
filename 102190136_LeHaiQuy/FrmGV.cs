using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102190136_LeHaiQuy
{
    public partial class FrmGV : Form
    {
        string id;
        private List<GV> ListGV = CSDL_OOP.Instance.GetAllGV();
        private List<CS> ListCS = CSDL_OOP.Instance.GetAllCS();
        public FrmGV()
        {
            InitializeComponent();
            SetCBB();
        }
        void SetCBB()
        {
            int index = 0;
            cbCS.Items.Add(new CBBItems { Value = 0, Text = "All" });
            foreach (CS item in ListCS)
            {
                cbCS.Items.Add(new CBBItems { Value = ++index, Text = item.TenCS,Val = item.MaCS });
            }
            string[] prop = { "MaGV", "TenSV", "SDT", "NS", "MaCS" };
            foreach (string item in prop)
            {
                cbSort.Items.Add(item);
            }
        }
        void ShowDS()
        {
            dtgvGV.DataSource = ListGV;
            dtgvGV.Show();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cbCS.SelectedItem.ToString() == "All") ShowDS();
            else
            {
                foreach (CS item in ListCS)
                {
                    if (cbCS.SelectedItem.ToString() == item.TenCS)
                    {
                        foreach (GV s in ListGV)
                        {
                            if (item.MaCS == s.MaCS)
                            {
                                dtgvGV.DataSource = CSDL_OOP.Instance.GetListGV(s.MaCS);
                            }
                        }
                    }
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbCS.SelectedItem.ToString() == "All")
            {
                foreach (GV s in ListGV)
                {
                    if (s.TenGV.Contains(txtSearch.Text))
                    {
                        dtgvGV.DataSource = CSDL_OOP.Instance.GetListName(txtSearch.Text);
                        dtgvGV.Show();
                    }
                }
            }
            else
            {
                foreach (CS item in ListCS)
                {
                    if(cbCS.SelectedItem.ToString() == item.TenCS)
                    {
                        foreach (GV i in ListGV)
                        {
                            if(item.MaCS == i.MaCS)
                            {
                                if (i.TenGV.Contains(txtSearch.Text))
                                {
                                    id = i.MaCS;
                                }
                                dtgvGV.DataSource = CSDL_OOP.Instance.GetListGV(id,txtSearch.Text);
                                dtgvGV.Show();
                            }
                        }
                    }
                }
            }


        }
        void Add(GV a)
        {
            if (CSDL_OOP.Instance.AddNewGV(a, true))
            {
                dtgvGV.DataSource = null;
                dtgvGV.DataSource = ListGV;
                MessageBox.Show("Added Successfully");
            }
            else MessageBox.Show("error");
        }
        private void btnAdd_Click(object sender,EventArgs e)
        {
            FrmDetailGV detail = new FrmDetailGV();
            detail.profile = new FrmDetailGV.MyDelegate(Add);
            detail.Show();
        }
        GV CellClick(DataGridViewRow row)
        {
            GV s = new GV();
            s.MaGV = (int)row.Cells["MaGV"].Value;
            s.TenGV = row.Cells["TenGV"].Value.ToString();
            s.MaCS = row.Cells["MaCS"].Value.ToString();
            s.NS = Convert.ToDateTime(row.Cells["NS"].Value);
            s.SDT = row.Cells["SDT"].Value.ToString();
            return s;
        }
        void Edit(GV a)
        {
            DataGridViewRow row = dtgvGV.CurrentRow;
            GV i = new GV();
            i = CellClick(row);
            if (a.MaGV == i.MaGV && CSDL_OOP.Instance.AddNewGV(a, false))
            {
                dtgvGV.DataSource = null;
                dtgvGV.DataSource = ListGV;
                MessageBox.Show("Edit Successfully");
            }
            else MessageBox.Show("Error Edit");

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmDetailGV detail = new FrmDetailGV();
            DataGridViewRow row = dtgvGV.CurrentRow;
            if (row != null)
            {
                detail.BindingDataSV(row);
                detail.profile = new FrmDetailGV.MyDelegate(Edit);
                detail.Show();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dtgvGV.CurrentRow;
            if (row != null)
            {
                GV a = new GV();
                a = CellClick(row);
                DialogResult result = MessageBox.Show("Bạn có muốn xóa SV này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dtgvGV.DataSource = null;
                    CSDL_OOP.Instance.DeleteSV(a);
                    dtgvGV.DataSource = ListGV;
                    MessageBox.Show("Delete Successfully");
                }
            }

        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            dtgvGV.DataSource = null;
            string choose = cbSort.SelectedItem.ToString();
            string[] prop = { "MaGV", "TenGV", "SDT", "NS", "MaCS" };
            if (choose == prop[0]) ListGV.Sort((x, y) => x.MaGV.CompareTo(y.MaGV));
            if (choose == prop[1]) ListGV.Sort((x, y) => x.TenGV.CompareTo(y.TenGV));
            if (choose == prop[2]) ListGV.Sort((x, y) => x.SDT.CompareTo(y.SDT));
            if (choose == prop[3]) ListGV.Sort((x, y) => x.NS.CompareTo(y.NS));
            if (choose == prop[4]) ListGV.Sort((x, y) => x.MaCS.CompareTo(y.MaCS));
            dtgvGV.DataSource = ListGV;
            dtgvGV.Show();
        }
    }
}
