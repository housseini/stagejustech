using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataInseminationIAC
    {
        public static Message Add(ActDataInseminationIAC actData)
        {
            return DAL_ActDataInseminationIAC.Add(actData);
        }

        public static List<ActDataInseminationIAC> GetByIdTraitement(int Id)
        {
            return DAL_ActDataInseminationIAC.GETS(Id);
        }
        public static Message Update(ActDataInseminationIAC actData)
        {
            return DAL_ActDataInseminationIAC.Update(actData);
        }

    }
}
