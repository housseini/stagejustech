using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_TentativeAnterieure
    {
        public static Message Add(TentativeAnterieur tentative)
        {
            return DAL_TentativeAnterieur.Add(tentative);
        }
        /// <summary>
        /// retourner selon IdRenseignement passe
        /// </summary>
        /// <param name="IdRenseignement"></param>
        /// <returns></returns>
        public static List<TentativeAnterieur> Gets(int IdRenseignement)
        {
            return DAL_TentativeAnterieur.Gets(IdRenseignement);
        }
        /// <summary>
        ///  retourner selon Idpasse
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static TentativeAnterieur GetById(int Id)
        {
            return DAL_TentativeAnterieur.GetById(Id);
        }
        /// <summary>
        /// modifier tentative
        /// </summary>
        /// <param name="tentative"></param>
        /// <returns></returns>
        public static Message Update(TentativeAnterieur tentative)
        {
            return DAL_TentativeAnterieur.Update(tentative);
        }
        /// <summary>
        /// Supprimer tentative selon l'id passer 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Message Delete(int Id)
        {
            return DAL_TentativeAnterieur.Delete(Id);

        }
    }
}
