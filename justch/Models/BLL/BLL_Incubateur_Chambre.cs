using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_Incubateur_Chambre
    {

        #region Incubateur I
        public static Message Add(Incubateur incubateur)
        {
            return DAL_Incubateur_Chambre.Add(incubateur);
        }

        public static List<Incubateur> Gets()
        {
            return DAL_Incubateur_Chambre.Gets();
        }
        public static Incubateur Get(int Id)
        {
            return DAL_Incubateur_Chambre.Get(Id);
        }
        public static Message Update(Incubateur incubateur)
        {
            return DAL_Incubateur_Chambre.Update(incubateur);
        }

        public static Message Delete(int Id)
        {
            return DAL_Incubateur_Chambre.Delete(Id);
        }
        #endregion
        #region chambre 
        public static Message Add(Chambre chambre)
        {
            return DAL_Incubateur_Chambre.Add(chambre);
        }

        public static Chambre GetChambre(int Id)
        {
            return DAL_Incubateur_Chambre.GetChambre(Id);
        }
        public static List<Chambre> GetsChambre()
        {
            return DAL_Incubateur_Chambre.GetsChambre();
        }
        public static Message Update(Chambre incubateur)
        {
            return DAL_Incubateur_Chambre.Update(incubateur);
        }
        public static Message DeleteChambre(int Id)
        {
            return DAL_Incubateur_Chambre.DeleteChambre(Id);
        }

        

            public static List<Chambre> GetsChambreByIdncubateur(int Id)
        {
            return DAL_Incubateur_Chambre.GetsChambreByIdncubateur(Id);
        }
        #endregion
    }
}
