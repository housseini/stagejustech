using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_SpermogrammeTMS
    {
        public static Message Add(SpermogrammeTMS spermogramme)
        {
            return DAL_SpermogrammeTMS.Add(spermogramme);
        }

        public static List<SpermogrammeTMS> Gets(int IdReneignement)
        {
            return DAL_SpermogrammeTMS.Gets(IdReneignement);
        }


        public static SpermogrammeTMS GETbyID(int ID)
        {
            return DAL_SpermogrammeTMS.GETbyID(ID);
        }

        public static Message Delete(int Id)
        {
            return DAL_SpermogrammeTMS.Delete(Id);

        }

        public static Message Update(SpermogrammeTMS spermogramme)
        {
            return DAL_SpermogrammeTMS.Update(spermogramme);
        }


    }
}
