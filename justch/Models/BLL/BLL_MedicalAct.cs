

using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.BLL
{
    public class BLL_MedicalAct
    {
        public static Message add(MedicalAct medicalAct)
        {
            return DAL_MedicalAct.add(medicalAct);
        }
        public static List<MedicalAct> gets()
        {
            DalMigration.create_table_MedicalAct();
            DalMigration.create_table_MedicalRecordAct();
            
            return DAL_MedicalAct.gets();   
        }
        public static Message delete(int id)
        {
            return DAL_MedicalAct.delete(id);
        }
        public static MedicalAct getByID(int value)
        {
            return DAL_MedicalAct.getByID(value);
        }
        public static Message update(MedicalAct medicalAct)
        {
            return DAL_MedicalAct.update(medicalAct);
        }

        public static MedicalActPersonnaliser GetMedicalActPersonnaliser(int Id)
        {
            var v = new MedicalActPersonnaliser(Id);
            return v;
        }
    }
}
