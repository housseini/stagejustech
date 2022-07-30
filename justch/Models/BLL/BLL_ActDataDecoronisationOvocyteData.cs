using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataDecoronisationOvocyteData
    {
        public static Message Add(ActDataDecoronisationOvocyteData actData)
        {
            return DAL_ActDataDecoronisationOvocyteData.Add(actData);
        }

        public static List<ActDataDecoronisationOvocyteData> GetByIdTraitement(int Id)
        {
            return DAL_ActDataDecoronisationOvocyteData.GETS(Id);
        }
        public static Message Update(List<int> listenumero, string etat, string commantaire, int Iddeco)
        {
            return DAL_ActDataDecoronisationOvocyteData.Update(listenumero,etat,commantaire,Iddeco);
        }

    }
}
