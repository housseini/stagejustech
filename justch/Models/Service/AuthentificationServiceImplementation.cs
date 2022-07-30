using justch.Models.DAL;
using justch.Models.ENTITIES;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace justch.Models.Service
{
    public class AuthentificationServiceImplementation : AuthentificationService
    {
       
     

            //DAL_Utilisateur.GetUtilisateurs();

        public Utilisateur Authentificate(string Utilisateur, string Passeword)
        {
            
             var utilisateurs =DAL_Utilisateur.GetUtilisateurs(); 
            return  utilisateurs.Where(u => u.UserName.ToUpper().Equals(Utilisateur.ToUpper()) && u.Password.Equals(Passeword)).FirstOrDefault();
        }


       
        public string Generetetoken(string key, List<Claim> claims)
        {
            var clé = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) ;
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(
                    clé,
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var Token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(Token);
        }
    }
}
