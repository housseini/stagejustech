using justch.Models.DAL;
using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.BLL
{
    public class BLL_TraitementCycle
    {
        public static List<TraitementCycle> Gets()
        {
            DalMigration.create_table_TraitementCycle();
            DalMigration.create_table_TreatmentCycleElementaryAct();
            return DAL_TraitementCycle.Gets();
        }
        public static Message Add(TraitementCycle t)
        {
            return DAL_TraitementCycle.Add(t);
        }
        /// <summary>
        /// cette foncontion retourne la liste de act mediac et le traitement relie  traitemen cycle a chaque act  
        /// </summary>
        /// <returns></returns>
        public static List<TCACM> ALLTCACM()
        {
            return TCACM.ALLTCACM();
        }
        /// <summary>
        /// supprime le traitement Cyce et le traiment elementaire cycle 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public static Message deletById(int Id)
        {
            return DAL_TraitementCycle.deletById(Id);
        }
        /// <summary>
        /// retourne le traitement Cyce et le traiment elementaire cycle 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public static TCACM GetTCACMbyID(int Id)
        {
            return DAL_TreatmentCycleElementaryAct.GetTCACMbyID(Id);
        }
        /// <summary>
        /// met ajours le TraitementCycle et  TreatmentCycleElementaryAct
        /// </summary>
        /// <param name="t"></param>
        /// <param name="te"></param>
        /// <returns></returns>
        public static Message Update(TraitementCycle t, TreatmentCycleElementaryAct te)
        {
            return DAL_TraitementCycle.Update(t, te);
        }
    }
}
