using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace justch.Models.Service
{
    interface AuthentificationService
    {
        Utilisateur Authentificate(string Utilisateur, string Passeword);

        string Generetetoken(string key, List<Claim> claims);
       

    }
}
    