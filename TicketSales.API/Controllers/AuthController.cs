using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketSales.API.Models;
using TicketSales.BLL.Abstract;
using TicketSales.Model.DTOs.CategoryDTO;
using TicketSales.Model.DTOs.UserDTO;
using TicketSales.Model.Entities;
using TicketSales.Model.Enums;

namespace TicketSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly IMapper _mapper;
        private readonly TokenOption tokenOption;


        public AuthController(IUserBLL userBLL, IMapper mapper, IOptions<TokenOption> options)
        {
            _userBLL = userBLL;
            _mapper = mapper;
            tokenOption = options.Value;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<User>(registerUserDTO);
                user.IsActive = true;

                _userBLL.Insert(user);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Mail Daha Önce Kullanılmıştır.");
            }


        }


        [HttpPost("registercompany")]
        public async Task<IActionResult> RegisterCompany(RegisterCompanyDTO registerCompanyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User()
            {

                Password = registerCompanyDTO.Password,
                FirstName = registerCompanyDTO.CompanyName,
                LastName = registerCompanyDTO.WebSite,
                Role = UserRole.Company,
                Email = registerCompanyDTO.Email,


            };

            _userBLL.Insert(user);
            return Ok();



        }



        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            var user = _userBLL.GetUserByLoginData(loginUserDTO.Email, loginUserDTO.Password);

            if (user == null)
            {
                return BadRequest("User Not Found");
            }

            string token = CreateToken(user);
            return Ok(token);

        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName, user.LastName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.ID)));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));



            JwtSecurityToken securityToken = new JwtSecurityToken(
            issuer: tokenOption.Issuer,
                audience: tokenOption.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(tokenOption.Expiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecretKey)), SecurityAlgorithms.HmacSha256)
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string userToken = tokenHandler.WriteToken(securityToken);
            return userToken;


        }
    }
}
