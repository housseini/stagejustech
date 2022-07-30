using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataPonction
    {
        public static Message Add(ActDataPonction actData)
        {
            return DAL_ActDataPonction.Add(actData);
        }

        public static List<ActDataPonction> GetByIdTraitement(int Id)
        {
            return DAL_ActDataPonction.GETS(Id);
        }
        public static Message Update(ActDataPonction actData)
        {
            return DAL_ActDataPonction.Update(actData);
        }
    }
}
