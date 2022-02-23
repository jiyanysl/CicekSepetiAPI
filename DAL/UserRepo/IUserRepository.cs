using CicekSepetiAPI.Models;
using System.Threading.Tasks;

namespace CicekSepetiAPI.DAL.UserRepo
{
    public interface IUserRepository : IRepository<User, string>
    {
        Task<User> Authenticate(string username, string password);
    }
}
