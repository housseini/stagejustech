using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_Serologie
    {

        public static Message Add(Serologie Serologie)
        {
            return DAL_Serologie.Add(Serologie);
        }
        public static List<Serologie> Gets(int IdReneignement)
        {
            return DAL_Serologie.Gets(IdReneignement);
        }
        public static Serologie GETbyID(int ID)
        {
            return DAL_Serologie.GETbyID(ID);
        }

        public static Message Update(Serologie Serologie)
        {
            return DAL_Serologie.Update(Serologie);
        }

        public static Message Delete(int Id)
        {
            return DAL_Serologie.Delete(Id);
        }


    }
}
