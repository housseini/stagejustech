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
    public class DAL_ActDataBiopsie
    {
        private static SqlConnection? connection = null;

        public static Message Add(ActDataBiopsie actData)
        {
            try
            {
                DalMigration.create_table_ActDataBiopsie();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ActDataBiopsie(" +
                    "IdMedicalRecordAct,IdTreatingDoctor," +
                    "IdEmbryologisteDoctor" +
                    ",EmbryologisteDoctorType,Date" +
                    ",Heure,TypeBiopsieTesticulaire,ExamenAnatomopathologique,TGPoleSupNombreFragments,TGPoleSupDilaceration,TGPoleSupResultat,TGPoleMedNombreFragments" +
                       ",TGPoleMedDilaceration,TGPoleMedResultat,TGPoleInfNombreFragments,TGPoleInfDilaceration,TGPoleInfResultat,TDPoleSupNombreFragments,TDPoleSupDilaceration" +
                        ",TDPoleSupResultat,TDPoleMedNombreFragments,TDPoleMedDilaceration,TDPoleMedResultat,TDPoleInfNombreFragments,TDPoleInfDilaceration,TDPoleInfResultat" +
                         ")" +
                    "VALUES(" +
                    "@IdMedicalRecordAct,@IdTreatingDoctor," +
                    "@IdEmbryologisteDoctor" +
                    ",@EmbryologisteDoctorType,@Date" +
                    ",@Heure,@TypeBiopsieTesticulaire,@ExamenAnatomopathologique,@TGPoleSupNombreFragments,@TGPoleSupDilaceration,@TGPoleSupResultat,@TGPoleMedNombreFragments" +
                       ",@TGPoleMedDilaceration,@TGPoleMedResultat,@TGPoleInfNombreFragments,@TGPoleInfDilaceration,@TGPoleInfResultat,@TDPoleSupNombreFragments,@TDPoleSupDilaceration" +
                        ",@TDPoleSupResultat,@TDPoleMedNombreFragments,@TDPoleMedDilaceration,@TDPoleMedResultat,@TDPoleInfNombreFragments,@TDPoleInfDilaceration,@TDPoleInfResultat" +
                          ");";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdTreatingDoctor", actData.IdTreatingDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdEmbryologisteDoctor", actData.IdEmbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<string>(command, "@TypeBiopsieTesticulaire", actData.TypeBiopsieTesticulaire);
                CommandHelper.AddParameterValue<string>(command, "@ExamenAnatomopathologique", actData.ExamenAnatomopathologique);
                CommandHelper.AddParameterValue<int>(command, "@TGPoleSupNombreFragments", actData.TGPoleSupNombreFragments);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleSupDilaceration", actData.TGPoleSupDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleSupResultat", actData.TGPoleSupResultat);
                CommandHelper.AddParameterValue<int>(command, "@TGPoleMedNombreFragments", actData.TGPoleMedNombreFragments);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleMedDilaceration", actData.TGPoleMedDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleMedResultat", actData.TGPoleMedResultat);
                CommandHelper.AddParameterValue<int>(command, "@TGPoleInfNombreFragments", actData.TGPoleInfNombreFragments);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleInfDilaceration", actData.TGPoleInfDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleInfResultat", actData.TGPoleInfResultat);
                CommandHelper.AddParameterValue<int>(command, "@TDPoleSupNombreFragments", actData.TDPoleSupNombreFragments);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleSupDilaceration", actData.TDPoleSupDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleSupResultat", actData.TDPoleSupResultat);
                CommandHelper.AddParameterValue<int>(command, "@TDPoleMedNombreFragments", actData.TDPoleMedNombreFragments);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleMedDilaceration", actData.TDPoleMedDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleMedResultat", actData.TDPoleMedResultat);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleInfDilaceration", actData.TDPoleInfDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleInfResultat", actData.TDPoleInfResultat);
                CommandHelper.AddParameterValue<int>(command, "@TDPoleInfNombreFragments", actData.TDPoleInfNombreFragments);

                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataBiopsie AJOUTER");
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

        public static ActDataBiopsie Get(DataRow row)
        {
            ActDataBiopsie act = new ActDataBiopsie();
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.IdTreatingDoctor = CommandHelper.ReadIdValue(row["IdTreatingDoctor"].ToString());
            act.IdTreatingDoctor = CommandHelper.ReadIdValue(row["IdTreatingDoctor"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.TDPoleMedResultat = CommandHelper.ReadValue(row["TDPoleMedResultat"].ToString());
            act.TDPoleInfNombreFragments = CommandHelper.ReadIdValue(row["TDPoleInfNombreFragments"].ToString());
            act.TDPoleInfDilaceration = CommandHelper.ReadValue(row["TDPoleInfDilaceration"].ToString());
            act.TDPoleInfResultat = CommandHelper.ReadValue(row["TDPoleInfResultat"].ToString());
            act.EmbryologisteDoctorType = CommandHelper.ReadValue(row["EmbryologisteDoctorType"].ToString());
            act.IdEmbryologisteDoctor = CommandHelper.ReadIdValue(row["IdEmbryologisteDoctor"].ToString());
            act.Date = CommandHelper.ReadValue(row["Date"].ToString());
            act.Heure = CommandHelper.ReadValue(row["Heure"].ToString());
            act.TypeBiopsieTesticulaire = CommandHelper.ReadValue(row["TypeBiopsieTesticulaire"].ToString());
            act.ExamenAnatomopathologique = CommandHelper.ReadValue(row["ExamenAnatomopathologique"].ToString());
            act.TGPoleSupNombreFragments = CommandHelper.ReadIdValue(row["TGPoleSupNombreFragments"].ToString());
            act.TGPoleSupDilaceration = CommandHelper.ReadValue(row["TGPoleSupDilaceration"].ToString());
            act.TGPoleSupResultat = CommandHelper.ReadValue(row["TGPoleSupResultat"].ToString());
            act.TGPoleMedNombreFragments = CommandHelper.ReadIdValue(row["TGPoleMedNombreFragments"].ToString());
            act.TGPoleMedDilaceration = CommandHelper.ReadValue(row["TGPoleMedDilaceration"].ToString());
            act.TGPoleMedResultat = CommandHelper.ReadValue(row["TGPoleMedResultat"].ToString());
            act.TGPoleInfNombreFragments = CommandHelper.ReadIdValue(row["TGPoleInfNombreFragments"].ToString());
            act.TGPoleInfDilaceration = CommandHelper.ReadValue(row["TGPoleInfDilaceration"].ToString());
            act.TGPoleInfResultat = CommandHelper.ReadValue(row["TGPoleInfResultat"].ToString());
            act.TDPoleSupNombreFragments = CommandHelper.ReadIdValue(row["TDPoleSupNombreFragments"].ToString());
            act.TDPoleSupDilaceration = CommandHelper.ReadValue(row["TDPoleSupDilaceration"].ToString());
            act.TDPoleSupResultat = CommandHelper.ReadValue(row["TDPoleSupResultat"].ToString());
            act.TDPoleMedNombreFragments = CommandHelper.ReadIdValue(row["TDPoleMedNombreFragments"].ToString());
            act.TDPoleMedDilaceration = CommandHelper.ReadValue(row["TDPoleMedDilaceration"].ToString());
            return act;
        }
        public static List<ActDataBiopsie> Gets(DataTable table)
        {
            List<ActDataBiopsie> acts = new List<ActDataBiopsie>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<ActDataBiopsie> GETS(int Id)
        {
            DalMigration.create_table_ActDataBiopsie();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from ActDataBiopsie  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(ActDataBiopsie actData)
        {
            try
            {
                DalMigration.create_table_ActDataBiopsie();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE ActDataBiopsie SET " +
                    "IdTreatingDoctor= @IdTreatingDoctor" +
                    ",IdEmbryologisteDoctor=@IdEmbryologisteDoctor ," +
                    "EmbryologisteDoctorType=@EmbryologisteDoctorType,Date= @Date," +
                    "Heure=@Heure, " +
                    "TypeBiopsieTesticulaire=@TypeBiopsieTesticulaire, " +
                    "ExamenAnatomopathologique=@ExamenAnatomopathologique, " +
                    "TGPoleSupNombreFragments=@TGPoleSupNombreFragments, " +
                    "TGPoleSupDilaceration=@TGPoleSupDilaceration, " +
                    "TGPoleSupResultat=@TGPoleSupResultat, " +
                    "TGPoleMedNombreFragments=@TGPoleMedNombreFragments, " +
                    "TGPoleMedDilaceration= @TGPoleMedDilaceration" +
                    ",TGPoleMedResultat=@TGPoleMedResultat ," +
                    "TGPoleInfNombreFragments=@TGPoleInfNombreFragments,TGPoleInfDilaceration= @TGPoleInfDilaceration," +
                    "TGPoleInfResultat=@TGPoleInfResultat, " +
                    "TDPoleSupNombreFragments=@TDPoleSupNombreFragments, " +
                    "TDPoleSupDilaceration=@TDPoleSupDilaceration, " +
                    "TDPoleSupResultat=@TDPoleSupResultat, " +
                    "TDPoleMedNombreFragments=@TDPoleMedNombreFragments, " +
                    "TDPoleMedDilaceration=@TDPoleMedDilaceration, " +
                    "TDPoleMedResultat=@TDPoleMedResultat, " +
                    "TDPoleInfNombreFragments=@TDPoleInfNombreFragments, " +
                    "TDPoleInfDilaceration=@TDPoleInfDilaceration, " +
                    "TDPoleInfResultat=@TDPoleInfResultat   " +
                   
                    "where(IdMedicalRecordAct=@IdMedicalRecordAct);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;
                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdTreatingDoctor", actData.IdTreatingDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdEmbryologisteDoctor", actData.IdEmbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<string>(command, "@TypeBiopsieTesticulaire", actData.TypeBiopsieTesticulaire);
                CommandHelper.AddParameterValue<string>(command, "@ExamenAnatomopathologique", actData.ExamenAnatomopathologique);
                CommandHelper.AddParameterValue<int>(command, "@TGPoleSupNombreFragments", actData.TGPoleSupNombreFragments);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleSupDilaceration", actData.TGPoleSupDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleSupResultat", actData.TGPoleSupResultat);
                CommandHelper.AddParameterValue<int>(command, "@TGPoleMedNombreFragments", actData.TGPoleMedNombreFragments);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleMedDilaceration", actData.TGPoleMedDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleMedResultat", actData.TGPoleMedResultat);
                CommandHelper.AddParameterValue<int>(command, "@TGPoleInfNombreFragments", actData.TGPoleInfNombreFragments);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleInfDilaceration", actData.TGPoleInfDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TGPoleInfResultat", actData.TGPoleInfResultat);
                CommandHelper.AddParameterValue<int>(command, "@TDPoleSupNombreFragments", actData.TDPoleSupNombreFragments);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleSupDilaceration", actData.TDPoleSupDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleSupResultat", actData.TDPoleSupResultat);
                CommandHelper.AddParameterValue<int>(command, "@TDPoleMedNombreFragments", actData.TDPoleMedNombreFragments);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleMedDilaceration", actData.TDPoleMedDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleMedResultat", actData.TDPoleMedResultat);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleInfDilaceration", actData.TDPoleInfDilaceration);
                CommandHelper.AddParameterValue<string>(command, "@TDPoleInfResultat", actData.TDPoleInfResultat);
                CommandHelper.AddParameterValue<int>(command, "@TDPoleInfNombreFragments", actData.TDPoleInfNombreFragments);

                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataBiopsie MOdifier");
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
