using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.BLL
{
    public class BLL_Doctor
    {
        public static Message add(Doctor doctor)
        {
            return DAL_Doctor.add(doctor);     
        }
        public static Message Delete(int id)
        {
            return DAL_Doctor.Delete(id);
        }
        public static List<Doctor> gets()
        {
            DalMigration.create_table_Doctor();
            return DAL_Doctor.gets();
        }
        public static Doctor getBy(int id)
        {
            return DAL_Doctor.getBy(id);
        }
        public static Message update(Doctor doctor)
        {
            return DAL_Doctor.update(doctor);
        }
    }
}
