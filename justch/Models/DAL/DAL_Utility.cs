using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.DAL
{
    public class DAL_Utility
    {
        public static List<Rdv_Complet> allRdv ( )
        {
            return Rdv_Complet.allRdv(DAL_Appointment.gets()); 
        }
        public static List<Rdv_Complet> RdvBY(int ID )
        {
            return Rdv_Complet.allRdv(DAL_Appointment.getsByID(ID));
        }
    }
}
