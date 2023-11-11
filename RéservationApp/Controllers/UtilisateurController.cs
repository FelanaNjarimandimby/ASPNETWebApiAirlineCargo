using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RéservationApp.Data;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Models.ModèleLogin;
using RéservationApp.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RéservationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : Controller
    {/*
        private readonly IUtilisateurRepository _utilisateurRepository;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;
        private readonly DataContext _context;
        private readonly JWTSetting _setting;


        public UtilisateurController(IUtilisateurRepository utilisateurRepository,
            IRefreshTokenGenerator refreshTokenGenerator,
            DataContext context,
            IOptions<JWTSetting> options)
        {
            _utilisateurRepository = utilisateurRepository;
            _refreshTokenGenerator = refreshTokenGenerator;
            _context = context;
            _setting = options.Value;
        }

        [NonAction]
        public TokenResponse Authenticate(string mail, Claim[] claims)
        {
            TokenResponse tokenResponse = new TokenResponse();
            var tokenkey = Encoding.UTF8.GetBytes(_setting.securitykey);
            var tokenhandler = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                 signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)

                );
            tokenResponse.JWTToken = new JwtSecurityTokenHandler().WriteToken(tokenhandler);
            tokenResponse.RefreshToken = _refreshTokenGenerator.GenerateToken(mail);

            return tokenResponse;
        }

        [Route("Authenticate")]
        [HttpPost]

        public IActionResult Authenticate([FromBody] UtilisateurDto user)
        {
            TokenResponse tokenResponse = new TokenResponse();

            var _user = _utilisateurRepository.Authenticate(user.Mail, user.MotPasse);
            if (_user == null)
                return Unauthorized();

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(_setting.securitykey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, _user.Mail),
                    }
                ),
                Expires = DateTime.Now.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)

            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);

            tokenResponse.JWTToken = finaltoken;
            tokenResponse.RefreshToken = _refreshTokenGenerator.GenerateToken(user.Mail);

            return Ok(tokenResponse);
        }*/

        /*
        [Route("Refresh")]
        [HttpPost]

        public IActionResult Refresh([FromBody] TokenResponse token)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenhandler.ValidateToken(token.JWTToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_setting.securitykey)),
                ValidateIssuer = false,
                ValidateAudience = false

            }, out securityToken);

            var _token = securityToken as JwtSecurityToken;

            if (_token != null && !_token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                return Unauthorized();
            }

            //var username = principal.Identity.Name;
            var mail = principal.Identity.Name;

            //var _user = context.TblUser.FirstOrDefault(o => o.Userid == user.username && o.Password == user.password);
            //var _reftable = _context.TblRefreshToken.FirstOrDefault(o => o.Mail == mail && o.RefreshToken == token.RefreshToken);
            var _reftable = _refreshTokenGenerator.Refresh(mail, token.RefreshToken);

            if (_reftable == null)
            {
                return Unauthorized();
            }

            TokenResponse _result = Authenticate(mail, principal.Claims.ToArray());

            return Ok(_result);
        }

        */
    }
}