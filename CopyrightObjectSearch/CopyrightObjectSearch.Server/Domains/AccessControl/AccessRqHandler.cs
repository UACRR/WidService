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
    public class AccessRqHandler
    {
        private readonly Mapper _mapper;

        private readonly CopyrightObjectSearchDbContext _dbContext;

        public AccessRqHandler(CopyrightObjectSearchDbContext dbContext)
        {
            _dbContext = dbContext;

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<User, LoginRsp>();
            }));
        }

        private byte[] GetPasswordHash(string userPassword)
        {
            var crypt = SHA256.Create();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes($"{userPassword}"));
            return crypto;
        }

        public LoginRsp Login(LoginRq rq)
        {
           try
           {
                var user = _dbContext.Users
                    .Include(x => x.UserRoles)
                    .SingleOrDefault(x => x.Login == rq.Login && x.PasswordHash == GetPasswordHash(rq.Password));

                if(user == null)
                {
                    return new LoginRsp
                    {
                        ErrorText = "Невірний обліковій запис і/або пароль",
                        Id          = 0,
                        Name        = "",
                        Login       = "",
                        RoleIds     = [],
                    };
                };

                var retVal = new LoginRsp
                {
                    ErrorText = "",
                    Id          = user.Id,
                    Name        = user.Name,
                    Login       = user.Login,
                    RoleIds     = [],
                };

                var roleIds = new List<int>();
                user.UserRoles.ToList().ForEach(x =>
                {
                    roleIds.Add(x.RoleId);
                });

                retVal.RoleIds = roleIds.ToArray();

                return retVal;
            }
            catch(Exception ex)
            {
                return new LoginRsp
                {
                    ErrorText = ex.Message,
                    Id = 0,
                    Name = "",
                    Login = "",
                    RoleIds = [],
                };
            }
        }
    }
}
