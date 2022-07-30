using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_DevenirEmbryon
    {
        public static Message Add(List<int> listenumero, string Devenir, int idculture)
        {
            return DAL_DevenirEmbryon.Add(listenumero,  Devenir,  idculture);
        }

        public static List<DevenirEmbryon> GetByIdTraitement(int Id)
        {
            return DAL_DevenirEmbryon.GETS(Id);
        }
        public static Message Update(List<int> listenumero, string Devenir, int idculture,int idcongelation,int idtransafert)
        {
            return DAL_DevenirEmbryon.Update(listenumero, Devenir, idculture, idcongelation, idtransafert);
        }


    }
}
