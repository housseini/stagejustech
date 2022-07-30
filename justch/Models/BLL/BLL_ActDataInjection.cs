using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataInjection
    {
        public static Message Add(ActDataInjection actData)
        {
            return DAL_ActDataInjection.Add(actData);
        }

        public static List<ActDataInjection> GetByIdTraitement(int Id)
        {
            return DAL_ActDataInjection.GETS(Id);
        }
        public static Message Update(ActDataInjection actData)
        {
            return DAL_ActDataInjection.Update(actData);
        }

    }
}
