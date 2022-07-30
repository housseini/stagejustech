using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_EnbryonnaireCongelationData
    {
        public static Message Add(EnbryonnaireCongelationData actData)
        {
            return DAL_EnbryonnaireCongelationData.Add(actData);
        }

        public static List<EnbryonnaireCongelationData> GetByIdTraitement(int Id)
        {
            return DAL_EnbryonnaireCongelationData.GETS(Id);
        }
        public static Message Update(EnbryonnaireCongelationData actData)
        {
            return DAL_EnbryonnaireCongelationData.Update(actData);
        }
    }
}
