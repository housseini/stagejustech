using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.DAL;
using justch.Models.ENTITIES;

namespace justch.Models.BLL
{
    public class BLL_BilanEndocrinien
    {
        public static Message Add(BilanEndocrinien bilan)
        {
            return DAL_BilanEncodocrinien.Add(bilan);
        }
        public static List<BilanEndocrinien> Gets(int id)
        {
            return DAL_BilanEncodocrinien.Gets(id);
        }
        public static BilanEndocrinien GETbyID(int ID)
        {
            return DAL_BilanEncodocrinien.GETbyID(ID);
        }

        public static Message Update(BilanEndocrinien bilan)
        {
            return DAL_BilanEncodocrinien.Update(bilan);
        }

        public static Message Delete(int Id)
        {
            return DAL_BilanEncodocrinien.Delete(Id);
        }

    }
}
