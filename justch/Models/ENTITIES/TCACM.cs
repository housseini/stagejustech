using justch.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// cette classe permet de mette en relation Act Medical avec traitement Cycle 
/// </summary>
namespace justch.Models.ENTITIES
{
    public class TCACM
    {
        public MedicalAct medicalAct { get; set; }
        public TreatmentCycleElementaryAct TreatmentCycleElementaryAct { get; set; }
        public TraitementCycle traitementCycle { get; set; }
        public TCACM (TreatmentCycleElementaryAct elementaryAct)
        {
            this.TreatmentCycleElementaryAct = elementaryAct;

            this.medicalAct = DAL_MedicalAct.getByID(elementaryAct.IdMedicalAct);
            this.traitementCycle = DAL_TraitementCycle.GetsById(elementaryAct.IdTreatmentCycle);
        }
        public static List<TCACM> ALLTCACM() {
            List<TCACM> tCACMs = new List<TCACM>();
            try
            {
                var trs = DAL_TreatmentCycleElementaryAct.gets();
                if (trs!=null)
                {
                    foreach (TreatmentCycleElementaryAct elment in trs)
                        tCACMs.Add(new TCACM(elment));
                    return tCACMs;

                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }



        }
    }
}
