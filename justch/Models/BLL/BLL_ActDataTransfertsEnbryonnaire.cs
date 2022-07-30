using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataTransfertsEnbryonnaire
    {
        public static Message Add(ActDataTransfertsEnbryonnaire actData)
        {
            return DAL_ActDataTransfertsEnbryonnaire.Add(actData);
        }

        public static List<ActDataTransfertsEnbryonnaire> GetByIdTraitement(int Id)
        {
            return DAL_ActDataTransfertsEnbryonnaire.GETS(Id);
        }
        public static Message Update(ActDataTransfertsEnbryonnaire actData)
        {
            return DAL_ActDataTransfertsEnbryonnaire.Update(actData);
        }
    }
}
