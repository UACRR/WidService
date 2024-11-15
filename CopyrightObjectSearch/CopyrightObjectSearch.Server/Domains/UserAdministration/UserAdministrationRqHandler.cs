using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace CopyrightObjectSearch.Server
{
    public class UserAdministrationRqHandler
    {
        private readonly Mapper _mapper;

        private readonly CopyrightObjectSearchDbContext _dbContext;

        public UserAdministrationRqHandler(CopyrightObjectSearchDbContext dbContext)
        {
            _dbContext = dbContext;

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<PartnerWork, PartnerWorkDto>();
            }));
        }

        private byte[] CreatePasswordHash(string userLogin)
        {
            var crypt = SHA256.Create();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes($"&{userLogin}$"));
            return crypto;
        }

        public void CreateSuperAdmin()
        {
            var superAdmin = _dbContext.Users
                .SingleOrDefault(x => x.Login.ToUpper() == "SUPERADMIN");
            if (superAdmin != null)
            {
                return;
            }

            var uid = Guid.NewGuid().ToString();
            var newUserName = "SUPERADMIN";
            var newUserLogin = "SUPERADMIN";

            var newUser = new User
            {
                Name = newUserName,
                Login = newUserLogin,
                PasswordHash = CreatePasswordHash(newUserLogin),
                IsPwdDefault = false,
                IsBlocked = false,
                IsSuperUser = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

                UserRoles = [
                    new UserRole
                    {
                        RoleId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new UserRole
                    {
                        RoleId = 2,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new UserRole
                    {
                        RoleId = 3,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    }
                ],
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public GetUsersRsp GetUsers()
        {
            var users = _dbContext.Users
                .Where(x => x.Login.ToUpper() != "SUPERADMIN")
                .Include(x => x.UserRoles).OrderBy(x => x.Login).ToList();
            var retVal = new GetUsersRsp { 
                Users = [],
            };

            var usersDto = new List<GetUsersRsp.UserDto>();
            users.ForEach(x =>
            {
                usersDto.Add(
                    new GetUsersRsp.UserDto
                    {
                        Id      = x.Id           ,
                        Name    = x.Name         ,
                        Login   = x.Login        ,
                        RoleIds = x.UserRoles
                            .Select(x => x.RoleId)
                            .ToArray()           ,
                    }
                );
            });
            retVal.Users = usersDto.ToArray();
            return retVal;
        }

        public AddUserRsp AddUser()
        {
            var uid = Guid.NewGuid().ToString();
            var newUserName = $"Новий користувач {uid}";
            var newUserLogin = $"NewUser-{uid}";

            var newUser = new User {
                Name         = newUserName,
                Login        = newUserLogin,
                PasswordHash = CreatePasswordHash(newUserLogin),
                IsPwdDefault = true,
                IsBlocked    = false,
                IsSuperUser  = false,
                CreatedAt    = DateTime.Now,
                UpdatedAt    = DateTime.Now,

                UserRoles = [
                    new UserRole 
                    { 
                        RoleId = 3,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    }
                ],
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            var retVal = new AddUserRsp {
                ErrorCode = "",
                Id        = newUser.Id,
                Name      = newUserName,
                Login     = newUserLogin,
                RoleIds   = [3],
            };

            return retVal;
        }

        public UpdateUserRsp UpdateUser(UpdateUserRq rq)
        {
            try
            {
                if (rq.Login.Length > 256)
                {
                    return new UpdateUserRsp { ErrorText = "Невірний обліковий запис - мусить містити менше 256 символів" };
                }

                if (rq.Name.Length > 256)
                {
                    return new UpdateUserRsp { ErrorText = "Невірне ім'я користувача  - мусить містити менше 256 символів" };
                }

                if (string.IsNullOrEmpty(rq.Login))
                {
                    return new UpdateUserRsp { ErrorText = "Невірний обліковий запис - мусить містити букви, цифри, дефіс обо підкреслення" };
                }

                var isValidLogin = rq.Login.All(c => Char.IsLetterOrDigit(c) || c.Equals('_') || c.Equals('-'));
                if (!isValidLogin)
                {
                    return new UpdateUserRsp { ErrorText = "Невірний обліковий запис - мусить містити букви, цифри, дефіс обо підкреслення" };
                }
                var existingUser = _dbContext.Users
                    .SingleOrDefault(x => x.Id != rq.Id && x.Login.ToLower() == rq.Login.ToLower());

                if (existingUser != null) {
                    return new UpdateUserRsp { ErrorText = "Невірний обліковий запис - користувач з таким обліковим записом вже існує" };
                }

                var user = _dbContext.Users
                    .Include(x => x.UserRoles)
                    .Single(x => x.Id == rq.Id);
                user.Name = rq.Name;
                user.Login = rq.Login;
                user.PasswordHash = CreatePasswordHash(rq.Login);
                user.UpdatedAt = DateTime.Now;
                user.UserRoles.Clear();

                rq.RoleIds.ToList().ForEach(x =>
                {
                    user.UserRoles.Add(new UserRole
                    {
                        RoleId = x,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    });
                });

                _dbContext.SaveChanges();
                return new UpdateUserRsp { ErrorText = "" };
            }
            catch (Exception ex)
            {
                return new UpdateUserRsp { ErrorText = ex.Message };
            }
        }

        public DeleteUserRsp DeleteUser(DeleteUserRq rq)
        {
            try
            {
                var user = _dbContext.Users.Single(x => x.Id == rq.UserId);
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
                return new DeleteUserRsp { ErrorText = "" };
            }
            catch (Exception ex)
            {
                return new DeleteUserRsp { ErrorText = ex.Message };
            }

        }
    }
}
