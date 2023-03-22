using API.Dtos.Request;
using API.Entities;

namespace API.Interfaces
{
    public interface IAccountRepository
    {

        Task<User> SignUpAsync(AccountDto accountDto);

        Task<User> SignInAsync(LoginDto loginDto);
    }
}
