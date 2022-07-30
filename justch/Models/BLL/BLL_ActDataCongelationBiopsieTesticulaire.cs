using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataCongelationBiopsieTesticulaire
    {
        public static Message Add(ActDataCongelationBiopsieTesticulaire actData)
        {
            return DAL_ActDataCongelationBiopsieTesticulaire.Add(actData);
        }

        public static List<ActDataCongelationBiopsieTesticulaire> GetByIdTraitement(int Id)
        {
            return DAL_ActDataCongelationBiopsieTesticulaire.GETS(Id);
        }
        public static Message Update(ActDataCongelationBiopsieTesticulaire actData)
        {
            return DAL_ActDataCongelationBiopsieTesticulaire.Update(actData);
        }

    }
}
