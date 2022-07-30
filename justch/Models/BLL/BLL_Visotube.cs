using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_Visotube
    {
        public static Message Add(Visotube actData)
        {
            return DAL_Visotube.Add(actData);
        }

        public static List<Visotube> GetById(int Id)
        {
            return DAL_Visotube.GETS(Id);
        }
        public static Message Update(Visotube actData)
        {
            return DAL_Visotube.Update(actData);
        }

        public static List<Visotube> GETS()
        {
            return DAL_Visotube.GETS();
        }

        public static Message delete(int Id)
        {
            return DAL_Visotube.delete(Id);
        }

        public  static List<Visotube> GETSIdcuve(int Id)
        {
            return DAL_Visotube.GETSIdCuve(Id);
        }

    }
}
