using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.BLL
{
    public class BLL_MedicalRecordAct
    {
        public static Message add(MedicalRecordAct medicalRecordAct)
        {
            return DAL_MedicalRecordAct.add(medicalRecordAct);
        }
        public static List<MedicalRecordAct> gets()
        {
            return DAL_MedicalRecordAct.gets();
        }
        public static List<MedicalRecordAct> getsByIdMedicalRecord(int value)
        {
            return DAL_MedicalRecordAct.getsByIdMedicalRecord(value);
        }
        public static Message delete(int id)
        {
            return DAL_MedicalRecordAct.delete(id);
        }
        public static MedicalRecordAct getBYiD ( int id )
        {
            return DAL_MedicalRecordAct.getBYiD(id);
        }
        public static Message update ( MedicalRecordAct medicalRecordAct )
        {
            return DAL_MedicalRecordAct.update(medicalRecordAct);
        }
        public static int countMedicalrecordActbyIdactIddossier ( string IdACT, int IdDosssier, string patients )
        {
            return DAL_MedicalRecordAct.countMedicalrecordActbyIdactIddossier(IdACT, IdDosssier,patients);
        }

        public static Message terminer ( int Id )
        {
            return DAL_MedicalRecordAct.terminer(Id);
        }
    }
}
