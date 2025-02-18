using Hakawy.APIs.Dtos;
using Hakawy.APIs.Errors;
using Hakawy.Core.Identity;
using Hakawy.Repository.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hakawy.APIs.Controllers
{
	
	public class AccountsController : BaseApiController
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenService _tokenService;

		public AccountsController(UserManager<AppUser> userManager ,SignInManager<AppUser> signInManager,ITokenService tokenService)
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenService = tokenService;
		}

        // Register
        [HttpPost("Register")] // POST // api/accounts/Register
		public async Task<ActionResult<UserDto>> Register(RegisterDto model)
		{

			var user = new AppUser()
			{
				FName = model.FName,
				LName = model.LName,
				Email = model.Email,
				UserName = model.Email.Split("@")[0],
				PhoneNumber = model.PhoneNumber
			};

			var Result = await _userManager.CreateAsync(user, model.Password);
			if (!Result.Succeeded) return BadRequest(new ApiResponse(400));

			var ReturnedUser = new UserDto()
			{
				FName = user.FName,
				LName = user.LName,
				Email = user.Email,
				Token = await _tokenService.CreateTokenAsync(user, _userManager)
			};
			return Ok(ReturnedUser);

		}

		// Login
		[HttpPost("Login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user is null) return Unauthorized(new ApiResponse(401));

			var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

			if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

			return Ok(new UserDto()
			{
				FName = user.FName,
				LName = user.LName,
				Email = user.Email,
				Token = await _tokenService.CreateTokenAsync(user, _userManager)
			});
		

		}
	}
}
