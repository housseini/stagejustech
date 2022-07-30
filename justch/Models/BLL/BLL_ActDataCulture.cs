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
        public static Message Update(ActDataCulture actData)
        {
            return DAL_ActDataCulture.Update(actData);
        }
    }
}
