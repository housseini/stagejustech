using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.ENTITIES;
using justch.Models.Service;

namespace justch.Models.DAL
{
    public class DAL_ActDataPonction
    {
        private static SqlConnection? connection = null;

        public static Message Add(ActDataPonction actData )
        {
            try {
                DalMigration.create_table_ActDataPonction();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ActDataPonction(IdMedicalRecordAct,IdTretingDoctor,IdEnbryologisteDoctor,IdIncubateur,EmbryologisteDoctorType, Chambre,Date,Heure,NombreFollicules,NombreType,NombreOvocytesCollectes,OvocytesDegeneres,Commentaires)"+
                    "VALUES(@IdMedicalRecordAct, @IdTretingDoctor, @IdEnbryologisteDoctor, @IdIncubateur, @EmbryologisteDoctorType  , @Chambre, @Date, @Heure, @NombreFollicules,@NombreType,@NombreOvocytesCollectes,@OvocytesDegeneres,@Commentaires);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdTretingDoctor", actData.IdTretingDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdIncubateur", actData.IdIncubateur);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Chambre", actData.Chambre);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<int>(command, "@NombreFollicules", actData.NombreFollicules);
                CommandHelper.AddParameterValue<int>(command, "@NombreType", actData.NombreType);
                CommandHelper.AddParameterValue<int>(command, "@NombreOvocytesCollectes", actData.NombreOvocytesCollectes);
                CommandHelper.AddParameterValue<int>(command, "@OvocytesDegeneres", actData.OvocytesDegeneres);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Ponction AJOUTER");
            }
            catch 
            {
                connection.Close();
                return new Message(false, "erreur d Ajout ");
               

            }
            finally
            {
                connection.Close();
            }
        }

        public static ActDataPonction Get(DataRow row)
        {
            ActDataPonction act = new ActDataPonction();
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdTretingDoctor = CommandHelper.ReadIdValue(row["IdTretingDoctor"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.IdIncubateur = CommandHelper.ReadIdValue(row["IdIncubateur"].ToString());
            act.IdEnbryologisteDoctor = CommandHelper.ReadIdValue(row["IdEnbryologisteDoctor"].ToString());
            act.NombreFollicules = CommandHelper.ReadIdValue(row["NombreFollicules"].ToString());
            act.NombreOvocytesCollectes = CommandHelper.ReadIdValue(row["NombreOvocytesCollectes"].ToString());
            act.NombreType = CommandHelper.ReadIdValue(row["NombreType"].ToString());
            act.OvocytesDegeneres = CommandHelper.ReadIdValue(row["OvocytesDegeneres"].ToString());
            act.Date= CommandHelper.ReadValue(row["Date"].ToString());
            act.Heure = CommandHelper.ReadValue(row["Heure"].ToString());
            act.Commentaires = CommandHelper.ReadValue(row["Commentaires"].ToString());
            act.Chambre = CommandHelper.ReadValue(row["Chambre"].ToString());
            act.EmbryologisteDoctorType = CommandHelper.ReadValue(row["EmbryologisteDoctorType"].ToString());
            return act;
        }
        public static List<ActDataPonction> Gets(DataTable table)
        {
            List<ActDataPonction> acts = new List<ActDataPonction>();

            foreach(DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<ActDataPonction> GETS(int Id)
        {
            DalMigration.create_table_ActDataPonction();
            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from ActDataPonction  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(ActDataPonction actData)
        {
            try
            {
                DalMigration.create_table_ActDataPonction();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE ActDataPonction SET "+
                    "IdTretingDoctor= @IdTretingDoctor,IdEnbryologisteDoctor= @IdEnbryologisteDoctor"+
                    ",IdIncubateur=@IdIncubateur,EmbryologisteDoctorType=@EmbryologisteDoctorType ,"+
                    " Chambre=@Chambre,Date=@Date,Heure= @Heure,NombreFollicules=@NombreFollicules,"+
                    "NombreType=@NombreType,NombreOvocytesCollectes=@NombreOvocytesCollectes,"+
                    "OvocytesDegeneres=@OvocytesDegeneres,Commentaires=@Commentaires " +
                    "where(IdMedicalRecordAct=@IdMedicalRecordAct);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdTretingDoctor", actData.IdTretingDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<int>(command, "@IdIncubateur", actData.IdIncubateur);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Chambre", actData.Chambre);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<int>(command, "@NombreFollicules", actData.NombreFollicules);
                CommandHelper.AddParameterValue<int>(command, "@NombreType", actData.NombreType);
                CommandHelper.AddParameterValue<int>(command, "@NombreOvocytesCollectes", actData.NombreOvocytesCollectes);
                CommandHelper.AddParameterValue<int>(command, "@OvocytesDegeneres", actData.OvocytesDegeneres);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Ponction MOdifier");
            }
            catch (Exception e)
            {
                connection.Close();
                return new Message(false, "erreur d Ajout :  "+e.Message);


            }
            finally
            {
                connection.Close();
            }
        }
    }
}
