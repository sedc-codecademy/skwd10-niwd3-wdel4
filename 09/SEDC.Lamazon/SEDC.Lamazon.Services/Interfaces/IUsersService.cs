using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IUsersService
    {
        List<UserViewModel> GetAllUsers();
        PagedResultViewModel<UserViewModel> GetFilteredUsers(UsersDatatableRequestViewModel usersDatatableRequestViewModel);
        UserViewModel GetUserById(int id);
        UserViewModel RegisterUser(UserViewModel userViewModel);
        void UpdateUser(UserViewModel userViewModel);
        void DeleteUserById(int id);
        UserViewModel ValidateUser(UserCredentialsViewModel userCredentialsViewModel);
        bool HasOtherAdmins(UserViewModel userViewModel);
    }
}
