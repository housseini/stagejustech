using justch.Models.ENTITIES;
using justch.Models.DAL;
using System.Collections.Generic;
using System;

namespace justch.Models.BLL
{
    public class BLL_Appointment
    {
        public static Rdv_Complet re;
        public static Message add ( Appointment ap )
        {
            DalMigration.create_table_Appointment();

            return DAL_Appointment.add(ap);

        }
        public static List<Appointment> gets ( )
        {
            DalMigration.create_table_Appointment();
            return DAL_Appointment.gets();
        }

        public static Message delete ( int ID )
        {
            return DAL_Appointment.delete(ID);
        }
        public static Appointment GetbyIdappointement ( int Id )
        {
            return DAL_Appointment.GetbyIdappointement(Id);
        }

        public static Rdv_Complet GetRdv_Complet(int Id )
        {
            re = new Rdv_Complet(DAL_Appointment.GetbyIdappointement(Id));
            return re;
        }

        public static Message update ( Appointment ap )
        {
            return DAL_Appointment.update(ap);
        }
        /// <summary>
        /// mettre appointement en status terminer 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Message terminer(int Id) {
            return DAL_Appointment.terminer(Id);



        }




        public static List<Rdv_Complet> Rechercheravancer(int IPITENT, int Room, DateTime jour, int plage, int Idmedecin, int IdAct)
        {
            return DAL_Appointment.Rechercheravancer(IPITENT,Room,jour,plage,Idmedecin,IdAct);
        }
    }
}


