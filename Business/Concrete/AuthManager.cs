using Business.Abstract;
using Business.Constants.Messages;
using Core.Aspect.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Entitites.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Username = userForRegisterDto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true
            };

            _userService.Add(user);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        [LogAspect(typeof(SeqLogger))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByUsername(userForLoginDto.Username);

            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfullLogin);


        }

        public IResult UserExists(string username)
        {
            if (_userService.GetByUsername(username).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);

            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
