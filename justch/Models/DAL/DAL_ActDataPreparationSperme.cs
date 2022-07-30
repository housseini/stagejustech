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
    public class DAL_ActDataPreparationSperme
    {

        private static SqlConnection? connection = null;

        public static Message Add(ActDataPreparationSperme actData)
        {
            try
            {
                DalMigration.create_table_ActDataPreparationSperme();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ActDataPreparationSperme("+
                    "IdMedicalRecordAct,IdAnalyseInitialeEnbryologiste," +
                    "SpermeDate"+
                    ",SpermeOrigine,SpermeMilieu" +
                    ",SpermePreparation,SpermeRecueil,SpermeCommentaire,AnalyseInitialeHeure,AnalyseInitialJoursAbstinence,AnalyseInitialeAspect,AnalyseInitialeVolume"+
                       ",AnalyseInitialeViscosite,AnalyseInitialeLiquefaction,AnalyseInitialeMorphologie,AnalyseInitialeLeucocytes,AnalyseInitialeCelluleRondes,AnalyseInitialeCelluleEpitheliales,AnalyseInitialeAgglutination"+
                        ",AnalyseInitialeMobilite,AnalyseInitialeConcentration,AnalyseInitialeCommentaires,ApresTraitementVolumeTraite,ApresTraitementVolumeFinal,ApresTraitementVolumeMobilite,ApresTraitementVolumeConcentration"+
                          ",ApresTraitementVolumeCommentaireFinal,ApresTraitementNumerationTotaleTd,ApresTraitementCommentaire)" +
                    "VALUES("+
                    "@IdMedicalRecordAct,@IdAnalyseInitialeEnbryologiste," +
                    "@SpermeDate" +
                    ",@SpermeOrigine,@SpermeMilieu" +
                    ",@SpermePreparation,@SpermeRecueil,@SpermeCommentaire,@AnalyseInitialeHeure,@AnalyseInitialJoursAbstinence,@AnalyseInitialeAspect,@AnalyseInitialeVolume" +
                       ",@AnalyseInitialeViscosite,@AnalyseInitialeLiquefaction,@AnalyseInitialeMorphologie,@AnalyseInitialeLeucocytes,@AnalyseInitialeCelluleRondes,@AnalyseInitialeCelluleEpitheliales,@AnalyseInitialeAgglutination" +
                        ",@AnalyseInitialeMobilite,@AnalyseInitialeConcentration,@AnalyseInitialeCommentaires,@ApresTraitementVolumeTraite,@ApresTraitementVolumeFinal,@ApresTraitementVolumeMobilite,@ApresTraitementVolumeConcentration" +
                          ",@ApresTraitementVolumeCommentaireFinal,@ApresTraitementNumerationTotaleTd,@ApresTraitementCommentaire);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdAnalyseInitialeEnbryologiste", actData.IdAnalyseInitialeEnbryologiste);
                CommandHelper.AddParameterValue<string>(command, "@SpermeDate", actData.SpermeDate);
                CommandHelper.AddParameterValue<string>(command, "@SpermeOrigine", actData.SpermeOrigine);
                CommandHelper.AddParameterValue<string>(command, "@SpermeMilieu", actData.SpermeMilieu);
                CommandHelper.AddParameterValue<string>(command, "@SpermePreparation", actData.SpermePreparation);
                CommandHelper.AddParameterValue<string>(command, "@SpermeRecueil", actData.SpermeRecueil);
                CommandHelper.AddParameterValue<string>(command, "@SpermeCommentaire", actData.SpermeCommentaire);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeHeure", actData.AnalyseInitialeHeure);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialJoursAbstinence", actData.AnalyseInitialJoursAbstinence);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeAspect", actData.AnalyseInitialeAspect);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeVolume", actData.AnalyseInitialeVolume);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeViscosite", actData.AnalyseInitialeViscosite);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeLiquefaction", actData.AnalyseInitialeLiquefaction);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeMorphologie", actData.AnalyseInitialeMorphologie);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeLeucocytes", actData.AnalyseInitialeLeucocytes);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeCelluleRondes", actData.AnalyseInitialeCelluleRondes);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeCelluleEpitheliales", actData.AnalyseInitialeCelluleEpitheliales);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeAgglutination", actData.AnalyseInitialeAgglutination);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeMobilite", actData.AnalyseInitialeMobilite);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeConcentration", actData.AnalyseInitialeConcentration);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeCommentaires", actData.AnalyseInitialeCommentaires);

                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementVolumeTraite", actData.ApresTraitementVolumeTraite);
                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementVolumeMobilite", actData.ApresTraitementVolumeMobilite);

                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementVolumeConcentration", actData.ApresTraitementVolumeConcentration);
                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementVolumeCommentaireFinal", actData.ApresTraitementVolumeCommentaireFinal);
                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementVolumeFinal", actData.ApresTraitementVolumeFinal);

                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementNumerationTotaleTd", actData.ApresTraitementNumerationTotaleTd);
                CommandHelper.AddParameterValue<string>(command, "@ApresTraitementCommentaire", actData.ApresTraitementCommentaire);

                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataPreparationSperme AJOUTER");
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

        public static ActDataPreparationSperme Get(DataRow row)
        {
            ActDataPreparationSperme act = new ActDataPreparationSperme();
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.IdAnalyseInitialeEnbryologiste = CommandHelper.ReadIdValue(row["IdAnalyseInitialeEnbryologiste"].ToString());
            act.IdAnalyseInitialeEnbryologiste = CommandHelper.ReadIdValue(row["IdAnalyseInitialeEnbryologiste"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.ApresTraitementVolumeTraite = CommandHelper.ReadIdValue(row["ApresTraitementVolumeTraite"].ToString());
            act.ApresTraitementVolumeFinal = CommandHelper.ReadIdValue(row["ApresTraitementVolumeFinal"].ToString());
            act.ApresTraitementVolumeMobilite = CommandHelper.ReadIdValue(row["ApresTraitementVolumeMobilite"].ToString());
            act.ApresTraitementVolumeConcentration = CommandHelper.ReadIdValue(row["ApresTraitementVolumeConcentration"].ToString());
            act.ApresTraitementVolumeCommentaireFinal = CommandHelper.ReadIdValue(row["ApresTraitementVolumeCommentaireFinal"].ToString());
            act.ApresTraitementNumerationTotaleTd = CommandHelper.ReadIdValue(row["ApresTraitementNumerationTotaleTd"].ToString());
            act.ApresTraitementNumerationTotaleTd = CommandHelper.ReadIdValue(row["ApresTraitementNumerationTotaleTd"].ToString());
            act.ApresTraitementCommentaire = CommandHelper.ReadValue(row["ApresTraitementCommentaire"].ToString());
            act.SpermeOrigine = CommandHelper.ReadValue(row["SpermeOrigine"].ToString());
            act.SpermeDate = CommandHelper.ReadValue(row["SpermeDate"].ToString());
            act.SpermeMilieu = CommandHelper.ReadValue(row["SpermeMilieu"].ToString());
            act.SpermePreparation = CommandHelper.ReadValue(row["SpermePreparation"].ToString());
            act.SpermeRecueil = CommandHelper.ReadValue(row["SpermeRecueil"].ToString());
            act.SpermeCommentaire = CommandHelper.ReadValue(row["SpermeCommentaire"].ToString());
            act.AnalyseInitialeHeure = CommandHelper.ReadValue(row["AnalyseInitialeHeure"].ToString());
            act.AnalyseInitialJoursAbstinence = CommandHelper.ReadValue(row["AnalyseInitialJoursAbstinence"].ToString());
            act.AnalyseInitialeAspect = CommandHelper.ReadValue(row["AnalyseInitialeAspect"].ToString());
            act.AnalyseInitialeVolume = CommandHelper.ReadValue(row["AnalyseInitialeVolume"].ToString());
            act.AnalyseInitialeViscosite = CommandHelper.ReadValue(row["AnalyseInitialeViscosite"].ToString());
            act.AnalyseInitialeLiquefaction = CommandHelper.ReadValue(row["AnalyseInitialeLiquefaction"].ToString());
            act.AnalyseInitialeMorphologie = CommandHelper.ReadValue(row["AnalyseInitialeMorphologie"].ToString());
            act.AnalyseInitialeLeucocytes = CommandHelper.ReadValue(row["AnalyseInitialeLeucocytes"].ToString());
            act.AnalyseInitialeCelluleRondes = CommandHelper.ReadValue(row["AnalyseInitialeCelluleRondes"].ToString());
            act.AnalyseInitialeCelluleEpitheliales = CommandHelper.ReadValue(row["AnalyseInitialeCelluleEpitheliales"].ToString());
            act.AnalyseInitialeAgglutination = CommandHelper.ReadValue(row["AnalyseInitialeAgglutination"].ToString());
            act.AnalyseInitialeMobilite = CommandHelper.ReadValue(row["AnalyseInitialeMobilite"].ToString());
            act.AnalyseInitialeConcentration = CommandHelper.ReadValue(row["AnalyseInitialeConcentration"].ToString());
            act.AnalyseInitialeCommentaires = CommandHelper.ReadValue(row["AnalyseInitialeCommentaires"].ToString());
            return act;
        }
        public static List<ActDataPreparationSperme> Gets(DataTable table)
        {
            List<ActDataPreparationSperme> acts = new List<ActDataPreparationSperme>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<ActDataPreparationSperme> GETS(int Id)
        {
            DalMigration.create_table_ActDataPreparationSperme();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from ActDataPreparationSperme  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(ActDataPreparationSperme actData)
        {
            try
            {
                DalMigration.create_table_ActDataPreparationSperme();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE ActDataPreparationSperme SET " +
                    "IdAnalyseInitialeEnbryologiste= @IdAnalyseInitialeEnbryologiste" +
                    ",SpermeDate=@SpermeDate ," +
                    "SpermeOrigine=@SpermeOrigine,SpermeMilieu= @SpermeMilieu," +
                    "SpermePreparation=@SpermePreparation, " +
                    "SpermeRecueil=@SpermeRecueil, " +
                    "SpermeCommentaire=@SpermeCommentaire, " +
                    "AnalyseInitialeHeure=@AnalyseInitialeHeure, " +
                    "AnalyseInitialJoursAbstinence=@AnalyseInitialJoursAbstinence, " +
                    "AnalyseInitialeAspect=@AnalyseInitialeAspect, " +
                    "AnalyseInitialeVolume=@AnalyseInitialeVolume, " +
                    "AnalyseInitialeViscosite= @AnalyseInitialeViscosite" +
                    ",AnalyseInitialeLiquefaction=@AnalyseInitialeLiquefaction ," +
                    "AnalyseInitialeMorphologie=@AnalyseInitialeMorphologie,AnalyseInitialeLeucocytes= @AnalyseInitialeLeucocytes," +
                    "AnalyseInitialeCelluleRondes=@AnalyseInitialeCelluleRondes, " +
                    "AnalyseInitialeCelluleEpitheliales=@AnalyseInitialeCelluleEpitheliales, " +
                    "AnalyseInitialeAgglutination=@AnalyseInitialeAgglutination, " +
                    "AnalyseInitialeMobilite=@AnalyseInitialeMobilite, " +
                    "AnalyseInitialeConcentration=@AnalyseInitialeConcentration, " +
                    "AnalyseInitialeCommentaires=@AnalyseInitialeCommentaires, " +
                    "ApresTraitementVolumeTraite=@ApresTraitementVolumeTraite, " +
                    "ApresTraitementVolumeFinal=@ApresTraitementVolumeFinal, " +
                    "ApresTraitementVolumeMobilite=@ApresTraitementVolumeMobilite, " +
                    "ApresTraitementVolumeConcentration=@ApresTraitementVolumeConcentration, " +
                    "ApresTraitementVolumeCommentaireFinal=@ApresTraitementVolumeCommentaireFinal, " +
                    "ApresTraitementNumerationTotaleTd=@ApresTraitementNumerationTotaleTd, " +
                    "ApresTraitementCommentaire=@ApresTraitementCommentaire " +
                    "where(IdMedicalRecordAct=@IdMedicalRecordAct);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;
                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdAnalyseInitialeEnbryologiste", actData.IdAnalyseInitialeEnbryologiste);
                CommandHelper.AddParameterValue<string>(command, "@SpermeDate", actData.SpermeDate);
                CommandHelper.AddParameterValue<string>(command, "@SpermeOrigine", actData.SpermeOrigine);
                CommandHelper.AddParameterValue<string>(command, "@SpermeMilieu", actData.SpermeMilieu);
                CommandHelper.AddParameterValue<string>(command, "@SpermePreparation", actData.SpermePreparation);
                CommandHelper.AddParameterValue<string>(command, "@SpermeRecueil", actData.SpermeRecueil);
                CommandHelper.AddParameterValue<string>(command, "@SpermeCommentaire", actData.SpermeCommentaire);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeHeure", actData.AnalyseInitialeHeure);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialJoursAbstinence", actData.AnalyseInitialJoursAbstinence);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeAspect", actData.AnalyseInitialeAspect);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeVolume", actData.AnalyseInitialeVolume);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeViscosite", actData.AnalyseInitialeViscosite);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeLiquefaction", actData.AnalyseInitialeLiquefaction);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeMorphologie", actData.AnalyseInitialeMorphologie);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeLeucocytes", actData.AnalyseInitialeLeucocytes);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeCelluleRondes", actData.AnalyseInitialeCelluleRondes);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeCelluleEpitheliales", actData.AnalyseInitialeCelluleEpitheliales);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeAgglutination", actData.AnalyseInitialeAgglutination);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeMobilite", actData.AnalyseInitialeMobilite);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeConcentration", actData.AnalyseInitialeConcentration);
                CommandHelper.AddParameterValue<string>(command, "@AnalyseInitialeCommentaires", actData.AnalyseInitialeCommentaires);

                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementVolumeTraite", actData.ApresTraitementVolumeTraite);
                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementVolumeMobilite", actData.ApresTraitementVolumeMobilite);

                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementVolumeConcentration", actData.ApresTraitementVolumeConcentration);
                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementVolumeCommentaireFinal", actData.ApresTraitementVolumeCommentaireFinal);
                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementVolumeFinal", actData.ApresTraitementVolumeFinal);

                CommandHelper.AddParameterValue<int>(command, "@ApresTraitementNumerationTotaleTd", actData.ApresTraitementNumerationTotaleTd);
                CommandHelper.AddParameterValue<string>(command, "@ApresTraitementCommentaire", actData.ApresTraitementCommentaire);

                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataPreparationSperme MOdifier");
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
