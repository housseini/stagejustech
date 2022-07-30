using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_OvocyteCongelationData
    {
        public static Message Add(OvocyteCongelationData actData)
        {
            return DAL_OvocyteCongelationData.Add(actData);
        }

        public static List<OvocyteCongelationData> GetByIdTraitement(int Id)
        {
            return DAL_OvocyteCongelationData.GETS(Id);
        }
        public static Message Update(OvocyteCongelationData actData)
        {
            return DAL_OvocyteCongelationData.Update(actData);
        }
    }
}
