using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public static class Meta
    {
        public static dynamic DdexReportStatus;
        public static dynamic DdexReportSubStatus;
        public static dynamic CcidInFileStatus;
        public static dynamic CcidClFileStatus;
        public static dynamic IdentMWStatus;
        public static dynamic CrfDetailStatus;
        public static dynamic DdexAdjustmentType;

        public static void Load()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDdex"]))
            {
                conn.Open();
                DdexReportStatus = StatusInfo.GetStatusInfo(conn, "DdexReportStatus");
                DdexReportSubStatus = StatusInfo.GetStatusInfo(conn, "DdexReportSubStatus");
                CcidInFileStatus = StatusInfo.GetStatusInfo(conn, "CcidInFileStatus");
                CcidClFileStatus = StatusInfo.GetStatusInfo(conn, "CcidClFileStatus");
                IdentMWStatus = StatusInfo.GetStatusInfo(conn, "IdentMWStatus");
                CrfDetailStatus = StatusInfo.GetStatusInfo(conn, "CrfDetailStatus");
                DdexAdjustmentType = StatusInfo.GetStatusInfo(conn, "DdexAdjustmentType");
            }
        }
    }

    public sealed class StatusInfo : DynamicObject
    {
        private readonly Dictionary<string, object> _properties;
        private readonly Dictionary<int, string> _names;
        private readonly Dictionary<int, string> _actions;
        private readonly Dictionary<string, int> _values;

        public static dynamic GetStatusInfo(SqlConnection conn, string tableName)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = $"select * from {tableName}";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return new StatusInfo(dt);
            }
            
        }

        public StatusInfo(DataTable dt)
        {
            _properties = new Dictionary<string, object>();
            _names = new Dictionary<int, string>();
            _values = new Dictionary<string, int>();
            if (dt.Columns.Count > 4)
                _actions = new Dictionary<int, string>();
            foreach (DataRow row in dt.Rows)
            {
                _properties.Add((string)row[1], row[0]);
                _names.Add((int)row[0], (string)row[2]);
                _values.Add((string)row[1], (int)row[0]);
                _properties.Add($"{(string)row[1]}_Name", row[2]);
                if(row.ItemArray.Length > 3)
                    _properties.Add($"{(string)row[1]}_NameGroup", row[3]);
                if (dt.Columns.Count > 4)
                    _actions.Add((int)row[0], Convert.ToString(row[4]));
            }
        }

        public string Name(int i)
        {
            return _names[i];
        }

        public int Value(string name)
        {
            if (!_values.ContainsKey(name))
                throw new KeyNotFoundException($"System.Collections.Generic.KeyNotFoundException:: The given key was not present in the dictionary. Key: {name}.");
            return _values[name];
        }

        public string Action(int status)
        {
            if (_actions == null)
                return null;
            if (!_actions.ContainsKey(status))
                return null;
            return _actions[status];
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _properties.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                result = _properties[binder.Name];
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                _properties[binder.Name] = value;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

