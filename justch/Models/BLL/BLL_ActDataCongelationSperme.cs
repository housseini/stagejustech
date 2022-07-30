using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataCongelationSperme
    {
        public static Message Add(ActDataCongelationSperme actData)
        {
            return DAL_ActDataCongelationSperme.Add(actData);
        }

        public static List<ActDataCongelationSperme> GetByIdTraitement(int Id)
        {
            return DAL_ActDataCongelationSperme.GETS(Id);
        }
        public static Message Update(ActDataCongelationSperme actData)
        {
            return DAL_ActDataCongelationSperme.Update(actData);
        }
    }
}
