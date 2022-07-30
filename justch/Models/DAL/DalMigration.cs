using justch.Models.ENTITIES;
using System;
using justch.Models.DAL;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DalMigration
    {

        public static Message create_all()
        {
            try
            {
                create_table_Patient();
                create_table_DossierMedicale();
                create_table_DossierMedicalPatient();
                create_table_DocumentType();
                create_table_Document();
                create_table_Doctor();
                create_table_MedicalAct();
                create_table_MedicalRecordAct();
                create_table_Appointment();
                create_table_RoomType();
                create_table_Room();
                create_table_RoomMedicalAct();
                create_table_TraitementCycle();
                create_table_Utilisateur();
                return new Message(true, "Tables create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }


        }


        public static Message create_table_Patient()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Patient') CREATE TABLE [dbo].[Patient] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[Cin]             VARCHAR(200) NOT NULL,[IssuedOn]        NVARCHAR(MAX)NULL,[FirstName]       NVARCHAR(MAX) NOT NULL,[LastName]        NVARCHAR(MAX) NOT NULL,[MaidenName]       NVARCHAR(MAX) NULL,[State]     NVARCHAR(MAX) NULL,[Gender]          NVARCHAR(MAX) NULL,[Profession]      NVARCHAR(MAX) NULL,[Photo]           NVARCHAR(MAX) NULL,[Phone]           VARCHAR(250) NOT NULL,[Email]           VARCHAR(250) NULL,[Dataofbirth]     DATE NULL,[Placeofbirth]    NVARCHAR(MAX) NULL,[Address]         NVARCHAR(MAX) NULL,[PostalCode]      NVARCHAR(MAX) NULL,[City]            NVARCHAR(MAX) NULL,[Country]         NVARCHAR(MAX) NULL,[InsuranceAgency] NVARCHAR(MAX) NULL,[InsuranceID]     NVARCHAR(MAX) NULL,[Nationality]     NVARCHAR(MAX) NULL,[Civility]        NVARCHAR(MAX) NULL,[Addedon]       DATETIME      DEFAULT (getdate()) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC)); ALTER TABLE [dbo].[Patient] ADD  UNIQUE (Cin); ALTER TABLE [dbo].[Patient] ADD  UNIQUE (Email); ALTER TABLE [dbo].[Patient] ADD  UNIQUE (Phone);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Patient  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }
        public static Message create_table_DossierMedicale()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'DossierMedical') CREATE TABLE [dbo].[DossierMedical] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[Reference]             VARCHAR(250) NOT NULL,[DateAdmission]       DATETIME   NULL ,[Type]        NVARCHAR(MAX) NOT NULL,[State]       NVARCHAR(MAX) NULL, [DateCreation]       DATETIME      DEFAULT (GETDATE()) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC)) ; ALTER TABLE [dbo].[DossierMedical] ADD  UNIQUE (Reference);";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Dossier Medical  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_DossierMedicalPatient()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'DossierMedicalPatient') CREATE TABLE [dbo].[DossierMedicalPatient] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[Role]             NVARCHAR(MAX)  NULL,[IdPatient]       BIGINT   NOT NULL  ,[Observation]        NVARCHAR(MAX)  NULL, [IdDossierMedical]       BIGINT     NOT NULL ,PRIMARY KEY CLUSTERED([Id] ASC))  ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table DossierMedicalPatien  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_DocumentType()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'DocumentType') CREATE TABLE [dbo].[DocumentType] ([Code]         VARCHAR(250)  NOT NULL,[Label]        NVARCHAR(MAX) NOT NULL,PRIMARY KEY CLUSTERED([Code] ASC)) ; ALTER TABLE [dbo].[DocumentType] ADD  UNIQUE (Code);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table DOCUMENTTYPE   create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_Document()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Document') CREATE TABLE [dbo].[Document] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[IdPatient]           BIGINT   NOT NULL,[IdDossierMedical]       BIGINT  NOT NULL,[Name]        NVARCHAR(MAX) NOT NULL,[CodeDocumentType]       VARCHAR(250)  NOT NULL,[Description]       NVARCHAR(MAX) NULL, [Path]      NVARCHAR(MAX)  NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC)) ; ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table DOCUMENT   create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_Doctor()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Doctor') CREATE TABLE [dbo].[Doctor] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[FirstName]           NVARCHAR(MAX) NOT NULL ,[LastName]       NVARCHAR(MAX) NOT NULL,[Speciality]        NVARCHAR(MAX) NOT NULL,[Phone1]       NVARCHAR(MAX)  NOT NULL,[Phone2]       NVARCHAR(MAX) NULL, [Email]      VARCHAR(250)  NOT NULL,[Adress]       NVARCHAR(MAX) NULL,[Affiliation]       NVARCHAR(MAX) NULL, [Type]       NVARCHAR(MAX) NULL,PRIMARY KEY CLUSTERED([Id] ASC));ALTER TABLE [dbo].[Doctor] ADD  UNIQUE (Email); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table DOCTEUR   create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_MedicalAct()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'MedicalAct') CREATE TABLE [dbo].[MedicalAct] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[Name]           NVARCHAR(250) NOT NULL UNIQUE ,[MedicalActType]       NVARCHAR(MAX) NOT NULL,[Duration]        NVARCHAR(MAX) NOT NULL,[Category]       NVARCHAR(MAX)  NOT NULL,[IdRoom]  BIGINT  NOT NULL ,PRIMARY KEY CLUSTERED([Id] ASC)); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table MedicalAct   create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_MedicalRecordAct()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'MedicalRecordAct') CREATE TABLE [dbo].[MedicalRecordAct] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[Patients]           NVARCHAR(MAX) NOT NULL ,[MedicalActType]       NVARCHAR(MAX) NOT NULL,[MedicalActName]        NVARCHAR(MAX) NOT NULL,[Rang]        NVARCHAR(MAX) NULL,[State]        NVARCHAR(MAX) NULL,[IdMedicalRecord]      BIGINT NOT NULL,[IdPrescribingDoctorMedical]      BIGINT NOT NULL ,[IdMedicalAct]      BIGINT NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC)); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table MedicalRecordAct   create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_Appointment()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Appointment') CREATE TABLE [dbo].[Appointment] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[IdPatient1]           BIGINT NOT NULL ,[IdPatient2]     BIGINT  NULL,[IdRoom1]        BIGINT NOT NULL,[IdRoom2]        BIGINT NULL,[IdPrescribingDoctor1]        BIGINT NOT NULL,[IdPrescribingDoctor2]      BIGINT  NULL,[IdMedicalAct1]      BIGINT NOT NULL ,[IdMedicalAct2]   BIGINT    NULL,[Date]   DATETIME  NOT NULL,[Hour1]    DATETIME NOT  NULL,[Hour2]   DATETIME NOT   NULL,[Notes]     NVARCHAR(MAX) NULL,[State]    NVARCHAR(MAX)   NULL,PRIMARY KEY CLUSTERED([Id] ASC)); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Appointment   create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_Room()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Room') CREATE TABLE [dbo].[Room] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[Name]           NVARCHAR(MAX) NOT NULL ,[IdRoomType]    BIGINT NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC)); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Room   create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_RoomType()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'RoomType') CREATE TABLE [dbo].[RoomType] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[Name]   NVARCHAR(255) NOT NULL  UNIQUE ,PRIMARY KEY CLUSTERED([Id] ASC));";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table RoomType   create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_RoomMedicalAct()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'RoomMedicalAct') CREATE TABLE [dbo].[RoomMedicalAct] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[idRoom]          BIGINT NOT NULL,[IdMedicalAct]          BIGINT NOT NULL  ,PRIMARY KEY CLUSTERED([Id] ASC)); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table RoomMedicalAct   create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_TraitementCycle()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'TraitementCycle') CREATE TABLE [dbo].[TraitementCycle] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[Name]          NVARCHAR(250) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC)); ALTER TABLE [dbo].[TraitementCycle] ADD  UNIQUE (Name); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table TreatmentCycle     create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_TreatmentCycleElementaryAct()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'TreatmentCycleElementact') CREATE TABLE [dbo].[TreatmentCycleElementact] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[IdMedicalAct]              BIGINT NOT NULL, [IdTraitementCycle]              BIGINT NOT NULL ,PRIMARY KEY CLUSTERED([Id] ASC)); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table TreatmentCycleElementact     create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_table_TechnienEnbrylogiste()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'TechnienEnbrylogiste') CREATE TABLE [dbo].[TechnienEnbrylogiste] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[FirsName]          NVARCHAR(MAX) NOT NULL, [LastName]          NVARCHAR(MAX) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC)); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, " create_table_TechnienEnbrylogiste     create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }
        public static Message create_View_Patient_DossierMedicalPatient_DossierMedicale()
        {
            try
            {
                string query = "CREATE  VIEW [view_P_DMP_DM] AS SELECT  p.Id,FirstName,LastName,Cin ,IssuedOn ,MaidenName,Gender,Photo, Profession,Email ,Phone,Dataofbirth,Placeofbirth,Address,PostalCode, City,Country,InsuranceAgency,InsuranceID ,Nationality,Civility,Reference,DateAdmission,Type,dm.State ,IdPatient,IdDossierMedical,Role,Observation FROM Patient p,DossierMedicalPatient dmp ,DossierMedical dm where(p.Id=dmp.IdPatient AND dmp.IdDossierMedical=dm.Id );";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "VIEW view_P_DMP_DM     create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }

        public static Message create_table_Utilisateur()
        {

            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Utilisateur') CREATE TABLE [dbo].[Utilisateur] ([Id]              BIGINT IDENTITY(1, 1) NOT NULL,[UserName]             VARCHAR(250) NOT NULL,[email]       NVARCHAR(MAX)   NOT NULL ,[Type]        NVARCHAR(MAX) NOT NULL,[Password]       NVARCHAR(MAX) NULL, [DateCreation]       DATETIME      DEFAULT (GETDATE()) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC)) ; ALTER TABLE [dbo].[Utilisateur] ADD  UNIQUE (UserName); ; ALTER TABLE [dbo].[Utilisateur] ADD  UNIQUE (email);";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Utilisateur create");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }

        }

        public static Message create_table_RenseignementClinique()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'RenseignementClinique') CREATE TABLE [dbo].[RenseignementClinique] ([IdMedicalRecord] BIGINT  NOT NULL UNIQUE,    [Id]              BIGINT IDENTITY(1, 1) NOT NULL,[TypeDinfertilite]             VARCHAR(200) NOT NULL,[DurerDinfertilite]      BIGINT   NOT NULL,[Remarques]       NVARCHAR(MAX)  NULL,[NombreGrossesses]        NVARCHAR(MAX)  NULL,[DateGrossesses]       NVARCHAR(MAX) NULL,[NombreEnfants]     NVARCHAR(MAX) NULL,[DateEnfants]          NVARCHAR(MAX) NULL,[NombreGeu]      NVARCHAR(MAX) NULL,[DateGeu]           NVARCHAR(MAX) NULL,[NombreAvortement]           VARCHAR(250)  NULL,[DateAvortement]           VARCHAR(250) NULL,[PoidMonsieur]       VARCHAR(25) NULL,[TailleMonsieur]    NVARCHAR(25) NULL,[BMIMMonsieur]         NVARCHAR(250) NULL,[PoidMadame]      NVARCHAR(25) NULL,[TailleMadame]            NVARCHAR(25) NULL,[BMIMMMadame]         NVARCHAR(25) NULL,[Techniques] NVARCHAR(MAX) NULL,[Indications]     NVARCHAR(MAX) NULL,[Observation]     NVARCHAR(MAX) NULL,PRIMARY KEY CLUSTERED([Id] ASC));";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table RenseignementClinique  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }

        public static Message create_table_TentativeAnterieure()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'TentativeAnterieure') CREATE TABLE [dbo].[TentativeAnterieure] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdRenseignementClinique] BIGINT  NOT NULL," +
                    "[Acte] VARCHAR(200) NOT NULL," +
                    "[Remarques] VARCHAR(200) NOT NULL," +
                    "[Resultats] NVARCHAR(MAX)  NULL," +
                    "[Date] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table TentativeAnterieure  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }
        public static Message create_table_ExamenComplementaire()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ExamenComplementaire') CREATE TABLE [dbo].[ExamenComplementaire] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdRenseignementClinique] BIGINT  NOT NULL," +
                    "[Echo] VARCHAR(MAX) NOT NULL," +
                    "[Hsg] VARCHAR(MAX) NOT NULL," +
                    "[Hsg_Hs] NVARCHAR(MAX)  NULL," +
                    "[Tpc] NVARCHAR(MAX) NULL," +
                    "[Cytogenetique] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ExamenComplementaire  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }
        public static Message create_table_AntecedentParticulier()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'AntecedentParticulier') CREATE TABLE [dbo].[AntecedentParticulier] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdRenseignementClinique] BIGINT  NOT NULL," +
                    "[TypeAntecedent] VARCHAR(MAX) NOT NULL," +
                    "[Medicaux] VARCHAR(MAX)  NULL," +
                    "[Familiaux] NVARCHAR(MAX) NULL," +
                    "[Gynecologiques] NVARCHAR(MAX) NULL," +
                    "[Tabac] VARCHAR(MAX)  NULL," +
                    "[Chirurgicaux] NVARCHAR(200)  NULL," +
                    "[Alcool] NVARCHAR(200) NULL," +
                    "[Autres] NVARCHAR(200) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table AntecedentParticulier  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }

        public static Message create_table_Serologie()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Serologie') CREATE TABLE [dbo].[Serologie] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdRenseignementClinique] BIGINT  NOT NULL," +
                    "[TypeSerologie] VARCHAR(MAX) NOT NULL," +
                    "[Date] VARCHAR(MAX)  NULL," +
                    "[Hiv] NVARCHAR(MAX)  NULL," +
                    "[Hvb] NVARCHAR(MAX) NULL," +
                    "[Hvc] NVARCHAR(MAX) NULL," +
                    "[Syphilis] VARCHAR(MAX)  NULL," +
                    "[Chlamydia] NVARCHAR(200)  NULL," +
                    "[Mycoplasmes] NVARCHAR(200) NULL," +
                    "[Autres] NVARCHAR(200) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Serologie  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }
        public static Message create_table_BilanEncodocrinien()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'BilanEncodocrinien') CREATE TABLE [dbo].[BilanEncodocrinien] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdRenseignementClinique] BIGINT  NOT NULL," +
                    "[Type] VARCHAR(MAX) NOT NULL," +
                    "[Date] VARCHAR(MAX)  NULL," +
                    "[Fsh] NVARCHAR(MAX)  NULL," +
                    "[Lh] NVARCHAR(MAX) NULL," +
                    "[Prolactine] NVARCHAR(MAX) NULL," +
                    "[Tsh] VARCHAR(MAX)  NULL," +
                    "[E2] NVARCHAR(200)  NULL," +
                    "[Progesterone] NVARCHAR(200) NULL," +
                    "[Amh] NVARCHAR(200) NULL," +
                     "[Testosterone] NVARCHAR(200) NULL," +
                    "[Autres] NVARCHAR(200) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table BilanEncodocrinien  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }

        public static Message create_table_SpermogrammeTMS()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'SpermogrammeTMS') CREATE TABLE [dbo].[SpermogrammeTMS] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdRenseignementClinique] BIGINT  NOT NULL," +
                    "[Date] VARCHAR(MAX)  NULL," +
                    "[Vol] NVARCHAR(MAX)  NULL," +
                    "[Num] NVARCHAR(MAX) NULL," +
                    "[Mobilite] NVARCHAR(MAX) NULL," +
                    "[Vita] VARCHAR(MAX)  NULL," +
                    "[Ft] NVARCHAR(200)  NULL," +
                    "[Leuco] NVARCHAR(200) NULL" +

                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table SpermogrammeTMS  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }


        public static Message create_table_ActDataPreparationSperme()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataPreparationSperme') CREATE TABLE [dbo].[ActDataPreparationSperme] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdMedicalRecordAct] BIGINT  NOT NULL," +
                    "[IdAnalyseInitialeEnbryologiste]  BIGINT  NOT  NULL," +
                    "[SpermeDate] NVARCHAR(MAX)  NULL," +
                    "[SpermeOrigine] NVARCHAR(MAX) NULL," +
                    "[SpermeMilieu] NVARCHAR(MAX) NULL," +
                    "[SpermePreparation] VARCHAR(MAX)  NULL," +
                    "[SpermeRecueil] NVARCHAR(200)  NULL," +
                    "[SpermeCommentaire] NVARCHAR(200) NULL," +
                    "[AnalyseInitialeHeure] NVARCHAR(MAX)  NULL," +
                    "[AnalyseInitialJoursAbstinence] NVARCHAR(MAX) NULL," +
                    "[AnalyseInitialeAspect] NVARCHAR(MAX) NULL," +
                    "[AnalyseInitialeVolume] VARCHAR(MAX)  NULL," +
                    "[AnalyseInitialeViscosite] NVARCHAR(200)  NULL," +
                    "[AnalyseInitialeLiquefaction] NVARCHAR(200) NULL," +
                    "[AnalyseInitialeMorphologie] NVARCHAR(MAX)  NULL," +
                    "[AnalyseInitialeLeucocytes] NVARCHAR(MAX) NULL," +
                    "[AnalyseInitialeCelluleRondes] NVARCHAR(MAX) NULL," +
                    "[AnalyseInitialeCelluleEpitheliales] VARCHAR(MAX)  NULL," +
                    "[AnalyseInitialeAgglutination] NVARCHAR(200)  NULL," +
                    "[AnalyseInitialeMobilite] NVARCHAR(200) NULL," +
                    "[AnalyseInitialeConcentration] NVARCHAR(MAX)  NULL," +
                    "[AnalyseInitialeCommentaires] NVARCHAR(MAX) NULL," +
                    "[ApresTraitementVolumeFinal] BIGINT NULL," +
                    "[ApresTraitementVolumeTraite] BIGINT NULL," +

                    "[ApresTraitementVolumeMobilite] BIGINT  NULL," +
                    "[ApresTraitementVolumeConcentration] BIGINT  NULL," +
                    "[ApresTraitementVolumeCommentaireFinal] BIGINT NULL," +
                     "[ApresTraitementNumerationTotaleTd] BIGINT  NULL," +
                    "[ApresTraitementCommentaire] NVARCHAR(MAX)  NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataPreparationSperme  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }

        public static Message create_table_ActDataPonction()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataPonction') CREATE TABLE [dbo].[ActDataPonction] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdMedicalRecordAct] BIGINT  NOT NULL UNIQUE," +
                    "[IdTretingDoctor]  BIGINT  NOT  NULL," +
                     "[IdEnbryologisteDoctor]  BIGINT  NOT  NULL," +
                    "[IdIncubateur]  BIGINT  NOT  NULL," +
                    "[EmbryologisteDoctorType] NVARCHAR(MAX)  NULL," +
                    "[Chambre] NVARCHAR(MAX) NULL," +
                    "[Date] NVARCHAR(MAX) NULL," +
                    "[Heure] NVARCHAR(MAX) NULL," +

                    "[NombreFollicules] VARCHAR(MAX)  NULL," +
                    "[NombreType] NVARCHAR(200)  NULL," +
                    "[NombreOvocytesCollectes] NVARCHAR(200) NULL," +

                    "[OvocytesDegeneres] NVARCHAR(MAX)  NULL," +
                    "[Commentaires] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataPonction  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }


        public static Message create_table_ActDataDecoronisation()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataDecoronisation') CREATE TABLE [dbo].[ActDataDecoronisation] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdMedicalRecordAct] BIGINT  NOT NULL UNIQUE," +

                     "[IdEnbryologisteDoctor]  BIGINT  NOT  NULL," +

                    "[EmbryologisteDoctorType] NVARCHAR(MAX)  NULL," +

                    "[Date] NVARCHAR(MAX) NULL," +
                    "[Heure] NVARCHAR(MAX) NULL," +
                    "[Commentaires] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataDecoronisation  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }

        public static Message create_table_ActDataInjection()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataInjection') CREATE TABLE [dbo].[ActDataInjection] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdMedicalRecordAct] BIGINT  NOT NULL UNIQUE," +

                     "[IdEnbryologisteDoctor]  BIGINT  NOT  NULL," +
                       "[NombreOVocytesInjectes]  BIGINT  NOT  NULL," +
                    "[EmbryologisteDoctorType] NVARCHAR(MAX)  NULL," +

                    "[Date] NVARCHAR(MAX) NULL," +
                    "[Heure] NVARCHAR(MAX) NULL," +
                    "[Commentaires] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataInjection  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }
        public static Message create_table_ActDataCongelationBiopsieTesticulaire()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataCongelationBiopsieTesticulaire') CREATE TABLE [dbo].[ActDataCongelationBiopsieTesticulaire] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdMedicalRecordAct] BIGINT  NOT NULL UNIQUE," +
                     "[IdEnbryologisteDoctor]  BIGINT  NOT  NULL," +
                     "[Milieu]  NVARCHAR(MAX)  NOT  NULL," +
                    "[EmbryologisteDoctorType] NVARCHAR(MAX)  NULL," +
                    "[Date] NVARCHAR(MAX) NULL," +
                    "[Heure] NVARCHAR(MAX) NULL," +
                    "[Commentaires] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataCongelationBiopsieTesticulaire  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }

        public static Message create_table_ActDataInseminationIAC()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataInseminationIAC') CREATE TABLE [dbo].[ActDataInseminationIAC] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdMedicalRecordAct] BIGINT  NOT NULL UNIQUE," +
                     "[IdEnbryologisteDoctor]  BIGINT  NOT  NULL," +
                     "[VolumeInsemine]  BIGINT  NOT  NULL," +
                     "[NombreSpermatozoidesInsemines]  BIGINT  NOT  NULL," +
                    "[EmbryologisteDoctorType] NVARCHAR(MAX)  NULL," +
                    "[catheter] NVARCHAR(MAX) NULL," +
                    "[Glaire] NVARCHAR(MAX) NULL," +
                    "[Transerfer] NVARCHAR(MAX) NULL," +
                    "[Sang] NVARCHAR(MAX) NULL," +
                    "[Date] NVARCHAR(MAX) NULL," +
                    "[Heure] NVARCHAR(MAX) NULL," +
                    "[Commentaires] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataInseminationIAC  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }

        public static Message create_table_ActDataTransfertsEnbryonnaire()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataTransfertsEnbryonnaire') CREATE TABLE [dbo].[ActDataTransfertsEnbryonnaire] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdMedicalRecordAct] BIGINT  NOT NULL UNIQUE," +
                     "[IdEnbryologisteDoctor]  BIGINT  NOT  NULL," +
                    
                     "[NombreEnbryonsTransferes]  NVARCHAR(MAX)  NOT  NULL," +
                    "[EmbryologisteDoctorType] NVARCHAR(MAX)  NULL," +
                    "[catheter] NVARCHAR(MAX) NULL," +
                    "[Glaire] NVARCHAR(MAX) NULL," +
                    "[Transerfer] NVARCHAR(MAX) NULL," +
                    "[Sang] NVARCHAR(MAX) NULL," +
                    "[Date] NVARCHAR(MAX) NULL," +
                    "[Heure] NVARCHAR(MAX) NULL," +
                    "[Commentaires] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataInseminationIAC  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }



        public static Message create_table_EnbryonTransfertData()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'EnbryonTransfertData') CREATE TABLE [dbo].[EnbryonTransfertData] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdActDataTransfertsEnbryonnaire] BIGINT  NOT NULL UNIQUE," +
                     "[Numeroenbryon]  BIGINT  NOT  NULL," +

                     "[Jourtransfert]  NVARCHAR(MAX)  NOT  NULL" +
       
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table EnbryonTransfertData  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }






        public static Message create_table_Chambre()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Chambre') CREATE TABLE [dbo].[Chambre] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdIncubateur] BIGINT  NOT NULL," +
                    "[NomChambre] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Chambre  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }




        public static Message create_table_DecoronisationOvocyteData()
        {
            try
            {

                string query = "If not exists (select * from sysobjects where name = 'DecoronisationOvocyteData') CREATE TABLE [dbo].[DecoronisationOvocyteData] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdActDataDecoronisation] BIGINT  NOT NULL," +
                     "[DecoronisationOvocyteNumeroOvocyte] BIGINT  NOT NULL," +
                    "[DecoronisationOvocyteEtat] NVARCHAR(MAX) NULL," +
                     "[DecoronisationOvocyteCommentaire] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table DecoronisationOvocyteData  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }







        public static Message create_table_CulureOvocyteData()
        {
            try
            {

                string query = "If not exists (select * from sysobjects where name = 'CulureOvocyteData') CREATE TABLE [dbo].[CulureOvocyteData] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdActDataCulture] BIGINT  NOT NULL," +
                     "[OvocytesCultureNumeroOvocyte] BIGINT  NOT NULL," +
                    "[OvocytesCultureJour]  BIGINT NOT NULL," +
                     "[OvocytesCultureGrade] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table CulureOvocyteData  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }



        public static Message create_table_Incubateur()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Incubateur') CREATE TABLE [dbo].[Incubateur] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[NomIncubateur]  NVARCHAR(MAX) NULL," +
                    "[NombreChambre] BIGINT  NOT NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Incubateur  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }

        

              public static Message create_table_DevenirEmbryon()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'DevenirEmbryon') CREATE TABLE [dbo].[DevenirEmbryon] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[Devenir]  NVARCHAR(MAX) NULL," +
                    "[IdActeDataCulture] BIGINT  NOT NULL UNIQUE," +
                     "[NumeroEmbryon] BIGINT  NOT NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table DevenirEmbryon  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }



        public static Message create_table_ActDataDecoronisationOvocyteData()
        {
            try
            {

                string query = "If not exists (select * from sysobjects where name = 'ActDataDecoronisationOvocyteData') CREATE TABLE [dbo].[ActDataDecoronisationOvocyteData] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdActDataDecoronisation] BIGINT  NOT NULL UNIQUE," +
                     "[DecoronisationOvocyteNumeroOvocyte] BIGINT  NOT NULL," +
                    "[DecoronisationOvocyteEtat]  NVARCHAR(MAX) NOT NULL," +
                     "[DecoronisationOvocyteCommantaire] NVARCHAR(MAX) NOT NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataDecoronisationOvocyteData  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }




        public static Message create_table_Cuve()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Cuve') CREATE TABLE [dbo].[Cuve] ( [Id] BIGINT IDENTITY(1, 1) NOT NULL, [Nom]  NVARCHAR(245) NULL UNIQUE ,[Reference]  NVARCHAR(245)  NOT NULL UNIQUE,[NombreCanisters] BIGINT  NOT NULL );";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Cuve  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }





        public static Message create_table_Visotube()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Visotube') CREATE TABLE [dbo].[Visotube] ("+
                    " [Id] BIGINT IDENTITY(1, 1) NOT NULL, [Couleur]  NVARCHAR(245) NULL UNIQUE "+
                    ",[IdCube] BIGINT  NOT NULL  , [NumeroCanister] BIGINT  NOT NULL ,[NumeroEtage] BIGINT  NOT NULL ,[Capacite] BIGINT  NOT NULL );";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Visotube  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }





        public static Message create_table_Paillette()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'Paillette') CREATE TABLE [dbo].[Paillette] (" +
                    " [Id] BIGINT IDENTITY(1, 1) NOT NULL, [Couleur]  NVARCHAR(245) NULL UNIQUE " +
                    ",[IdVisotube] BIGINT  NOT NULL  , [Reference] NVARCHAR(245) NULL UNIQUE ,[Statu] NVARCHAR(245) NULL  ,[TypeCongelation] NVARCHAR(245) NULL );";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table Paillette  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }




        public static Message create_table_ActDataCongelationEnbryonnaire()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataCongelationEnbryonnaire') CREATE TABLE [dbo].[ActDataCongelationEnbryonnaire] (" +
                    " [Id] BIGINT IDENTITY(1, 1) NOT NULL, [IdMedicalRecordAct] BIGINT NOT NULL UNIQUE " +
                    ",[NombreEnbryonsCongeles] BIGINT  NOT NULL  , [Commentaires] NVARCHAR(MAX) NULL  );";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataCongelationEnbryonnaire  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }





        public static Message create_table_EnbryonnaireCongelationData()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'EnbryonnaireCongelationData') CREATE TABLE [dbo].[EnbryonnaireCongelationData] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[EmbryologisteDoctorType]  NVARCHAR(MAX) NULL," +
                    "[IdPaillette] BIGINT  NOT NULL," +
                    "[IdActDataCongelationEnbryonnaire] BIGINT  NOT NULL," +
                    "[IdEnbryologisteDoctor] BIGINT  NOT NULL," +
                    "[jourCongelation] BIGINT  NOT NULL," +
                    "[NumeroEnbroyon] BIGINT  NOT NULL," +
                     "[Heure]  NVARCHAR(MAX)  NOT NULL," +
                     "[GradeEnbryon]  NVARCHAR(MAX)  NOT NULL," +
                     "[Date]  NVARCHAR(MAX)  NOT NULL," +
                     "[Commentaires]  NVARCHAR(MAX)  NOT NULL," +
                     "[Milieu]  NVARCHAR(MAX)  NOT NULL," +
                     "[Statu]  NVARCHAR(MAX)  NOT NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table EnbryonnaireCongelationData  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }




        public static Message create_table_ActDataCongelationSperme()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataCongelationSperme') CREATE TABLE [dbo].[ActDataCongelationSperme] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdMedicalRecordAct] BIGINT  NOT NULL UNIQUE," +
                     "[IdEnbryologisteDoctor]  BIGINT  NOT  NULL," +
                     "[Milieu]  NVARCHAR(MAX)  NOT  NULL," +
                    "[EmbryologisteDoctorType] NVARCHAR(MAX)  NULL," +
                    "[Date] NVARCHAR(MAX) NULL," +
                    "[Heure] NVARCHAR(MAX) NULL," +
                    "[Commentaires] NVARCHAR(MAX) NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataCongelationSperme  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }

        public static Message create_table_ActDataCongelationOvocyte()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataCongelationOvocyte') CREATE TABLE [dbo].[ActDataCongelationOvocyte] (" +
                    " [Id] BIGINT IDENTITY(1, 1) NOT NULL, [IdMedicalRecordAct] BIGINT NOT NULL UNIQUE " +
                    ",[NombreOvocyteCongeles] BIGINT  NOT NULL  , [Commentaires] NVARCHAR(MAX) NULL  );";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataCongelationOvocyte  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }



        public static Message create_table_OvocyteCongelationData()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'OvocyteCongelationData') CREATE TABLE [dbo].[OvocyteCongelationData] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[EmbryologisteDoctorType]  NVARCHAR(MAX) NULL," +
                    "[IdPaillette] BIGINT  NOT NULL," +
                    "[IdActDataCongelationOvocyte] BIGINT  NOT NULL," +
                    "[IdEnbryologisteDoctor] BIGINT  NOT NULL," +
                    "[jourCongelation] BIGINT  NOT NULL," +
                    "[NumeroOvocyte] BIGINT  NOT NULL," +
                     "[Heure]  NVARCHAR(MAX)  NOT NULL," +
                    
                     "[Date]  NVARCHAR(MAX)  NOT NULL," +
                     "[Commentaires]  NVARCHAR(MAX)  NOT NULL," +
                     "[Milieu]  NVARCHAR(MAX)  NOT NULL," +
                     "[Statu]  NVARCHAR(MAX)  NOT NULL" +
                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table OvocyteCongelationData  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }



        public static Message create_table_ActDataBiopsie()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataBiopsie') CREATE TABLE [dbo].[ActDataBiopsie] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdMedicalRecordAct] BIGINT  NOT NULL UNIQUE," +
                    "[IdTreatingDoctor] BIGINT  NOT NULL," +
                    "[IdEmbryologisteDoctor] BIGINT  NOT NULL," +
                     "[EmbryologisteDoctorType]  NVARCHAR(MAX)  NOT NULL," +
                     "[Heure]  NVARCHAR(MAX)  NOT NULL," +

                     "[Date]  NVARCHAR(MAX)  NOT NULL," +
                     "[TypeBiopsieTesticulaire] NVARCHAR(MAX)   NOT NULL," +
                     "[ExamenAnatomopathologique]  NVARCHAR(MAX)  NOT NULL," +
                     "[TGPoleSupNombreFragments]  BIGINT NOT NULL," +

                     "[TGPoleSupDilaceration] NVARCHAR(MAX)   NOT NULL," +
                     "[TGPoleSupResultat]  NVARCHAR(MAX)  NOT NULL," +
                     "[TGPoleMedNombreFragments]  BIGINT NOT NULL," +

                     "[TGPoleMedDilaceration] NVARCHAR(MAX)   NOT NULL," +
                     "[TGPoleMedResultat]  NVARCHAR(MAX)  NOT NULL," +
                     "[TGPoleInfNombreFragments]  BIGINT NOT NULL," +



                     "[TGPoleInfDilaceration] NVARCHAR(MAX)   NOT NULL," +
                     "[TGPoleInfResultat]  NVARCHAR(MAX)  NOT NULL," +
                     "[TDPoleSupNombreFragments]  BIGINT NOT NULL," +


                      "[TDPoleSupDilaceration] NVARCHAR(MAX)   NOT NULL," +
                     "[TDPoleSupResultat]  NVARCHAR(MAX)  NOT NULL," +
                     "[TDPoleMedNombreFragments]  BIGINT NOT NULL," +


                     "[TDPoleMedDilaceration] NVARCHAR(MAX)   NOT NULL," +
                     "[TDPoleMedResultat]  NVARCHAR(MAX)  NOT NULL," +
                     "[TDPoleInfNombreFragments]  BIGINT NOT NULL," +


                       "[TDPoleInfDilaceration]  NVARCHAR(MAX)  NOT NULL," +
                     "[TDPoleInfResultat]  NVARCHAR(MAX)  NOT NULL" +


                    ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataBiopsie  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }

        public static Message create_table_ActDataCulture()
        {
            try
            {
                string query = "If not exists (select * from sysobjects where name = 'ActDataCulture') CREATE TABLE [dbo].[ActDataCulture] (" +
                    "[Id] BIGINT IDENTITY(1, 1) NOT NULL," +
                    "[IdMedicalRecordAct] BIGINT  NOT NULL UNIQUE," +
                    "[IdJ1EmbryologisteDoctor] BIGINT  NOT NULL," +
                    "[IdJ2EmbryologisteDoctor] BIGINT  NOT NULL," +
                    "[IdJ3EmbryologisteDoctor] BIGINT  NOT NULL," +
                    "[IdJ4EmbryologisteDoctor] BIGINT  NOT NULL," +
                    "[IdJ5EmbryologisteDoctor] BIGINT  NOT NULL," +
                    "[IdJ6EmbryologisteDoctor] BIGINT  NOT NULL," +
                    "[IdJ1Incubateur] BIGINT  NOT NULL," +
                    "[IdJ2Incubateur] BIGINT  NOT NULL," +
                    "[IdJ3Incubateur] BIGINT  NOT NULL," +
                    "[IdJ4Incubateur] BIGINT  NOT NULL," +
                    "[IdJ5Incubateur] BIGINT  NOT NULL," +
                    "[IdJ6Incubateur] BIGINT  NOT NULL," +
                    "[J1Chambres]  NVARCHAR(MAX)  NOT NULL," +
                    "[J2Chambres]  NVARCHAR(MAX)  NOT NULL," +
                    "[J3Chambres]  NVARCHAR(MAX)  NOT NULL," +
                    "[J4Chambres]  NVARCHAR(MAX)  NOT NULL," +
                    "[J5Chambres]  NVARCHAR(MAX)  NOT NULL," +
                    "[J6Chambres]  NVARCHAR(MAX)  NOT NULL," +
                     "[J1EmbryologisteDoctorType]  NVARCHAR(MAX)  NOT NULL," +
                     "[J2EmbryologisteDoctorType]  NVARCHAR(MAX)  NOT NULL," +
                     "[J3EmbryologisteDoctorType]  NVARCHAR(MAX)  NOT NULL," +
                     "[J4EmbryologisteDoctorType]  NVARCHAR(MAX)  NOT NULL," +
                     "[J5EmbryologisteDoctorType]  NVARCHAR(MAX)  NOT NULL," +
                     "[J6EmbryologisteDoctorType]  NVARCHAR(MAX)  NOT NULL," +
                     "[J1Heure]  NVARCHAR(MAX)  NOT NULL," +
                     "[J2Heure]  NVARCHAR(MAX)  NOT NULL," +
                     "[J3Heure]  NVARCHAR(MAX)  NOT NULL," +
                     "[J4Heure]  NVARCHAR(MAX)  NOT NULL," +
                     "[J5Heure]  NVARCHAR(MAX)  NOT NULL," +
                     "[J6Heure]  NVARCHAR(MAX)  NOT NULL," +
                     "[J1Date]  NVARCHAR(MAX)  NOT NULL," +
                     "[J2Date]  NVARCHAR(MAX)  NOT NULL," +
                     "[J3Date]  NVARCHAR(MAX)  NOT NULL," +
                     "[J4Date]  NVARCHAR(MAX)  NOT NULL," +
                     "[J5Date]  NVARCHAR(MAX)  NOT NULL," +
                     "[J6Date]  NVARCHAR(MAX)  NOT NULL" +  ");";

                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Table ActDataCulture  create");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }


        }




    }
}
