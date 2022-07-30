using justch.Models.DAL;
using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.BLL
{
    public class BLL_Utilisateur
    {
        public static Message AddUtilisateur(Utilisateur utilisateur)
        {
            

            return DAL_Utilisateur.AddUtilisateur(utilisateur);
        }

        public static List<Utilisateur> GetUtilisateurs()
        {
            DalMigration.create_table_Utilisateur();
            return DAL_Utilisateur.GetUtilisateurs();
        }

        public static Utilisateur GetById(int Id)
        {

            return DAL_Utilisateur.GetById(Id);

        }

        public static Message UpdateUtilisateur(Utilisateur utilisateur)

        {
            return DAL_Utilisateur.UpdateUtilisateur(utilisateur);
        }

        public static Message delete(int ID)
        {
            return DAL_Utilisateur.delete(ID);
        }

        public static List<Utilisateur> GetUtilisateursEnbrologite()
        {
            return DAL_Utilisateur.GetUtilisateursEnbrologite();
        }
    }
}
