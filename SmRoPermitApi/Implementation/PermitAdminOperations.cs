using Microsoft.Extensions.Configuration;
using SmRoPermitCommonLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartRoyaltyPermitApi
{
    public class PermitAdminOperations
    {
        public static IConfiguration config;
        private delegate void SqlOperation(SqlCommand cmd);

        private static void RunSqlOperation(SqlOperation oper, bool throwException = false)
        {
            try
            {
                //using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                using (SqlConnection conn = new SqlConnection(config.GetConnectionString("SmartRoyalty")))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandTimeout = 0;
                    oper(cmd);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void RunSqlOperationT(SqlOperation oper, bool throwException = false)
        {
            try
            {
                //ing (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                using (SqlConnection conn = new SqlConnection(config.GetConnectionString("SmartRoyalty")))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.Transaction = tran;
                                cmd.CommandTimeout = 0;
                                oper(cmd);
                                tran.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static string ConvertToString(object val)
        {
            return val == DBNull.Value ? "" : Convert.ToString(val);
        }
        private static int ConvertToInt32(object val)
        {
            return val == DBNull.Value ? 0 : Convert.ToInt32(val);
        }
        private static DateTime ConvertToDateTime(object val)
        {
            return val == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(val);
        }
        private static bool ConvertToBoolean(object val)
        {
            return val == DBNull.Value ? false : Convert.ToBoolean(val);
        }

        private static string GeneratePassword()
        {
            int length = 8;
            bool nonAlphanumeric = true;
            bool digit = true;
            bool lowercase = true;
            bool uppercase = true;

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            while (password.Length < length)
            {
                char c = (char)random.Next(32, 126);

                password.Append(c);

                if (char.IsDigit(c))
                    digit = false;
                else if (char.IsLower(c))
                    lowercase = false;
                else if (char.IsUpper(c))
                    uppercase = false;
                else if (!char.IsLetterOrDigit(c))
                    nonAlphanumeric = false;
            }

            if (nonAlphanumeric)
                password.Append((char)random.Next(33, 48));
            if (digit)
                password.Append((char)random.Next(48, 58));
            if (lowercase)
                password.Append((char)random.Next(97, 123));
            if (uppercase)
                password.Append((char)random.Next(65, 91));

            return password.ToString();
        }
        private static bool IsLoginUnique(User user)
        {
            bool retVal = true;
            RunSqlOperation(cmd => {
                cmd.CommandText = @"
                    select count(*)
                    from PermitUser
                    where login = @login
                        and codeI <> @codeI
                ";
                cmd.Parameters.AddWithValue("@login", user.Login);
                cmd.Parameters.AddWithValue("@codeI", user.CodeI);
                retVal = (int)cmd.ExecuteScalar() == 0;
            });
            return retVal;
        }

        private static List<User> userList = null;
        private static List<Role> roleList = null;
        private static List<UserRole> userRoleList = null;

        private static User CreateUserFromDataRow(DataRow row)
        {
            return new User
            {
                CodeI = ConvertToInt32(row["codeI"]),
                Login = ConvertToString(row["login"]),
                FirstName = ConvertToString(row["firstName"]),
                SurName = ConvertToString(row["surName"]),
                LastName = ConvertToString(row["lastName"]),
                Email = ConvertToString(row["email"]),
                PhoneNumber = ConvertToString(row["phoneNumber"]),
                PasswordHash = ConvertToString(row["passwordHash"]),
                CreateDate = ConvertToDateTime(row["createDate"]),
                ModifyDate = ConvertToDateTime(row["modifyDate"]),
                IsLock = ConvertToBoolean(row["isLock"]),
                Comment = ConvertToString(row["comment"])
            };
        }

        private static Role CreateRoleFromDataRow(DataRow row)
        {
            return new Role
            {
                CodeI = ConvertToInt32(row["codeI"]),
                Name = ConvertToString(row["name"]),
                IsRead = false,
                IsWrite = false
            };
        }

        private static UserRole CreateUserRoleFromDataRow(DataRow row)
        {
            return new UserRole
            {
                UserCode = ConvertToInt32(row["userCode"]),
                RoleCode = ConvertToInt32(row["roleCode"]),
                IsRead = ConvertToBoolean(row["isRead"]),
                IsWrite = ConvertToBoolean(row["isWrite"])
            };
        }

        private static void LoadData(string lang)
        {
            userList = new List<User>();
            roleList = new List<Role>();
            userRoleList = new List<UserRole>();

            RunSqlOperation(cmd => {
                cmd.CommandText = @"
                    select *
                    from PermitUser
                ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    userList.Add(CreateUserFromDataRow(row));
                }

                cmd.CommandText = @"
                    select t1.codeI
                        , coalesce(t2.name, t1.Name) Name
                    from PermitRole t1
                        left join PermitRoleTr t2 on t1.codeI = t2.codeI
                    where t2.lang = @lang
                ";
                cmd.Parameters.AddWithValue("@lang", lang);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    roleList.Add(CreateRoleFromDataRow(row));
                }

                cmd.CommandText = @"
                    select *
                    from PermitUserRole
                ";
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    userRoleList.Add(CreateUserRoleFromDataRow(row));
                }
            });
        }

        public static List<User> GetAllUsers(string lang)
        {
            if (userList != null)
                return userList;
            LoadData(lang);
            return userList;
        }

        public static List<Role> GetUserRoles(int userCodeI, string lang)
        {
            if (userList == null)
                LoadData(lang);
            roleList.ToList().ForEach(role =>
            {
                role.IsRead = false;
                role.IsWrite = false;
            });

            if (userRoleList.Exists(x => x.UserCode == userCodeI))
            {
                userRoleList.Where(x => x.UserCode == userCodeI).ToList().ForEach(userRole =>
                {
                    var role = roleList.Single(x => x.CodeI == userRole.RoleCode);
                    role.IsRead = userRole.IsRead;
                    role.IsWrite = userRole.IsWrite;
                });
            }

            return roleList;
        }

        public static RspAddUser.AddUserResult AddUser(User user, List<Role> roles)
        {
            if (!IsLoginUnique(user))
            {
                throw new LoginNotUniqueException();
            }

            roleList = roles;
            RspAddUser.AddUserResult retVal = new RspAddUser.AddUserResult();
            RunSqlOperation(cmd => {
                cmd.CommandText = @"
                    declare @codeI int;
                    insert PermitUser(
                          login
                        , firstName
                        , surName
                        , lastName
                        , email
                        , phoneNumber
                        , passwordHash
                        , isLock
                        , comment
                        , modifyDate
                        , isTempPassword
                    ) 
                    values(
                          @login
                        , @firstName
                        , @surName
                        , @lastName
                        , @email
                        , @phoneNumber
                        , hashbytes('SHA2_512', @passwordHash)
                        , @isLock
                        , @comment
                        , getdate()
                        , 1
                    );
                    set @codeI = scope_identity();

                    select *
                    from PermitUser
                    where codeI = @codeI
                ";

                string defaultPassword = GeneratePassword();
                cmd.Parameters.AddWithValue("@login", user.Login);
                cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                cmd.Parameters.AddWithValue("@surName", user.SurName);
                cmd.Parameters.AddWithValue("@lastName", user.LastName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@passwordHash", defaultPassword);
                cmd.Parameters.AddWithValue("@isLock", user.IsLock);
                cmd.Parameters.AddWithValue("@comment", user.Comment);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                User newUser = CreateUserFromDataRow(dt.Rows[0]);

                UpdateUserRolesInDb(newUser, cmd);

                userList.Add(newUser);
                UpdateUserAndRolesInMemory(newUser);

                retVal.CodeI = newUser.CodeI;
                retVal.Password = defaultPassword;
            });
            return retVal;
        }

        public static void DeleteUser(int codeI)
        {
            RunSqlOperationT(cmd => {
                cmd.CommandText = @"
                    delete
                    from PermitUserRole
                    where userCode = @codeI;

                    delete
                    from PermitUser
                    where codeI = @codeI;
                ";
                cmd.Parameters.AddWithValue("@codeI", codeI);
                cmd.ExecuteNonQuery();
                userList.Remove(userList.Single(x => x.CodeI == codeI));
            });
        }

        private static void UpdateUserRolesInDb(User user, SqlCommand cmd)
        {
            foreach (Role role in roleList)
            {
                if (role.IsRead || role.IsWrite)
                {
                    cmd.CommandText = @"
                            if exists (select null from PermitUserRole where userCode = @userCode and roleCode = @roleCode)
                            begin
                                update PermitUserRole
                                set isRead = @isRead
                                    , isWrite = @isWrite
                                where userCode = @userCode
                                    and roleCode = @roleCode
                            end
                            else
                            begin
                                insert PermitUserRole (userCode, roleCode, isRead, isWrite)
                                values (@userCode, @roleCode, @isRead, @isWrite)
                            end
                        ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@userCode", user.CodeI);
                    cmd.Parameters.AddWithValue("@roleCode", role.CodeI);
                    cmd.Parameters.AddWithValue("@isRead", role.IsRead);
                    cmd.Parameters.AddWithValue("@isWrite", role.IsWrite);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = @"
                            delete
                            from PermitUserRole
                            where userCode = @userCode
                                and roleCode = @roleCode
                         ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@userCode", user.CodeI);
                    cmd.Parameters.AddWithValue("@roleCode", role.CodeI);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void UpdateUserAndRolesInMemory(User user)
        {
            foreach (Role role in roleList)
            {
                if (role.IsRead || role.IsWrite)
                {
                    if (userRoleList.Exists(x => x.UserCode == user.CodeI && x.RoleCode == role.CodeI))
                    {
                        var userRole = userRoleList.Single(x => x.UserCode == user.CodeI && x.RoleCode == role.CodeI);
                        userRole.IsRead = role.IsRead;
                        userRole.IsWrite = role.IsWrite;
                    }
                    else
                    {
                        userRoleList.Add(new UserRole
                        {
                            UserCode = user.CodeI,
                            RoleCode = role.CodeI,
                            IsRead = role.IsRead,
                            IsWrite = role.IsWrite
                        });
                    }
                }
                else
                {
                    userRoleList.RemoveAll(x => x.UserCode == user.CodeI && x.RoleCode == role.CodeI);
                }
            }

            User userFromList = userList.Single(x => x.CodeI == user.CodeI);
            userFromList.Login = user.Login;
            userFromList.FirstName = user.FirstName;
            userFromList.SurName = user.SurName;
            userFromList.LastName = user.LastName;
            userFromList.Email = user.Email;
            userFromList.PhoneNumber = user.PhoneNumber;
            userFromList.PasswordHash = user.PasswordHash;
            userFromList.IsLock = user.IsLock;
            userFromList.Comment = user.Comment;
        }

        public static void SaveUser(User user, List<Role> roles)
        {
            if(!IsLoginUnique(user))
            {
                throw new LoginNotUniqueException();
            }

            roleList = roles;
            RunSqlOperationT(cmd => {
                cmd.CommandText = @"
                    update PermitUser
                    set login = @login
                        , firstName = @firstName
                        , surName = @surName
                        , lastName = @lastName
                        , email = @email
                        , phoneNumber = @phoneNumber
                        --, passwordHash = @passwordHash
                        , isLock = @isLock
                        , comment = @comment
                        , modifyDate = getdate()
                    where codeI = @codeI
                ";
                cmd.Parameters.AddWithValue("@login", user.Login);
                cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                cmd.Parameters.AddWithValue("@surName", user.SurName);
                cmd.Parameters.AddWithValue("@lastName", user.LastName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
                //cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@isLock", user.IsLock);
                cmd.Parameters.AddWithValue("@comment", user.Comment);
                cmd.Parameters.AddWithValue("@codeI", user.CodeI);
                cmd.ExecuteNonQuery();

                UpdateUserRolesInDb(user, cmd);
            });

            UpdateUserAndRolesInMemory(user);
        }

        public static string ResetPassword(int codeI)
        {
            string defaultPassword = null;
            RunSqlOperation(cmd => {
                cmd.CommandText = @"
                    update PermitUser
                    set passwordHash = hashbytes('SHA2_512', @passwordHash)
                        , isTempPassword = 1
                    where codeI = @codeI
                ";
                defaultPassword = GeneratePassword();
                cmd.Parameters.AddWithValue("@passwordHash", defaultPassword);
                cmd.Parameters.AddWithValue("@codeI", codeI);
                cmd.ExecuteNonQuery();
            });
            return defaultPassword;
        }

        public static RspLogin Login(string login, string password)
        {
            RspLogin retVal = new RspLogin
            {
                Result = RspLogin.LoginResult.Failed
            };
            RunSqlOperation(cmd => {
                cmd.CommandText = @"
                    select codeI, isTempPassword
                    from PermitUser
                    where login = @login
                        and passwordHash = hashbytes('SHA2_512', @password)
                        and isLock = 0
               ";
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.HasRows)
                    {
                        retVal.Result = RspLogin.LoginResult.Failed;
                    }
                    else
                    {
                        r.Read();
                        retVal.UserCodeI = r.GetInt32(0);
                        retVal.Result = r.GetBoolean(1) ? RspLogin.LoginResult.ChangePassword : RspLogin.LoginResult.Success;
                    }
                }
            });
            return retVal;
        }

        public static RspLogin ChangePasswordAndLogin(string login, string password)
        {
            RspLogin retVal = new RspLogin
            {
                Result = RspLogin.LoginResult.Success
            };
            RunSqlOperation(cmd => {
                cmd.CommandText = @"
                    update PermitUser
                    set passwordHash = hashbytes('SHA2_512', @password)
                        , isTempPassword = 0
                    from PermitUser
                    where login = @login

                    select codeI
                    from PermitUser
                    where login = @login 
                ";
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                retVal.UserCodeI = (int)cmd.ExecuteScalar();
            });
            return retVal;
        }

        public static List<UserPermission> GetUserPermissions(int codeI)
        {
            List<UserPermission> retVal = new List<UserPermission>();
            RunSqlOperation(cmd => {
                cmd.CommandText = @"
                    select t5.codeI
                        , t5.codeName
                        , t2.isRead
                        , t2.isWrite
                    from PermitUser t1
                        join PermitUserRole t2 on t2.userCode = t1.codeI
                        join PermitRole t3 on t3.codeI = t2.roleCode
                        join PermitRoleTask t4 on t4.roleCode = t3.codeI
                        join PermitTask t5 on t5.codeI = t4.taskCode
                    where t1.codeI = @codeI
                ";
                cmd.Parameters.AddWithValue("@codeI", codeI);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        retVal.Add(new UserPermission
                        {
                            FuncCode = r.GetString(1),
                            IsRead = r.GetBoolean(2),
                            IsWrite = r.GetBoolean(3),
                        });
                    }
                }
            });
            return retVal;
        }
    }
}
