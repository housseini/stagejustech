using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_EnbryonTransfertData
    {

        public static Message Add(EnbryonTransfertData actData)
        {
            return DAL_EnbryonTransfertData.Add(actData);
        }

        public static List<EnbryonTransfertData> GetByIdTraitement(int Id)
        {
            return DAL_EnbryonTransfertData.GETS(Id);
        }
        public static Message Update(EnbryonTransfertData actData)
        {
            return DAL_EnbryonTransfertData.Update(actData);
        }
    }
}
