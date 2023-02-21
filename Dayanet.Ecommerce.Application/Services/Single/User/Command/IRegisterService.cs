using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Command;
public interface IRegisterService {
    Task<ResultDto<AuthResultDto>> RegisterAsync(CreateUserDto createUserDto);
}