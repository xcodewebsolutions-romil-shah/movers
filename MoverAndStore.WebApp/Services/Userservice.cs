using MoverAndStore.WebApp.Models;

namespace MoverAndStore.WebApp.Services
{
    public interface IUserService
    {
        Task<User> Login(string username, string password);
    }
    public class Userservice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        //    public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
        //    {
        //        _unitOfWork = unitOfWork;
        //        _configuration = configuration;
        //    }
        //    public async Task<User> Login(string username, string password)
        //    {
        //        try
        //        {
        //            var user = _unitOfWork.UserRepository
        //            .Query().Include(i => i.Person)
        //            .FirstOrDefault(x => x.Username != null && x.Username.ToLower() == username.ToLower());

        //            if (user == null)
        //                throw new BadRequestException("Username or Password is invalid");

        //            var MD5password = Md5HashHelper.GetMd5Hash(password, _configuration["KeySalt"]);

        //            if (!user.PasswordHash.SequenceEqual(MD5password))
        //                throw new BadRequestException("Username or Password is invalid");

        //            user.LastLogin = DateTime.Now;
        //            _unitOfWork.UserRepository.Update(user);
        //            await _unitOfWork.SaveChangesAsync();

        //            return user;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
    }
}
