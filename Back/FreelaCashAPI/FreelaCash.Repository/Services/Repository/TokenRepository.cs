using AutoMapper;
using FreelaCash.Dominio.Identity;
using FreelaCash.Repository.Dto;
using FreelaCash.Repository.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Repository.Services.Repository
{
    public class TokenRepository : ITokenService
    {

        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public TokenRepository(IConfiguration config, UserManager<User> userManager, IMapper mapper)
        {
            _config = config;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<string> CreateToken(UserUpdateDto userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenKey = "super-secret-key";

            var keyBytes = Encoding.UTF8.GetBytes(tokenKey);
            if (keyBytes.Length < 64) // 64 bytes = 512 bits
            {
                var paddedKeyBytes = new byte[64]; // Tamanho mínimo da chave para HMAC-SHA512
                Array.Copy(keyBytes, paddedKeyBytes, keyBytes.Length);
                keyBytes = paddedKeyBytes;
            }

            var key = new SymmetricSecurityKey(keyBytes);

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
