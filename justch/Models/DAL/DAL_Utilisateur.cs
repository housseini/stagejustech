using justch.Models.ENTITIES;
using justch.Models.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.DAL
{
    public class DAL_Utilisateur
    {
        public static Utilisateur Get(DataRow row) {
            Utilisateur utilisateur = new Utilisateur();
            if (string.IsNullOrEmpty(row["Id"].ToString())) { }
            else
                utilisateur.Id = Int32.Parse(row["Id"].ToString());
            if (string.IsNullOrEmpty(row["Id"].ToString())) { }
            else
                utilisateur.UserName = (row["UserName"].ToString());


            if (string.IsNullOrEmpty(row["email"].ToString())) { }
            else
                utilisateur.Email = (string)row["email"];


            if (string.IsNullOrEmpty(row["Password"].ToString())) { }
            else
                utilisateur.Password = CryptageEncryptage.decrypte( (string)row["Password"]);
            if (string.IsNullOrEmpty(row["Type"].ToString())) { }
            else
                utilisateur.Type = (string)row["Type"];
            return utilisateur;
        }

        public static List<Utilisateur> GetUtilisateur(DataTable table)
        {
            try
            {
                List<Utilisateur> Utilisateurs = new List<Utilisateur>();

                if (table != null)
                {
                    foreach (DataRow datarow in table.Rows)
                        Utilisateurs.Add(Get(datarow));


                }
                return Utilisateurs;
            }
            catch
            {
                return null;
            }
        }

        public  static List<Utilisateur> GetUtilisateurs()
        {
            try
            {
                string query = "select *from Utilisateur; ";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return GetUtilisateur(table);
            }
            catch
            {
                return null;

            }
        }

        public static Message AddUtilisateur(Utilisateur utilisateur)
        {
            try
            {


                string query = "insert into Utilisateur(UserName,email,Password,Type)values(@UserName,@Email,@Password,@Type);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(utilisateur.UserName))
                    cmd.Parameters.AddWithValue("@UserName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@UserName", utilisateur.UserName);

                if (string.IsNullOrEmpty(utilisateur.Email))
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Email", utilisateur.Email);


                if (string.IsNullOrEmpty(utilisateur.Password))
                    cmd.Parameters.AddWithValue("@Password", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Password", CryptageEncryptage.Encrypte( utilisateur.Password));
                if (string.IsNullOrEmpty(utilisateur.Type))
                    cmd.Parameters.AddWithValue("@Type", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Type", utilisateur.Type);
                cmd.ExecuteNonQuery();
                mycon.Close();
                EmailConfiguration.sendmessage(utilisateur.Email,"Votre compte a été creer" ,"votre  nom d utilisateur :"+ utilisateur.UserName +" est vote mot de passe :" + utilisateur.Password);
                return new Message(true, "Utilisateur  ajouter avec success");

            }
            catch (Exception e)
            {
                if (e.Message.Contains("Violation of UNIQUE KEY"))
                    return new Message(false, "cette UserName  existe deja");
                else
                    return new Message(false, e.Message);

            }

        }
        public static Utilisateur GetById(int Id)
        {
            try
            {
                string query = "select *from Utilisateur where(Id=@Id); ";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType =  CommandType.Text;
                command.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return Get(table.Rows[0]);
            }
            catch
            {
                return null;

            }
        }

        public static Message delete(int ID)
        {
            try
            {
                string query = "DELETE  Utilisateur WHERE(Id=@ID);";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(ID.ToString())) { cmd.Parameters.AddWithValue("@ID", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@ID", ID); }

                cmd.ExecuteNonQuery();
                con.Close();
                return new Message(true, "Utilisateur Supprimer");


            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
        }
        public static Message UpdateUtilisateur(Utilisateur utilisateur)
        {
            try
            {


                string query = "update  Utilisateur set UserName=@UserName,email=@Email,Password=@Password,Type=@Type Where(Id=@Id) ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(utilisateur.UserName))
                    cmd.Parameters.AddWithValue("@UserName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@UserName", utilisateur.UserName);

                if (string.IsNullOrEmpty(utilisateur.Email))
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Email", utilisateur.Email);


                if (string.IsNullOrEmpty(utilisateur.Password))
                    cmd.Parameters.AddWithValue("@Password", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Password", CryptageEncryptage.Encrypte(utilisateur.Password));
                if (string.IsNullOrEmpty(utilisateur.Type))
                    cmd.Parameters.AddWithValue("@Type", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Type", utilisateur.Type);
                cmd.Parameters.AddWithValue("@Id", utilisateur.Id);
                cmd.ExecuteNonQuery();
                mycon.Close();

                return new Message(true, "Utilisateur  modifié avec success");










            }
            catch (Exception e)
            {
                if (e.Message.Contains("Violation of UNIQUE KEY"))
                    return new Message(false, "cette UserName  existe deja");
                else
                    return new Message(false, e.Message);

            }

        }


        public static List<Utilisateur> GetUtilisateursEnbrologite()
        {
            try
            {
                string query = "select *from Utilisateur where (Type='Embryologiste') ; ";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return GetUtilisateur(table);
            }
            catch
            {
                return null;

            }
        }
    }
    
}

