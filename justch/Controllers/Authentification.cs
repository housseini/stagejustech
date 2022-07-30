using justch.Models.ENTITIES;
using justch.Models.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace justch.Controllers
{
    public class Authentification : Controller
    {
        private const string V = "Bearer=";
        private readonly AuthentificationServiceImplementation _authentificationService;
        private readonly IConfiguration _configuration1;

        public Authentification(AuthentificationServiceImplementation authentification, IConfiguration configuration)
        {
            this._authentificationService = authentification;
            this._configuration1 = configuration;
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            var utilisateur = _authentificationService.Authentificate(login.Utilisateur, login.Passeword);


            if (utilisateur != null)
            {


                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,utilisateur.UserName),

                };
                var token = _authentificationService.Generetetoken(_configuration1["Jwt:Key"], claims);
                Response.Cookies.Append("access_token", token, new CookieOptions {
                    HttpOnly = false,
                    Expires  = DateTime.UtcNow.AddMinutes(60),
                    SameSite = SameSiteMode.Strict

                });
                return Ok(new
                {
                    access_token = token,
                    token_type = " bearer ",
                    expires_in = DateTime.UtcNow.AddMinutes(15),
                });
            }

            return Json ("non");

        }
    
}
}
