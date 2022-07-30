using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{     public class ActDataPreparationSperme
    {
        public int Id { get; set; }
        public int IdMedicalRecordAct { get; set; }
        public int IdAnalyseInitialeEnbryologiste { get; set; }
        public string SpermeDate { get; set; }
        public string SpermeOrigine  { get; set; }
        public string SpermeMilieu { get; set; }
        public string SpermePreparation { get; set; }
        public string SpermeRecueil { get; set; }
        public string SpermeCommentaire  { get; set; }
        public string AnalyseInitialeHeure { get; set; }
        public string AnalyseInitialJoursAbstinence { get; set; }
        public string AnalyseInitialeAspect  { get; set; }
        public string AnalyseInitialeVolume { get; set; }
        public string AnalyseInitialeViscosite { get; set; }
        public string AnalyseInitialeLiquefaction { get; set; }
        public string AnalyseInitialeMorphologie { get; set; }
        public string AnalyseInitialeLeucocytes { get; set; }
        public string AnalyseInitialeCelluleRondes { get; set; }
        public string AnalyseInitialeCelluleEpitheliales { get; set; }
        public string AnalyseInitialeAgglutination { get; set; }
        public string AnalyseInitialeMobilite { get; set; }
        public string AnalyseInitialeConcentration { get; set; }
        public string AnalyseInitialeCommentaires { get; set; }
        public int ApresTraitementVolumeTraite { get; set; }
        public int ApresTraitementVolumeFinal { get; set; }
        public int ApresTraitementVolumeMobilite { get; set; }
        public int ApresTraitementVolumeConcentration { get; set; }
        public int ApresTraitementVolumeCommentaireFinal { get; set; }
        public int ApresTraitementNumerationTotaleTd { get; set; }
        public string ApresTraitementCommentaire  { get; set; }

    }
}
