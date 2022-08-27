using justch.Models.DAL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Web;

namespace justch.Models.BLL
{
    public class BLL_Database_Registre
    {

        public static Message Add( string nam,string cause)
        {
            return DAL_Database_Registre.Add(nam,cause,"Administrateur");
        }
        public static List<Database_Registre> GETS()
        {
            return DAL_Database_Registre.GETS();

        }
        public static Message Add1( string Name, string CAUSEs, string namedata)
        {
            return DAL_Database_Registre.Add(Name, CAUSEs, "Administrateur",  namedata);
        }
    }
}
