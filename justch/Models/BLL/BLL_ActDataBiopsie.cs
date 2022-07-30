using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataBiopsie
    {

        public static Message Add(ActDataBiopsie actData)
        {
            return DAL_ActDataBiopsie.Add(actData);
        }

        public static List<ActDataBiopsie> GetByIdTraitement(int Id)
        {
            return DAL_ActDataBiopsie.GETS(Id);
        }
        public static Message Update(ActDataBiopsie actData)
        {
            return DAL_ActDataBiopsie.Update(actData);
        }

    }
}
