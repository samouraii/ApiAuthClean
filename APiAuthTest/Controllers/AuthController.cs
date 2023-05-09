using APiAuthTest.Model;
using APiAuthTest.Model.UserModel;
using APiAuthTest.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace APiAuthTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly UserContext _usercontext;

        public AuthController(IConfiguration configuration, IUserService userService, UserContext userContext)
        {
            this._configuration = configuration;
            this._userService = userService;
            _usercontext = userContext;
        }
        //public static User user = new User();

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var username = _userService.GetMyName();
            return Ok(username);

        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User();
            user.Username = request.UserName;
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            user.personne = request.personne;
            _userService.InsertUser(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> login(UserDTO request)
        {
            _usercontext.Users.FirstOrDefault(s => s.Username == "string");
            User? user = _userService.FindOneUser(request.UserName);
            if (user == null || user.Username != request.UserName)
            {
                return BadRequest("User Not found.");
            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }
            string token = CreateToken(user);
            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken, user);
            return Ok(JsonConvert.SerializeObject(new Token { token= token }));
        }

        [HttpPost("refresh-token")]
       /* public async Task<ActionResult<string>> RefreshToken(User user)
        {
            
            var refreshToken = Request.Cookies["refreshToken"];
            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalide Refresh Token");
            }
            else if (user.TokenExpire < DateTime.Now)
            {
                return Unauthorized("Token expired");
            }

            string token = CreateToken(user);
            var newrefreshToken = GenerateRefreshToken();
            SetRefreshToken(newrefreshToken,  user);
            return Ok(token);
        } */

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expire = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };
            return refreshToken;
        }
        private void SetRefreshToken(RefreshToken refreshToken, User user)
        {
           
            var CookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expire
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, CookieOptions);

            //user.RefreshToken = refreshToken.Token;
            //user.TokenCreated = refreshToken.Created;
            //user.TokenExpire = refreshToken.Expire;
        }
        private string CreateToken(User user)
        {
            DateTime t = DateTime.Now.AddMinutes(60);
            string roles = "";
            var tt = _userService.GetPermissions(user.Id).ToList<Permissions>();
                tt.ForEach(x => roles += roles.Length >0? ";"+x.Name: x.Name);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, roles),
               
                new Claim(ClaimTypes.Expiration,t.ToString()),
                };
            if (user.personne != null && user.personne.Societes.Count() > 0 ) {
                claims.Add(new Claim("societe", user.personne.Societes.First().Name));
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: t,
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
       
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash (string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash .SequenceEqual(passwordHash);
            }
        }
    }
}
