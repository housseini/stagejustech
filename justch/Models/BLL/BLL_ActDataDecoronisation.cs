using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataDecoronisation
    {
        public static Message Add(ActDataDecoronisation actData)
        {
            return DAL_ActDataDecoronisation.Add(actData);
        }

        public static List<ActDataDecoronisation> GetByIdTraitement(int Id)
        {
            return DAL_ActDataDecoronisation.GETS(Id);
        }
        public static Message Update(ActDataDecoronisation actData)
        {
            return DAL_ActDataDecoronisation.Update(actData);
        }
    }
}
