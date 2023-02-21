using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Application.Services.Single.User.Command;
using Dayanet.Ecommerce.Application.Services.Single.User.Query;

namespace Dayanet.Ecommerce.Application.FASADE.Users;

public class UserFasade : IUserFasade {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public UserFasade(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }
    private ILoginService _loginService;
    public ILoginService LoginService {
        get {
            return _loginService = _loginService ?? new LoginService(_db, _mapper);
        }
    }
    private IRegisterService _registerService;
    public IRegisterService RegisterService {
        get {
            return _registerService = _registerService ?? new RegisterService(_db, _mapper);
        }
    }
    private IFetchUsersService _fetchUsersService;
    public IFetchUsersService FetchUsersService {
        get {
            return _fetchUsersService = _fetchUsersService ?? new FetchUsersService(_db, _mapper);
        }
    }
    private IFetchUserByIdService _fetchUserByIdService;
    public IFetchUserByIdService FetchUsersByIdService {
        get {
            return _fetchUserByIdService = _fetchUserByIdService ?? new FetchUserByIdService(_db, _mapper);
        }
    }

    private IDeleteUserService _deleteUserService;
    public IDeleteUserService DeleteUserService {
        get {
            return _deleteUserService = _deleteUserService ?? new DeleteUserService(_db);
        }
    }
    private IUserAddressService _userAddressService;
    public IUserAddressService UserAddressService {
        get {
            return _userAddressService = _userAddressService ?? new UserAddressService(_db, _mapper);
        }
    }
    private IUpdateUserService _updateUserService;
    public IUpdateUserService UpdateUserService {
        get {
            return _updateUserService = _updateUserService ?? new UpdateUserService(_db);
        }
    }
}