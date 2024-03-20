using MyRESTServices.BLL.DTOs;
using MyWebFormApp.BLL.DTOs;
using System.Collections.Generic;
using RoleDTO = MyRESTServices.BLL.DTOs.RoleDTO;

namespace MyRESTServices.BLL.Interfaces
{
    public interface IRoleBLL
    {
        Task<IEnumerable<RoleDTO>> GetAllRoles();
        Task<Task> AddRole(string roleName);
        Task<Task> AddUserToRole(string username, int roleId);
    }
}
