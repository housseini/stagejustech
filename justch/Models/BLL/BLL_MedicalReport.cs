using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.BLL
{
    public class BLL_MedicalReport
    {
        public static Message Add(MedicalReport actData)
        {
            return DAL_MedicalReport.Add(actData);
        }
        public static List<MedicalReport> GETS(int Id)
        {
            return DAL_MedicalReport.GETS(Id);
        }
        public static Message Regernere(int Id)
        {
            return Regernere(Id);
        }
    }
}
