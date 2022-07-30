using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_CulureOvocyteData
    {
        public static Message Add(CulureOvocyteData actData)
        {
            return DAL_CulureOvocyteData.Add(actData);
        }

        public static List<CulureOvocyteData> GetByIdTraitement(int Id)
        {
            return DAL_CulureOvocyteData.GETS(Id);
        }
        public static Message Update(CulureOvocyteData actData)
        {
            return DAL_CulureOvocyteData.Update(actData);
        }
    }
}
