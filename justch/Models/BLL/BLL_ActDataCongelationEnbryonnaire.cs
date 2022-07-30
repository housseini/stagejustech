using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataCongelationEnbryonnaire
    {

        public static Message Add(List<int> listenumero, int IdMedicalRecordAct, int IdEnbryologisteDoctor, string Date, string heur, string sang, string glaire, string Mileu, string com, int IdPaillete, string Jours, int idculture)
        {
            return DAL_ActDataCongelationEnbryonnaire.Add( listenumero,  IdMedicalRecordAct,  IdEnbryologisteDoctor,  Date,  heur,  sang,  glaire,  Mileu,  com,   IdPaillete,  Jours,  idculture);
        }

        public static List<ActDataCongelationEnbryonnaire> GetByIdTraitement(int Id)
        {
            return DAL_ActDataCongelationEnbryonnaire.GETS(Id);
        }
        public static Message Update(ActDataCongelationEnbryonnaire actData)
        {
            return DAL_ActDataCongelationEnbryonnaire.Update(actData);
        }
    }
}
