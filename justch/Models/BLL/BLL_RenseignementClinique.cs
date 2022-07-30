using justch.Models.DAL;
using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.BLL
{
    public class BLL_RenseignementClinique
    {
        /// <summary>
        ///  ajouter le renseignement clinique depuis un dossier  
        /// </summary>
        /// <param name="renseignementClinique"></param>
        /// <returns></returns>
        public static Message Add(RenseignementClinque renseignementClinique)
        {
            return DAL_RenseignementClinque.Add(renseignementClinique);

        }

        /// <summary> 
        /// /retourner le renseignement clininique d un dossier 
        /// </summary>
        /// <param name="Iddossiermedical"></param>
        /// <returns></returns>
        public static RenseignementClinque GETBYIDMEDICALE(int Iddossiermedical)
        {
            return DAL_RenseignementClinque.GETBYIDMEDICALE(Iddossiermedical);
        }
        /// <summary>
        ///  mise à jours 
        /// </summary>
        /// <param name="renseignementClinique"></param>
        /// <returns></returns>

        public static Message Update(RenseignementClinque renseignementClinique)
        {
            return DAL_RenseignementClinque.Update(renseignementClinique);

        }



    }
}
