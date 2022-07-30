using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataCongelationOvocyte
    {
        public static Message Add(ActDataCongelationOvocyte actData)
        {
            return DAL_ActDataCongelationOvocyte.Add(actData);
        }

        public static List<ActDataCongelationOvocyte> GetByIdTraitement(int Id)
        {
            return DAL_ActDataCongelationOvocyte.GETS(Id);
        }
        public static Message Update(ActDataCongelationOvocyte actData)
        {
            return DAL_ActDataCongelationOvocyte.Update(actData);
        }
    }
}
