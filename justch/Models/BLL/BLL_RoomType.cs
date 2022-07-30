using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.BLL
{
    public class BLL_RoomType
    {
        public static Message Add(RoomType RoomType)
        {
            DalMigration.create_table_RoomType();
            return DAL_RoomType.Add(RoomType);
        }
        public static List<RoomType> Gets()
        {
            return DAL_RoomType.Gets();
        }
        public static Message delete ( int id )
        {
            return DAL_RoomType.delete(id);
        }
        public static Message Update ( RoomType RoomType )
        {
            return DAL_RoomType.Update(RoomType);
        }
        public static List<RoomType> GetsBy(int Value)
        {
            return DAL_RoomType.GetsBy(Value);
        }
        public static RoomType GetsByNom(string Value)
        {
            return DAL_RoomType.GetsByNom(Value);
        }
        }
}
