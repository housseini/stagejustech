using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_ActDataPreparationSperme
    {
        public static Message Add(ActDataPreparationSperme actData)
        {
            return DAL_ActDataPreparationSperme.Add(actData);
        }

        public static List<ActDataPreparationSperme> GetByIdTraitement(int Id)
        {
            return DAL_ActDataPreparationSperme.GETS(Id);
        }
        public static Message Update(ActDataPreparationSperme actData)
        {
            return DAL_ActDataPreparationSperme.Update(actData);
        }
    }
}
