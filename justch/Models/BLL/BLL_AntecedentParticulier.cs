using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_AntecedentParticulier
    {
        public static Message Add(AntecedentParticulier antecedent)
        {
            return DAL_AntecedentParticulier.Add(antecedent);
        }

        public static List<AntecedentParticulier> Gets(int IdReneignement)
        {
            return DAL_AntecedentParticulier.Gets(IdReneignement);
        }

        public static Message Update(AntecedentParticulier antecedent)
        {
            return DAL_AntecedentParticulier.Update(antecedent);
        }


        public static Message Delete(int Id)
        {
            return DAL_AntecedentParticulier.Delete(Id);
        }

        public static AntecedentParticulier GET (int Id)
        {
            return DAL_AntecedentParticulier.GETbyID(Id);
        }



    }

}
