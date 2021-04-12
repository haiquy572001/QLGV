using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190136_LeHaiQuy
{
    class CSDL
    {
        public DataTable DTCS { get; private set; }
        public DataTable DTGV { get; private set; }
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set { }
        }

        private static CSDL _Instance;
        public CSDL()
        {
            DTGV = new DataTable();
            DataColumn[] datas = new DataColumn[]
            {
                new DataColumn("MaGV",typeof(int)),
                new DataColumn("TenGV",typeof(string)),
                new DataColumn("SDT",typeof(string)),
                new DataColumn("NS",typeof(DateTime)),
                new DataColumn("MaCS",typeof(string)),
            };
            DTGV.Columns.AddRange(datas);
            string date = DateTime.Now.ToString().Split(' ')[0];
            DataRow dr = DTGV.NewRow();
            dr["MaGV"] = 1;
            dr["TenGV"] = "Nguyen Van An";
            dr["SDT"] = "0999888777";
            dr["NS"] = date;
            dr["MaCS"] = "abcde";
            DTGV.Rows.Add(dr);
            DataRow dr1 = DTGV.NewRow();
            dr1["MaGV"] = 2;
            dr1["TenGV"] = "Nguyen Van Binh";
            dr1["SDT"] = "0954546567";
            dr1["NS"] = date;
            dr1["MaCS"] = "abcde";
            DTGV.Rows.Add(dr1);
            DataRow dr2 = DTGV.NewRow();
            dr2["MaGV"] = 3;
            dr2["TenGV"] = "Nguyen Thi Ha";
            dr2["SDT"] = "0994434377";
            dr2["NS"] = date;
            dr2["MaCS"] = "abcdf";
            DTGV.Rows.Add(dr2);
            DataRow dr3 = DTGV.NewRow();
            dr3["MaGV"] = 4;
            dr3["TenGV"] = "Le Hai Quy";
            dr3["SDT"] = "0995455377";
            dr3["NS"] = date;
            dr3["MaCS"] = "abcdh";
            DTGV.Rows.Add(dr3);


            //Lop Co So
            DTCS = new DataTable();
            DTCS.Columns.AddRange(new DataColumn[]{
                new DataColumn("MaCS",typeof(string)),
                new DataColumn("TenCS",typeof(string)),
                new DataColumn("SLGV",typeof(int))
            });
            DataRow ls = DTCS.NewRow();
            ls["MaCS"] = "abcde";
            ls["TenCS"] = "THPT Dương Văn An";
            ls["SLGV"] = 40;
            DTCS.Rows.Add(ls);
            DataRow ls1 = DTCS.NewRow();
            ls1["MaCS"] = "abcdf";
            ls1["TenCS"] = "THPT Chuyên Lê Quý Đôn";
            ls1["SLGV"] = 45;
            DTCS.Rows.Add(ls1);
            DataRow ls2 = DTCS.NewRow();
            ls2["MaCS"] = "abcdh";
            ls2["TenCS"] = "THPT Hoàng Hoa Thám";
            ls2["SLGV"] = 55;
            DTCS.Rows.Add(ls2);
        }
        public void AddNewRow(GV a)
        {
            DataRow b = DTGV.NewRow();
            b["MaGV"] = a.MaGV;
            b["TenGV"] = a.TenGV;
            b["SDT"] = a.SDT;
            b["MaCS"] = a.MaCS;
            b["NS"] = a.NS.ToString().Split(' ')[0];
            DTGV.Rows.Add(b);
        }
        public void EditRow(GV a)
        {
            foreach (DataRow item in Instance.DTGV.Rows)
            {
                if ((int)item["MaGV"] == a.MaGV)
                {
                    item["TenGV"] = a.TenGV;
                    item["NS"] = a.NS.ToString().Split(' ')[0];
                    item["SDT"] = a.SDT;
                    item["MaCS"] = a.MaCS;
                }
            }
        }
        public void DeleteRow(GV a)
        {
            foreach (DataRow item in Instance.DTGV.Rows)
            {
                if ((int)item["MaGV"] == a.MaGV)
                {
                    Instance.DTGV.Rows.Remove(item);
                    break;
                }
            }

        }

    }
}
