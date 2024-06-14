using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using WebApplication1.Data;
using WebApplication1.IServices;
using WebApplication1.models;
using WebApplication1.shared.Interfaces;


namespace WebApplication1.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserDbContext _db;
        private readonly IConfiguration _configuration;
        public DbSet<User> dbSet;
        private readonly IPasswordHasher _passwordHasher;

        public LoginService(UserDbContext db, IConfiguration configuration, IPasswordHasher passwordHasher)
        {
            _db = db;
            _configuration = configuration;
            dbSet = db.Set<User>();
            _passwordHasher = passwordHasher;
        }


        public async Task<string> Login(ILoginUser loginUser)
        {
          

            var user = await dbSet.SingleOrDefaultAsync(x => x.UserName == loginUser.UserName);


            if (user == null)
            {
                throw new BadHttpRequestException("User does not exist");
            }
            var loginUserPasswordHashed = _passwordHasher.Hash(loginUser.Password, user.Salt);

            if (loginUserPasswordHashed != user.PasswordHash)
            {
                throw new BadHttpRequestException("User does not exist");
            }


            string token = await GenerateJwtToken(user);
            return token;

        }

        private async Task<string>GenerateJwtToken(User user)
        {
            var claims = new List<Claim> // Claims se salju u payload jwt tokena
        {
           
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //Global Unique identifier
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            
        };

            var roleIds = await _db.UserRole.Where(x => x.UserId == user.Id).Select(y => y.RoleId).ToListAsync();
            var permissionIds = await _db.RolePermission.Where(x => roleIds.Contains(x.RoleId)).Select(y=> y.PermissionId).Distinct().ToListAsync(); 

            //claims.AddRange(permissions.Select(p => new Claim("permissions", p.PermissionId + "")));
            var permissionClaim = new Claim("permissions", JsonSerializer.Serialize(permissionIds));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                //expires: DateTime.Now.AddMinutes( _configuration["Jwt:ExpiresInMinutes"])
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
