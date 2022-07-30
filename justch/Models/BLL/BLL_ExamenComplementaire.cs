using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;
using justch.Models.Service;

namespace justch.Models.BLL
{
    public class BLL_ExamenComplementaire
    {
        public static Message Add(ExamenComplementaire examen)
        {
            return DAL_ExamenComplementaire.Add(examen);
        }
        public static List<ExamenComplementaire> Gets(int IdRenseignement)
        {
            return DAL_ExamenComplementaire.Gets(IdRenseignement);
        }

        public static ExamenComplementaire GetbyId(int Id)
        {
            return DAL_ExamenComplementaire.GetbyId(Id);
        }



        public static Message Update(ExamenComplementaire examen)
        {
            return DAL_ExamenComplementaire.Update(examen);
        }

        public static Message Delete(int Id)
        {
            return DAL_ExamenComplementaire.Delete(Id);
        }

    }
}
