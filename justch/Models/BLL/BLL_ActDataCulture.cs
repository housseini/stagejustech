using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataCulture
    {
        public static Message Add(ActDataCulture actData)
        {
            return DAL_ActDataCulture.Add(actData);
        }

        public static List<ActDataCulture> GetByIdTraitement(int Id)
        {
            return DAL_ActDataCulture.GETS(Id);
        }
        public static Message Update(List<int> listenumero, int idactculture, int Jours, string Grade, string chambre, int Incubateur, int enbryologite, string date, string heur, string Commentaire, int iddeco)
        {
            return DAL_ActDataCulture.Update( listenumero,  idactculture,  Jours,  Grade,  chambre,  Incubateur,  enbryologite,  date,  heur,  Commentaire,  iddeco);
        }

        public static CultureComplet GetCultureComplet(int Id)
        {

           CultureComplet c = new CultureComplet(Id);
            if (c.IdTraitement != 0)
            {
                return c;

            }
            return null;
             
        }


    }
}
