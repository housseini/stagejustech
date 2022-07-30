using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.BLL
{
    public class BLL_Utiliy
    {
        public static List<Rdv_Complet> allRdv ( )
        {
             return DAL_Utility.allRdv ( );
        }

        public static List<Rdv_Complet> RdvBY ( int ID )
        {
            return DAL_Utility.RdvBY ( ID );    
        }
        public static List <MedicalAct> MedicalAct ( )
        {
            return BLL_MedicalAct.gets();
        }
        public static Rdv_Complet GetRdvById(int id)
        {
            return new Rdv_Complet(id);
        }
    }
}
