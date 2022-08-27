using System.Collections.Generic;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_BACKUP_Programmer
    {
        public static Message Add(BACKUP_Programmer bACKUP_Programmer)
        {
            return DAL_BACKUP_Programmer.Add(bACKUP_Programmer);
        }
        public static List<BACKUP_Programmer> GETS()
        {
            return DAL_BACKUP_Programmer.GETS();
        }
    }
}
