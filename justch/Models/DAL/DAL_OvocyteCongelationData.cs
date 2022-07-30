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
    public class DAL_OvocyteCongelationData
    {
        private static SqlConnection? connection = null;

        public static Message Add(OvocyteCongelationData actData)
        {
            try
            {
                DalMigration.create_table_OvocyteCongelationData();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO OvocyteCongelationData(IdPaillette," +
                    "IdEnbryologisteDoctor,EmbryologisteDoctorType,Date,Heure," + "Commentaires,IdActDataCongelationOvocyte,NumeroOvocyte,jourCongelation,Statu,Milieu)" +
                    "VALUES(@IdPaillette, @IdEnbryologisteDoctor, @EmbryologisteDoctorType  , @Date, @Heure,@Commentaires,@IdActDataCongelationOvocyte,@NumeroOvocyte,@jourCongelation,@Statu,@Milieu);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdPaillette", actData.IdPaillette);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<int>(command, "@jourCongelation", actData.jourCongelation);
                CommandHelper.AddParameterValue<string>(command, "@Milieu", actData.Milieu);
                CommandHelper.AddParameterValue<string>(command, "@Statu", actData.Statu);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                CommandHelper.AddParameterValue<int>(command, "@IdActDataCongelationOvocyte", actData.IdActDataCongelationOvocyte);
                CommandHelper.AddParameterValue<int>(command, "@NumeroOvocyte", actData.NumeroOvocyte);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " OvocyteCongelationData AJOUTER");
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

        public static OvocyteCongelationData Get(DataRow row)
        {
            OvocyteCongelationData act = new OvocyteCongelationData();
            act.IdActDataCongelationOvocyte = CommandHelper.ReadIdValue(row["IdActDataCongelationOvocyte"].ToString());
            act.NumeroOvocyte = CommandHelper.ReadIdValue(row["NumeroOvocyte"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdPaillette = CommandHelper.ReadIdValue(row["IdPaillette"].ToString());
            act.IdEnbryologisteDoctor = CommandHelper.ReadIdValue(row["IdEnbryologisteDoctor"].ToString());
            act.Date = CommandHelper.ReadValue(row["Date"].ToString());
            act.Heure = CommandHelper.ReadValue(row["Heure"].ToString());
            act.jourCongelation = CommandHelper.ReadIdValue(row["jourCongelation"].ToString());
            act.Statu = CommandHelper.ReadValue(row["Statu"].ToString());
            act.Milieu = CommandHelper.ReadValue(row["Milieu"].ToString());
            act.Commentaires = CommandHelper.ReadValue(row["Commentaires"].ToString());
            act.EmbryologisteDoctorType = CommandHelper.ReadValue(row["EmbryologisteDoctorType"].ToString());
            return act;
        }
        public static List<OvocyteCongelationData> Gets(DataTable table)
        {
            List<OvocyteCongelationData> acts = new List<OvocyteCongelationData>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<OvocyteCongelationData> GETS(int Id)
        {
            DalMigration.create_table_OvocyteCongelationData();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from OvocyteCongelationData  where(IdActDataCongelationOvocyte=@IdActDataCongelationOvocyte);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdActDataCongelationOvocyte", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(OvocyteCongelationData actData)
        {
            try
            {
                DalMigration.create_table_OvocyteCongelationData();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE OvocyteCongelationData SET " +
                    "IdEnbryologisteDoctor= @IdEnbryologisteDoctor" +
                    ",EmbryologisteDoctorType=@EmbryologisteDoctorType ," +
                    "Date=@Date,Heure= @Heure," +
                    "IdPaillette=@IdPaillette, " +
                    "Commentaires=@Commentaires, " +
                    "NumeroOvocyte=@NumeroOvocyte, " +
                    "jourCongelation=@jourCongelation, " +
                    "Statu=@Statu, " +
                    "Milieu=@Milieu  "
                      +
                    "where(IdActDataCongelationOvocyte=@IdActDataCongelationOvocyte);";

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
                CommandHelper.AddParameterValue<string>(command, "@Milieu", actData.Milieu);
                CommandHelper.AddParameterValue<int>(command, "@IdActDataCongelationOvocyte", actData.IdActDataCongelationOvocyte);
                CommandHelper.AddParameterValue<int>(command, "@NumeroOvocyte", actData.NumeroOvocyte);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " OvocyteCongelationData MOdifier");
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
