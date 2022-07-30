using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_DossierMedical
    {
        public static DossierMedical GetDossierMedical(DataRow dataRow)
        {
            DossierMedical dossier=new DossierMedical();
            dossier.Id = Int32.Parse(dataRow["Id"].ToString());
            if (dataRow["Reference"] == DBNull.Value) { dossier.Reference = null; }
            else { dossier.Reference = (string)dataRow["Reference"]; }
            if (dataRow["DateAdmission"] == DBNull.Value) {  }
            else {dossier.DateAdmission= (dataRow["DateAdmission"].ToString()); }
            if (dataRow["DateCreation"] == DBNull.Value) { }
            else { dossier.DateCreation = DateTime.Parse(dataRow["DateCreation"].ToString()); }
            if (dataRow["Type"] == DBNull.Value) { dossier.Type = null; }
            else { dossier.Type = (string)dataRow["Type"]; }
            if (dataRow["State"] == DBNull.Value) { dossier.State = null; }
            else { dossier.State  = (string)dataRow["State"]; }

            return  dossier;
        }
        public static List<DossierMedical> Get_list_Dossier(DataTable tab) {
            List<DossierMedical> dossiers = new List<DossierMedical>();
            foreach (DataRow row in tab.Rows) {
              
                dossiers.Add(GetDossierMedical(row));

            }
            return dossiers;
        }
        public static  Message AddDossierMedical(DossierMedical d,int  Idpatient )
        {
            try {

                
                    string query = "insert into DossierMedical(Reference,Type,State)values(@Reference,@Type,@State);";
                    SqlConnection mycon = DbConnection.GetConnection();
                    mycon.Open();
                    SqlCommand cmd = new SqlCommand(query, mycon);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(d.Reference))
                        cmd.Parameters.AddWithValue("@Reference", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Reference", d.Reference);
                    
                    if (string.IsNullOrEmpty(d.Type))
                        cmd.Parameters.AddWithValue("@Type", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Type", d.Type);
                    if (string.IsNullOrEmpty(d.State))
                        cmd.Parameters.AddWithValue("@State", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@State", d.State);
                    cmd.ExecuteNonQuery();
                     mycon.Close();
                DossierMedicalPatient dossierMedicalPatient = new DossierMedicalPatient();
                    dossierMedicalPatient.IdPatient = Idpatient;
                    dossierMedicalPatient.IdDossierMedical = GetDossierMedicalbyReference(d.Reference).Id;
                    DAL_DossierMedicalPatient.AddDossierMedicalPatient(dossierMedicalPatient);
                    return new Message(true, "dossier medical ajouter avec success");
              
                

                
               
                

            

               
            }
            catch(Exception e)
            {
                if (e.Message.Contains("Violation of UNIQUE KEY"))
                    return new Message(false,"cette reference du  dossier existe deja");
                else
                    return new Message(false, e.Message);

            }
           
        }
        public static List<DossierMedical> GetDossiersMedicals()
        {
          try
            {
                string query = "SELECT *FROM DossierMedical ORDER BY Id DESC; ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                cmd.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                mycon.Close();
                return Get_list_Dossier(dataTable);
            }catch (Exception e)
            {
                return null; 
            }
        }
        public static DossierMedical GetDossierMedicalbyReference( string Reference)
        {
            try
            {
                string query = "SELECT *FROM DossierMedical where(Reference=@Reference); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(Reference))
                    cmd.Parameters.AddWithValue("@Reference", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Reference", Reference);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                mycon.Close();
                return GetDossierMedical(dataTable.Rows[0]);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
        public static DossierMedical GetDossierMedicalbyID(int Reference)
        {
            try
            {

                string query = "SELECT *FROM DossierMedical where(Id=@Reference); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(Reference.ToString()))
                    cmd.Parameters.AddWithValue("@Reference", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Reference", Reference);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                mycon.Close();
                return GetDossierMedical(dataTable.Rows[0]);
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public static Message deleteDossierMedical(string Field, string value)
        {
            try
            {
                string query = "delete from DossierMedical where(Id=@value);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(value))
                    cmd.Parameters.AddWithValue("@value", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@value", value);

                cmd.ExecuteNonQuery();
                mycon.Close();
                DAL_MedicalRecordAct.deleteDossierMedical(Int32.Parse(value));
                DAL_Document.DeletebyIddossier(Int32.Parse( value));
                return DAL_DossierMedicalPatient.deleteDossierMedicalPatient("IdDossierMedical", value);
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);

            }

        }
        public static Message updateDossierMedical(DossierMedical d, DossierMedicalPatient dmp)
        {
            try
            {
                string query = "update  DossierMedical set Reference=@Reference, Type=@Type,State=@State where(Id=@Id);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(d.Reference))
                    cmd.Parameters.AddWithValue("@Reference", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Reference", d.Reference);

                if (string.IsNullOrEmpty(d.Type))
                    cmd.Parameters.AddWithValue("@Type", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Type", d.Type);
                if (string.IsNullOrEmpty(d.State))
                    cmd.Parameters.AddWithValue("@State", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@State", d.State);
                if (string.IsNullOrEmpty(d.Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", d.Id);
                cmd.ExecuteNonQuery();
                mycon.Close();
                DAL_DossierMedicalPatient.AddDossierMedicalPatient(dmp);







                return new Message(true, "dossier medical modifier avec success");
            }
            catch (Exception e)
            {

                if (e.Message.Contains("Violation of UNIQUE KEY constraint 'UQ__DossierM__062B9EB8B3B6D036'"))
                    return new Message(false, "cette reference du  dossier existe deja");
                else
                    return new Message(false, e.Message);

            }
        }
        public static Message updateDossierMedical ( DossierMedical d)
        {
            try
            {
                string query = "update  DossierMedical set Reference=@Reference, Type=@Type,State=@State where(Id=@Id);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(d.Reference))
                    cmd.Parameters.AddWithValue("@Reference", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Reference", d.Reference);

                if (string.IsNullOrEmpty(d.Type))
                    cmd.Parameters.AddWithValue("@Type", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Type", d.Type);
                if (string.IsNullOrEmpty(d.State))
                    cmd.Parameters.AddWithValue("@State", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@State", d.State);
                if (string.IsNullOrEmpty(d.Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", d.Id);
                cmd.ExecuteNonQuery();
                mycon.Close();
              







                return new Message(true, "dossier medical modifier avec success");
            }
            catch (Exception e)
            {

                if (e.Message.Contains("Violation of UNIQUE KEY constraint 'UQ__DossierM__062B9EB8B3B6D036'"))
                    return new Message(false, "cette reference du  dossier existe deja");
                else
                    return new Message(false, e.Message);

            }
        }
        public static DataTable RechercherAvance(int Id ,string Cin,string Ref, DateTime dataa,string email,string telephone,int nombre)

        {
            
            DateTime datDIN = dataa.AddDays(-nombre);
            DateTime dat = dataa.AddDays(nombre);
           
            string queri = "select dmp.IdDossierMedical,dm.State,dm.Type,dm.DateAdmission ,dm.Reference ,dm.DateCreation from (( DossierMedical dm     INNER JOIN   DossierMedicalPatient dmp   on  (dmp.IdDossierMedical=dm.Id) ) INNER JOIN Patient ON (Patient.Id=dmp.IdPatient )) WHERE (Patient.Email =@email OR Patient.Phone=@telephone OR Patient.Cin=@Cin OR dm.Reference=@Ref  or Patient.Id=@Id or ( dm.DateCreation between  @dataa and @dat)) ;";
            SqlConnection conn =DbConnection.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(queri, conn);
            cmd.CommandTimeout = 50;
            cmd.CommandType = CommandType.Text;
            if (string.IsNullOrEmpty(Id.ToString()))
                cmd.Parameters.AddWithValue("@Id", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Id", Id);

            if (string.IsNullOrEmpty(Cin))
                cmd.Parameters.AddWithValue("@Cin", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Cin", Cin);

            if (string.IsNullOrEmpty(Ref))
                cmd.Parameters.AddWithValue("@Ref", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Ref", Ref);


            string t = dataa.ToString();
            if (t.Contains("01/01/0001"))
                cmd.Parameters.AddWithValue("@dataa", "01-01-2000"); 
            else
                cmd.Parameters.AddWithValue("@dataa", datDIN);

            if (string.IsNullOrEmpty(email))
                cmd.Parameters.AddWithValue("@email", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@email", email);

            if (string.IsNullOrEmpty(telephone))
                cmd.Parameters.AddWithValue("@telephone", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@telephone", telephone);
           
            if (t.Contains("01/01/0001"))
                cmd.Parameters.AddWithValue("@dat", "01-01-2000");
            else
                cmd.Parameters.AddWithValue("@dat", dat);



            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            conn.Close();
            return (dt);




        }
        public static int Count ( )
        {
            try
            {
                string query = "SELECT SUM(Id) From DossierMedical;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
              
                if (sqlDataReader.Read())
                {
                   
                    return Int32.Parse(sqlDataReader[0].ToString());
                }
                else
                {
                    return 0;
                }


            }
            catch 
            {
                return 0;
            }
        }
        public static Message completer ( int Id )
        {
            try
            {

                string query = "update  DossierMedical set  State='complet' ,DateAdmission=(getdate())  where(Id=@Id);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;

                if (string.IsNullOrEmpty(Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "dossier medical completer avec success");


                //if (DAL_Document.CountDocumentbyIdDossier(Id)!=0)
                //{


                //    string query = "update  DossierMedical set  State='complet' ,DateAdmission=(getdate())  where(Id=@Id);";
                //    SqlConnection mycon = DbConnection.GetConnection();
                //    mycon.Open();
                //    SqlCommand cmd = new SqlCommand(query, mycon);
                //    cmd.CommandType = CommandType.Text;

                //    if (string.IsNullOrEmpty(Id.ToString()))
                //        cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                //    else
                //        cmd.Parameters.AddWithValue("@Id", Id);
                //    cmd.ExecuteNonQuery();
                //    mycon.Close();
                //    return new Message(true, "dossier medical completer avec success");
                //}
                //else
                //{
                //    return new Message(false, "cet dossier ne peut pas etre modifier il ne contient aucum Document ajouter au moins un documment  ");
                //}

            }
            catch (Exception e)
            {

                return new Message(false, e.Message);

            }
        }
        

             public static Message InCompleter(int Id)
        {
            try
            {
                //if (DAL_Document.CountDocumentbyIdDossier(Id) != 0)
                //{


                    string query = "update  DossierMedical set  State='Incomplet' ,DateAdmission=NULL  where(Id=@Id);";
                    SqlConnection mycon = DbConnection.GetConnection();
                    mycon.Open();
                    SqlCommand cmd = new SqlCommand(query, mycon);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 50;

                if (string.IsNullOrEmpty(Id.ToString()))
                        cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                    mycon.Close();
                    return new Message(true, "dossier medical incompleter avec success");
                //}
                //else
                //{
                //    return new Message(false, "cet dossier ne peut pas etre modifier il ne contient aucum Document ajouter au moins un documment  ");
                //}

            }
            catch (Exception e)
            {

                return new Message(false, e.Message);

            }
        }


    }
}