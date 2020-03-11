using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmRoPermitServerLib
{
    static public class AllPermissions
    {
        //private static Dictionary<int, Dictionary<string, UserPermission>> Permissions { get; set; }
        private static string connectString;

        public static void Init(string connectString)
        {
            AllPermissions.connectString = connectString;
            /*Permissions = new Dictionary<int, Dictionary<string, UserPermission>>();
            using (SqlConnection conn = new SqlConnection(connectString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = @"
                    select t1.codeI
                        , t5.codeName
                        , t2.isRead
                        , t2.isWrite
                    from PermitUser t1
                        join PermitUserRole t2 on t2.userCode = t1.codeI
                        join PermitRole t3 on t3.codeI = t2.roleCode
                        join PermitRoleTask t4 on t4.roleCode = t3.codeI
                        join PermitTask t5 on t5.codeI = t4.taskCode
                    order by t5.codeI
                ";
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    int curCodeI = 0;
                    Dictionary<string, UserPermission> userPermissions = null;
                    while (r.Read())
                    {
                        int codeI = r.GetInt32(0);
                        if (codeI != curCodeI)
                        {
                            userPermissions = new Dictionary<string, UserPermission>();
                            Permissions.Add(codeI, userPermissions);
                            curCodeI = codeI;
                        }
                        userPermissions.Add(r.GetString(1), new UserPermission
                        {
                            FuncCode = r.GetString(1),
                            IsRead = r.GetBoolean(2),
                            IsWrite = r.GetBoolean(3),
                        });
                    }
                }
            }*/
        }

        /*
        public static bool CanRead(int userCodeI, string funcName)
        {
            if (!Permissions.ContainsKey(userCodeI))
            {
                return false;
            }
            else
            {
                if(!Permissions[userCodeI].ContainsKey(funcName))
                {
                    return false;
                }
                return Permissions[userCodeI][funcName].IsRead;
            }
        }

        public static bool CanWrite(int userCodeI, string funcName)
        {
            if (!Permissions.ContainsKey(userCodeI))
            {
                return false;
            }
            else
            {
                if (!Permissions[userCodeI].ContainsKey(funcName))
                {
                    return false;
                }
                return Permissions[userCodeI][funcName].IsWrite;
            }
        }
        */

        public static bool HasPermit(string login, string password, string funcCodeName, string permit)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                string filterByPwd = !string.IsNullOrEmpty(password) ? "and t1.passwordHash = hashbytes('SHA2_512', @password)" : "";
                cmd.CommandText = $@"
                    select count(*)
                    from PermitUser t1
                        join PermitUserRole t2 on t2.userCode = t1.codeI
                        join PermitRole t3 on t3.codeI = t2.roleCode
                        join PermitRoleTask t4 on t4.roleCode = t3.codeI
                        join PermitTask t5 on t5.codeI = t4.taskCode
                    where t1.login = @login
                        {filterByPwd}
                        and t5.codeName = @funcCodeName
                        and t2.Is{permit} = 1
                    option (recompile)
                ";
                cmd.Parameters.AddWithValue("@login", login);
                if (!string.IsNullOrEmpty(password))
                    cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@funcCodeName", funcCodeName);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}
