using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.ENTITIES;

using justch.Models.Service;

namespace justch.Models.DAL
{
    public class DAL_ActDataCulture
    {

        private static SqlConnection? connection = null;

        public static Message Add(ActDataCulture actData)
        {
            try
            {
                DalMigration.create_table_ActDataCulture();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ActDataCulture(" +
                    "IdMedicalRecordAct,IdJ1EmbryologisteDoctor," +
                    "IdJ2EmbryologisteDoctor" +
                    ",IdJ3EmbryologisteDoctor,IdJ2Incubateur" +
                    ",IdJ3Incubateur,IdJ4Incubateur,IdJ5Incubateur,IdJ6Incubateur,J1Chambres,J2Chambres,J3Chambres" +
                       ",J4Chambres,J5Chambres,J6Chambres,J1EmbryologisteDoctorType,J2EmbryologisteDoctorType,J3EmbryologisteDoctorType,J4EmbryologisteDoctorType" +
                        ",J5EmbryologisteDoctorType,J6EmbryologisteDoctorType,J1Date,IdJ4EmbryologisteDoctor,IdJ5EmbryologisteDoctor,IdJ6EmbryologisteDoctor,IdJ1Incubateur" +
                        ",J1Heure,J2Date,J2Heure,J3Date,J3Heure,J4Date,J4Heure" +
                        ",J5Date,J5Heure,J6Date,J6Heure" +
                         ")" +
                    "VALUES(" +
                    "@IdMedicalRecordAct,@IdJ1EmbryologisteDoctor," +
                    "@IdJ2EmbryologisteDoctor" +
                    ",@IdJ3EmbryologisteDoctor,@IdJ2Incubateur" +
                    ",@IdJ3Incubateur,@IdJ4Incubateur,@IdJ5Incubateur,@IdJ6Incubateur,@J1Chambres,@J2Chambres,@J3Chambres" +
                       ",@J4Chambres,@J5Chambres,@J6Chambres,@J1EmbryologisteDoctorType,@J2EmbryologisteDoctorType,@J3EmbryologisteDoctorType,@J4EmbryologisteDoctorType" +
                        ",@J5EmbryologisteDoctorType,@J6EmbryologisteDoctorType,@J1Date,@IdJ4EmbryologisteDoctor,@IdJ5EmbryologisteDoctor,@IdJ6EmbryologisteDoctor,@IdJ1Incubateur" +
                         ",@J1Heure,@J2Date,@J2Heure,@J3Date,@J3Heure,@J4Date,@J4Heure" +
                        ",@J5Date,@J5Heure,@J6Date,@J6Heure" +
                          ");";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdJ1EmbryologisteDoctor", actData.IdJ1EmbryologisteDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdJ2EmbryologisteDoctor", actData.IdJ2EmbryologisteDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdJ3EmbryologisteDoctor", actData.IdJ3EmbryologisteDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdJ2Incubateur", actData.IdJ2Incubateur);
                CommandHelper.AddParameterValue<int>(command, "@IdJ4Incubateur", actData.IdJ4Incubateur);
                CommandHelper.AddParameterValue<int>(command, "@IdJ5Incubateur", actData.IdJ5Incubateur);
                CommandHelper.AddParameterValue<int>(command, "@IdJ6Incubateur", actData.IdJ6Incubateur);
                CommandHelper.AddParameterValue<string>(command, "@J1Chambres", actData.J1Chambres);
                CommandHelper.AddParameterValue<string>(command, "@J2Chambres", actData.J2Chambres);
                CommandHelper.AddParameterValue<string>(command, "@J3Chambres", actData.J3Chambres);
                CommandHelper.AddParameterValue<string>(command, "@J4Chambres", actData.J4Chambres);
                CommandHelper.AddParameterValue<string>(command, "@J5Chambres", actData.J5Chambres);
                CommandHelper.AddParameterValue<string>(command, "@J6Chambres", actData.J6Chambres);
                CommandHelper.AddParameterValue<string>(command, "@J1EmbryologisteDoctorType", actData.J1EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@J2EmbryologisteDoctorType", actData.J2EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@J3EmbryologisteDoctorType", actData.J3EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@J4EmbryologisteDoctorType", actData.J4EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@J5EmbryologisteDoctorType", actData.J5EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@J6EmbryologisteDoctorType", actData.J6EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@J1Date", actData.J1Date);
                CommandHelper.AddParameterValue<string>(command, "@J3Date", actData.J3Date);
                CommandHelper.AddParameterValue<string>(command, "@J2Date", actData.J2Date);
                CommandHelper.AddParameterValue<string>(command, "@J4Date", actData.J4Date);
                CommandHelper.AddParameterValue<string>(command, "@J5Date", actData.J5Date);
                CommandHelper.AddParameterValue<string>(command, "@J6Date", actData.J6Date);
                CommandHelper.AddParameterValue<string>(command, "@J1Heure", actData.J1Heure);
                CommandHelper.AddParameterValue<string>(command, "@J2Heure", actData.J2Heure);
                CommandHelper.AddParameterValue<string>(command, "@J3Heure", actData.J3Heure);
                CommandHelper.AddParameterValue<string>(command, "@J4Heure", actData.J4Heure);
                CommandHelper.AddParameterValue<string>(command, "@J5Heure", actData.J5Heure);
                CommandHelper.AddParameterValue<string>(command, "@J6Heure", actData.J6Heure);
                CommandHelper.AddParameterValue<int>(command, "@IdJ4EmbryologisteDoctor", actData.IdJ4EmbryologisteDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdJ6EmbryologisteDoctor", actData.IdJ6EmbryologisteDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdJ1Incubateur", actData.IdJ1Incubateur);
                CommandHelper.AddParameterValue<int>(command, "@IdJ3Incubateur", actData.IdJ3Incubateur);
                CommandHelper.AddParameterValue<int>(command, "@IdJ5EmbryologisteDoctor", actData.IdJ5EmbryologisteDoctor);

                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataCulture AJOUTER");
            }
            catch (Exception e)
            {
                connection.Close();
                return new Message(false, "erreur d Ajout " + e.Message);


            }
            finally
            {
                connection.Close();
            }
        }

        public static ActDataCulture Get(DataRow row)
        {
            ActDataCulture act = new ActDataCulture();
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.IdJ1EmbryologisteDoctor = CommandHelper.ReadIdValue(row["IdJ1EmbryologisteDoctor"].ToString());
            act.IdJ1EmbryologisteDoctor = CommandHelper.ReadIdValue(row["IdJ1EmbryologisteDoctor"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.IdJ4EmbryologisteDoctor = CommandHelper.ReadIdValue(row["IdJ4EmbryologisteDoctor"].ToString());
            act.IdJ5EmbryologisteDoctor = CommandHelper.ReadIdValue(row["IdJ5EmbryologisteDoctor"].ToString());
            act.IdJ6EmbryologisteDoctor = CommandHelper.ReadIdValue(row["IdJ6EmbryologisteDoctor"].ToString());
            act.IdJ1Incubateur = CommandHelper.ReadIdValue(row["IdJ1Incubateur"].ToString());
            act.IdJ3EmbryologisteDoctor = CommandHelper.ReadIdValue(row["IdJ3EmbryologisteDoctor"].ToString());
            act.IdJ2EmbryologisteDoctor = CommandHelper.ReadIdValue(row["IdJ2EmbryologisteDoctor"].ToString());
            act.IdJ2Incubateur = CommandHelper.ReadIdValue(row["IdJ2Incubateur"].ToString());
            act.IdJ2Incubateur = CommandHelper.ReadIdValue(row["IdJ3Incubateur"].ToString());
            act.IdJ4Incubateur = CommandHelper.ReadIdValue(row["IdJ4Incubateur"].ToString());
            act.IdJ5Incubateur = CommandHelper.ReadIdValue(row["IdJ5Incubateur"].ToString());
            act.IdJ6Incubateur = CommandHelper.ReadIdValue(row["IdJ6Incubateur"].ToString());
            act.J1Chambres = CommandHelper.ReadValue(row["J1Chambres"].ToString());
            act.J2Chambres = CommandHelper.ReadValue(row["J2Chambres"].ToString());
            act.J3Chambres = CommandHelper.ReadValue(row["J3Chambres"].ToString());
            act.J4Chambres = CommandHelper.ReadValue(row["J4Chambres"].ToString());
            act.J5Chambres = CommandHelper.ReadValue(row["J5Chambres"].ToString());
            act.J6Chambres = CommandHelper.ReadValue(row["J6Chambres"].ToString());
            act.J1EmbryologisteDoctorType = CommandHelper.ReadValue(row["J1EmbryologisteDoctorType"].ToString());
            act.J2EmbryologisteDoctorType = CommandHelper.ReadValue(row["J2EmbryologisteDoctorType"].ToString());
            act.J3EmbryologisteDoctorType = CommandHelper.ReadValue(row["J3EmbryologisteDoctorType"].ToString());
            act.J4EmbryologisteDoctorType = CommandHelper.ReadValue(row["J4EmbryologisteDoctorType"].ToString());
            act.J5EmbryologisteDoctorType = CommandHelper.ReadValue(row["J5EmbryologisteDoctorType"].ToString());
            act.J6EmbryologisteDoctorType = CommandHelper.ReadValue(row["J6EmbryologisteDoctorType"].ToString());
            act.J1Date = CommandHelper.ReadValue(row["J1Date"].ToString());
            act.J2Date = CommandHelper.ReadValue(row["J2Date"].ToString());
            act.J3Date = CommandHelper.ReadValue(row["J3Date"].ToString());
            act.J4Date = CommandHelper.ReadValue(row["J4Date"].ToString());
            act.J5Date = CommandHelper.ReadValue(row["J5Date"].ToString());
            act.J6Date = CommandHelper.ReadValue(row["J6Date"].ToString());
            act.J1Heure = CommandHelper.ReadValue(row["J1Heure"].ToString());
            act.J2Heure = CommandHelper.ReadValue(row["J2Heure"].ToString());
            act.J3Heure = CommandHelper.ReadValue(row["J3Heure"].ToString());
            act.J4Heure = CommandHelper.ReadValue(row["J4Heure"].ToString());
            act.J5Heure = CommandHelper.ReadValue(row["J5Heure"].ToString());
            act.J6Heure = CommandHelper.ReadValue(row["J6Heure"].ToString());
            return act;
        }
        public static List<ActDataCulture> Gets(DataTable table)
        {
            List<ActDataCulture> acts = new List<ActDataCulture>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<ActDataCulture> GETS(int Id)
        {
            DalMigration.create_table_ActDataCulture();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from ActDataCulture  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(List<int> listenumero, int idactculture, int Jours, string Grade, string chambre ,int Incubateur ,int enbryologite,string date , string heur ,string Commentaire,int iddeco)
        {
            try
            {
                DalMigration.create_table_ActDataCulture();

                connection = DbConnection.GetConnection();
                connection.Open();





                if (Jours==1)
                {

              

                       string    query = "UPDATE ActDataCulture SET " +
                    "IdJ1EmbryologisteDoctor= @IdJ1EmbryologisteDoctor," +
                    "IdJ1Incubateur= @IdJ1Incubateur," +
                    "J1Chambres=@J1Chambres, " +                              
                    "J1Date=@J1Date, " +
                    "J1Heure=@J1Heure   " +
                    "where(Id=@IdMedicalRecordAct);";
                        var command = new SqlCommand(query, connection);
                        command.CommandTimeout = 50;
                        CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", idactculture);
                        CommandHelper.AddParameterValue<int>(command, "@IdJ1EmbryologisteDoctor", enbryologite);
                        CommandHelper.AddParameterValue<int>(command, "@IdJ1Incubateur", Incubateur);
                        CommandHelper.AddParameterValue<string>(command, "@J1Chambres", chambre);
                        CommandHelper.AddParameterValue<string>(command, "@J1EmbryologisteDoctorType", "Enbryologiste");
                        CommandHelper.AddParameterValue<string>(command, "@J1Date", date);
                        CommandHelper.AddParameterValue<string>(command, "@J1Heure", heur);
                        command.ExecuteNonQuery();
                        connection.Close();
                }

                if (Jours == 2)
                {
                    string query = "UPDATE ActDataCulture SET " +
                    "IdJ2EmbryologisteDoctor= @IdJ1EmbryologisteDoctor," +
                    "IdJ2Incubateur= @IdJ1Incubateur," +
                    "J2Chambres=@J1Chambres, " +
                    "J2Date=@J1Date, " +
                    "J2Heure=@J1Heure   " +
                    "where(Id=@IdMedicalRecordAct);";
                    var command = new SqlCommand(query, connection);
                    command.CommandTimeout = 50;
                    CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", idactculture);
                    CommandHelper.AddParameterValue<int>(command, "@IdJ1EmbryologisteDoctor", enbryologite);
                    CommandHelper.AddParameterValue<int>(command, "@IdJ1Incubateur", Incubateur);
                    CommandHelper.AddParameterValue<string>(command, "@J1Chambres", chambre);
                    CommandHelper.AddParameterValue<string>(command, "@J1EmbryologisteDoctorType", "Enbryologiste");
                    CommandHelper.AddParameterValue<string>(command, "@J1Date", date);
                    CommandHelper.AddParameterValue<string>(command, "@J1Heure", heur);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                if (Jours == 3)
                {
                    string query = "UPDATE ActDataCulture SET " +
                    "IdJ3EmbryologisteDoctor= @IdJ1EmbryologisteDoctor," +
                    "IdJ3Incubateur= @IdJ1Incubateur," +
                    "J3Chambres=@J1Chambres, " +
                    "J3Date=@J1Date, " +
                    "J3Heure=@J1Heure   " +
                    "where(Id=@IdMedicalRecordAct);";
                    var command = new SqlCommand(query, connection);
                    command.CommandTimeout = 50;
                    CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", idactculture);
                    CommandHelper.AddParameterValue<int>(command, "@IdJ1EmbryologisteDoctor", enbryologite);
                    CommandHelper.AddParameterValue<int>(command, "@IdJ1Incubateur", Incubateur);
                    CommandHelper.AddParameterValue<string>(command, "@J1Chambres", chambre);
                    CommandHelper.AddParameterValue<string>(command, "@J1EmbryologisteDoctorType", "Enbryologiste");
                    CommandHelper.AddParameterValue<string>(command, "@J1Date", date);
                    CommandHelper.AddParameterValue<string>(command, "@J1Heure", heur);
                    command.ExecuteNonQuery();
                    connection.Close();

                }
                if (Jours == 4)
                {
                    string query = "UPDATE ActDataCulture SET " +
                    "IdJ4EmbryologisteDoctor= @IdJ1EmbryologisteDoctor," +
                    "IdJ4Incubateur= @IdJ1Incubateur," +
                    "J4Chambres=@J1Chambres, " +
                    "J4Date=@J1Date, " +
                    "J4Heure=@J1Heure   " +
                    "where(Id=@IdMedicalRecordAct);";
                    var command = new SqlCommand(query, connection);
                    command.CommandTimeout = 50;
                    CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", idactculture);
                    CommandHelper.AddParameterValue<int>(command, "@IdJ1EmbryologisteDoctor", enbryologite);
                    CommandHelper.AddParameterValue<int>(command, "@IdJ1Incubateur", Incubateur);
                    CommandHelper.AddParameterValue<string>(command, "@J1Chambres", chambre);
                    CommandHelper.AddParameterValue<string>(command, "@J1EmbryologisteDoctorType", "Enbryologiste");
                    CommandHelper.AddParameterValue<string>(command, "@J1Date", date);
                    CommandHelper.AddParameterValue<string>(command, "@J1Heure", heur);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                if (Jours == 5)
                {
                    string query = "UPDATE ActDataCulture SET " +
                    "IdJ5EmbryologisteDoctor= @IdJ1EmbryologisteDoctor," +
                    "IdJ5Incubateur= @IdJ1Incubateur," +
                    "J5Chambres=@J1Chambres, " +
                    "J5Date=@J1Date, " +
                    "J5Heure=@J1Heure   " +
                    "where(Id=@IdMedicalRecordAct);";
                    var command = new SqlCommand(query, connection);
                    command.CommandTimeout = 50;
                    CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", idactculture);
                    CommandHelper.AddParameterValue<int>(command, "@IdJ1EmbryologisteDoctor", enbryologite);
                    CommandHelper.AddParameterValue<int>(command, "@IdJ1Incubateur", Incubateur);
                    CommandHelper.AddParameterValue<string>(command, "@J1Chambres", chambre);
                    CommandHelper.AddParameterValue<string>(command, "@J1EmbryologisteDoctorType", "Enbryologiste");
                    CommandHelper.AddParameterValue<string>(command, "@J1Date", date);
                    CommandHelper.AddParameterValue<string>(command, "@J1Heure", heur);
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                if (Jours == 6)
                {
                  string   query = "UPDATE ActDataCulture SET " +
                    "IdJ6EmbryologisteDoctor= @IdJ1EmbryologisteDoctor," +
                    "IdJ6Incubateur= @IdJ1Incubateur," +
                    "J6Chambres=@J1Chambres, " +
                    "J6Date=@J1Date, " +
                    "J6Heure=@J1Heure   " +
                    "where(Id=@IdMedicalRecordAct);";
                    var command = new SqlCommand(query, connection);
                    command.CommandTimeout = 50;
                    CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", idactculture);
                    CommandHelper.AddParameterValue<int>(command, "@IdJ1EmbryologisteDoctor", enbryologite);
                    CommandHelper.AddParameterValue<int>(command, "@IdJ1Incubateur", Incubateur);
                    CommandHelper.AddParameterValue<string>(command, "@J1Chambres", chambre);
                    CommandHelper.AddParameterValue<string>(command, "@J1EmbryologisteDoctorType", "Enbryologiste");
                    CommandHelper.AddParameterValue<string>(command, "@J1Date", date);
                    CommandHelper.AddParameterValue<string>(command, "@J1Heure", heur);
                    command.ExecuteNonQuery();
                    connection.Close();
                    

                }

                
                DAL_CulureOvocyteData.Update(listenumero, idactculture, Jours, Grade);
                DAL_ActDataDecoronisationOvocyteData.Update(listenumero, Commentaire, iddeco);


                return new Message(true, " ActDataCulture MOdifier");
            }
            catch (Exception e)
            {
                connection.Close();
                return new Message(false, "erreur de MOdification :  " + e.Message);


            }
            finally
            {
                connection.Close();
            }
        }

    }
}
