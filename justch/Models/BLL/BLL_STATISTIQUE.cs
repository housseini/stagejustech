using System;
using System.Collections.Generic;
using System.Data;

using justch.Models.DAL;

namespace justch.Models.BLL
{
    public class BLL_STATISTIQUE
    {

        public static Dictionary<string, int> COUNTGENRE()
        {
            return DAL_STATISTIQUE.COUNTGENRE();
        }

        public static Dictionary<string, int> COUNTdossierType()
        {
            return DAL_STATISTIQUE.COUNTdossierType();
        }
        public static Dictionary<string, int> COUNTMEDICALRECOREType()
        {
            return DAL_STATISTIQUE.COUNTMEDICALRECOREType();
        }
    }
}
