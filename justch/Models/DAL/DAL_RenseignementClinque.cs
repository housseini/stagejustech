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
    public class DAL_RenseignementClinque
    {
        public static Message Add(RenseignementClinque renseignementClinque)
        {
            try
            {
                DalMigration.create_table_RenseignementClinique();
                string query = @" insert into RenseignementClinique(IdMedicalRecord ,TypeDinfertilite,DurerDinfertilite,Remarques ,NombreGrossesses ,DateGrossesses,NombreEnfants,DateEnfants, NombreGeu,DateGeu ,NombreAvortement,DateAvortement,PoidMonsieur,TailleMonsieur,BMIMMonsieur, PoidMadame,TailleMadame,BMIMMMadame,Techniques ,Indications,Observation) values(@IdMedicalRecord,@TypeDinfertilite,@DurerDinfertilite,@Remarques ,@NombreGrossesses ,@DateGrossesses,@NombreEnfants,@DateEnfants, @NombreGeu,@DateGeu ,@NombreAvortement,@DateAvortement,@PoidMonsieur,@TailleMonsieur,@BMIMMonsieur,@PoidMadame,@TailleMadame,@BMIMMMadame,@Techniques ,@Indications,@Observation);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(renseignementClinque.IdMedicalRecord.ToString()))
                    cmd.Parameters.AddWithValue("@IdMedicalRecord", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdMedicalRecord", renseignementClinque.IdMedicalRecord);

                if (string.IsNullOrEmpty(renseignementClinque.DurerDinfertilite.ToString()))
                    cmd.Parameters.AddWithValue("@DurerDinfertilite", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DurerDinfertilite",(renseignementClinque.DurerDinfertilite));

                if (string.IsNullOrEmpty(renseignementClinque.TypeDinfertilite))
                    cmd.Parameters.AddWithValue("@TypeDinfertilite", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@TypeDinfertilite", CryptageEncryptage.Encrypte(renseignementClinque.TypeDinfertilite));


                if (string.IsNullOrEmpty(renseignementClinque.Remarques))
                    cmd.Parameters.AddWithValue("@Remarques", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Remarques", CryptageEncryptage.Encrypte(renseignementClinque.Remarques));


                if (string.IsNullOrEmpty(renseignementClinque.NombreGrossesses))
                    cmd.Parameters.AddWithValue("@NombreGrossesses", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NombreGrossesses", CryptageEncryptage.Encrypte(renseignementClinque.NombreGrossesses));


                if (string.IsNullOrEmpty(renseignementClinque.DateGrossesses))
                    cmd.Parameters.AddWithValue("@DateGrossesses", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DateGrossesses", CryptageEncryptage.Encrypte(renseignementClinque.DateGrossesses));

                if (string.IsNullOrEmpty(renseignementClinque.NombreEnfants))
                    cmd.Parameters.AddWithValue("@NombreEnfants", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NombreEnfants", CryptageEncryptage.Encrypte(renseignementClinque.NombreEnfants));


                if (string.IsNullOrEmpty(renseignementClinque.DateEnfants))
                    cmd.Parameters.AddWithValue("@DateEnfants", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DateEnfants", CryptageEncryptage.Encrypte(renseignementClinque.DateEnfants));


                if (string.IsNullOrEmpty(renseignementClinque.NombreGeu))
                    cmd.Parameters.AddWithValue("@NombreGeu", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NombreGeu", CryptageEncryptage.Encrypte(renseignementClinque.NombreGeu));



                if (string.IsNullOrEmpty(renseignementClinque.DateGeu))
                    cmd.Parameters.AddWithValue("@DateGeu", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DateGeu", CryptageEncryptage.Encrypte(renseignementClinque.DateGeu));


                if (string.IsNullOrEmpty(renseignementClinque.NombreAvortement))
                    cmd.Parameters.AddWithValue("@NombreAvortement", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NombreAvortement", CryptageEncryptage.Encrypte(renseignementClinque.NombreAvortement));


                if (string.IsNullOrEmpty(renseignementClinque.DateAvortement))
                    cmd.Parameters.AddWithValue("@DateAvortement", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DateAvortement", renseignementClinque.DateAvortement);



                if (string.IsNullOrEmpty(renseignementClinque.PoidMonsieur))
                    cmd.Parameters.AddWithValue("@PoidMonsieur", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@PoidMonsieur", CryptageEncryptage.Encrypte(renseignementClinque.PoidMonsieur));




                if (string.IsNullOrEmpty(renseignementClinque.TailleMonsieur))
                    cmd.Parameters.AddWithValue("@TailleMonsieur", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@TailleMonsieur", CryptageEncryptage.Encrypte(renseignementClinque.TailleMonsieur));


                if (string.IsNullOrEmpty(renseignementClinque.BMIMMonsieur))
                    cmd.Parameters.AddWithValue("@BMIMMonsieur", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@BMIMMonsieur", CryptageEncryptage.Encrypte(renseignementClinque.BMIMMonsieur));


                if (string.IsNullOrEmpty(renseignementClinque.PoidMadame))
                    cmd.Parameters.AddWithValue("@PoidMadame", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@PoidMadame", CryptageEncryptage.Encrypte(renseignementClinque.PoidMadame));



                if (string.IsNullOrEmpty(renseignementClinque.TailleMadame))
                    cmd.Parameters.AddWithValue("@TailleMadame", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@TailleMadame", CryptageEncryptage.Encrypte(renseignementClinque.TailleMadame));



                if (string.IsNullOrEmpty(renseignementClinque.BMIMMMadame))
                    cmd.Parameters.AddWithValue("@BMIMMMadame", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@BMIMMMadame", CryptageEncryptage.Encrypte(renseignementClinque.BMIMMMadame));


                if (string.IsNullOrEmpty(renseignementClinque.Techniques))
                    cmd.Parameters.AddWithValue("@Techniques", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Techniques", CryptageEncryptage.Encrypte(renseignementClinque.Techniques));



                if (string.IsNullOrEmpty(renseignementClinque.Indications))
                    cmd.Parameters.AddWithValue("@Indications", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Indications", CryptageEncryptage.Encrypte(renseignementClinque.Indications));


                if (string.IsNullOrEmpty(renseignementClinque.Observation))
                    cmd.Parameters.AddWithValue("@Observation", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Observation", CryptageEncryptage.Encrypte(renseignementClinque.Observation));


             



                cmd.ExecuteNonQuery();



                return new Message(true, "renseignement clinique Ajouter");
            }
            catch(Exception e)
            {
                if (e.Message.Contains("Violation of UNIQUE KEY"))
                    return new Message(false, "ce dossier a deja les  renseignement ");

                return new Message(false, e.Message);
            }

        }
        public static RenseignementClinque GET(DataRow data)
        {
            try
            { var RC = new RenseignementClinque();
                RC.Id = Int32.Parse(data["Id"].ToString());
                RC.IdMedicalRecord= Int32.Parse(data["IdMedicalRecord"].ToString());
                if (data["TypeDinfertilite"] == DBNull.Value) { RC.TypeDinfertilite = null; }
                else { RC.TypeDinfertilite = CryptageEncryptage.decrypte((string)data["TypeDinfertilite"]); }

                if (data["DurerDinfertilite"] == DBNull.Value) { RC.DurerDinfertilite = 0; }
                else { RC.DurerDinfertilite = Int32.Parse(data["DurerDinfertilite"].ToString()); }

                if (data["Remarques"] == DBNull.Value) { RC.Remarques = null; }
                else { RC.Remarques = CryptageEncryptage.decrypte((string)data["Remarques"]); }

                if (data["NombreGrossesses"] == DBNull.Value) { RC.NombreGrossesses = null; }
                else { RC.NombreGrossesses = CryptageEncryptage.decrypte((string)data["NombreGrossesses"]); }

                if (data["DateGrossesses"] == DBNull.Value) { RC.DateGrossesses = null; }
                else { RC.DateGrossesses = CryptageEncryptage.decrypte((string)data["DateGrossesses"]); }

                if (data["NombreEnfants"] == DBNull.Value) { RC.NombreEnfants = null; }
                else { RC.NombreEnfants = CryptageEncryptage.decrypte((string)data["NombreEnfants"]); };

                if (data["DateEnfants"] == DBNull.Value) { RC.DateEnfants = null; }
                else { RC.DateEnfants = CryptageEncryptage.decrypte((string)data["DateEnfants"]); }



                if (data["NombreGeu"] == DBNull.Value) { RC.NombreGeu = null; }
                else { RC.NombreGeu = CryptageEncryptage.decrypte((string)data["NombreGeu"]); }


                if (data["DateGeu"] == DBNull.Value) { RC.DateGeu = null; }
                else { RC.DateGeu = CryptageEncryptage.decrypte((string)data["DateGeu"]); }


                if (data["NombreAvortement"] == DBNull.Value) { RC.NombreAvortement = null; }
                else { RC.NombreAvortement = CryptageEncryptage.decrypte((string)data["NombreAvortement"]); }

                if (data["DateAvortement"] == DBNull.Value) { }
                else { RC.DateAvortement = data["DateAvortement"].ToString(); }


                if (data["PoidMonsieur"] == DBNull.Value) { RC.PoidMonsieur = null; }
                else { RC.PoidMonsieur = CryptageEncryptage.decrypte((string)data["PoidMonsieur"]); }


                if (data["TailleMonsieur"] == DBNull.Value) { RC.TailleMonsieur = null; }
                else { RC.TailleMonsieur = CryptageEncryptage.decrypte((string)data["TailleMonsieur"]); }


                if (data["BMIMMonsieur"] == DBNull.Value) { RC.BMIMMonsieur = null; }
                else { RC.BMIMMonsieur = CryptageEncryptage.decrypte((string)data["BMIMMonsieur"]); }


                if (data["PoidMadame"] == DBNull.Value) { RC.PoidMadame = null; }
                else { RC.PoidMadame = CryptageEncryptage.decrypte((string)data["PoidMadame"]); }


                if (data["TailleMadame"] == DBNull.Value) { RC.TailleMadame = null; }
                else { RC.TailleMadame = CryptageEncryptage.decrypte((string)data["TailleMadame"]); }



                if (data["BMIMMMadame"] == DBNull.Value) { RC.BMIMMMadame = null; }
                else { RC.BMIMMMadame = CryptageEncryptage.decrypte((string)data["BMIMMMadame"]); }


                if (data["Techniques"] == DBNull.Value) { RC.Techniques = null; }
                else { RC.Techniques = CryptageEncryptage.decrypte((string)data["Techniques"]); }

                if (data["Indications"] == DBNull.Value) { RC.Indications = null; }
                else { RC.Indications = CryptageEncryptage.decrypte((string)data["Indications"]); }

                if (data["Observation"] == DBNull.Value) { RC.Observation = null; }
                else { RC.Observation = CryptageEncryptage.decrypte((string)data["Observation"]); }



                return RC;
            }
            catch ( Exception  e) 
            {
               var  C = new RenseignementClinque();
                C.BMIMMMadame = e.Message;
                return null;
            }
        }

        public static RenseignementClinque GETBYIDMEDICALE(int Iddossiermedical)
        {
            try
            {
                string query = @"select * from RenseignementClinique where(IdMedicalRecord=" + Iddossiermedical + @");";
                SqlConnection cn = DbConnection.GetConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 50;
                DataTable table = new DataTable();
                SqlDataReader MyReader = cmd.ExecuteReader();
                table.Load(MyReader);
                cn.Close();
                return GET(table.Rows[0]);



            }
            catch
            {
                return null;
            }
        }

        public static Message Update(RenseignementClinque renseignementClinque)
        {

            try
            {
             
                string query = @" update  RenseignementClinique set  TypeDinfertilite=@TypeDinfertilite ,DurerDinfertilite=@DurerDinfertilite,Remarques=@Remarques ,NombreGrossesses=@NombreGrossesses ,DateGrossesses=@DateGrossesses,NombreEnfants=@NombreEnfants,DateEnfants=@DateEnfants, NombreGeu=@NombreGeu,DateGeu=@DateGeu ,NombreAvortement=@NombreAvortement,DateAvortement=@DateAvortement,PoidMonsieur=@PoidMonsieur,TailleMonsieur=@TailleMonsieur,BMIMMonsieur=@BMIMMonsieur, PoidMadame=@PoidMadame,TailleMadame=@TailleMadame,BMIMMMadame=@BMIMMMadame,Techniques=@Techniques ,Indications=@Indications,Observation=@Observation where(IdMedicalRecord=@IdMedicalRecord);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(renseignementClinque.IdMedicalRecord.ToString()))
                    cmd.Parameters.AddWithValue("@IdMedicalRecord", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdMedicalRecord", renseignementClinque.IdMedicalRecord);

                if (string.IsNullOrEmpty(renseignementClinque.DurerDinfertilite.ToString()))
                    cmd.Parameters.AddWithValue("@DurerDinfertilite", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DurerDinfertilite", (renseignementClinque.DurerDinfertilite));

                if (string.IsNullOrEmpty(renseignementClinque.TypeDinfertilite))
                    cmd.Parameters.AddWithValue("@TypeDinfertilite", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@TypeDinfertilite", CryptageEncryptage.Encrypte(renseignementClinque.TypeDinfertilite));


                if (string.IsNullOrEmpty(renseignementClinque.Remarques))
                    cmd.Parameters.AddWithValue("@Remarques", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Remarques", CryptageEncryptage.Encrypte(renseignementClinque.Remarques));


                if (string.IsNullOrEmpty(renseignementClinque.NombreGrossesses))
                    cmd.Parameters.AddWithValue("@NombreGrossesses", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NombreGrossesses", CryptageEncryptage.Encrypte(renseignementClinque.NombreGrossesses));


                if (string.IsNullOrEmpty(renseignementClinque.DateGrossesses))
                    cmd.Parameters.AddWithValue("@DateGrossesses", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DateGrossesses", CryptageEncryptage.Encrypte(renseignementClinque.DateGrossesses));

                if (string.IsNullOrEmpty(renseignementClinque.NombreEnfants))
                    cmd.Parameters.AddWithValue("@NombreEnfants", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NombreEnfants", CryptageEncryptage.Encrypte(renseignementClinque.NombreEnfants));


                if (string.IsNullOrEmpty(renseignementClinque.DateEnfants))
                    cmd.Parameters.AddWithValue("@DateEnfants", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DateEnfants", CryptageEncryptage.Encrypte(renseignementClinque.DateEnfants));


                if (string.IsNullOrEmpty(renseignementClinque.NombreGeu))
                    cmd.Parameters.AddWithValue("@NombreGeu", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NombreGeu", CryptageEncryptage.Encrypte(renseignementClinque.NombreGeu));



                if (string.IsNullOrEmpty(renseignementClinque.DateGeu))
                    cmd.Parameters.AddWithValue("@DateGeu", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DateGeu", CryptageEncryptage.Encrypte(renseignementClinque.DateGeu));


                if (string.IsNullOrEmpty(renseignementClinque.NombreAvortement))
                    cmd.Parameters.AddWithValue("@NombreAvortement", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NombreAvortement", CryptageEncryptage.Encrypte(renseignementClinque.NombreAvortement));


                if (string.IsNullOrEmpty(renseignementClinque.DateAvortement))
                    cmd.Parameters.AddWithValue("@DateAvortement", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DateAvortement", renseignementClinque.DateAvortement);



                if (string.IsNullOrEmpty(renseignementClinque.PoidMonsieur))
                    cmd.Parameters.AddWithValue("@PoidMonsieur", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@PoidMonsieur", CryptageEncryptage.Encrypte(renseignementClinque.PoidMonsieur));




                if (string.IsNullOrEmpty(renseignementClinque.TailleMonsieur))
                    cmd.Parameters.AddWithValue("@TailleMonsieur", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@TailleMonsieur", CryptageEncryptage.Encrypte(renseignementClinque.TailleMonsieur));


                if (string.IsNullOrEmpty(renseignementClinque.BMIMMonsieur))
                    cmd.Parameters.AddWithValue("@BMIMMonsieur", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@BMIMMonsieur", CryptageEncryptage.Encrypte(renseignementClinque.BMIMMonsieur));


                if (string.IsNullOrEmpty(renseignementClinque.PoidMadame))
                    cmd.Parameters.AddWithValue("@PoidMadame", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@PoidMadame", CryptageEncryptage.Encrypte(renseignementClinque.PoidMadame));



                if (string.IsNullOrEmpty(renseignementClinque.TailleMadame))
                    cmd.Parameters.AddWithValue("@TailleMadame", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@TailleMadame", CryptageEncryptage.Encrypte(renseignementClinque.TailleMadame));



                if (string.IsNullOrEmpty(renseignementClinque.BMIMMMadame))
                    cmd.Parameters.AddWithValue("@BMIMMMadame", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@BMIMMMadame", CryptageEncryptage.Encrypte(renseignementClinque.BMIMMMadame));


                if (string.IsNullOrEmpty(renseignementClinque.Techniques))
                    cmd.Parameters.AddWithValue("@Techniques", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Techniques", CryptageEncryptage.Encrypte(renseignementClinque.Techniques));



                if (string.IsNullOrEmpty(renseignementClinque.Indications))
                    cmd.Parameters.AddWithValue("@Indications", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Indications", CryptageEncryptage.Encrypte(renseignementClinque.Indications));


                if (string.IsNullOrEmpty(renseignementClinque.Observation))
                    cmd.Parameters.AddWithValue("@Observation", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Observation", CryptageEncryptage.Encrypte(renseignementClinque.Observation));






                cmd.ExecuteNonQuery();



                return new Message(true, "renseignement clinique Modifier");
            }
            catch (Exception e)
            {
               
                return new Message(false, e.Message);
            }

        }



    }
}
