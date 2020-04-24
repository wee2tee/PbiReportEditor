using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PbiReportEditor.Misc
{
    public class Armas
    {
        public string cuscod { get; set; }
        public string cusnam { get; set; }
        public decimal orgnum { get; set; }
        public string custyp { get; set; }
        public string custyp_desc { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string addr03 { get; set; }
        public string zipcod { get; set; }
    }

    public class Apmas
    {
        public string supcod { get; set; }
        public string supnam { get; set; }
        public decimal orgnum { get; set; }
        public string suptyp { get; set; }
        public string suptyp_desc { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string addr03 { get; set; }
    }

    public class Stmas
    {
        public string stkcod { get; set; }
        public double totbal { get; set; }
        public string stkdes { get; set; }
        public string qucod { get; set; }
        public string stkcods { get; set; }
        public string stktyp { get; set; }
        public string packing { get; set; }
        public string stkdes2 { get; set; }
    }

    public class Glacc
    {
        public string accnum { get; set; }
        public string accnam { get; set; }
        public string group { get; set; }
        public decimal level { get; set; }
        public string acctyp { get; set; }
        public string parent { get; set; }

        public string _group_desc
        {
            get
            {
                switch (this.group)
                {
                    case "1":
                        return "สินทรัพย์";
                    case "2":
                        return "หนี้สิน";
                    case "3":
                        return "ทุน";
                    case "4":
                        return "รายได้";
                    case "5":
                        return "ค่าใช้จ่าย";
                    default:
                        return "";
                }
            }
        }
        public string _acctyp_desc
        {
            get
            {
                switch (this.acctyp)
                {
                    case "1":
                        return "SUM";
                    case "0":
                        return "POS";
                    default:
                        return "";
                }
            }
        }
    }

    public class Slm
    {
        public string slmcod { get; set; }
        public string slmnam { get; set; }
    }

    public class Istab
    {
        public string tabtyp { get; set; }
        public string typcod { get; set; }
        public string shortnam { get; set; }
        public string typdes { get; set; }
    }

    public static class HelperDbf
    {
        public static List<Armas> GetArmas(string data_path)
        {
            List<Armas> list_armas = new List<Armas>();

            try
            {
                string sql = "Select a.cuscod as cuscod, a.cusnam as cusnam, a.orgnum as orgnum, a.custyp as custyp, i.typdes as custyp_desc, a.addr01 as addr01, a.addr02 as addr02, a.addr03 as addr03, a.zipcod as zipcod From armas as a Left Join istab as i On a.custyp = i.typcod and i.tabtyp = '45' Order By a.cuscod";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Armas a = new Armas()
                    {
                        cuscod = !row.IsNull("cuscod") ? row.Field<string>("cuscod").TrimEnd() : string.Empty,
                        cusnam = !row.IsNull("cusnam") ? row.Field<string>("cusnam").TrimEnd() : string.Empty,
                        orgnum = !row.IsNull("orgnum") ? row.Field<decimal>("orgnum") : 0m,
                        custyp = !row.IsNull("custyp") ? row.Field<string>("custyp").TrimEnd() : string.Empty,
                        custyp_desc = !row.IsNull("custyp_desc") ? row.Field<string>("custyp_desc").TrimEnd() : string.Empty,
                        addr01 = !row.IsNull("addr01") ? row.Field<string>("addr01").TrimEnd() : string.Empty,
                        addr02 = !row.IsNull("addr02") ? row.Field<string>("addr02").TrimEnd() : string.Empty,
                        addr03 = !row.IsNull("addr03") ? row.Field<string>("addr03").TrimEnd() : string.Empty,
                        zipcod = !row.IsNull("zipcod") ? row.Field<string>("zipcod").TrimEnd() : string.Empty
                    };
                    list_armas.Add(a);
                }

                return list_armas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Apmas> GetApmas(string data_path)
        {
            List<Apmas> list_apmas = new List<Apmas>();

            try
            {
                string sql = "Select a.supcod as supcod, a.supnam as supnam, a.orgnum as orgnum, a.suptyp as suptyp, i.typdes as suptyp_desc, a.addr01 as addr01, a.addr02 as addr02, a.addr03 as addr03 From apmas as a Left Join istab as i On a.suptyp = i.typcod and i.tabtyp = '46' Order By a.supcod";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Apmas a = new Apmas()
                    {
                        supcod = !row.IsNull("supcod") ? row.Field<string>("supcod").TrimEnd() : string.Empty,
                        supnam = !row.IsNull("supnam") ? row.Field<string>("supnam").TrimEnd() : string.Empty,
                        orgnum = !row.IsNull("orgnum") ? row.Field<decimal>("orgnum") : 0m,
                        suptyp = !row.IsNull("suptyp") ? row.Field<string>("suptyp").TrimEnd() : string.Empty,
                        suptyp_desc = !row.IsNull("suptyp_desc") ? row.Field<string>("suptyp_desc").TrimEnd() : string.Empty,
                        addr01 = !row.IsNull("addr01") ? row.Field<string>("addr01").TrimEnd() : string.Empty,
                        addr02 = !row.IsNull("addr02") ? row.Field<string>("addr02").TrimEnd() : string.Empty,
                        addr03 = !row.IsNull("addr03") ? row.Field<string>("addr03").TrimEnd() : string.Empty
                    };
                    list_apmas.Add(a);
                }

                return list_apmas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Stmas> GetStmas(string data_path)
        {
            List<Stmas> list_stmas = new List<Stmas>();

            try
            {
                string sql = "Select a.stkcod as stkcod, a.totbal as totbal, a.stkdes as stkdes, a.stkcods as stkcods, a.stktyp as stktyp, a.stkdes2 as stkdes2, a.qucod as qucod, a.packing as packing From stmas as a Order By a.stkcod";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Stmas s = new Stmas()
                    {
                        stkcod = !row.IsNull("stkcod") ? row.Field<string>("stkcod").TrimEnd() : string.Empty,
                        totbal = !row.IsNull("totbal") ? row.Field<double>("totbal") : 0,
                        stkdes = !row.IsNull("stkdes") ? row.Field<string>("stkdes").TrimEnd() : string.Empty,
                        stkcods = !row.IsNull("stkcods") ? row.Field<string>("stkcods").TrimEnd() : string.Empty,
                        stktyp = !row.IsNull("stktyp") ? row.Field<string>("stktyp").TrimEnd() : string.Empty,
                        stkdes2 = !row.IsNull("stkdes2") ? row.Field<string>("stkdes2").TrimEnd() : string.Empty,
                        qucod = !row.IsNull("qucod") ? row.Field<string>("qucod").TrimEnd() : string.Empty,
                        packing = !row.IsNull("packing") ? row.Field<string>("packing").TrimEnd() : string.Empty
                    };
                    list_stmas.Add(s);
                }

                return list_stmas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Glacc> GetGlacc(string data_path)
        {
            List<Glacc> list_glacc = new List<Glacc>();

            try
            {
                string sql = "Select a.accnum as accnum, a.accnam as accnam, a.acctyp as acctyp, a.group as group, a.level as level, a.parent as parent From glacc as a Order By a.accnum";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Glacc g = new Glacc()
                    {
                        accnum = !row.IsNull("accnum") ? row.Field<string>("accnum").TrimEnd() : string.Empty,
                        accnam = !row.IsNull("accnam") ? row.Field<string>("accnam").TrimEnd() : string.Empty,
                        acctyp = !row.IsNull("acctyp") ? row.Field<string>("acctyp").TrimEnd() : string.Empty,
                        group = !row.IsNull("group") ? row.Field<string>("group").TrimEnd() : string.Empty,
                        level = !row.IsNull("level") ? row.Field<decimal>("level") : 0,
                        parent = !row.IsNull("parent") ? row.Field<string>("parent").TrimEnd() : string.Empty
                    };
                    list_glacc.Add(g);
                }

                return list_glacc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Slm> GetSlm(string data_path)
        {
            List<Slm> list_slm = new List<Slm>();

            try
            {
                string sql = "Select a.slmcod as slmcod, a.slmnam as slmnam From oeslm as a Order By a.slmcod";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Slm s = new Slm()
                    {
                        slmcod = !row.IsNull("slmcod") ? row.Field<string>("slmcod").TrimEnd() : string.Empty,
                        slmnam = !row.IsNull("slmnam") ? row.Field<string>("slmnam").TrimEnd() : string.Empty
                    };
                    list_slm.Add(s);
                }

                return list_slm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Istab> GetDep(string data_path)
        {
            List<Istab> list_dep = new List<Istab>();

            try
            {
                string sql = "Select a.tabtyp as tabtyp, a.typcod as typcod, a.shortnam as shortnam, a.typdes as typdes From istab as a Where a.tabtyp='50' Order By a.typcod";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Istab d = new Istab()
                    {
                        tabtyp = !row.IsNull("tabtyp") ? row.Field<string>("tabtyp").TrimEnd() : string.Empty,
                        typcod = !row.IsNull("typcod") ? row.Field<string>("typcod").TrimEnd() : string.Empty,
                        shortnam = !row.IsNull("shortnam") ? row.Field<string>("shortnam").TrimEnd() : string.Empty,
                        typdes = !row.IsNull("typdes") ? row.Field<string>("typdes").TrimEnd() : string.Empty
                    };
                    list_dep.Add(d);
                }

                return list_dep;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Istab> GetLoc(string data_path)
        {
            List<Istab> list_loc = new List<Istab>();

            try
            {
                string sql = "Select a.tabtyp as tabtyp, a.typcod as typcod, a.shortnam as shortnam, a.typdes as typdes From istab as a Where a.tabtyp='21' Order By a.typcod";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Istab l = new Istab()
                    {
                        tabtyp = !row.IsNull("tabtyp") ? row.Field<string>("tabtyp").TrimEnd() : string.Empty,
                        typcod = !row.IsNull("typcod") ? row.Field<string>("typcod").TrimEnd() : string.Empty,
                        shortnam = !row.IsNull("shortnam") ? row.Field<string>("shortnam").TrimEnd() : string.Empty,
                        typdes = !row.IsNull("typdes") ? row.Field<string>("typdes").TrimEnd() : string.Empty
                    };
                    list_loc.Add(l);
                }

                return list_loc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Istab> GetStkgrp(string data_path)
        {
            List<Istab> list_stkgrp = new List<Istab>();

            try
            {
                string sql = "Select a.tabtyp as tabtyp, a.typcod as typcod, a.shortnam as shortnam, a.typdes as typdes From istab as a Where a.tabtyp='22' Order By a.typcod";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Istab s = new Istab()
                    {
                        tabtyp = !row.IsNull("tabtyp") ? row.Field<string>("tabtyp").TrimEnd() : string.Empty,
                        typcod = !row.IsNull("typcod") ? row.Field<string>("typcod").TrimEnd() : string.Empty,
                        shortnam = !row.IsNull("shortnam") ? row.Field<string>("shortnam").TrimEnd() : string.Empty,
                        typdes = !row.IsNull("typdes") ? row.Field<string>("typdes").TrimEnd() : string.Empty
                    };
                    list_stkgrp.Add(s);
                }

                return list_stkgrp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Istab> GetArea(string data_path)
        {
            List<Istab> list_area = new List<Istab>();

            try
            {
                string sql = "Select a.tabtyp as tabtyp, a.typcod as typcod, a.shortnam as shortnam, a.typdes as typdes From istab as a Where a.tabtyp='40' Order By a.typcod";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Istab a = new Istab()
                    {
                        tabtyp = !row.IsNull("tabtyp") ? row.Field<string>("tabtyp").TrimEnd() : string.Empty,
                        typcod = !row.IsNull("typcod") ? row.Field<string>("typcod").TrimEnd() : string.Empty,
                        shortnam = !row.IsNull("shortnam") ? row.Field<string>("shortnam").TrimEnd() : string.Empty,
                        typdes = !row.IsNull("typdes") ? row.Field<string>("typdes").TrimEnd() : string.Empty
                    };
                    list_area.Add(a);
                }

                return list_area;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Istab> GetSuptyp(string data_path)
        {
            List<Istab> list_suptyp = new List<Istab>();

            try
            {
                string sql = "Select a.tabtyp as tabtyp, a.typcod as typcod, a.shortnam as shortnam, a.typdes as typdes From istab as a Where a.tabtyp='46' Order By a.typcod";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Istab s = new Istab()
                    {
                        tabtyp = !row.IsNull("tabtyp") ? row.Field<string>("tabtyp").TrimEnd() : string.Empty,
                        typcod = !row.IsNull("typcod") ? row.Field<string>("typcod").TrimEnd() : string.Empty,
                        shortnam = !row.IsNull("shortnam") ? row.Field<string>("shortnam").TrimEnd() : string.Empty,
                        typdes = !row.IsNull("typdes") ? row.Field<string>("typdes").TrimEnd() : string.Empty
                    };
                    list_suptyp.Add(s);
                }

                return list_suptyp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Istab> GetCustyp(string data_path)
        {
            List<Istab> list_custyp = new List<Istab>();

            try
            {
                string sql = "Select a.tabtyp as tabtyp, a.typcod as typcod, a.shortnam as shortnam, a.typdes as typdes From istab as a Where a.tabtyp='45' Order By a.typcod";
                DataTable dt = QueryModel.RawQuery(data_path, sql);

                foreach (DataRow row in dt.Rows)
                {
                    Istab c = new Istab()
                    {
                        tabtyp = !row.IsNull("tabtyp") ? row.Field<string>("tabtyp").TrimEnd() : string.Empty,
                        typcod = !row.IsNull("typcod") ? row.Field<string>("typcod").TrimEnd() : string.Empty,
                        shortnam = !row.IsNull("shortnam") ? row.Field<string>("shortnam").TrimEnd() : string.Empty,
                        typdes = !row.IsNull("typdes") ? row.Field<string>("typdes").TrimEnd() : string.Empty
                    };
                    list_custyp.Add(c);
                }

                return list_custyp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
