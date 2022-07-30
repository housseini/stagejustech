using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.BLL
{
    public class BLL_Room
    {
        public static Message Add ( Room room )
        {
            return DAL_Room.Add(room);
        }

        public static List<Room> Gets ( )
        {
            DalMigration.create_table_Room();
            return DAL_Room.Gets();
        }
        public static Message delete ( int id )
        {
            return DAL_Room.delete(id);
        }
         public static Room GetByID(int id )
        {
            return DAL_Room.GetByID(id);
        }
        public static Message Update(Room room)
        {
            return DAL_Room.Update(room);
        }
    }
}
