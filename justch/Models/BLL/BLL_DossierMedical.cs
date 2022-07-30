using justch.Models.DAL;
using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;

namespace justch.Models.BLL
{
    public class BLL_DossierMedical
    {
        public static List<DossierMedical> GetDossiersMedicals()
        {
            DalMigration.create_table_DossierMedicale();
            DalMigration.create_table_DossierMedicalPatient();
            return DAL_DossierMedical.GetDossiersMedicals();
        }
        public static Message AddDossierMedical(DossierMedical d, int p)
        {
            return DAL_DossierMedical.AddDossierMedical(d, p);
        }
        public static DossierMedical GetDossierMedicalbyReference(string Reference)
        {
            return DAL_DossierMedical.GetDossierMedicalbyReference(Reference);
        }
        public static Message deleteDossierMedical(string Field, string value)
        {
            return DAL_DossierMedical.deleteDossierMedical(Field, value);
        }
        public static DossierMedical GetDossierMedicalbyID(int Reference)
        {
            return DAL_DossierMedical.GetDossierMedicalbyID(Reference);
        }
        public static Message updateDossierMedical(DossierMedical d, DossierMedicalPatient dp)
        {
            return DAL_DossierMedical.updateDossierMedical(d, dp);
        }

        public static Message updateDossierMedical ( DossierMedical d )
        {
            return DAL_DossierMedical.updateDossierMedical(d);
        }
        // cette fonction car retourr le dossier medical patient car on a pas une couche BLL_DossierMedicalPatient
        public static DossierMedicalPatient GetDossierMedicalPatient(int IdDossierMedical)
        {
            return DAL_DossierMedicalPatient.GetDossierMedicalPatient(IdDossierMedical);
        }

        public static DataTable RechercherAvance(int Id, string Cin, string Ref, DateTime dataa, string email, string telephone,int nbr)
        {
            return DAL_DossierMedical.RechercherAvance(Id, Cin, Ref, dataa, email, telephone, nbr);
        }
        public static int Count ( )
        {
            return DAL_DossierMedical.Count();
        }
        public static Message completer ( int Id )
        {
            return DAL_DossierMedical.completer(Id);
        }

        public static Message InCompleter(int Id)
        {
            return DAL_DossierMedical.InCompleter(Id);
        }

    }
}
