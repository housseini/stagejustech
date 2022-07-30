using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_DevenirEmbryon
    {
        public static Message Add(DevenirEmbryon actData)
        {
            return DAL_DevenirEmbryon.Add(actData);
        }

        public static List<DevenirEmbryon> GetByIdTraitement(int Id)
        {
            return DAL_DevenirEmbryon.GETS(Id);
        }
        public static Message Update(DevenirEmbryon actData)
        {
            return DAL_DevenirEmbryon.Update(actData);
        }
    }
}
