using AspNetCore.Entities;
using AspNetCore.Entities.Models;
using AspNetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _context;
        readonly IConfiguration _configuration;
        public AuthController(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginModel appUser)//[FromBody] 
        {
            var account = await _context.Users.FirstOrDefaultAsync(u => u.Email == appUser.Email && u.Password == appUser.Password && u.IsActive);
            if (account == null)
            {
                return NotFound();// Content("NotFound");// 
            }
            //Security  Key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            // Eğer rol bazlı yapacaksak
            var claims = new List<Claim>() // Claim = hak
                        {
                            new Claim(ClaimTypes.Name, account.UserName),
                            new Claim(ClaimTypes.Role, account.IsAdmin ? "Admin" : "User"),
                            new Claim("UserId", account.Id.ToString())
                        };
            Token tokenInstance = new();
            //Oluşturulacak token ayarlarını veriyoruz.
            tokenInstance.Expiration = DateTime.Now.AddMinutes(15);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: DateTime.Now.AddMinutes(10),
                notBefore: DateTime.Now,//Token üretildikten ne kadar süre sonra devreye girsin ayarlıyouz.
                signingCredentials: signingCredentials,
                claims: claims
                );
            //Token oluşturucu sınıfında bir örnek alıyoruz.
            JwtSecurityTokenHandler tokenHandler = new();

            //Token üretiyoruz.
            tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken);

            //Refresh Token üretiyoruz.
            tokenInstance.RefreshToken = Guid.NewGuid().ToString();

            //Refresh token Users tablosuna işleniyor.
            account.RefreshToken = tokenInstance.RefreshToken;
            account.RefreshTokenExpireDate = tokenInstance.Expiration.AddMinutes(30);
            _context.Users.Update(account);
            await _context.SaveChangesAsync();

            return Ok(tokenInstance);
        }
        /*
         * https://localhost:7132/api/Brands api adresi, auth ile korumaya aldık
         * postman veya swagger dan https://localhost:7132/api/Auth a user json göndererek token alıyoruz 
         * bu tokenla postmanı açıp get isteği olarak headers sekmesine sola Authorization sağa Bearer token ı yapıştırıp isteği yolla
         */
        //return Created("", new JwtTokenGenerator(_configuration).GenerateToken());
        // POST: api/AppUsers
        [HttpPost("SignUp")]
        public async Task<ActionResult<User>> SignUp(User appUser)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == appUser.Email);
                if (user != null)
                {
                    return Conflict(new { errMes = appUser.Email + " adresi sistemde zaten kayıtlı!" });
                }
                else
                {
                    appUser.CreateDate = DateTime.Now;
                    appUser.IsActive = true;
                    await _context.Users.AddAsync(appUser);
                    await _context.SaveChangesAsync();
                    return Ok(appUser);
                }
            }
            catch (Exception)
            {
                return Problem("Hata Oluştu!");
            }
        }
    }
}
