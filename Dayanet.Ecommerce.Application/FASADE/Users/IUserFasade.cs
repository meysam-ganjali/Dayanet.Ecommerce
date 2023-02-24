using Dayanet.Ecommerce.Application.Services.Single.User.Command;
using Dayanet.Ecommerce.Application.Services.Single.User.Query;

namespace Dayanet.Ecommerce.Application.FASADE.Users;

public interface IUserFasade
{
    ILoginService LoginService { get; }
    IRegisterService RegisterService { get; }
    IFetchUsersService FetchUsersService { get; }
    IFetchUserByIdService FetchUsersByIdService { get; }
    IDeleteUserService DeleteUserService { get; }
    IUserAddressService UserAddressService { get; }
    IUpdateUserService UpdateUserService { get; }
    ICreateUserAdminService CreateUserAdminService { get; }
}