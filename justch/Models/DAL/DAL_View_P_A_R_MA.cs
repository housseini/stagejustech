using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_View_P_A_R_MA
    {

        public static DataTable Gets ( )
        {
            string query = "select  ap.Date ,ap.Hour1 ,ap.Hour2, pa.FirstName ,pa.LastName,ro.Name,meA.Duration ,meA.Name  from Appointment ap,Room ro,Patient pa,MedicalAct meA  where((ap.IdMedicalAct2=pa.Id oR ap.IdPatient1=pa.Id) AND ( ap.IdRoom1=ro.Id or ap.IdRoom2=ro.Id) AND (ap.IdMedicalAct1=meA.Id or ap.IdMedicalAct2=meA.Id));";
            SqlConnection conn = DbConnection.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader(); 
            DataTable table = new DataTable();
            table.Load(reader);
            conn.Close();
            return table;
        }
    }
}
