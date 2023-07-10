using FreelaCash.Repository.Dto;
using FreelaCash.Repository.Services.Interface;
using FreelaCashAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelaCashAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AccountController(IAccountService accountService, ITokenService tokenService, IWebHostEnvironment hostEnvironment)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet("GetUser")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                //recuperando o nome do usuario pelo token
                string userName = User.GetUserName();

                var user = await _accountService.GetUserByUsernameAsync(userName);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Usuario. Erro: {ex.Message}");
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                if (await _accountService.UserExists(userDto.UserName))
                {
                    return BadRequest("Usuario ja existe");
                }

                var user = await _accountService.CreateAccountAsync(userDto);
                if (user != null)
                {
                    return Ok("Usuario Criado com Sucesso!");
                }

                return BadRequest("Usuario nao criado, tente novamente mais tarde!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar registrar Usuario. Erro: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            try
            {
                var user = await _accountService.GetUserByUsernameAsync(userLogin.UserName);

                if (user == null)
                    return Unauthorized("Usuario ou senha esta errado");

                var result = await _accountService.CheckUserPasswordAsync(user, userLogin.Password);

                if (!result.Succeeded)
                    return Unauthorized("Usuario ou senha esta errado");

                return Ok(new
                {
                    userName = user.UserName,
                    primeiroNome = user.PrimeiroNome,
                    token = _tokenService.CreateToken(user).Result,
                    imagemUrl = $"https://localhost:7230/Resources/images/{user.ImagemUrl}"
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar realizar login Usuario. Erro: {ex.Message}");
            }
        }

        [HttpPost("upload-image")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadImagem()
        {
            try
            {
                var user = await _accountService.GetUserByUsernameAsync(User.GetUserName());

                if (user == null)
                    return NoContent();

                var file = Request.Form.Files[0];
                if(file.Length > 0)
                {
                    DeleteImage(user.ImagemUrl);
                    user.ImagemUrl = await SaveImage(file);
                }

                var userRetorno = await _accountService.UpdateAccount(user);
                if (userRetorno == null)
                    return NoContent();

                return Ok(userRetorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar realizar login Usuario. Erro: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userDto)
        {
            try
            {
                var user = await _accountService.GetUserByUsernameAsync(User.GetUserName());

                if (user == null)
                    return Unauthorized("Usuario Invalido");

                //var file = Request.Form.Files[0];
                //if (file.Length > 0)
                //{
                //    DeleteImage(user.ImagemUrl);
                //    user.ImagemUrl = await SaveImage(file);
                //}

                var userReturn = await _accountService.UpdateAccount(userDto);
                if (userReturn == null)
                {
                    return NoContent();
                }

                return Ok(userReturn);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar Usuario. Erro: {ex.Message}");
            }
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName)
                .Take(10)
                .ToArray()).Replace(' ', '-');

            imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";

            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/Images", imageName);
            using(var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            if(imageName != null)
            {
                var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/Images", imageName);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
        }
    }
}
