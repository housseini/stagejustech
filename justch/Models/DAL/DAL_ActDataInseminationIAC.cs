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
    public class DAL_ActDataInseminationIAC
    {
        private static SqlConnection? connection = null;

        public static Message Add(ActDataInseminationIAC actData)
        {
            try
            {
                DalMigration.create_table_ActDataInseminationIAC();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ActDataInseminationIAC(IdMedicalRecordAct,IdEnbryologisteDoctor,EmbryologisteDoctorType,Date,Heure,Commentaires,VolumeInsemine,NombreSpermatozoidesInsemines,catheter,Transerfer,Sang,Glaire)" +
                    "VALUES(@IdMedicalRecordAct, @IdEnbryologisteDoctor, @EmbryologisteDoctorType  , @Date, @Heure,@Commentaires,@VolumeInsemine,@NombreSpermatozoidesInsemines,@catheter,@Transerfer,@Sang,@Glaire);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<string>(command, "@catheter", actData.catheter);
                CommandHelper.AddParameterValue<string>(command, "@Sang", actData.Sang);
                CommandHelper.AddParameterValue<string>(command, "@Glaire", actData.Glaire);
                CommandHelper.AddParameterValue<string>(command, "@Transerfer", actData.Transerfer);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                CommandHelper.AddParameterValue<int>(command, "@VolumeInsemine", actData.VolumeInsemine);
                CommandHelper.AddParameterValue<int>(command, "@NombreSpermatozoidesInsemines", actData.NombreSpermatozoidesInsemines);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataInseminationIAC AJOUTER");
            }
            catch (Exception e)
            {
                connection.Close();
                return new Message(false, "erreur d Ajout "+e.Message);


            }
            finally
            {
                connection.Close();
            }
        }

        public static ActDataInseminationIAC Get(DataRow row)
        {
            ActDataInseminationIAC act = new ActDataInseminationIAC();
            act.VolumeInsemine = CommandHelper.ReadIdValue(row["VolumeInsemine"].ToString());
            act.NombreSpermatozoidesInsemines = CommandHelper.ReadIdValue(row["NombreSpermatozoidesInsemines"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.IdEnbryologisteDoctor = CommandHelper.ReadIdValue(row["IdEnbryologisteDoctor"].ToString());
            act.Date = CommandHelper.ReadValue(row["Date"].ToString());
            act.Heure = CommandHelper.ReadValue(row["Heure"].ToString());
            act.catheter = CommandHelper.ReadValue(row["catheter"].ToString());
            act.Transerfer = CommandHelper.ReadValue(row["Transerfer"].ToString());
            act.Sang = CommandHelper.ReadValue(row["Sang"].ToString());
            act.Glaire = CommandHelper.ReadValue(row["Glaire"].ToString());
            act.Commentaires = CommandHelper.ReadValue(row["Commentaires"].ToString());
            act.EmbryologisteDoctorType = CommandHelper.ReadValue(row["EmbryologisteDoctorType"].ToString());
            return act;
        }
        public static List<ActDataInseminationIAC> Gets(DataTable table)
        {
            List<ActDataInseminationIAC> acts = new List<ActDataInseminationIAC>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<ActDataInseminationIAC> GETS(int Id)
        {
            DalMigration.create_table_ActDataInseminationIAC();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from ActDataInseminationIAC  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(ActDataInseminationIAC actData)
        {
            try
            {
                DalMigration.create_table_ActDataInseminationIAC();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE ActDataInseminationIAC SET " +
                    "IdEnbryologisteDoctor= @IdEnbryologisteDoctor" +
                    ",EmbryologisteDoctorType=@EmbryologisteDoctorType ," +
                    "Date=@Date,Heure= @Heure," +
                    "Commentaires=@Commentaires, " +
                    "NombreSpermatozoidesInsemines=@NombreSpermatozoidesInsemines, " +
                    "catheter=@catheter, " +
                    "Transerfer=@Transerfer, " +
                    "Sang=@Sang, " +
                    "Glaire=@Glaire, " +
                      "VolumeInsemine=@VolumeInsemine " +
                    "where(IdMedicalRecordAct=@IdMedicalRecordAct);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                CommandHelper.AddParameterValue<string>(command, "@catheter", actData.catheter);
                CommandHelper.AddParameterValue<string>(command, "@Transerfer", actData.Transerfer);
                CommandHelper.AddParameterValue<string>(command, "@Sang", actData.Sang);
                CommandHelper.AddParameterValue<string>(command, "@Glaire", actData.Glaire);
                CommandHelper.AddParameterValue<int>(command, "@VolumeInsemine", actData.VolumeInsemine);
                CommandHelper.AddParameterValue<int>(command, "@NombreSpermatozoidesInsemines", actData.NombreSpermatozoidesInsemines);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataInseminationIAC MOdifier");
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
