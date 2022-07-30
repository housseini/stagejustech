using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataTransfertsEnbryonnaire
    {
        public static Message Add(List<int> listenumero, int IdMedicalRecordAct, int IdEnbryologisteDoctor, string Date, string heur, string sang, string glaire, string cathere, string transfer, string com, string nombreembroyontr, string Jours, int IdDoctor,int idculture)
        {
            return DAL_ActDataTransfertsEnbryonnaire.Add( listenumero,  IdMedicalRecordAct,  IdEnbryologisteDoctor,  Date,  heur,  sang,  glaire,  cathere,  transfer,  com,  nombreembroyontr,  Jours,IdDoctor,idculture);
        }

        public static List<ActDataTransfertsEnbryonnaire> GetByIdTraitement(int Id)
        {
            return DAL_ActDataTransfertsEnbryonnaire.GETS(Id);
        }
        public static Message Update(ActDataTransfertsEnbryonnaire actData)
        {
            return DAL_ActDataTransfertsEnbryonnaire.Update(actData);
        }
    }
}
