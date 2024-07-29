using AhmedabadMediaAdminPanel_User.Entity.DataModels;
using AhmedabadMediaAdminPanel_User.Entity.Models;
using AhmedabadMediaAdminPanel_User.Repository.Repository;
using AhmedabadMediaAdminPanel_User.Repository.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Net;

namespace AhmedabadMediaAdminPanel_User.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<IActionResult> UserDetailsList()
        {
            var userDetails = await _userRepository.GetAllUsers();
            return View("UserDetailsList", userDetails);
        }


        public async Task<IActionResult> Delete(int UserId)
        {
            await _userRepository.DeleteUser(UserId);
            TempData["Delete"] = "User Deleted Successfully";
            return RedirectToAction("UserDetailsList");
        }


        public async Task<IActionResult> Add(int? UserId)
        {
            ViewBag.RoleList = await _userRepository.DropDownMenuOfRole();

            if (UserId != null)
            {
                UserDetails userDetails = await _userRepository.GetEmployeeSelectByPK(UserId);

                if (userDetails != null)
                {
                    UserDetails user = new UserDetails();
                    user.UserId = userDetails.UserId;
                    user.FirstName = userDetails.FirstName;
                }

                ViewData["Title"] = "Edit User";
                return View("AddUserDetails", userDetails);
            }
            ViewData["Title"] = "Add User";
            return View("AddUserDetails");
        }


        public async Task<IActionResult> Save(UserDetails userDetails)
        {

            ViewBag.RoleList = await _userRepository.DropDownMenuOfRole();
            

            if (ModelState.IsValid)
            {
                var userData = new UserDetails()
                {
                    UserId = userDetails.UserId,
                    FirstName = userDetails.FirstName,
                    LastName = userDetails.LastName,
                    Email = userDetails.Email,
                    RoleId = userDetails.RoleId,
                    Status = userDetails.Status,
                    BirthDate = userDetails.BirthDate,
                    ContactNo = userDetails.ContactNo,
                    Address = userDetails.Address,
                    City = userDetails.City,
                    State = userDetails.State,
                    Description = userDetails.Description,
                    ModifiedBy = userDetails.ModifiedBy,
                };

                if (userDetails.UserId == null)
                {
                    await _userRepository.AddUser(userData);
                    TempData["Add"] = "User Added Successfully";
                    return RedirectToAction("UserDetailsList");
                }
                else
                {
                    await _userRepository.UpdateUser(userData);
                    TempData["Update"] = "User Updated Successfully";
                    return RedirectToAction("UserDetailsList");
                }
            }
            return View("AddUserDetails");
        }


        public async Task<IActionResult> AddUserDetails()
        {
            ViewBag.RoleList = await _userRepository.DropDownMenuOfRole();
            ViewData["Title"] = "Add User";
            return View();
        }

        public async Task<IActionResult> RoleWiseMenuDetails(int roleId)
        {
            var roleWiseMenu = await _userRepository.DropDownMenuOfRoleWiseMenu(roleId);

            var jsonResult = roleWiseMenu.Select(x => new
            {
                menuName = x.MenuName
            }).ToList();

            return Json(jsonResult);

        }
    }
}
