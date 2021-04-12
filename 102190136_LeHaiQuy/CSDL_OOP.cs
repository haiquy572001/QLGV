using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190136_LeHaiQuy
{
    class CSDL_OOP
    {
        private static CSDL_OOP _Instance;

        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null) _Instance = new CSDL_OOP();
                return _Instance;
            }
            private set { }
        }
        private List<CS> ListCS { get; set; }
        private List<GV> ListGV { get; set; }

        public List<GV> GetAllGV()
        {
            if (ListGV != null) ListGV.Clear();
            else ListGV = new List<GV>();
            foreach (DataRow item in CSDL.Instance.DTGV.Rows)
            {
                GV s = new GV();
                s.MaGV = (int)(item["MaGV"]);
                s.TenGV = item["TenGV"].ToString();
                s.SDT = item["SDT"].ToString();
                s.MaCS = item["MaCS"].ToString();
                s.NS = Convert.ToDateTime(item["NS"]);
                ListGV.Add(s);
            }
            return ListGV;
        }
        public List<CS> GetAllCS()
        {
            if (ListCS != null) ListCS.Clear();
            else ListCS = new List<CS>();
            foreach (DataRow item in CSDL.Instance.DTCS.Rows)
            {
                CS ls = new CS();
                ls.MaCS = item["MaCS"].ToString();
                ls.TenCS = item["TenCS"].ToString();
                ListCS.Add(ls);
            }
            return ListCS;
        }
        public GV GetGV(DataRow row)
        {
            GV a = new GV();
            DataTable dt = CSDL.Instance.DTGV;
            foreach (DataRow item in dt.Rows)
            {
                if (row == item)
                {
                    a.MaGV = (int)item["MaGV"];
                    a.TenGV = item["TenGV"].ToString();
                    a.SDT = item["SDT"].ToString();
                    a.NS = Convert.ToDateTime(item["NS"]);
                    a.MaCS = item["ID_Lop"].ToString();
                }

            }
            return a;
        }
        public CS GetCS(DataRow i)
        {
            CS ls = new CS();
            foreach (DataRow item in CSDL.Instance.DTCS.Rows)
            {
                if (item == i)
                {
                    ls.MaCS = item["MaCS"].ToString();
                    ls.TenCS = item["TenCS"].ToString();
                }
            }
            return ls;

        }
        public List<GV> GetListGV(string MaCS, string Name)
        {
            List<GV> s = new List<GV>();
            DataTable dt = CSDL.Instance.DTGV;
            foreach (DataRow item in dt.Rows)
            {
                if (item["MaCS"].ToString() == MaCS && item["TenGV"].ToString().Contains(Name))
                {
                    GV a = new GV();
                    a.MaGV = (int)item["MaGV"];
                    a.TenGV = item["TenGV"].ToString();
                    a.SDT = item["SDT"].ToString();
                    a.NS = Convert.ToDateTime(item["NS"]);
                    a.MaCS = item["MaCS"].ToString();
                    s.Add(a);
                }
            }
            return s;
        }
        public List<GV> GetListName(string Name)
        {
            List<GV> s = new List<GV>();
            DataTable dt = CSDL.Instance.DTGV;
            foreach (DataRow item in dt.Rows)
            {
                if (item["TenGV"].ToString().Contains(Name))
                {
                    GV a = new GV();
                    a.MaGV = (int)item["MaGV"];
                    a.TenGV = item["TenGV"].ToString();
                    a.SDT = item["SDT"].ToString();
                    a.NS = Convert.ToDateTime(item["NS"]);
                    a.MaCS = item["MaCS"].ToString();
                    s.Add(a);
                }
            }
            return s;
        }
        public List<GV> GetListGV(string MaCS)
        {
            List<GV> s = new List<GV>();
            DataTable dt = CSDL.Instance.DTGV;
            foreach (DataRow item in dt.Rows)
            {
                if (item["MaCS"].ToString() == MaCS)
                {
                    GV a = new GV();
                    a.MaGV = (int)item["MaGV"];
                    a.TenGV = item["TenGV"].ToString();
                    a.SDT = item["SDT"].ToString();
                    a.NS = Convert.ToDateTime(item["NS"]);
                    a.MaCS = item["MaCS"].ToString();
                    s.Add(a);
                }
            }
            return s;
        }
        public bool checkMaGV(int a)
        {
            foreach (GV i in ListGV)
            {
                if (i.MaGV == a) return false;
            }
            return true;
        }
        public bool AddNewGV(GV gv, bool isAdd)
        {
            if (isAdd)
            {
                if (checkMaGV(gv.MaGV))
                {
                    CSDL.Instance.AddNewRow(gv);
                    Instance.GetAllGV();
                    return true;
                }
                return false;
            }
            else
            {
                CSDL.Instance.EditRow(gv);
                Instance.GetAllGV();
                return true;
            }
        }
        public void DeleteSV(GV gv)
        {
            CSDL.Instance.DeleteRow(gv);
            Instance.GetAllGV();
        }
    }
}
