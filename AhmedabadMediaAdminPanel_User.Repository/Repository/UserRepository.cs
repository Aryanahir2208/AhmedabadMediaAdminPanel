using AhmedabadMediaAdminPanel_User.Entity.DataContext;
using AhmedabadMediaAdminPanel_User.Entity.DataModels;
using AhmedabadMediaAdminPanel_User.Entity.Models;
using AhmedabadMediaAdminPanel_User.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AhmedabadMediaAdminPanel_User.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDetails>> GetAllUsers()
        {
            try
            {
                var users = await (from x in _context.Users
                                   join y in _context.Roles
                                   on x.RoleId equals y.Roleid
                                   select new UserDetails
                                   {
                                       UserId = x.UserId,
                                       AspNetUserId = x.AspNetUserId,
                                       FirstName = x.FirstName,
                                       LastName = x.LastName,
                                       Email = x.Email,
                                       RoleId = x.RoleId,
                                       Rolename = y.Name,
                                       Status = x.Status,
                                       BirthDate = x.BirthDate,
                                       ContactNo = x.ContactNo,
                                       Address = x.Address,
                                       City = x.City,
                                       State = x.State,
                                       Description = x.Description,
                                       CreatedBy = x.CreatedBy,
                                       CreatedDate = x.CreatedDate,
                                       ModifiedBy = x.ModifiedBy,
                                       ModifiedDate = x.ModifiedDate
                                   }).ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<UserDetails> GetEmployeeSelectByPK(int? UserId)
        {
            try
            {
                var user = await (from x in _context.Users
                                  join y in _context.Roles
                                  on x.RoleId equals y.Roleid
                                  where x.UserId == UserId
                                  select new UserDetails
                                  {
                                      UserId = x.UserId,
                                      AspNetUserId = x.AspNetUserId,
                                      FirstName = x.FirstName,
                                      LastName = x.LastName,
                                      Email = x.Email,
                                      RoleId = x.RoleId,
                                      Rolename = y.Name,
                                      Status = x.Status,
                                      BirthDate = x.BirthDate,
                                      ContactNo = x.ContactNo,
                                      Address = x.Address,
                                      City = x.City,
                                      State = x.State,
                                      Description = x.Description,
                                      CreatedBy = x.CreatedBy,
                                      CreatedDate = x.CreatedDate,
                                      ModifiedBy = x.ModifiedBy,
                                      ModifiedDate = x.ModifiedDate
                                  }).FirstOrDefaultAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUser(int UserId)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = await _context.Users.FindAsync(UserId);

                    if (user != null)
                    {
                        _context.Users.Remove(user);
                        _context.SaveChanges();
                        await transaction.CommitAsync();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        public async Task<bool> AddUser(UserDetails userDetails)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    User user = new User();

                    user.AspNetUserId = 1;
                    user.FirstName = userDetails.FirstName;
                    user.LastName = userDetails.LastName;
                    user.Email = userDetails.Email;
                    user.RoleId = userDetails.RoleId;
                    user.Status = 1;
                    user.BirthDate = userDetails.BirthDate;
                    user.ContactNo = userDetails.ContactNo;
                    user.Address = userDetails.Address;
                    user.City = userDetails.City;
                    user.State = userDetails.State;
                    user.Description = userDetails.Description;
                    user.CreatedBy = 2;
                    user.CreatedDate = DateTime.Now;

                    _context.Users.Add(user);

                    _context.SaveChanges();

                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }

        }

        public async Task<bool> UpdateUser(UserDetails userDetails)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    User? user = _context.Users.FirstOrDefault(x => x.UserId == userDetails.UserId);

                    user.FirstName = userDetails.FirstName;
                    user.LastName = userDetails.LastName;
                    user.Email = userDetails.Email;
                    user.RoleId = userDetails.RoleId;
                    user.Status = 1;
                    user.BirthDate = userDetails.BirthDate;
                    user.ContactNo = userDetails.ContactNo;
                    user.Address = userDetails.Address;
                    user.City = userDetails.City;
                    user.State = userDetails.State;
                    user.ModifiedBy = 2;
                    user.ModifiedDate = DateTime.Now;


                    _context.Users.Update(user);

                    _context.SaveChanges();

                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        public async Task<List<Role>> DropDownMenuOfRole()
        {
            try
            {
                var roles = await (from x in _context.Roles
                                   where x.Isdeleted == false
                                   select new Role
                                   {
                                       Roleid = x.Roleid,
                                       Name = x.Name
                                   }).ToListAsync();

                return roles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RoleWiseMenuDetails>> DropDownMenuOfRoleWiseMenu(int roleId)
        {
            try
            {
                var roleWiseMenu = await (from role in _context.Roles
                                          join rolemenu in _context.Rolemenus on role.Roleid equals rolemenu.Roleid
                                          join menu in _context.Menus on rolemenu.Menuid equals menu.Menuid
                                          where role.Roleid == roleId
                                          select new RoleWiseMenuDetails
                                          {

                                              MenuName = menu.Name

                                          }).ToListAsync();

                return roleWiseMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
