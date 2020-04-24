using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace PbiReportEditor.Misc
{
    public class QueryModel
    {
        public MasterFile masterFile { get; set; }
        public List<RelateFile> relateFile { get; set; }
        public List<string> selectedField { get; set; }
        public List<string> query { get; set; }
        public List<ControlScope> controlScope { get; set; }
        public List<OrderBy> orderBy { get; set; }
        public LicenseCheck license { get; set; }
        public string sql { get { return this.ToSql(); } }
        private List<string> adding_where = new List<string>();


        private string ToSql()
        {
            string sql = "Select ";
            sql += string.Join(",", this.selectedField) + " ";
            sql += "From " + this.masterFile.fileName + " As " + this.masterFile.alias + " ";

            sql += makeJoinClause(this.relateFile, this.masterFile);

            sql += makeWhereClause(this.query);

            sql += makeOrderByClause(this.orderBy);

            return sql;
        }

        private string makeJoinClause(List<RelateFile> relateFile, MasterFile masterFile)
        {
            string sql = string.Empty;

            foreach (var f in relateFile)
            {
                sql += "Left Join " + f.fileName.Trim() + " As " + f.alias.Trim() + " On (" + masterFile.alias.Trim() + "." + f.masterRelatedField.Trim() + "=" + f.alias.Trim() + "." + f.fieldName.Trim();
                sql += f.filter != null && f.filter.Trim().Length > 0 ? " And " + f.alias.Trim() + "." + f.filter.Trim() + ") " : ") ";

                if (f.relateFile != null && f.relateFile.Count > 0)
                {
                    MasterFile mf = new MasterFile { alias = f.alias, fileName = f.fileName };
                    sql += makeJoinClause(f.relateFile, mf);
                }
            }

            return sql;
        }

        private string makeWhereClause(List<string> where)
        {
            string where_clause = string.Empty;

            if (where != null && where.Where(w => w.Trim().Length > 0).Count() > 0)
            {
                where_clause += string.Join(" And ", where.Where(w => w.Trim().Length > 0));
            }

            /* adding Where clause */
            if (this.adding_where.Count > 0)
            {
                string aw = string.Join(" And ", this.adding_where.Where(w => w.Trim().Length > 0));
                where_clause += where_clause.Trim().Length > 0 ? " And " + aw : aw;
            }

            return where_clause.Trim().Length > 0 ? " Where " + where_clause : where_clause;
        }

        private string makeOrderByClause(List<OrderBy> order)
        {
            string order_by = string.Empty;

            if (order != null && order.Count > 0)
            {
                List<string> rewrite_order = new List<string>();
                order.ForEach(o =>
                {
                    rewrite_order.Add(o.fieldName + " " + (o.descending.ToLower() == "y" ? "Desc" : "Asc"));
                });

                order_by = string.Join(",", rewrite_order);
            }

            return order_by.Trim().Length > 0 ? " Order By " + order_by : order_by;
        }

        public void AddWhereClause(List<string> where)
        {
            this.adding_where = where;
        }

        public DataTable Query(string data_path, string query_string = null)
        {
            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            //using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=d:\express\expressi\test"))
            {
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query_string == null ? this.sql : query_string;

                DataTable dt = new DataTable();

                conn.Open();
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    da.Fill(dt);
                    conn.Close();

                    return dt;
                }
            }
        }

        public static DataTable RawQuery(string data_path, string query_string)
        {
            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query_string;

                DataTable dt = new DataTable();

                conn.Open();
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    da.Fill(dt);
                    conn.Close();

                    return dt;
                }
            }
        }
    }

    public class MasterFile
    {
        public string alias { get; set; }
        public string fileName { get; set; }
    }

    public class RelateFile
    {
        public string alias { get; set; }
        public string fileName { get; set; }
        public string fieldName { get; set; }
        public string masterFile { get; set; }
        public string masterRelatedField { get; set; }
        public string filter { get; set; }
        public List<RelateFile> relateFile { get; set; }
    }

    public class OrderBy
    {
        private string _desc = "N";
        public string fieldName { get; set; }
        public string descending { get { return this._desc; } set { this._desc = value; } }
    }

    public class ControlScope
    {
        public ControlType controlType { get; set; }
        public string bindingTo { get; set; }
        public string[] label { get; set; }
    }

    public class LicenseCheck
    {
        public string sn { get; set; }
    }

    public enum ControlType
    {
        DateAs,
        DateRange,
        CusAs,
        CusRange,
        SupAs,
        SupRange,
        StkAs,
        StkRange,
        AccAs,
        AccRange,
        DocAs,
        DocRange,
        TextAs,
        TextRange,
        DepAs,
        DepRange,
        SlmAs,
        SlmRange,
        LocAs,
        LocRange,
        StkgrpAs,
        StkgrpRange,
        AreaAs,
        AreaRange,
        SuptypAs,
        SuptypRange,
        CustypAs,
        CustypRange
    }
}
