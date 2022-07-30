using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.BLL
{
    public class BLL_DossierMedicalPersonniser
    {
        public static DossierMedicalPersonniser get(int ID )
        {
            return new DossierMedicalPersonniser(ID);
        }
    }
}
