using API.Dtos.Request;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;

        public AccountRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> SignInAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
               throw new  NullReferenceException("User Not Found");

            return user;
        }

        public async Task<User> SignUpAsync(AccountDto accountDto)
        {
            var user = new User
            {
                UserName = accountDto.Email,
                Email = accountDto.Email,
                Address = accountDto.Address,
                PhoneNumber = accountDto.PhoneNumber,
                FullName = accountDto.FullName
            };

            var result = await _userManager.CreateAsync(user, accountDto.Password);

            if (!result.Succeeded) throw new NullReferenceException("User Not Created");


            await _userManager.AddToRoleAsync(user, "Member");

            return user;
        }
    }
}
