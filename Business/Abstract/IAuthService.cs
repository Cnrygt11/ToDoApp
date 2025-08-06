using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<string> Register(UserForRegisterDto dto);
        IDataResult<string> Login(UserForLoginDto dto);
    }
}
