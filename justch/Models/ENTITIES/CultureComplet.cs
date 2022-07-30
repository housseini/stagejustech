using justch.Models.DAL;
using System.Collections.Generic;

namespace justch.Models.ENTITIES
{
    public class CultureComplet
    {
        public int IdTraitement { get; set; }
        public ActDataCulture ActDataCulture {get; set;}
        public ActDataDecoronisation actDataDecoronisation { get; set; }
        public List<CulureOvocyteData> cuturesData { get; set; }
        public   List<ActDataDecoronisationOvocyteData> dataDecoronisationOvocyteDatas { get; set; }
        public List<DevenirEmbryon> devenirEmbryons { get; set; }
        public ActDataCongelationEnbryonnaire ActDataCongelationEnbryonnaire { get; set; }
        public List<EnbryonnaireCongelationData>  enbryonnaireCongelationDatas { get; set; }

        public List<Utilisateur> Enbryologistes { get; set; }   
        public List<Cuve> cuves { get; set; }
        public List<Visotube> visotubes { get; set; }
        public List<Paillette> paillettes { get; set; } 
        public CultureComplet(int idtraitement ) {
            this.IdTraitement = idtraitement;
            this.ActDataCulture = new ActDataCulture();
            this.ActDataCongelationEnbryonnaire = new ActDataCongelationEnbryonnaire();
            this.actDataDecoronisation = new ActDataDecoronisation();
            this.Enbryologistes = new List<Utilisateur>();
            if (DAL_ActDataCulture.GETS(IdTraitement).Count !=0){
                this.ActDataCulture = DAL_ActDataCulture.GETS(this.IdTraitement)[0];
                this.cuturesData = new List<CulureOvocyteData>();
                this.cuturesData = DAL_CulureOvocyteData.GETS(this.ActDataCulture.Id);
                if (DAL_ActDataDecoronisation.GETS(IdTraitement).Count !=0 )
                {

               
                this.actDataDecoronisation = DAL_ActDataDecoronisation.GETS(IdTraitement)[0];
                this.dataDecoronisationOvocyteDatas = new List<ActDataDecoronisationOvocyteData>();
                this.dataDecoronisationOvocyteDatas = DAL_ActDataDecoronisationOvocyteData.GETS(this.actDataDecoronisation.Id);
                this.devenirEmbryons = new List<DevenirEmbryon>();
                this.devenirEmbryons = DAL_DevenirEmbryon.GETS(this.ActDataCulture.Id);
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
            }
   
        }
    }
}
