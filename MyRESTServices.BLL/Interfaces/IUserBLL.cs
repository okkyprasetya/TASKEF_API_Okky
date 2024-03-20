using MyRESTServices.BLL.DTOs;
using MyWebFormApp.BLL.DTOs;
using System.Collections.Generic;
using LoginDTO = MyRESTServices.BLL.DTOs.LoginDTO;
using UserCreateDTO = MyRESTServices.BLL.DTOs.UserCreateDTO;
using UserDTO = MyRESTServices.BLL.DTOs.UserDTO;

namespace MyRESTServices.BLL.Interfaces
{
    public interface IUserBLL
    {
        Task<Task> ChangePassword(string username, string newPassword);
        Task<bool> Delete(string username);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetByUsername(string username);
        Task<Task> Insert(UserCreateDTO entity);
        Task<UserDTO> Login(string username, string password);
        Task<UserDTO> LoginMVC(LoginDTO loginDTO);

        Task<UserDTO> GetUserWithRoles(string username);
        Task<IEnumerable<UserDTO>> GetAllWithRoles();
    }
}
