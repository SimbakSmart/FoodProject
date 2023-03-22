

using API.Dtos.Request;
using API.Dtos.Response;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BasicApiController
    {
        private readonly IAccountRepository _repo;
        private readonly TokenService _tokenService;

        public AccountController(IAccountRepository repo, TokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult> SingUpAsync(AccountDto accountDto)
        {

            var result = await _repo.SignUpAsync(accountDto);
            if (result == null) return BadRequest();


            return StatusCode(201);

        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<UserResponseDto>> SingInAsync(LoginDto loginDto)
        {

            var result = await _repo.SignInAsync(loginDto);
            if (result == null) return BadRequest();


            return new UserResponseDto
            {
                Id = result.Id,
                FullName = result.FullName,
                Email = result.Email!,
                Token = await _tokenService.GenerateToken(result)
            };

        }
    }
}
