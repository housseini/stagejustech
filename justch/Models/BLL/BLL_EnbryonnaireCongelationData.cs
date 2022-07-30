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
      

        public static List<EnbryonnaireCongelationData> GetByIdTraitement(int Id)
        {
            return DAL_EnbryonnaireCongelationData.GETS(Id);
        }
        public static Message Update(EnbryonnaireCongelationData actData)
        {
            return DAL_EnbryonnaireCongelationData.Update(actData);
        }

        public static EnbryonnaireCongelationData GET(int Id)
        {
            return DAL_EnbryonnaireCongelationData.GET(Id);
        }
    }
}
