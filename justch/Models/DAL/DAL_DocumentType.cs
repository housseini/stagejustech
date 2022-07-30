using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_DocumentType
    {
        public static DocumentType get(DataRow row)
        {
            DocumentType documentType = new DocumentType();
            documentType.Code = (string)row["Code"];
            if (string.IsNullOrEmpty((string)row["Label"]))
                documentType.Label = "";
            else
                documentType.Label = (string)row["Label"];


            return documentType;
        }
        public static List<DocumentType> gets(DataTable DataTable)
        {
            List<DocumentType> list = new List<DocumentType>();
            foreach (DataRow row in DataTable.Rows)
                list.Add(get(row));
            return list;

        }
        public static List<DocumentType> gets()
        {
            try
            {
                string query = "select * from DocumentType ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                DataTable table = new DataTable();
                SqlDataReader MyReader = cmd.ExecuteReader();
                table.Load(MyReader);
                mycon.Close();
                return gets(table);
            }
            catch
            {
                return null;
            }

        }
        public static DocumentType getByCode(string Code)
        {
            try
            {
                string query = "select * from DocumentType where(Code=@Code)";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                cmd.Parameters.AddWithValue("@Code", Code);
                DataTable table = new DataTable();

                SqlDataReader MyReader = cmd.ExecuteReader();
                table.Load(MyReader);
                mycon.Close();
                return get(table.Rows[0]);
            }
            catch
            {
                return null;
            }


        }
        public static Message add(DocumentType documentType)
        {
            try
            {
                string query = "insert into DocumentType (Code,Label) values (@Code,@Label); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;

                if (string.IsNullOrEmpty(documentType.Code))
                    cmd.Parameters.AddWithValue("@Code", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Code", documentType.Code);


                if (string.IsNullOrEmpty(documentType.Label))
                    cmd.Parameters.AddWithValue("@Label", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Label", documentType.Label);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "DocummentType Ajouté");


            }
            catch (Exception e)
            {
                if (e.Message.Contains("Violation of PRIMARY KEY constraint 'PK__Document__A25C5AA60D9389EA"))
                    return new Message(false, "le Code DocummentType existe");
                else
                    return new Message(false, e.Message);
            }

        }
        public static Message update(DocumentType documentType,string code)
        {
            try
            {
                string query = "update  DocumentType set Code=@Code,Label=@Label where(Code=@code1);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;

                if (string.IsNullOrEmpty(documentType.Code))
                    cmd.Parameters.AddWithValue("@Code", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Code", documentType.Code);


                if (string.IsNullOrEmpty(documentType.Label))
                    cmd.Parameters.AddWithValue("@Label", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Label", documentType.Label);
                cmd.Parameters.AddWithValue("@code1",code);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "DocummentType Modifié");


            }
            catch (Exception e)
            {
                if (e.Message.Contains("Violation of UNIQUE KEY"))
                    return new Message(false, "le Code DocummentType existe");
                else
                    return new Message(false, e.Message);
            }

        }
        public static Message delete(string code)
        {
            try
            {
                string query = "delete DocumentType where(Code=@value); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@value", code);
                cmd.ExecuteNonQuery();
                mycon.Close();
                DAL_Document.Deletecodedocumentypee(code);
                return new Message(true, "Document type supprimer supprimé");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
        }
    }
}
