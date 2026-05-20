using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Versioning;
using System.Xml.Linq;
using System.Security.AccessControl;
using System.Diagnostics;
using System.Data.SqlTypes;
using System.IO.IsolatedStorage;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;


namespace DVLD_DB_Layer
{
    public class clsSetting
    {
        public static string ConnectionString = "Server=.; Database=DVLD; User id=sa; password=123456";
    }

    public class clsDvPeople
    {
        public static bool GetPersonInfoByNationalNumber(string NatNo, ref int id, ref string fName, ref string secName, ref string thName, ref string lName,
                                         ref DateTime Birth, ref byte Gendor, ref string address, ref string phone,
                                         ref string email, ref int natCountyid, ref string imgPath)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "Select * from People Where NationalNo = @NN";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NN", NatNo);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    id = (int)reader["PersonID"];
                    fName = (string)reader["FirstName"];
                    secName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        thName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        thName = "";
                    }
                    lName = (string)reader["LastName"];
                    Birth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        email = (string)reader["Email"];
                    }
                    else
                    {
                        email = "";
                    }
                    natCountyid = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        imgPath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        imgPath = "";
                    }
                }
                reader.Close();
            }
            catch (SqlException ex) { }
            finally
            {
                con.Close();
            }

            return isFound;
        }
        public static bool GetPersonInfoById( int id, ref string NatNo, ref string fName, ref string secName, ref string thName, ref string lName,
                                         ref DateTime Birth, ref byte Gendor, ref string address, ref string phone,
                                         ref string email, ref int natCountyid, ref string imgPath )
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "Select * from People Where PersonID = @personid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@personid", id);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    NatNo = (string)reader["NationalNo"];
                    fName = (string)reader["FirstName"];
                    secName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        thName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        thName = "";
                    }
                        lName = (string)reader["LastName"];
                    Birth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        email = (string)reader["Email"];
                    }
                    else
                    {
                        email = "";
                    }
                        natCountyid = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                    imgPath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        imgPath = "";
                    }    
                }
                reader.Close();
            }
            catch (SqlException ex) {  }
            finally
            {
                con.Close();
            }

            return isFound;
        }
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @"SELECT People.PersonID, People.NationalNo,
                             People.FirstName, People.SecondName, People.ThirdName, People.LastName,
                             People.DateOfBirth, People.Gendor,
                                CASE
                                  WHEN People.Gendor = 0 THEN 'Male'
                                ELSE 'Female'
                                END AS GendorCaption, People.Address, People.Phone, People.Email,
                                People.NationalityCountryID, Countries.CountryName, People.ImagePath
                             FROM People INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID
                             ORDER BY People.FirstName";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch(Exception ex) { }
            finally
            {
                con.Close();
            }
            return dt;
        }
    
        public static int GetTotalCount()
        {
            int TotalCount = 0;

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT COUNT(*) FROM People";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                TotalCount = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }
            return TotalCount;
        }

        public static bool IsExistById(int id)
        {
            bool isExist = false;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT found=1 FROM People WHERE PersonID = @p";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@p", id);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }
            return isExist;
        }
        public static bool IsExistByNationalNumber(string NationalNumber)
        {
            bool isExist = false;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT found=1 FROM People WHERE NationalNo = @p";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@p", NationalNumber);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }
            return isExist;
        }

        public static int AddNewPerson(string natNo, string Fname, string SecName, string ThdName, string Lname,
            DateTime BrDat, byte Gen, string Add, string phone, string email, int NatCountry, string img)
        {
            int id = -1;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @"INSERT INTO People
           (NationalNo ,FirstName ,SecondName ,ThirdName ,LastName
            ,DateOfBirth ,Gendor ,Address ,Phone ,Email ,NationalityCountryID ,ImagePath)
         VALUES
           (@NationalNo, @FirstName ,@SecondName ,@ThirdName ,@LastName 
            ,@DateOfBirth ,@Gendor ,@Address,@Phone ,@Email ,@NationalityCountryID ,@ImagePath)
            SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NationalNo", natNo);
            cmd.Parameters.AddWithValue("@FirstName", Fname);
            cmd.Parameters.AddWithValue("@SecondName", SecName);
            if(ThdName != "" && ThdName != null)
            {
                cmd.Parameters.AddWithValue("@ThirdName", ThdName);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@LastName", Lname);
            cmd.Parameters.AddWithValue("@DateOfBirth", BrDat);
            cmd.Parameters.AddWithValue("@Gendor", Gen);
            cmd.Parameters.AddWithValue("@Address", Add);
            cmd.Parameters.AddWithValue("@Phone", phone);
            if(email != null && email != "")
            {

            cmd.Parameters.AddWithValue("@Email", email);
            }else
            {
            cmd.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@NationalityCountryID", NatCountry);
            if (img != null && img != "")
            {

                cmd.Parameters.AddWithValue("@ImagePath", img);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                id = Convert.ToInt32(result);

            }
            catch (Exception ex) { }
            finally { con.Close(); }

            return id;
        }

        public static bool UpdatePerson(int id, string natNo, string Fname, string SecName, string ThdName, string Lname,
            DateTime BrDat, byte Gen, string Add, string phone, string email, int NatCountry, string img)
        {
            int RowAffected = 0;

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @" UPDATE People SET
                   NationalNo = @NN,
                   FirstName = @FN,
                   SecondName = @SN,
                   ThirdName = @TN,
                   LastName = @LN,
                   DateOfBirth = @D,
                   Gendor = @G,
                   Address = @ADD,
                   Phone = @PH,
                   Email = @E,
                   NationalityCountryID = @NC,
                   ImagePath = @Img
                 WHERE PersonID = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NN", natNo);
            cmd.Parameters.AddWithValue("@FN", Fname);
            cmd.Parameters.AddWithValue("@SN", SecName);
            cmd.Parameters.AddWithValue("@TN", (object)ThdName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LN", Lname);
            cmd.Parameters.AddWithValue("@D", BrDat);
            cmd.Parameters.AddWithValue("@G", Gen);
            cmd.Parameters.AddWithValue("@ADD", Add);
            cmd.Parameters.AddWithValue("@PH", phone);
            cmd.Parameters.AddWithValue("@E", (object)email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NC", NatCountry);
            cmd.Parameters.AddWithValue("@Img", (object)img ?? DBNull.Value);

            try
            {
                con.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw;
            }
            finally { con.Close(); }

            return ( RowAffected > 0 );
        }

        public static bool DeletePerson(int id)
        {
            int rowAffected = 0;

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "DELETE FROM People WHERE PersonID = @i";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@i", id);
            try
            {
                con.Open();
                rowAffected = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                //throw new Exception("DB Error: ", ex);
            }
            finally
            {
                con.Close();
            }

            return (rowAffected > 0);
        }
    }

    public class clsDalCountries
    {
        public static bool GetCountryById(int id, ref string CountryName)
        {
            bool isFound = false;

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryID = @c";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@c", id);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryName = (string)reader["CountryName"];
                }
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isFound;
        }

        public static bool GetCountryByName(string name, ref int id)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryName = @c";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@c", name);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    id = (int)reader["CountryID"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isFound;
        }
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT * FROM Countries";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }catch (Exception ex) { }
            finally { con.Close(); }

            return dt;
        }
    }

    public class clsDBusers
    {
        public static bool GetUserByID(int id, ref int PersonID, ref string Username, ref string Pass, ref bool Active)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @"Select * from Users WHERE UserID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    Username = (string)reader["UserName"];
                    Pass = (string)reader["Password"];
                    Active = (bool)reader["IsActive"];
                }
            }
            catch(Exception ex) { throw; }
            finally { con.Close(); }
            return isFound;
        }
        public static bool GetUserByPersonID(int personID, ref int userID, ref string userName, ref string password, ref bool isActive)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = @"SELECT UserID, UserName, Password, IsActive
                         FROM Users
                         WHERE PersonID = @PersonID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PersonID", personID);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        userID = (int)reader["UserID"];
                        userName = reader["UserName"].ToString();
                        password = reader["Password"].ToString();
                        isActive = (bool)reader["IsActive"];
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // اختياري: يمكن تسجيل الخطأ
                    //System.Diagnostics.Debug.WriteLine(ex.Message);
                    throw;
                }
            }
            return isFound;
        }

        public static bool GetUserInfoByUserNameAndPassword(string username, string password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = @"Select * from Users WHERE UserName = @uname and Password = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uname", username);
                cmd.Parameters.AddWithValue("@pass", password);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        UserID = (int)reader["UserID"];
                        PersonID = (int)reader["PersonID"];
                        IsActive = (bool)reader["IsActive"];
                    }
                }
                catch { throw; }
            }
            return isFound;
        }


        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(clsSetting.ConnectionString);
            string query = @"SELECT UserID, People.PersonID, UserName,
                            FirstName +' '+ SecondName + ' ' +ThirdName + ' ' + LastName AS FullName, IsActive
                            FROM Users JOIN People ON People.PersonID = Users.PersonID";
            SqlCommand cmd = new SqlCommand(query, cn);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch(Exception ex) { throw; }
            finally {  cn.Close(); }
            return dt;
        }

        public static int AddNewUser(int personID, string username, string pass, bool isActive)
        {
            int newId = -1;
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                         VALUES (@pid, @uname, @pass, @isact);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@pid", personID);
                    cmd.Parameters.AddWithValue("@uname", username);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@isact", isActive);

                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            newId = Convert.ToInt32(result);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    //finally { con.Close(); }
                }
            }
            return newId;
        }

        public static bool UpdateUser(int id, string username, string pass, bool isactive)
        {
            int RowAffected = 0;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @" UPDATE Users SET
                   UserName = @un,
                   Password = @pass,
                   IsActive = @ia
                 WHERE UserID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@un", username);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@ia", isactive);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { con.Close(); }

            return (RowAffected > 0);
        }

        public static bool DeleteUser(int id)
        {
            int rowAffected = 0;

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "DELETE FROM Users WHERE UserID = @i";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@i", id);
            try
            {
                con.Open();
                rowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DB Error: ", ex);
            }
            finally
            {
                con.Close();
            }

            return (rowAffected > 0);
        }

        public static bool IsExistById(int id)
        {
            bool isExist = false;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT found=1 FROM Users WHERE UserID = @p";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@p", id);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex) { throw; }
            finally
            {
                con.Close();
            }
            return isExist;
        }

        public static bool IsExistByUsername(string username)
        {
            bool isExist = false;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT found=1 FROM Users WHERE UserName = @p";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@p", username);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex) { throw; }
            finally
            {
                con.Close();
            }
            return isExist;
        }

        public static bool IsExistForPersonID(int pid)
        {
            bool isExist = false;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT found=1 FROM Users WHERE PersonID = @p";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@p", pid);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex) { throw; }
            finally
            {
                con.Close();
            }
            return isExist;
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int rowAffected = 0;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @"Update Users
                             set Password = @pass
                             WHERE UserID = @userid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@pass", NewPassword);
            try
            {
                con.Open();
                rowAffected = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw;
            }
            finally { con.Close(); }
            
            return (rowAffected > 0);
        }
        public static int GetTotalCountUsers()
        {
            int TotalCount = 0;

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT COUNT(*) FROM Users";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                TotalCount = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex) { throw; }
            finally
            {
                con.Close();
            }
            return TotalCount;
        }
        


    }

    public class clsAppType_DL
    {
        public static bool GetApplicationTypeInfoByID(int AppID, ref string AppTypeTitle, ref float AppFees)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", AppID);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    AppTypeTitle = Convert.ToString(reader["ApplicationTypeTitle"]);
                    AppFees = Convert.ToSingle(reader["ApplicationFees"]);
                }

            }
            catch (Exception ex)
            {
                // log or show message
                throw new Exception("Error in GetApplicationTypeInfoByID(): " + ex.Message, ex);
            }

            finally { con.Close(); }

            return isFound;

        }
        
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT * FROM ApplicationTypes order by ApplicationTypeTitle";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex) { throw; }
            finally { con.Close(); }

            return dt;
        }
    
        public static bool UpdateApplicationType(int AppID, string Title, float fees)
        {
            int RowAffected = 0;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @"UPDATE ApplicationTypes SET
                   ApplicationTypeTitle = @title,
                   ApplicationFees = @fees
                 WHERE ApplicationTypeID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@fees", fees);
            cmd.Parameters.AddWithValue("@id", AppID);

            try
            {
                con.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { con.Close(); }

            return (RowAffected > 0);
        }
    }
    public class clsTestAppointmentData
    {
        public static bool GetTestAppointmentInfoByID(int TestID, ref int TestTypeID, ref int LoclDLID,
            ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedUserID, ref bool IsLocked,
            ref int retakeTeseAppID)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @id";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", TestID);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestID = Convert.ToInt32(reader["TestAppointmentID"]);
                    TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                    LoclDLID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsLocked = (bool)reader["IsLocked"];
                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        retakeTeseAppID = -1;
                    else
                        retakeTeseAppID = Convert.ToInt32(reader["RetakeTestApplicationID"]);
                }

            }
            catch (Exception ex)
            {
                // log or show message
                throw new Exception("Error in GetApplicationTypeInfoByID(): " + ex.Message, ex);
            }

            finally { con.Close(); }

            return isFound;
        }
        public static bool GetLastTestAppointment(int LDLAID, int TestTypeID, ref int TestAppointmentID,
            ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked,
            ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT top 1 * FROM TestAppointments WHERE (TestTypeID = @TestID) AND (LocalDrivingLicenseApplicationID = @localID) order by TestAppointmentID DESC";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@TestID", TestTypeID);
            cmd.Parameters.AddWithValue("@localID", LDLAID);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                }

            }
            catch (Exception ex)
            {
                // log or show message
                throw new Exception("Error in GetApplicationTypeInfoByID(): " + ex.Message, ex);
            }

            finally { con.Close(); }

            return isFound;
        }
        public static DataTable GetAllTestAppointments()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = @"select * from TestAppointments_View order by AppointmentDate Desc";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return dt;
        }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = @"SELECT TestAppointmentID, AppointmentDate,PaidFees, IsLocked
                        FROM TestAppointments
                        WHERE  
                        (TestTypeID = @TestTypeID) 
                        AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                        order by TestAppointmentID desc;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                            dt.Load(reader);
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return dt;
        }
        public static int AddNewTestAppointment(
             int TestTypeID, int LocalDrivingLicenseApplicationID,
             DateTime AppointmentDate, float PaidFees, int CreatedByUserID, int RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = @"Insert Into TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID)
                            Values (@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,0,@RetakeTestApplicationID);
                            SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    if (RetakeTestApplicationID == -1)
                        cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            TestAppointmentID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return TestAppointmentID;
        }
        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
             DateTime AppointmentDate, float PaidFees,
             int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"Update  TestAppointments  
                            set TestTypeID = @TestTypeID,
                                LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                AppointmentDate = @AppointmentDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID = @CreatedByUserID,
                                IsLocked=@IsLocked,
                                RetakeTestApplicationID=@RetakeTestApplicationID
                                where TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID == -1)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            using (SqlConnection connection = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            TestID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return TestID;
        }

    }

    public class clsTestTypes_DL
    {
        public static bool GetTestTypeByID(int id, ref string TestTypeTitle, ref string TestTypeDescription, ref float TestTypeFees)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "select * from TestTypes WHERE TestTypeID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestTypeTitle = Convert.ToString(reader["TestTypeTitle"]);
                    TestTypeDescription = Convert.ToString(reader["TestTypeDescription"]);
                    TestTypeFees = Convert.ToSingle(reader["TestTypeFees"]);
                }

            }
            catch (Exception ex)
            {
                // log or show message
                throw new Exception("Error in GetApplicationTypeInfoByID(): " + ex.Message, ex);
            }

            finally { con.Close(); }
            return isFound;
        }
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT * FROM TestTypes";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex) { throw; }
            finally { con.Close(); }
            return dt;
        }
        public static bool UpdateTestType(int id, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            int RowAffected = 0;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @"UPDATE TestTypes SET
                   TestTypeTitle = @title,
                   TestTypeDescription = @des,
                   TestTypeFees = @fees
                 WHERE TestTypeID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@title", TestTypeTitle);
            cmd.Parameters.AddWithValue("@des", TestTypeDescription);
            cmd.Parameters.AddWithValue("@fees", TestTypeFees);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { con.Close(); }

            return (RowAffected > 0);
        }


    }
    public class clsGeneralApplicationData
    {
        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID,
         ref DateTime ApplicationDate, ref int ApplicationTypeID,
         ref byte ApplicationStatus, ref DateTime LastStatusDate,
         ref float PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = "SELECT * FROM Applications WHERE ApplicationID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", ApplicationID);

                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ApplicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                                ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                                ApplicationTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                                ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]);
                                LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in GetApplicationInfoByID(): " + ex.Message, ex);
                    }
                }
            }
            return isFound;
        }

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = "select * from Applications order by ApplicationDate desc";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex) { throw new Exception(ex.Message, ex); }
                }
            }
            return dt;
        }

        public static int AddNewApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID)
        {
            int NewID = -1;

            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = @"INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                                ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                         VALUES (@appPersonid, @AppDate, @AppType, @AppStatus, @LastStatusDate, @PaidFees, @CreatUser);
                                SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@appPersonid", ApplicantPersonID);
                    cmd.Parameters.AddWithValue("@AppDate", ApplicationDate);
                    cmd.Parameters.AddWithValue("@AppType", ApplicationTypeID);
                    cmd.Parameters.AddWithValue("@AppStatus", ApplicationStatus);
                    cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@CreatUser", CreatedByUserID);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                            NewID = Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error adding application: " + ex.Message);
                    }
                }

            }

            return NewID;
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID)
        {
            int RowAffected = 0;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @"UPDATE Applications
              SET
                   ApplicantPersonID = @pID,
                   ApplicationDate = @AppDate,
                   ApplicationTypeID = @AppType,
                   ApplicationStatus = @AppStatus,
                   LastStatusDate = @LastDate,
                   PaidFees = @Paid,
                   CreatedByUserID = @User
              WHERE ApplicationID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@pID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@AppDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@AppType", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@AppStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@Paid", PaidFees);
            cmd.Parameters.AddWithValue("@User", CreatedByUserID);
            cmd.Parameters.AddWithValue("@id", ApplicationID);

            try
            {
                con.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating application: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
                con.Dispose();
            }
            return (RowAffected > 0);
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            int RowAffected = 0;

            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "DELETE FROM Applications WHERE ApplicationID = @AppID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@AppID", ApplicationID);

            try
            {
                con.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting application: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

                cmd.Dispose();
                con.Dispose();
            }
            return (RowAffected > 0);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isExist = false;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT found=1 FROM Applications WHERE ApplicationID = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", ApplicationID);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex)
            {
                isExist = false;
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();
                con.Dispose();
            }
            return isExist;
        }

        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {
            int RowAffected = 0;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @"UPDATE Applications 
                      SET ApplicationStatus = @AppStatus, 
                          LastStatusDate = GETDATE()
                      WHERE ApplicationID = @id";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@AppStatus", NewStatus);
            cmd.Parameters.AddWithValue("@id", ApplicationID);
            try
            {
                con.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating application: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
                con.Dispose();
            }
            return (RowAffected > 0);
        }

        public static bool DosePersonHaveActiveApplication(int PersonID, int AppTypeID)
        {
            return (GetActiveApplicationID(PersonID, AppTypeID) != -1);
        }
        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @"select ActiveApplicationID = ApplicationID from Applications
                            where ApplicantPersonID = @AppPersonID and ApplicationTypeID = @AppType
                            and ApplicationStatus = 1;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@AppPersonID", PersonID);
            cmd.Parameters.AddWithValue("@AppType", ApplicationTypeID);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    ActiveApplicationID = id;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { con.Close(); }
            return ActiveApplicationID;
        }
        
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;
            SqlConnection con = new SqlConnection(clsSetting.ConnectionString);
            string query = @"SELECT Applications.ApplicationID
                            FROM Applications 
                            INNER JOIN LocalDrivingLicenseApplications 
                                ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE Applications.ApplicantPersonID = @ApplicantPersonID 
                              AND Applications.ApplicationTypeID = @ApplicationTypeID 
                              AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                              AND Applications.ApplicationStatus = 1;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                con.Close();
            }
            return ActiveApplicationID;
        }
    
    }
    public class clsLocalDrivingLicenseApplicationData
    {
        /* this code for Local driving license application this class get the data from
          small table that have 3 faileds ApplicationID from General Applications table,
          Local Driving License ApplicatonID as primary key and License classID From
          license classes Table.
          this table will be inheret the General Application table.
          the important thing [the inheret will be in the buisnessLayer not in data access layer].
         */
        public static bool GetLocalDrivingLicenseApplicationInfoByID(
            int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", LocalDrivingLicenseApplicationID);
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                                LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in GetLocalDrivingLicenseApplicationInfoByID(): " + ex.Message, ex);
                    }
                }
            }
            return isFound;
        }
        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(
            int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", ApplicationID);
                    try
                    {
                        con.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                                LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Error in GetLocalDrivingLicenseApplicationInfoByApplicationID: " + ex.Message);
                    }
                }
            }
            return isFound;
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications_View order by ApplicationDate Desc";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex) { throw new Exception(ex.Message, ex); }
                }
            }
            return dt;
        }
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int newID = -1;
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) VALUES (@AID, @LCID);
                               SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AID", ApplicationID);
                    cmd.Parameters.AddWithValue("@LCID", LicenseClassID);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                            newID = Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error adding : " + ex.Message);
                    }
                }
            }
            return newID;
        }
        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int RowAffected = 0;
            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = @"UPDATE LocalDrivingLicenseApplications
              SET
                   ApplicationID = @APPID,
                   LicenseClassID = @LCID
              WHERE 
                   LocalDrivingLicenseApplicationID = @LDLAPPID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@APPID", ApplicationID);
                    cmd.Parameters.AddWithValue("@LCID", LicenseClassID);
                    cmd.Parameters.AddWithValue("@LDLAPPID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        con.Open();
                        RowAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error updating: " + ex.Message);
                    }
                }
            }
            return (RowAffected > 0);
        }
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int RowAffected = 0;

            using (SqlConnection con = new SqlConnection(clsSetting.ConnectionString))
            {
                string query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LDID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@LDID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        con.Open();
                        RowAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //throw new Exception("Error deleting: " + ex.Message);
                        return false;
                    }
                }
            }
            return (RowAffected > 0);
        }
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool Result = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {

            bool Result = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
                }

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }

    }
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByID(int LicenseClassID,
            ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge,
            ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isFound = true;

                        ClassName = (string)reader["ClassName"];
                        ClassDescription = (string)reader["ClassDescription"];
                        MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                        DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                        ClassFees = Convert.ToSingle(reader["ClassFees"]);
                    }
                    else
                    {
                        isFound = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool GetLicenseClassInfoByClassName(string ClassName, ref int LicenseClassID,
            ref string ClassDescription, ref byte MinimumAllowedAge,
           ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);
            string query = "SELECT * FROM LicenseClasses order by ClassName";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static int AddNewLicenseClass(string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            int LicenseClassID = -1;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"Insert Into LicenseClasses 
           (
            ClassName,ClassDescription,MinimumAllowedAge, 
            DefaultValidityLength,ClassFees)
                            Values ( 
            @ClassName,@ClassDescription,@MinimumAllowedAge, 
            @DefaultValidityLength,@ClassFees)
                            where LicenseClassID = @LicenseClassID;
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseClassID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseClassID;

        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName,
            string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"Update  LicenseClasses  
                            set ClassName = @ClassName,
                                ClassDescription = @ClassDescription,
                                MinimumAllowedAge = @MinimumAllowedAge,
                                DefaultValidityLength = @DefaultValidityLength,
                                ClassFees = @ClassFees
                                where LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
    public class clsDriverData
    {

        public static bool GetDriverInfoByDriverID(int DriverID,
            ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID,
            ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllDrivers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "SELECT * FROM Drivers_View order by FullName";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            int DriverID = -1;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"Insert Into Drivers (PersonID,CreatedByUserID,CreatedDate)
                            Values (@PersonID,@CreatedByUserID,@CreatedDate);
                          
                            SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DriverID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return DriverID;

        }

        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);
            //we dont update the createddate for the driver.
            string query = @"Update  Drivers  
                            set PersonID = @PersonID,
                                CreatedByUserID = @CreatedByUserID
                                where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
    public class clsLicenseData
    {

        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
            ref float PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["DriverID"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "SELECT * FROM Licenses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetDriverLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
             DateTime IssueDate, DateTime ExpirationDate, string Notes,
             float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"
                              INSERT INTO Licenses
                               (ApplicationID,
                                DriverID,
                                LicenseClass,
                                IssueDate,
                                ExpirationDate,
                                Notes,
                                PaidFees,
                                IsActive,IssueReason,
                                CreatedByUserID)
                         VALUES
                               (
                               @ApplicationID,
                               @DriverID,
                               @LicenseClass,
                               @IssueDate,
                               @ExpirationDate,
                               @Notes,
                               @PaidFees,
                               @IsActive,@IssueReason, 
                               @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes == "")
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseID;

        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
             DateTime IssueDate, DateTime ExpirationDate, string Notes,
             float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"UPDATE Licenses
                           SET ApplicationID=@ApplicationID, DriverID = @DriverID,
                              LicenseClass = @LicenseClass,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              Notes = @Notes,
                              PaidFees = @PaidFees,
                              IsActive = @IsActive,IssueReason=@IssueReason,
                              CreatedByUserID = @CreatedByUserID
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes == "")
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseID;
        }

        public static bool DeactivateLicense(int LicenseID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"UPDATE Licenses
                           SET 
                              IsActive = 0
                             
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
    public class clsDetainedLicenseData
    {

        public static bool GetDetainedLicenseInfoByID(int DetainID,
            ref int LicenseID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)

                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];


                    if (reader["ReleasedByUserID"] == DBNull.Value)

                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)

                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID,
         ref int DetainID, ref DateTime DetainDate,
         ref float FineFees, ref int CreatedByUserID,
         ref bool IsReleased, ref DateTime ReleaseDate,
         ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "SELECT top 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID order by DetainID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)

                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];


                    if (reader["ReleasedByUserID"] == DBNull.Value)

                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)

                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllDetainedLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "select * from detainedLicenses_View order by IsReleased ,DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int AddNewDetainedLicense(
            int LicenseID, DateTime DetainDate,
            float FineFees, int CreatedByUserID)
        {
            int DetainID = -1;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"INSERT INTO dbo.DetainedLicenses
                               (LicenseID,
                               DetainDate,
                               FineFees,
                               CreatedByUserID,
                               IsReleased
                               )
                            VALUES
                               (@LicenseID,
                               @DetainDate, 
                               @FineFees, 
                               @CreatedByUserID,
                               0
                             );
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DetainID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return DetainID;

        }

        public static bool UpdateDetainedLicense(int DetainID,
            int LicenseID, DateTime DetainDate,
            float FineFees, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"UPDATE dbo.DetainedLicenses
                              SET LicenseID = @LicenseID, 
                              DetainDate = @DetainDate, 
                              FineFees = @FineFees,
                              CreatedByUserID = @CreatedByUserID,   
                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainedLicenseID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool ReleaseDetainedLicense(int DetainID,
                 int ReleasedByUserID, int ReleaseApplicationID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"UPDATE dbo.DetainedLicenses
                              SET IsReleased = 1, 
                              ReleaseDate = @ReleaseDate, 
                              ReleaseApplicationID = @ReleaseApplicationID   
                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"select IsDetained=1 
                            from detainedLicenses 
                            where 
                            LicenseID=@LicenseID 
                            and IsReleased=0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsDetained = Convert.ToBoolean(result);
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return IsDetained;
            ;

        }

    }
    public class clsInternationalLicenseData
    {

        public static bool GetInternationalLicenseInfoByID(int InternationalLicenseID,
            ref int ApplicationID,
            ref int DriverID, ref int IssuedUsingLocalLicenseID,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];


                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["DriverID"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllInternationalLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"
            SELECT    InternationalLicenseID, ApplicationID,DriverID,
		                IssuedUsingLocalLicenseID , IssueDate, 
                        ExpirationDate, IsActive
		    from InternationalLicenses 
                order by IsActive, ExpirationDate desc";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"
            SELECT    InternationalLicenseID, ApplicationID,
		                IssuedUsingLocalLicenseID , IssueDate, 
                        ExpirationDate, IsActive
		    from InternationalLicenses where DriverID=@DriverID
                order by ExpirationDate desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }


        public static int AddNewInternationalLicense(int ApplicationID,
             int DriverID, int IssuedUsingLocalLicenseID,
             DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"
                               Update InternationalLicenses 
                               set IsActive=0
                               where DriverID=@DriverID;

                             INSERT INTO InternationalLicenses
                               (
                                ApplicationID,
                                DriverID,
                                IssuedUsingLocalLicenseID,
                                IssueDate,
                                ExpirationDate,
                                IsActive,
                                CreatedByUserID)
                         VALUES
                               (@ApplicationID,
                                @DriverID,
                                @IssuedUsingLocalLicenseID,
                                @IssueDate,
                                @ExpirationDate,
                                @IsActive,
                                @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return InternationalLicenseID;

        }

        public static bool UpdateInternationalLicense(
              int InternationalLicenseID, int ApplicationID,
             int DriverID, int IssuedUsingLocalLicenseID,
             DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"UPDATE InternationalLicenses
                           SET 
                              ApplicationID=@ApplicationID,
                              DriverID = @DriverID,
                              IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              IsActive = @IsActive,
                              CreatedByUserID = @CreatedByUserID
                         WHERE InternationalLicenseID=@InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"  
                            SELECT Top 1 InternationalLicenseID
                            FROM InternationalLicenses 
                            where DriverID=@DriverID and GetDate() between IssueDate and ExpirationDate 
                            order by ExpirationDate Desc;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return InternationalLicenseID;
        }

    }
    public class clsTestData
    {

        public static bool GetTestInfoByID(int TestID,
            ref int TestAppointmentID, ref bool TestResult,
            ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "SELECT * FROM Tests WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass
            (int PersonID, int LicenseClassID, int TestTypeID, ref int TestID,
              ref int TestAppointmentID, ref bool TestResult,
              ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID = @PersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID=@TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = "SELECT * FROM Tests order by TestID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult,
             string Notes, int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"Insert Into Tests (TestAppointmentID,TestResult,
                                                Notes,   CreatedByUserID)
                            Values (@TestAppointmentID,@TestResult,
                                                @Notes,   @CreatedByUserID);
                            
                                UPDATE TestAppointments 
                                SET IsLocked=1 where TestAppointmentID = @TestAppointmentID;

                                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes != "" && Notes != null)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);



            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return TestID;

        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,
             string Notes, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"Update  Tests  
                            set TestAppointmentID = @TestAppointmentID,
                                TestResult=@TestResult,
                                Notes = @Notes,
                                CreatedByUserID=@CreatedByUserID
                                where TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsSetting.ConnectionString);

            string query = @"SELECT PassedTestCount = count(TestTypeID)
                         FROM Tests INNER JOIN
                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						 where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestResult=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    PassedTestCount = ptCount;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return PassedTestCount;



        }



    }

}
