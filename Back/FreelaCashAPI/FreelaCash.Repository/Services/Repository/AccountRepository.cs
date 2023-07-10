using AutoMapper;
using FreelaCash.Dominio;
using FreelaCash.Dominio.Identity;
using FreelaCash.Repository.Dto;
using FreelaCash.Repository.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Repository.Services.Repository
{
    public class AccountRepository : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly Context _context;

        public AccountRepository(UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IMapper mapper,
            IUserService userService,
            Context context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userService = userService;
            _context = context;
        }

        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password)
        {
            try
            {
                var user = await _userManager.Users
                    .SingleOrDefaultAsync(x => x.UserName == userUpdateDto.UserName.ToLower());
                return await _signInManager.CheckPasswordSignInAsync(user, password, false);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");
            }
        }

        public async Task<UserDto> CreateAccountAsync(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);

                if(result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserDto>(user);
                    return userToReturn;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao tentar criar conta. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDto> GetUserByUsernameAsync(string username)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(username);

                if(user == null)
                {
                    return null;
                }

                var userUpdateDto = _mapper.Map<UserUpdateDto>(user);
                return userUpdateDto;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao tentar recuperar usuario. Erro: {ex.Message}");
            }

        }

        public async Task<UserUpdateDto> UpdateAccount(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(userUpdateDto.UserName);

                if (user == null)
                    return null;

                userUpdateDto.Id = user.Id;
                userUpdateDto.Password = "12345";

                _mapper.Map(userUpdateDto, user);

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, userUpdateDto.Password);

                //_context.Add(user);
                _context.Users.Update(user);
                if(await _context.SaveChangesAsync() > 0)
                {
                    var userRetorno = await _userService.GetUserByUsernameAsync(user.UserName);
                    return _mapper.Map<UserUpdateDto>(userRetorno);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao tentar atualizar conta. Erro: {ex.Message}");
            }

        }

        public async Task<bool> UserExists(string username)
        {
            try
            {
                return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao tentar verificar se o usuario existe. Erro: {ex.Message}");
            }

        }
    }
}
