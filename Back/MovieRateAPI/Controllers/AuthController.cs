using Microsoft.AspNetCore.Mvc;
using MovieRateAPI.DTO.Usuario;
using MovieRateAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MovieRateAPI.Services.Usuarios;

namespace MovieRateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly string _jwtKey;

        public AuthController(IUsuarioService usuarioService, IConfiguration config)
        {
            _usuarioService = usuarioService;
            _jwtKey = config["Jwt:Key"]!;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UsuarioDto model)
        {
            var existente = await _usuarioService.GetByEmailAsync(model.Email);
            if (existente != null)
                return BadRequest(new { message = "E-mail já cadastrado." });
            var user = new Usuario
            {
                SenhaHash = model.Senha,
                Email = model.Email,
                Nome = model.Nome
            };

            var result = await _usuarioService.AddAsync(user, model.Senha);

            if (result != null)
                return Ok();

            return BadRequest("Erro ao registrar");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _usuarioService.GetByEmailAsync(model.Email);
            if (user == null)
                return Unauthorized("Usuário ou senha inválidos.");

            var isPasswordValid = await _usuarioService.CheckPasswordAsync(user.Email, model.Senha);
            if (!isPasswordValid)
                return Unauthorized("Usuário ou senha inválidos.");

            var token = GerarToken(user);

            return Ok(new { token, userId = user.Id });
        }

        private string GerarToken(Usuario user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("nome", user.Nome)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}