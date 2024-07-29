using AhmedabadMediaAdminPanel_User.Entity.DataModels;
using AhmedabadMediaAdminPanel_User.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedabadMediaAdminPanel_User.Repository.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<UserDetails>> GetAllUsers();

        Task<bool> DeleteUser(int UserId);

        Task<UserDetails> GetEmployeeSelectByPK(int? UserId);

        Task<bool> AddUser(UserDetails userDetails);

        Task<bool> UpdateUser(UserDetails userDetails);

        Task<List<Role>> DropDownMenuOfRole();

        Task<List<RoleWiseMenuDetails>> DropDownMenuOfRoleWiseMenu(int roleID);
    }
}
