using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_Cuve
    {
        public static Message Add(Cuve actData)
        {
            return DAL_Cuve.Add(actData);
        }

        public static List<Cuve> GetById(int Id)
        {
            return DAL_Cuve.GETS(Id);
        }
        public static Message Update(Cuve actData)
        {
            return DAL_Cuve.Update(actData);
        }

        public static List<Cuve> GETS()
        {
            return DAL_Cuve.GETS();
        }

        public static Message delete(int Id)
        {
            return DAL_Cuve.delete(Id);
        }



    }
}
