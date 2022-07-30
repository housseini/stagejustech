using justch.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class MedicalActPersonnaliser
    {
        public MedicalAct medicalAct { get; set; }
        public List<MedicalRecordAct> medicalRecordActs { get; set; }
        public MedicalActPersonnaliser(int  IdmedicalAct)
        {
            var me= DAL_MedicalAct.getByID(IdmedicalAct);
            if (me != null)
            {
                this.medicalAct = me;
            }
            medicalRecordActs = new List<MedicalRecordAct>();
            var MED = DAL_MedicalRecordAct.getsByIdMedicalACT(IdmedicalAct);
            if (MED != null)
            {
                foreach (MedicalRecordAct medicalRecordAct in MED)
                {
                    if (medicalRecordAct!=null)
                        medicalRecordActs.Add(medicalRecordAct);
                }

                   
            }


        }


    }
}
