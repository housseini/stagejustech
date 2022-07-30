using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_Document
    {
        public static Document get(DataRow dataRow) {
            Document document = new Document();
            document.Id = Int32.Parse(dataRow["Id"].ToString()) ;
            document.IdPatient = Int32.Parse(dataRow["IdPatient"].ToString());
            document.IdDossierMedical = Int32.Parse(dataRow["IdDossierMedical"].ToString());
            document.CodeDocumentType=(string)dataRow["CodeDocumentType"];
            if (string.IsNullOrEmpty(dataRow["Description"].ToString()))
                document.Description = "";
            else
                document.Description = (string)dataRow["Description"];
            if (string.IsNullOrEmpty(dataRow["Name"].ToString()))
                document.Name = "";
            else
                document.Name = (string)dataRow["Name"];
            if (string.IsNullOrEmpty(dataRow["Path"].ToString()))
                document.Path = "";
            else
                document.Path = (string)dataRow["Path"];
            return document;
                }
        public static List<Document> gets(DataTable table)
        {
            List<Document> documents = new List<Document>();
            foreach (DataRow dataRow in table.Rows)
                documents.Add(get(dataRow));
            return documents;
        }

        public static List<Document> getsBy(string Field,int value)
        {
            string query = "select * from Document where(IdPatient=@value); ";
            SqlConnection mycon = DbConnection.GetConnection();
            mycon.Open();
            SqlCommand cmd = new SqlCommand(query, mycon);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 50;

            cmd.Parameters.AddWithValue("@value", value) ;
            
            SqlDataReader reader= cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            mycon.Close();
            return gets(table);
        }
        public static List<Document> getsByIdDossier( int value)
        {
            string query = "select * from Document where(IdDossierMedical=@value); ";
            SqlConnection mycon = DbConnection.GetConnection();
            mycon.Open();
            SqlCommand cmd = new SqlCommand(query, mycon);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 50;


            cmd.Parameters.AddWithValue("@value", value);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            mycon.Close();
            return gets(table);
        }

        public static List<Document> getsBycode(string value)
        {
            string query = "select * from Document where(CodeDocumentType=@value); ";
            SqlConnection mycon = DbConnection.GetConnection();
            mycon.Open();
            SqlCommand cmd = new SqlCommand(query, mycon);
            cmd.CommandTimeout = 50;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@value", value);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            mycon.Close();
            return gets(table);
        }

        public static Document getsById(int value)
        {
            string query = "select * from Document where(Id=@value); ";
            SqlConnection mycon = DbConnection.GetConnection();
            mycon.Open();
            SqlCommand cmd = new SqlCommand(query, mycon);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 50;
            cmd.Parameters.AddWithValue("@value", value);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            mycon.Close();
            return get(table.Rows[0]);
        }


        public static Message Delete(int id)
        {
            try
            {
                string query = "delete Document where(Id=@value); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;


                cmd.Parameters.AddWithValue("@value", id);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Document supprimé"); 
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }
        public static Message DeletebyIddossier(int id)
        {
            try
            {
                string query = "delete Document where([IdDossierMedical]=@value); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;


                cmd.Parameters.AddWithValue("@value", id);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Document supprimé");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }

        public static Message Deletecodedocumentypee(string code)
        {
            try
            {
                string query = "delete Document where(CodeDocumentType=@value); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                cmd.Parameters.AddWithValue("@value", code);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Document supprimé");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }

        public static Message DeleteByidpatiene(int id)
        {
            try
            {
                string query = "delete Document where(IdPatient=@value); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                cmd.Parameters.AddWithValue("@value", id);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Document supprimé");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }
        public static Message add(Document document,int idpatient2)
        {
            try
            {
                string query = "insert into Document ( IdPatient,CodeDocumentType,IdDossierMedical,Name,Description,Path) Values (@IdPatient,@CodeDocumentType,@IdDossierMedical,@Name,@Description,@Path) ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;


                if (string.IsNullOrEmpty(document.IdPatient.ToString()))
                    cmd.Parameters.AddWithValue("@IdPatient", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdPatient", document.IdPatient);
                if (string.IsNullOrEmpty(document.IdDossierMedical.ToString()))
                    cmd.Parameters.AddWithValue("@IdDossierMedical", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdDossierMedical", document.IdDossierMedical);

                if (string.IsNullOrEmpty(document.CodeDocumentType))
                    cmd.Parameters.AddWithValue("@CodeDocumentType", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@CodeDocumentType", document.CodeDocumentType);

                if (string.IsNullOrEmpty(document.Name))
                    cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Name", document.Name);

                if (string.IsNullOrEmpty(document.Description))
                    cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Description", document.Description);
                if (string.IsNullOrEmpty(document.Path))
                    cmd.Parameters.AddWithValue("@Path", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Path", document.Path);
                cmd.ExecuteNonQuery();
                mycon.Close();

                if (idpatient2 != 0)
                {
                     query = "insert into Document ( IdPatient,CodeDocumentType,IdDossierMedical,Name,Description,Path) Values (@IdPatient,@CodeDocumentType,@IdDossierMedical,@Name,@Description,@Path) ";
                     mycon = DbConnection.GetConnection();
                    mycon.Open();
                    SqlCommand cmd1 = new SqlCommand(query, mycon);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandTimeout = 50;

                    if (string.IsNullOrEmpty(idpatient2.ToString()))
                        cmd1.Parameters.AddWithValue("@IdPatient", DBNull.Value);
                    else
                        cmd1.Parameters.AddWithValue("@IdPatient", idpatient2);
                    if (string.IsNullOrEmpty(document.IdDossierMedical.ToString()))
                        cmd1.Parameters.AddWithValue("@IdDossierMedical", DBNull.Value);
                    else
                        cmd1.Parameters.AddWithValue("@IdDossierMedical", document.IdDossierMedical);

                    if (string.IsNullOrEmpty(document.CodeDocumentType))
                        cmd1.Parameters.AddWithValue("@CodeDocumentType", DBNull.Value);
                    else
                        cmd1.Parameters.AddWithValue("@CodeDocumentType", document.CodeDocumentType);

                    if (string.IsNullOrEmpty(document.Name))
                        cmd1.Parameters.AddWithValue("@Name", DBNull.Value);
                    else
                        cmd1.Parameters.AddWithValue("@Name", document.Name);

                    if (string.IsNullOrEmpty(document.Description))
                        cmd1.Parameters.AddWithValue("@Description", DBNull.Value);
                    else
                        cmd1.Parameters.AddWithValue("@Description", document.Description);
                    if (string.IsNullOrEmpty(document.Path))
                        cmd1.Parameters.AddWithValue("@Path", DBNull.Value);
                    else
                        cmd1.Parameters.AddWithValue("@Path", document.Path);
                    cmd1.ExecuteNonQuery();
                    mycon.Close();

                }
                return new Message(true, "documment ajouté ");
            }
            catch(Exception e)
            {
               
                    return new Message(false, e.Message);
            }
        }
        public static Message update(Document document)
        {
            try
            {
                string query = "update Document set  IdPatient=@IdPatient,CodeDocumentType=@CodeDocumentType,IdDossierMedical=@IdDossierMedical,Name=@Name,Description=@Description,Path=@Path where(Id=@Id);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(document.Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", document.Id);

                if (string.IsNullOrEmpty(document.IdPatient.ToString()))
                    cmd.Parameters.AddWithValue("@IdPatient", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdPatient", document.IdPatient);
                if (string.IsNullOrEmpty(document.IdDossierMedical.ToString()))
                    cmd.Parameters.AddWithValue("@IdDossierMedical", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdDossierMedical", document.IdDossierMedical);

                if (string.IsNullOrEmpty(document.CodeDocumentType))
                    cmd.Parameters.AddWithValue("@CodeDocumentType", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@CodeDocumentType", document.CodeDocumentType);

                if (string.IsNullOrEmpty(document.Name))
                    cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Name", document.Name);

                if (string.IsNullOrEmpty(document.Description))
                    cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Description", document.Description);
                if (string.IsNullOrEmpty(document.Path))
                    cmd.Parameters.AddWithValue("@Path", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Path", document.Path);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "documment modifié ");
            }
            catch (Exception e)
            {

                return new Message(false, e.Message);
            }
        }

        public static int CountDocumentbyIdDossier (int IdDOOSSIER )
        {
            try
            {
                string query = "SELECT COUNT(*) From Document WHERE(IdDossierMedical=@IdDOOSSIER);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                cmd.Parameters.AddWithValue("IdDOOSSIER", IdDOOSSIER);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                mycon.Close();
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
    }


}
