using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
                cfg.CreateMap<ExternalObject, ExternalObjectDto>();
            }));
        }

        public GetUsersRsp GetUsers()
        {
            var users = _dbContext.Users.Include(x => x.UserRoles).OrderBy(x => x.Login).ToList();
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
            var maxUserId = _dbContext.Users.Max(x => (int?)x.Id);
            var newUserIdx = maxUserId == null ? 1 : maxUserId + 1;
            var newUserName = $"Новий користувач {newUserIdx}";
            var newUserLogin = $"NewUser{newUserIdx}";

            var crypt = SHA256.Create();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes($"&{newUserLogin}$"));
            var newUser = new User {
                Name         = newUserName,
                Login        = newUserLogin,
                PasswordHash = crypto,
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
    }
}
