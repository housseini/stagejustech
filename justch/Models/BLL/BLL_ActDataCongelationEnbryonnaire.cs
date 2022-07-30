using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataCongelationEnbryonnaire
    {

        public static Message Add(ActDataCongelationEnbryonnaire actData)
        {
            return DAL_ActDataCongelationEnbryonnaire.Add(actData);
        }

        public static List<ActDataCongelationEnbryonnaire> GetByIdTraitement(int Id)
        {
            return DAL_ActDataCongelationEnbryonnaire.GETS(Id);
        }
        public static Message Update(ActDataCongelationEnbryonnaire actData)
        {
            return DAL_ActDataCongelationEnbryonnaire.Update(actData);
        }
    }
}
