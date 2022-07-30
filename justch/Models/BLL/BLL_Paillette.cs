using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_Paillette
    {
       
            public static Message Add(Paillette actData)
            {
                return DAL_Paillette.Add(actData);
            }

            public static List<Paillette> GetById(int Id)
            {
                return DAL_Paillette.GETS(Id);
            }
            public static Message Update(Paillette actData)
            {
                return DAL_Paillette.Update(actData);
            }

            public static List<Paillette> GETS()
            {
                return DAL_Paillette.GETS();
            }

            public static Message delete(int Id)
            {
                return DAL_Paillette.delete(Id);
            }

            public static List<Paillette> GETSIdVisotube(int Id)
            {
                return DAL_Paillette.GETSIdVisotube(Id);
            }

      
    }
}
