using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly JwtTokenHelper _tokenHelper;

        public AuthManager(IUserDal userDal, JwtTokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }

        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<string> Register(UserForRegisterDto dto)
        {
            IResult result = BusinessRules.Run(
                CheckIfEmailExists(dto.Email),
                CheckIfUsernameExists(dto.Username)
            );
            if (result != null)
                return new ErrorDataResult<string>(result.Message);

            HashingHelper.CreatePasswordHash(dto.Password, out var hash, out var salt);

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "User"
            };

            _userDal.Add(user);

            var token = _tokenHelper.CreateToken(user.Username, user.Role, user.Id);
            return new SuccessDataResult<string>(token, Messages.RegisterSuccessful);
        }

        [ValidationAspect(typeof(LoginValidator))]
        public IDataResult<string> Login(UserForLoginDto dto)
        {
            var user = _userDal.Get(u => u.Username == dto.Username);
            if (user == null)
                return new ErrorDataResult<string>(Messages.UserNotFound);

            var isValid = HashingHelper.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt);
            if (!isValid)
                return new ErrorDataResult<string>(Messages.PasswordError);

            var token = _tokenHelper.CreateToken(user.Username, user.Role, user.Id);
            return new SuccessDataResult<string>(token, Messages.LoginSuccessful);
        }

        private IResult CheckIfEmailExists(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if (user != null)
                return new ErrorResult(Messages.UserAlreadyExists);
            return new SuccessResult();
        }

        private IResult CheckIfUsernameExists(string username)
        {
            var user = _userDal.Get(u => u.Username == username);
            if (user != null)
                return new ErrorResult(Messages.UsernameAlreadyExists);
            return new SuccessResult();
        }


    }
}
