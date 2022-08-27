using justch.Models.DAL;
using System.Collections.Generic;

namespace justch.Models.ENTITIES
{
    public class CultureComplet
    {
        public int IdTraitement { get; set; }
        public MedicalRecordAct MedicalRecordAct { get; set; }
        public ActDataCulture ActDataCulture {get; set;}
        public ActDataTransfertsEnbryonnaire ActDataTransfertsEnbryonnaire { get; set; }
        public ActDataPonction ActDataPonction { get; set; }
        public ActDataPreparationSperme ActDataPreparationSperme { get; set; }
        public ActDataDecoronisation actDataDecoronisation { get; set; }
        public ActDataInjection  actDataInjection { get; set; }
        public List<CulureOvocyteData> cuturesData { get; set; }
        public   List<ActDataDecoronisationOvocyteData> dataDecoronisationOvocyteDatas { get; set; }
        public List<DevenirEmbryon> devenirEmbryons { get; set; }
        public ActDataCongelationEnbryonnaire ActDataCongelationEnbryonnaire { get; set; }
        public List<EnbryonnaireCongelationData>  enbryonnaireCongelationDatas { get; set; }
        public List<EnbryonTransfertData> EnbryonTransfertDatas { get; set; }
        public List<Utilisateur> Enbryologistes { get; set; }   
        public List<Cuve> cuves { get; set; }
        public List<Visotube> visotubes { get; set; }
        public List<Paillette> paillettes { get; set; } 
        public MedicalReport MedicalReport { get; set; }

        public ActDataInseminationIAC actDataInsemination { get; set; }
        public ActDataCongelationSperme ActDataCongelationSperme { get; set; }
        public ActDataBiopsie ActDataBiopsies { get; set; }
        public CultureComplet(int idtraitement ) {
            this.IdTraitement = idtraitement;
            this.ActDataCulture = new ActDataCulture();
            this.ActDataCongelationEnbryonnaire = new ActDataCongelationEnbryonnaire();
            this.actDataDecoronisation = new ActDataDecoronisation();
            this.Enbryologistes = new List<Utilisateur>();
            this.MedicalRecordAct = new MedicalRecordAct();
            if (DAL_MedicalRecordAct.getBYiD(idtraitement) != null)
            {
                this.MedicalRecordAct = DAL_MedicalRecordAct.getBYiD(idtraitement);
            }

            if (DAL_ActDataCulture.GETS(IdTraitement).Count != 0)
            {
                this.ActDataCulture = DAL_ActDataCulture.GETS(this.IdTraitement)[0];
                this.cuturesData = new List<CulureOvocyteData>();
                this.cuturesData = DAL_CulureOvocyteData.GETS(this.ActDataCulture.Id);
            }
            else
            {
                this.ActDataCulture = null; this.cuturesData=null;
            }
                if (DAL_ActDataDecoronisation.GETS(IdTraitement).Count !=0 )
                {

               
                this.actDataDecoronisation = DAL_ActDataDecoronisation.GETS(IdTraitement)[0];
                this.dataDecoronisationOvocyteDatas = new List<ActDataDecoronisationOvocyteData>();
                this.dataDecoronisationOvocyteDatas = DAL_ActDataDecoronisationOvocyteData.GETS(this.actDataDecoronisation.Id);
                this.devenirEmbryons = new List<DevenirEmbryon>();
                this.devenirEmbryons = DAL_DevenirEmbryon.GETS(this.ActDataCulture.Id);
                }
                else
                {

                    this.actDataDecoronisation = null; 
                    this.dataDecoronisationOvocyteDatas = null; 
                    this.devenirEmbryons = null; 

                }
                if (DAL_ActDataCongelationEnbryonnaire.GETS(IdTraitement).Count != 0)
                {
                    this.enbryonnaireCongelationDatas = new List<EnbryonnaireCongelationData>();
                    this.ActDataCongelationEnbryonnaire = DAL_ActDataCongelationEnbryonnaire.GETS(this.IdTraitement)[0];
                    this.enbryonnaireCongelationDatas = DAL_EnbryonnaireCongelationData.GETS(this.ActDataCongelationEnbryonnaire.Id);
                    this.cuves = new List<Cuve>();
                    this.visotubes = new List<Visotube>();
                    this.paillettes = new List<Paillette>();
                    this.cuves = DAL_Cuve.GETS();
                    this.visotubes = DAL_Visotube.GETS();
                    this.paillettes = DAL_Paillette.GETS();
                    this.Enbryologistes = DAL_Utilisateur.GetUtilisateursEnbrologite();
                }
            else
            {
                this.enbryonnaireCongelationDatas = null;
                this.ActDataCongelationEnbryonnaire = null;

            }
                if (DAL_ActDataPonction.GETS(idtraitement).Count != 0)
                {
                    this.ActDataPonction = new ActDataPonction();
                    this.ActDataPonction = DAL_ActDataPonction.GETS(idtraitement)[0];
                }

                if (DAL_ActDataPreparationSperme.GETS(IdTraitement).Count != 0)
                {
                    this.ActDataPreparationSperme = new ActDataPreparationSperme();
                    this.ActDataPreparationSperme = DAL_ActDataPreparationSperme.GETS(IdTraitement)[0];

                }
                if (DAL_ActDataInjection.GETS(idtraitement).Count != 0)
                {
                    this.actDataInjection=new ActDataInjection();
                    this.actDataInjection = DAL_ActDataInjection.GETS(idtraitement)[0];
                }
                if (DAL_ActDataTransfertsEnbryonnaire.GETS(idtraitement).Count != 0)
                {
                    this.ActDataTransfertsEnbryonnaire = new ActDataTransfertsEnbryonnaire();
                    this.ActDataTransfertsEnbryonnaire = DAL_ActDataTransfertsEnbryonnaire.GETS(idtraitement)[0];

                    this.EnbryonTransfertDatas = new List<EnbryonTransfertData>();
                    this.EnbryonTransfertDatas = DAL_EnbryonTransfertData.GETS(this.ActDataTransfertsEnbryonnaire.Id);
                }

            if (DAL_ActDataInseminationIAC.GETS(idtraitement).Count != 0)
            {
                this.actDataInsemination = new ActDataInseminationIAC();
                this.actDataInsemination = DAL_ActDataInseminationIAC.GETS(idtraitement)[0];


            }
            else
            {
                this.actDataInsemination = null;
            }

            if (DAL_ActDataCongelationSperme.GETS(idtraitement).Count != 0)
            {
                this.ActDataCongelationSperme = new ActDataCongelationSperme();
                this.ActDataCongelationSperme = DAL_ActDataCongelationSperme.GETS(idtraitement)[0];
            }
            else
            {
                this.ActDataCongelationSperme = null;

            }
            if (DAL_MedicalReport.GETS(idtraitement).Count != 0)
            {
                this.MedicalReport=new MedicalReport();
                this.MedicalReport = DAL_MedicalReport.GETS(idtraitement)[0];
            }
            else
            {
                this.MedicalReport = null;
            }

            if (DAL_ActDataBiopsie.GETS(idtraitement).Count != 0)
            {
                this.ActDataBiopsies =  new ActDataBiopsie();
                this.ActDataBiopsies = DAL_ActDataBiopsie.GETS(this.MedicalRecordAct.Id)[0];

            }
            else
            {

                this.ActDataBiopsies = null;
            }

            }
   
        
    }
}
