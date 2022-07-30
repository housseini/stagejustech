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
    public class DAL_EnbryonnaireCongelationData
    {

        private static SqlConnection? connection = null;

        public static Message Add(EnbryonnaireCongelationData actData)
        {
            try
            {
                DalMigration.create_table_EnbryonnaireCongelationData();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO EnbryonnaireCongelationData(IdPaillette,"+
                    "IdEnbryologisteDoctor,EmbryologisteDoctorType,Date,Heure,"+"Commentaires,IdActDataCongelationEnbryonnaire,NumeroEnbroyon,jourCongelation,Statu,GradeEnbryon,Milieu)" +
                    "VALUES(@IdPaillette, @IdEnbryologisteDoctor, @EmbryologisteDoctorType  , @Date, @Heure,@Commentaires,@IdActDataCongelationEnbryonnaire,@NumeroEnbroyon,@jourCongelation,@Statu,@GradeEnbryon,@Milieu);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdPaillette", actData.IdPaillette);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<int>(command, "@jourCongelation", actData.jourCongelation);
                CommandHelper.AddParameterValue<string>(command, "@GradeEnbryon", actData.GradeEnbryon);
                CommandHelper.AddParameterValue<string>(command, "@Milieu", actData.Milieu);
                CommandHelper.AddParameterValue<string>(command, "@Statu", actData.Statu);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                CommandHelper.AddParameterValue<int>(command, "@IdActDataCongelationEnbryonnaire", actData.IdActDataCongelationEnbryonnaire);
                CommandHelper.AddParameterValue<int>(command, "@NumeroEnbroyon", actData.NumeroEnbroyon);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " EnbryonnaireCongelationData AJOUTER");
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

        public static EnbryonnaireCongelationData Get(DataRow row)
        {
            EnbryonnaireCongelationData act = new EnbryonnaireCongelationData();
            act.IdActDataCongelationEnbryonnaire = CommandHelper.ReadIdValue(row["IdActDataCongelationEnbryonnaire"].ToString());
            act.NumeroEnbroyon = CommandHelper.ReadIdValue(row["NumeroEnbroyon"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdPaillette = CommandHelper.ReadIdValue(row["IdPaillette"].ToString());
            act.IdEnbryologisteDoctor = CommandHelper.ReadIdValue(row["IdEnbryologisteDoctor"].ToString());
            act.Date = CommandHelper.ReadValue(row["Date"].ToString());
            act.Heure = CommandHelper.ReadValue(row["Heure"].ToString());
            act.jourCongelation = CommandHelper.ReadIdValue(row["jourCongelation"].ToString());
            act.Statu = CommandHelper.ReadValue(row["Statu"].ToString());
            act.GradeEnbryon = CommandHelper.ReadValue(row["GradeEnbryon"].ToString());
            act.Milieu = CommandHelper.ReadValue(row["Milieu"].ToString());
            act.Commentaires = CommandHelper.ReadValue(row["Commentaires"].ToString());
            act.EmbryologisteDoctorType = CommandHelper.ReadValue(row["EmbryologisteDoctorType"].ToString());
            return act;
        }
        public static List<EnbryonnaireCongelationData> Gets(DataTable table)
        {
            List<EnbryonnaireCongelationData> acts = new List<EnbryonnaireCongelationData>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<EnbryonnaireCongelationData> GETS(int Id)
        {
            DalMigration.create_table_EnbryonnaireCongelationData();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from EnbryonnaireCongelationData  where(IdActDataCongelationEnbryonnaire=@IdActDataCongelationEnbryonnaire);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdActDataCongelationEnbryonnaire", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(EnbryonnaireCongelationData actData)
        {
            try
            {
                DalMigration.create_table_EnbryonnaireCongelationData();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE EnbryonnaireCongelationData SET " +
                    "IdEnbryologisteDoctor= @IdEnbryologisteDoctor" +
                    ",EmbryologisteDoctorType=@EmbryologisteDoctorType ," +
                    "Date=@Date,Heure= @Heure," +
                    "IdPaillette=@IdPaillette, " +
                    "Commentaires=@Commentaires, " +
                    "NumeroEnbroyon=@NumeroEnbroyon, " +
                    "jourCongelation=@jourCongelation, " +
                    "Statu=@Statu, " +
                    "GradeEnbryon=@GradeEnbryon, " +
                    "Milieu=@Milieu  " 
                      +
                    "where(IdActDataCongelationEnbryonnaire=@IdActDataCongelationEnbryonnaire);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdPaillette", actData.IdPaillette);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                CommandHelper.AddParameterValue<int>(command, "@jourCongelation", actData.jourCongelation);
                CommandHelper.AddParameterValue<string>(command, "@Statu", actData.Statu);
                CommandHelper.AddParameterValue<string>(command, "@GradeEnbryon", actData.GradeEnbryon);
                CommandHelper.AddParameterValue<string>(command, "@Milieu", actData.Milieu);
                CommandHelper.AddParameterValue<int>(command, "@IdActDataCongelationEnbryonnaire", actData.IdActDataCongelationEnbryonnaire);
                CommandHelper.AddParameterValue<int>(command, "@NumeroEnbroyon", actData.NumeroEnbroyon);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " EnbryonnaireCongelationData MOdifier");
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
