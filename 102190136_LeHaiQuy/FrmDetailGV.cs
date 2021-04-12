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
    public partial class FrmDetailGV : Form
    {
        public delegate void MyDelegate(GV s);
        public MyDelegate profile { get; set; }
        public FrmDetailGV()
        {
            InitializeComponent();
            SetCBB();
        }
        public void SetCBB()
        {
            int index = 0;
            foreach (CS i in CSDL_OOP.Instance.GetAllCS())
            {
                cbCS.Items.Add(new CBBItems { Value = ++index, Text = i.TenCS,Val =i.MaCS });
            }
        }
        string index;
        string GetID()
        {
            
            foreach (CBBItems item in cbCS.Items)
            {
                if (item.Value == ((CBBItems)(cbCS.SelectedItem)).Value) index = item.Val;
            }
            return index;
        }
        bool Validate()
        {
            int n = 0;
            if (txtSDT.Text.Length != 10 || (!int.TryParse(txtSDT.Text,out n)))
            {
                MessageBox.Show("Loi SDT");
                txtSDT.Focus();
                return false;
            }
            return true;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                GV gv = new GV();
                gv.MaGV = Convert.ToInt32(txtMaGV.Text);
                gv.TenGV = txtTenGV.Text;
                gv.SDT = txtSDT.Text;

                gv.MaCS = GetID();
                gv.NS = Convert.ToDateTime(datepicker.Value);
                profile(gv);
            };
            this.Close();
        }
        public void BindingDataSV(DataGridViewRow r)
        {
            txtMaGV.Text = (r.Cells["MaGV"].Value).ToString();
            txtMaGV.Enabled = false;
            txtTenGV.Text = (r.Cells["TenGV"].Value).ToString();
            foreach (CBBItems i in cbCS.Items)
            {
                if (i.Val == r.Cells["MaCS"].Value.ToString()) cbCS.SelectedItem = i;
               
            }
            datepicker.Value = Convert.ToDateTime(r.Cells["NS"].Value);
            txtSDT.Text = (r.Cells["SDT"].Value).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
