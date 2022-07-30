using justch.Models.ENTITIES;
using justch.Models.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace justch.Models.DAL
{
    public class DAL_Patient
    {
        public static Patient GetPatient(DataRow dataRow)
        {
            Patient p = new Patient();
            if (string.IsNullOrEmpty(dataRow["Id"].ToString()))
                p.Id = 0;
            else
            {
                p.Id = Int32.Parse(dataRow["Id"].ToString());
            }


            if (dataRow["Cin"] == DBNull.Value) { p.Cin = null; }
            else { p.Cin = CryptageEncryptage.decrypte((string)dataRow["Cin"]); }

            if (dataRow["IssuedOn"] == DBNull.Value) { p.IssuedOn = null; }
            else { p.IssuedOn = CryptageEncryptage.decrypte((string)dataRow["IssuedOn"]); }

            if (dataRow["FirstName"] == DBNull.Value) { p.FirstName = null; }
            else { p.FirstName = CryptageEncryptage.decrypte((string)dataRow["FirstName"]); }

            if (dataRow["LastName"] == DBNull.Value) { p.LastName = null; }
            else { p.LastName = CryptageEncryptage.decrypte((string)dataRow["LastName"]); }

            if (dataRow["MaidenName"] == DBNull.Value) { p.MaidenName = null; }
            else { p.MaidenName = CryptageEncryptage.decrypte((string)dataRow["MaidenName"]); }

            if (dataRow["Gender"] == DBNull.Value) { p.Gender = null; }
            else { p.Gender = CryptageEncryptage.decrypte((string)dataRow["Gender"]); }
         ;

            if (dataRow["Profession"] == DBNull.Value) { p.Profession = null; }
            else { p.Profession = CryptageEncryptage.decrypte((string)dataRow["Profession"]); }



            if (dataRow["Photo"] == DBNull.Value) { p.Photo = null; }
            else { p.Photo = CryptageEncryptage.decrypte((string)dataRow["Photo"]); }


            if (dataRow["Phone"] == DBNull.Value) { p.Phone = null; }
            else { p.Phone = CryptageEncryptage.decrypte((string)dataRow["Phone"]); }


            if (dataRow["Email"] == DBNull.Value) { p.Email = null; }
            else { p.Email = CryptageEncryptage.decrypte((string)dataRow["Email"]); }

            if (dataRow["Dataofbirth"] == DBNull.Value) { }
            else { p.Dataofbirth = DateTime.Parse(dataRow["Dataofbirth"].ToString()); }


            if (dataRow["Placeofbirth"] == DBNull.Value) { p.Placeofbirth = null; }
            else { p.Placeofbirth = CryptageEncryptage.decrypte((string)dataRow["Placeofbirth"]); }


            if (dataRow["Address"] == DBNull.Value) { p.Address = null; }
            else { p.Address = CryptageEncryptage.decrypte((string)dataRow["Address"]); }


            if (dataRow["PostalCode"] == DBNull.Value) { p.PostalCode = null; }
            else { p.PostalCode = CryptageEncryptage.decrypte((string)dataRow["PostalCode"]); }


            if (dataRow["City"] == DBNull.Value) { p.City = null; }
            else { p.City = CryptageEncryptage.decrypte((string)dataRow["City"]); }


            if (dataRow["Country"] == DBNull.Value) { p.Country = null; }
            else { p.Country = CryptageEncryptage.decrypte((string)dataRow["Country"]); }



            if (dataRow["InsuranceAgency"] == DBNull.Value) { p.InsuranceAgency = null; }
            else { p.InsuranceAgency = CryptageEncryptage.decrypte((string)dataRow["InsuranceAgency"]); }


            if (dataRow["InsuranceID"] == DBNull.Value) { p.InsuranceID = null; }
            else { p.InsuranceID = CryptageEncryptage.decrypte((string)dataRow["InsuranceID"]); }

            if (dataRow["Nationality"] == DBNull.Value) { p.Nationality = null; }
            else { p.Nationality = CryptageEncryptage.decrypte((string)dataRow["Nationality"]); }


            if (dataRow["Civility"] == DBNull.Value) { p.Civility = null; }
            else { p.Civility = CryptageEncryptage.decrypte((string)dataRow["Civility"]); }


            if (dataRow["State"] == DBNull.Value) { p.State = null; }
            else { p.State = CryptageEncryptage.decrypte((string)dataRow["State"]); }



            if (dataRow["Addedon"] == DBNull.Value) { }
            else { p.Addedon = (DateTime)dataRow["Addedon"]; }

            return p;
        }
        public static List<Patient> Get_list_Patients(DataTable tab)
        {

            var list = new List<Patient>();

        

            
                        foreach (DataRow dr in tab.Rows)
                        {
                            list.Add(GetPatient(dr));
                        }
           

            return list;

        }
        public static Message Dal_patient_add(Patient patient)
        {
            try
            {

                string query = @" insert into Patient(FirstName,LastName,Cin ,IssuedOn ,MaidenName,Gender,Photo, Profession,Email ,Phone,Dataofbirth,Placeofbirth,Address,PostalCode, City,Country,InsuranceAgency,InsuranceID ,Nationality,Civility,State) values(@FirstName,@LastName,@Cin ,@IssuedOn ,@MaidenName,@Gender,@Photo, @Profession,@Email ,@Phone,@Dataofbirth,@Placeofbirth,@Address,@PostalCode,@City,@Country,@InsuranceAgency,@InsuranceID ,@Nationality,@Civility,@State);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(patient.FirstName))
                    cmd.Parameters.AddWithValue("@FirstName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@FirstName", CryptageEncryptage.Encrypte(patient.FirstName));


                if (string.IsNullOrEmpty(patient.LastName))
                    cmd.Parameters.AddWithValue("@LastName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@LastName", CryptageEncryptage.Encrypte(patient.LastName));


                if (string.IsNullOrEmpty(patient.Cin))
                    cmd.Parameters.AddWithValue("@Cin", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Cin", CryptageEncryptage.Encrypte(patient.Cin));


                if (string.IsNullOrEmpty(patient.IssuedOn))
                    cmd.Parameters.AddWithValue("@IssuedOn", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IssuedOn", CryptageEncryptage.Encrypte(patient.IssuedOn));


                if (string.IsNullOrEmpty(patient.MaidenName))
                    cmd.Parameters.AddWithValue("@MaidenName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@MaidenName", CryptageEncryptage.Encrypte(patient.MaidenName));

                if (string.IsNullOrEmpty(patient.Gender))
                    cmd.Parameters.AddWithValue("@Gender", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Gender", CryptageEncryptage.Encrypte(patient.Gender));


                if (string.IsNullOrEmpty(patient.Photo))
                    cmd.Parameters.AddWithValue("@Photo", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Photo", CryptageEncryptage.Encrypte(patient.Photo));


                if (string.IsNullOrEmpty(patient.Profession))
                    cmd.Parameters.AddWithValue("@Profession", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Profession", CryptageEncryptage.Encrypte(patient.Profession));



                if (string.IsNullOrEmpty(patient.Email))
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Email", CryptageEncryptage.Encrypte(patient.Email));


                if (string.IsNullOrEmpty(patient.Phone))
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Phone", CryptageEncryptage.Encrypte(patient.Phone));


                if (string.IsNullOrEmpty(patient.Dataofbirth.ToString()))
                    cmd.Parameters.AddWithValue("@Dataofbirth", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Dataofbirth", patient.Dataofbirth);



                if (string.IsNullOrEmpty(patient.Placeofbirth))
                    cmd.Parameters.AddWithValue("@Placeofbirth", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Placeofbirth", CryptageEncryptage.Encrypte(patient.Placeofbirth));




                if (string.IsNullOrEmpty(patient.Address))
                    cmd.Parameters.AddWithValue("@Address", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Address", CryptageEncryptage.Encrypte(patient.Address));


                if (string.IsNullOrEmpty(patient.PostalCode))
                    cmd.Parameters.AddWithValue("@PostalCode", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@PostalCode", CryptageEncryptage.Encrypte(patient.PostalCode));


                if (string.IsNullOrEmpty(patient.City))
                    cmd.Parameters.AddWithValue("@City", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@City", CryptageEncryptage.Encrypte(patient.City));



                if (string.IsNullOrEmpty(patient.Country))
                    cmd.Parameters.AddWithValue("@Country", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Country", CryptageEncryptage.Encrypte(patient.Country));



                if (string.IsNullOrEmpty(patient.InsuranceAgency))
                    cmd.Parameters.AddWithValue("@InsuranceAgency", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@InsuranceAgency", CryptageEncryptage.Encrypte(patient.InsuranceAgency));


                if (string.IsNullOrEmpty(patient.InsuranceID))
                    cmd.Parameters.AddWithValue("@InsuranceID", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@InsuranceID", CryptageEncryptage.Encrypte(patient.InsuranceID));



                if (string.IsNullOrEmpty(patient.Nationality))
                    cmd.Parameters.AddWithValue("@Nationality", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Nationality", CryptageEncryptage.Encrypte(patient.Nationality));


                if (string.IsNullOrEmpty(patient.Civility))
                    cmd.Parameters.AddWithValue("@Civility", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Civility", CryptageEncryptage.Encrypte(patient.Civility));


                if (string.IsNullOrEmpty(patient.State))
                    cmd.Parameters.AddWithValue("@State", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@State", CryptageEncryptage.Encrypte(patient.State));




                cmd.ExecuteNonQuery();

                mycon.Close();
                return new Message(true, "Patient ajouter avec success");






            }
            catch (Exception e)
            {
                if (e.Message.Contains(" Violation of UNIQUE KEY"))
                    return new Message(false, "CE CIN EXISTE   DEJA ");
                if (e.Message.Contains(" UNIQUE KEY constraint 'UQ__Patient__C1FFD81E9BE1234F'"))
                    return new Message(false, "CE CIN EXIST DEJA ");
                if (e.Message.Contains(" UNIQUE KEY constraint 'UQ__Patient__5C7E359E260C7649'"))
                    return new Message(false, "Cet Numero de telephone   EXIST DEJA"); 
                if (e.Message.Contains("Violation of UNIQUE KEY constraint 'UQ__Patient__A9D10534C0788B0C'"))
                    return new Message(false, "Cet Adresse Email  EXIST DEJA ");

                else
                    return new Message(false, e.Message);


            }



        }
        public static DataTable getPatients()
        {
            try
            {
                string query = @"select * from Patient ORDER BY Id Desc;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                DataTable table = new DataTable();
                SqlDataReader MyReader = cmd.ExecuteReader();
                table.Load(MyReader);
                mycon.Close();
                return (table);
            }
            catch
            {
                return null;
            }

        }
        public static Patient getPatientById(int id)
        {
            try
            {
                string query = @"select * from Patient where(Id=" + id + @");";
                SqlConnection cn = DbConnection.GetConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 50;
                DataTable table = new DataTable();
                SqlDataReader MyReader = cmd.ExecuteReader();
                table.Load(MyReader);
                cn.Close();
                return GetPatient(table.Rows[0]);



            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static Patient getPatientsByCIN(string CIN)
        {


            try
            {
                string query = @"select *from Patient where(Cin ='" + CryptageEncryptage.Encrypte(CIN) + @"',);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                DataTable table = new DataTable();
                SqlDataReader MyReader = cmd.ExecuteReader();
                table.Load(MyReader);
                mycon.Close();
                return GetPatient(table.Rows[0]);
            }
            catch
            {
                return null;
            }
        }
        public static List<Patient> getPatientsBy_Fisrtname_LastName(string fisrtname, string lastname)
        {
            try
            {
                string query = @"select *from Patient where(FirstName ='" + CryptageEncryptage.Encrypte(fisrtname) + @"or LastName='" + CryptageEncryptage.Encrypte(lastname) + @"',);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                DataTable table = new DataTable();
                SqlDataReader MyReader = cmd.ExecuteReader();
                table.Load(MyReader);
                mycon.Open();
                return Get_list_Patients(table);
            }
            catch
            {
                return null;
            }

        }
        public static List<Patient> getPatientsBy_EMAIL_Adress(string email, string adree)
        {
            try
            {
                string query = @"select *from Patient where(Email ='" + CryptageEncryptage.Encrypte(email) + @"or Address='" + CryptageEncryptage.Encrypte(adree) + @"',);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                DataTable table = new DataTable();
                SqlDataReader MyReader = cmd.ExecuteReader();
                table.Load(MyReader);
                mycon.Close();
                return Get_list_Patients(table);
            }
            catch
            {
                return null;
            }

        }
        public static Patient getPatientsBy_EMAIL(string email)
        {
            try
            {
                string query = "select *from Patient where(Email =@email);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@email", CryptageEncryptage.Encrypte(email));
                DataTable table = new DataTable();
                SqlDataReader MyReader = cmd.ExecuteReader();
                table.Load(MyReader);
               
                return GetPatient(table.Rows[0]);
            }
            catch
            {
                return null;
            }

        }



        public static Message deletePatient(int id)
        {
            try
            {
                string query = @"delete from Patient where(Id=" + id + @");";
                SqlConnection cn = DbConnection.GetConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 50;
                cmd.ExecuteNonQuery();
                DAL_Appointment.deletebyidPatients(id);
                if (DAL_DossierMedicalPatient.GetsbyIdPatient(id) != null) { 
                foreach(DossierMedicalPatient me in DAL_DossierMedicalPatient.GetsbyIdPatient(id))
                {
                    DAL_DossierMedical.deleteDossierMedical("", me.IdDossierMedical.ToString());
                    DAL_MedicalRecordAct.deleteDossierMedical(me.IdDossierMedical);

                }
                }
                DAL_DossierMedicalPatient.deleteDossierMedicalPatient("IdPatient", id.ToString());
                DAL_Document.DeleteByidpatiene(id);
                cn.Close();
                return new Message(true, "Patient supprimé ");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }
        }
        public static Message update(Patient p)
        {
            try
            {
                string query = "Update Patient set Cin=@Cin,IssuedOn=@IssuedOn,FirstName=@FirstName,LastName=@LastName,State=@State,MaidenName=@MaidenName,Gender=@Gender,Profession=@Profession,Photo=@Photo,Phone=@Phone,Email=@Email,Dataofbirth=@Dataofbirth,Placeofbirth=@Placeofbirth,Address=@Address,PostalCode=@PostalCode,City=@City,Country=@Country,InsuranceAgency=@InsuranceAgency,InsuranceID=@InsuranceID,Nationality=@Nationality,Civility=@Civility where(Id=@Id)";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                command.CommandType = CommandType.Text;
                if (String.IsNullOrEmpty(p.Cin))
                    command.Parameters.AddWithValue("@Cin", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Cin", CryptageEncryptage.Encrypte(p.Cin));
                if (String.IsNullOrEmpty(p.IssuedOn))
                    command.Parameters.AddWithValue("@IssuedOn", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@IssuedOn", CryptageEncryptage.Encrypte(p.IssuedOn));
                if (String.IsNullOrEmpty(p.FirstName))
                    command.Parameters.AddWithValue("@FirstName", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@FirstName", CryptageEncryptage.Encrypte(p.FirstName));
                if (String.IsNullOrEmpty(p.LastName))
                    command.Parameters.AddWithValue("@LastName", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@LastName", CryptageEncryptage.Encrypte(p.LastName));
                if (String.IsNullOrEmpty(p.State))
                    command.Parameters.AddWithValue("@State", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@State", CryptageEncryptage.Encrypte(p.State));

                if (String.IsNullOrEmpty(p.MaidenName))
                    command.Parameters.AddWithValue("@MaidenName", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@MaidenName", CryptageEncryptage.Encrypte(p.MaidenName));
                if (String.IsNullOrEmpty(p.Gender))
                    command.Parameters.AddWithValue("@Gender", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Gender", CryptageEncryptage.Encrypte(p.Gender));

                if (String.IsNullOrEmpty(p.Profession))
                    command.Parameters.AddWithValue("@Profession", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Profession", CryptageEncryptage.Encrypte(p.Profession));
                if (String.IsNullOrEmpty(p.Photo))
                    command.Parameters.AddWithValue("@Photo", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Photo", CryptageEncryptage.Encrypte(p.Photo));
                if (String.IsNullOrEmpty(p.Phone))
                    command.Parameters.AddWithValue("@Phone", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Phone", CryptageEncryptage.Encrypte(p.Phone));
                if (String.IsNullOrEmpty(p.Email))
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Email", CryptageEncryptage.Encrypte(p.Email));
                if (String.IsNullOrEmpty(p.Dataofbirth.ToString()))
                    command.Parameters.AddWithValue("@Dataofbirth", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Dataofbirth", p.Dataofbirth);
                if (String.IsNullOrEmpty(p.Placeofbirth))
                    command.Parameters.AddWithValue("@PlaceOfBirth", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@PlaceOfBirth", CryptageEncryptage.Encrypte(p.Placeofbirth));
                if (String.IsNullOrEmpty(p.Address))
                    command.Parameters.AddWithValue("@Address", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Address", CryptageEncryptage.Encrypte(p.Address));
                if (String.IsNullOrEmpty(p.Country))
                    command.Parameters.AddWithValue("@Country", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Country", CryptageEncryptage.Encrypte(p.Country));
                if (String.IsNullOrEmpty(p.City))
                    command.Parameters.AddWithValue("@City", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@City", CryptageEncryptage.Encrypte(p.City));
                if (String.IsNullOrEmpty(p.PostalCode))
                    command.Parameters.AddWithValue("@PostalCode", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@PostalCode", CryptageEncryptage.Encrypte(p.PostalCode));
                if (String.IsNullOrEmpty(p.InsuranceAgency))
                    command.Parameters.AddWithValue("@InsuranceAgency", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@InsuranceAgency", CryptageEncryptage.Encrypte(p.InsuranceAgency));
                if (String.IsNullOrEmpty(p.InsuranceID))
                    command.Parameters.AddWithValue("@InsuranceID", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@InsuranceID", CryptageEncryptage.Encrypte(p.InsuranceID));
                if (String.IsNullOrEmpty(p.Nationality))
                    command.Parameters.AddWithValue("@Nationality", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Nationality", CryptageEncryptage.Encrypte(p.Nationality));
                if (String.IsNullOrEmpty(p.Civility))
                    command.Parameters.AddWithValue("@Civility", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Civility", CryptageEncryptage.Encrypte(p.Civility));
                command.Parameters.AddWithValue("@Id", p.Id);
                command.ExecuteNonQuery();


                connection.Close();


                return new Message(true, "   modifié avec succes ");
            }
            catch (Exception e)
            {
                return new Message(false, e.ToString());
            }
        }
        public static List<Patient> getPatientsBy(string CIN, string FirstName, string LastName, string Phone, string Email, DateTime Addedon, string State, DateTime Dataofbirth, int nombre)
        {


            try
            {

                DateTime datDIN = Addedon.AddDays(-nombre);
                DateTime dat = Addedon.AddDays(nombre);
                string query = "select *from Patient where( Cin=@CIN OR   FirstName=@FirstName OR LastName=@LastName OR Phone=@Phone  OR Email=@Email OR Dataofbirth=@Dataofbirth OR State=@State OR   ( Addedon between  @dataa and @dat)) ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandTimeout = 50;
                cmd.CommandType = CommandType.Text;
                if (String.IsNullOrEmpty(CIN))
                    cmd.Parameters.AddWithValue("@CIN", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@CIN", CryptageEncryptage.Encrypte(CIN));
                if (String.IsNullOrEmpty(FirstName))
                    cmd.Parameters.AddWithValue("@FirstName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@FirstName", CryptageEncryptage.Encrypte( FirstName));


                if (String.IsNullOrEmpty(LastName))
                    cmd.Parameters.AddWithValue("@LastName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@LastName", CryptageEncryptage.Encrypte( LastName));

                if (String.IsNullOrEmpty(Phone))
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Phone", CryptageEncryptage.Encrypte(Phone));

                if (String.IsNullOrEmpty(Email))
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Email", CryptageEncryptage.Encrypte(Email));

                string ta = Dataofbirth.ToString();
                if (ta.Contains("01/01/0001"))
                    cmd.Parameters.AddWithValue("@Dataofbirth", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Dataofbirth", Dataofbirth);

                if (String.IsNullOrEmpty(State))
                    cmd.Parameters.AddWithValue("@State", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@State", CryptageEncryptage.Encrypte(State));


                string t = Addedon.ToString();
                if (t.Contains("01/01/0001"))
                    cmd.Parameters.AddWithValue("@dataa", "01-01-2000");
                else
                    cmd.Parameters.AddWithValue("@dataa", datDIN);
                if (t.Contains("01/01/0001"))
                    cmd.Parameters.AddWithValue("@dat", "01-01-2000");
                else
                    cmd.Parameters.AddWithValue("@dat", dat);


                DataTable table = new DataTable();
                SqlDataReader MyReader = cmd.ExecuteReader();
                table.Load(MyReader);
                mycon.Close();
                return Get_list_Patients(table);
            }
            catch
            {
                return null;
            }
        }


    }
}
