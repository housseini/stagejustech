using justch.Models.BLL;
using justch.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class DossierMedicalPersonniser
    {
        public DossierMedical dossierMedical { get; set; }
        public List<Patient> patients { get; set; }
        public List<Document> documents { get; set; }
        public DossierMedicalPatient DossierMedicalPatient { get; set; }
        public  List< MedicalRecordAct >MedicalRecordActs { get; set; }
        public List<Doctor> doctors { get; set; }
        public List<TechnienEnbrylogiste> technienEnbrylogistes { get; set; }
        public List<EnbryonnaireCongelationData> enbryonnaireCongelationDatas { get; set; }
        public List<ActDataCongelationEnbryonnaire> actDataCongelationEnbryonnaires { get; set; }
        public DossierMedicalPersonniser( int IdDossier)
        {
            this.technienEnbrylogistes = new List<TechnienEnbrylogiste>();
            this.technienEnbrylogistes = BLL_TechnienEnbrylogiste.Gets();
            this.enbryonnaireCongelationDatas = new List<EnbryonnaireCongelationData>();
            this.actDataCongelationEnbryonnaires = new List<ActDataCongelationEnbryonnaire>();
            var DM = DAL_DossierMedical.GetDossierMedicalbyID(IdDossier);
            if (DM!=null)
                this.dossierMedical = DM;
            var P= DAL_View_P_DMP_DM.Get_list_Patient_forDossier(IdDossier);
            if (P != null)
                this.patients = P;
             var doc = DAL_Document.getsByIdDossier(IdDossier);
            if (doc != null)
                this.documents = doc;

            var dmp = DAL_DossierMedicalPatient.GetDossierMedicalPatientByIdDossier(IdDossier);
            if (dmp != null)
                this.DossierMedicalPatient = dmp;
            var MRA = DAL_MedicalRecordAct.getsByIdMedicalRecord( IdDossier);
            if (MRA != null)
                this.MedicalRecordActs = MRA;

            if (this.MedicalRecordActs != null)
            {
                this.doctors = new List<Doctor>();
                foreach (MedicalRecordAct medical in this.MedicalRecordActs)
                {
                    var doctor = DAL_Doctor.getBy(medical.IdPrescribingDoctorMedical);
                    if (doctor != null)
                        this.doctors.Add(doctor);
                }    
            }

            if (this.MedicalRecordActs != null)
            {
                foreach(MedicalRecordAct MedicalRecordActss in this.MedicalRecordActs)
                {
                    if(MedicalRecordActss.MedicalActName=="Congélation de Enbryonnaire")
                    {
                        var tes = BLL_ActDataCongelationEnbryonnaire.GetByIdTraitement(MedicalRecordActss.Id);
                        if (tes != null)
                        {
                            this.actDataCongelationEnbryonnaires.Add(BLL_ActDataCongelationEnbryonnaire.GetByIdTraitement(MedicalRecordActss.Id)[0]);

                            var enb = BLL_EnbryonnaireCongelationData.GetByIdTraitement(tes[0].Id);
                            if (enb != null)
                                this.enbryonnaireCongelationDatas.Add(enb[0]);



                        }

                    }
                }

            }


        }


    }
}
