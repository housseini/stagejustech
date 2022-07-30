using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;
using System.Data;

namespace justch.Models.BLL
{
    public class BLL_View_P_DMP_DM
    {
        public static List<DossierMedical> GetDossierMedicalesByIdPatient(int id)
        {
            return DAL_View_P_DMP_DM.GetDossierMedicalesByIdPatient(id);
        }
        public static List<Patient_Dossier_> Get_list_Patient(int Reference)
        {
            return DAL_View_P_DMP_DM.patient_Dossier_s(Reference);
        }
    }
}

