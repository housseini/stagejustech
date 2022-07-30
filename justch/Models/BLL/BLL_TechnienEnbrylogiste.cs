using justch.Models;
using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.BLL
{
    public class BLL_TechnienEnbrylogiste
    {

        public static Message Add ( TechnienEnbrylogiste enbrylogiste ) {


            return DAL_TechnienEnbrylogiste.Add(enbrylogiste);


        }

        public static List<TechnienEnbrylogiste> Gets ( )
        {
            DalMigration.create_table_TechnienEnbrylogiste();
            return DAL_TechnienEnbrylogiste.Gets();
            }

        public static TechnienEnbrylogiste GetsbyId ( int Id )
        {
            return DAL_TechnienEnbrylogiste.GetsbyId(Id);
        }
        public static Message Update ( TechnienEnbrylogiste enbrylogiste )
        {
            return DAL_TechnienEnbrylogiste.Update(enbrylogiste);
        }

        public static Message Delete ( int id )
        {
            return DAL_TechnienEnbrylogiste.Delete(id);

        }

    }
}
