using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Transactions;
using WebApplication1.Data;
using WebApplication1.DTO;
using WebApplication1.IServices;
using WebApplication1.models;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _db;
        public DbSet<User> dbSet;
        public readonly IMapper _mapper;

        public UserService(UserDbContext db, IMapper mapper) // contstructooooor
        {
            _db = db;
            dbSet = db.Set<User>();
            _mapper = mapper;
        }

        public async Task<UserDTO> GetCurrentLoggedInUser(ClaimsPrincipal user)
        {
            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new BadHttpRequestException("User is not logged in!");
            }

            var userId = int.Parse(userIdClaim.Value);
            var dbUser = await _db.Users.FindAsync(userId);
            if (dbUser == null)
            {
                throw new BadHttpRequestException("User is not logged in!");
            }

            var userDto = _mapper.Map<UserDTO>(dbUser);
            return userDto;
        }

        public async Task<List<IUser>> GetUsersByCityId(int cityId)
        {
            var UserInCity = await dbSet.Where(x => x.CityId == cityId).ToListAsync();
            var result = _mapper.Map<List<IUser>>(UserInCity);
            return result;
        }
        public async Task<List<IPermission>> GetPermisionByUsersId(List<int> userIds)
        {
            var users = await dbSet.Where(x => userIds.Contains(x.Id)).ToListAsync();
            var permissions = users.SelectMany(x => x.UserRoles.SelectMany(x => x.Role.RolePermissions.Select(rp => rp.Permission))).Distinct().ToList();
            var result = _mapper.Map<List<IPermission>>(permissions);
            return result;

        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await dbSet.SingleOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new BadHttpRequestException("User does not exist");
            }
            dbSet.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<IUser>> GetAllUsers()
        {
            var user = await dbSet
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .ToListAsync();
            return user.ToList<IUser>();

        }

        public async Task<IUser> GetUserById(int userId)
        {
            var user = await dbSet
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                        .ThenInclude(r => r.RolePermissions)
                            .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new BadHttpRequestException("User does not exist");
            }

            return user;
        }



        public async Task<bool> UpdateUser(int userId, IUserInsert userInsertDto)
        {
            var userToUpdate = await dbSet.SingleOrDefaultAsync(x => x.Id == userId);
            if (userToUpdate == null)
            {
                throw new BadHttpRequestException("User does not exist");
            }

            _mapper.Map(userInsertDto, userToUpdate);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IUser> CreateUser(IUserInsert userInsertData)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    User userForInsert = _mapper.Map<User>(userInsertData);

                    await dbSet.AddAsync(userForInsert);
                    await _db.SaveChangesAsync();

                    if (userInsertData.RoleIds != null)
                    {
                        var userRoles = userInsertData.RoleIds.Select(roleId => new UserRole
                        {
                            UserId = userForInsert.Id,
                            RoleId = roleId
                        }).ToList();

                        await _db.UserRole.AddRangeAsync(userRoles);
                        await _db.SaveChangesAsync();
                    }
                    scope.Complete();
                    return userForInsert;
                }
                catch (Exception ex)
                {
                    throw new BadHttpRequestException("Something went wrong");
                }

            }

        }


    }
}
