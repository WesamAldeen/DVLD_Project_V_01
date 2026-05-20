using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DVLD_DB_Layer;
using static DVLD_BuisnessLayer.clsPeopleBuisnes;

namespace DVLD_BuisnessLayer
{
    public class clsPeopleBuisnes
    {
        public int PersonID { get; set; }
        public string Nationalnumber { get; set; }
        public string Fname { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Lname { get; set; }
        public string FullName
        {
            get { return $"{Fname} {SecondName} {ThirdName} {Lname}".Replace("  ", " ").Trim(); }
        }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode = enMode.AddNew;

        public clsPeopleBuisnes()
        {
            this.PersonID = -1;
            this.Nationalnumber = "";
            this.Fname = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.Lname = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 2;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            Mode = enMode.AddNew;
        }
        private clsPeopleBuisnes(int personID, string nationalnumber, string fname, string secondName, string thirdName, string lname, DateTime dateOfBirth, byte gendor, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            PersonID = personID;
            Nationalnumber = nationalnumber;
            Fname = fname;
            SecondName = secondName;
            ThirdName = thirdName;
            Lname = lname;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            Mode = enMode.Update;
        }

        public static clsPeopleBuisnes Find(int id)
        {
            // return new private constructer full by data
            int nationalityCountyrid = -1;
            DateTime dateOfBirth = DateTime.Now;
            byte gendor = 1;
            string fName = "", secName = "", thName = "", lName = "", nationalnumber = "",
                   address = "", Phone = "", email = "", imgPath = "";
            // Cold DBLayer to get person date by id [all by ref]

            if (clsDvPeople.GetPersonInfoById(id, ref nationalnumber, ref fName, ref secName, ref thName, ref lName, ref dateOfBirth,
                ref gendor, ref address, ref Phone, ref email, ref nationalityCountyrid, ref imgPath))
            {
                // make variables here to get data from database to here
                return new clsPeopleBuisnes(id, nationalnumber, fName, secName, thName, lName, dateOfBirth, gendor, address, Phone, email, nationalityCountyrid, imgPath);
            }
            else
            {
                return null;
            }
        }
        public static clsPeopleBuisnes Find(string nationalnumber)
        {
            // return new private constructer full by data
            int nationalityCountyrid = -1;
            int id = -1;
            DateTime dateOfBirth = DateTime.Now;
            byte gendor = 1;
            string fName = "", secName = "", thName = "", lName = "",
                   address = "", Phone = "", email = "", imgPath = "";
            // Cold DBLayer to get person date by id [all by ref]

            if (clsDvPeople.GetPersonInfoByNationalNumber(nationalnumber, ref id, ref fName, ref secName, ref thName, ref lName, ref dateOfBirth,
                ref gendor, ref address, ref Phone, ref email, ref nationalityCountyrid, ref imgPath))
            {
                // make variables here to get data from database to here
                return new clsPeopleBuisnes(id, nationalnumber, fName, secName, thName, lName, dateOfBirth, gendor, address, Phone, email, nationalityCountyrid, imgPath);
            }
            else
            {
                return null;
            }
        }
        public static DataTable GetAllPeopleData()
        {
            return clsDvPeople.GetAllPeople();
        }

        public static int GetTotalCount()
        {
            return clsDvPeople.GetTotalCount();
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsDvPeople.AddNewPerson(this.Nationalnumber, this.Fname, this.SecondName,
                this.ThirdName, this.Lname, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
                this.NationalityCountryID, this.ImagePath);
            return (PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsDvPeople.UpdatePerson(this.PersonID, this.Nationalnumber, this.Fname, this.SecondName, this.ThirdName, this.Lname,
                                            this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
                                            this.NationalityCountryID, this.ImagePath);
        }

        public static bool IsExist(int id)
        {
            return clsDvPeople.IsExistById(id);
        }
        public static bool IsExist(string na)
        {
            return clsDvPeople.IsExistByNationalNumber(na);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }
        public static bool DeletePerson(int id)
        {
            return clsDvPeople.DeletePerson(id);
        }


    }
    public class clsBusCountries
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public clsBusCountries()
        {
            this.CountryId = -1;
            this.CountryName = "";
        }
        private clsBusCountries(int id, string name)
        {
            CountryId = id;
            CountryName = name;
        }
        public static clsBusCountries FindCountryById(int id)
        {
            string cName = "";
            if (clsDalCountries.GetCountryById(id, ref cName))
                return new clsBusCountries(id, cName);
            else
                return null;
        }
        public static clsBusCountries FindCountryByName(string name)
        {
            int cID = -1;
            if (clsDalCountries.GetCountryByName(name, ref cID))
                return new clsBusCountries(cID, name);
            else
                return null;
        }
        public static DataTable GetAllCountries()
        {
            return clsDalCountries.GetAllCountries();
        }

    }
    public class clsUsers
    {
        public clsPeopleBuisnes PersonInfo;
        public int UserId { get; set; }
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        enum enUserMode { add = 1, edit = 2 };
        enUserMode UserMode = enUserMode.add;

        public clsUsers()
        {
            UserId = -1;
            UserName = "";
            Password = "";
            IsActive = false;
            UserMode = enUserMode.add;
        }
        private clsUsers(int id, int PersonID, string userName, string password, bool isActive)
        {
            this.UserId = id;
            this.PersonID = PersonID;
            this.UserName = userName;
            this.PersonInfo = clsPeopleBuisnes.Find(PersonID); // Composition.
            this.Password = password;
            this.IsActive = isActive;
            this.UserMode = enUserMode.edit;
        }

        public static DataTable LoadAllUsers()
        {
            return clsDBusers.GetAllUsers();
        }
        public static int TotalUserCount()
        {
            return clsDBusers.GetTotalCountUsers();
        }

        public static clsUsers FindUserByUserID(int userID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsDBusers.GetUserByID(userID, ref PersonID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                return new clsUsers(userID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        public static clsUsers FindUserByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            if (clsDBusers.GetUserByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUsers FindUserByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = false;
            bool IsFound = clsDBusers.GetUserInfoByUserNameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive);
            if (IsFound)
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        private bool _AddNewUser()
        {
            this.UserId = clsDBusers.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.UserId != -1);
        }
        private bool _UpdateUser()
        {
            return clsDBusers.UpdateUser(this.UserId, this.UserName, this.Password, this.IsActive);
        }
        public bool ChangePassword(string newPassword)
        {
            if (this.UserId <= 0)
                return false;

            bool isChanged = clsDBusers.ChangePassword(this.UserId, newPassword);

            if (isChanged)
                this.Password = newPassword;

            return isChanged;
        }

        public bool Save()
        {
            switch (UserMode)
            {
                case enUserMode.add:
                    if (_AddNewUser())
                    {
                        UserMode = enUserMode.edit;
                        return true;
                    }
                    break;
                case enUserMode.edit:
                    return _UpdateUser();
            }
            return false;
        }

        public static bool DeleteUser(int id)
        {
            return clsDBusers.DeleteUser(id);
        }
        public static bool IsUserExist(int id)
        {
            return clsDBusers.IsExistById(id);
        }
        public static bool IsUserExistByUsername(string username)
        {
            return clsDBusers.IsExistByUsername(username);
        }
        public static bool IsUserExistByPersonID(int Personid)
        {
            return clsDBusers.IsExistForPersonID(Personid);
        }




    }
    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int AppID { get; set; }
        public string AppTitle { get; set; }
        public float Fees { get; set; }

        public clsApplicationType()
        {
            AppID = -1;
            AppTitle = "";
            Fees = 0;
            Mode = enMode.AddNew;
        }
        private clsApplicationType(int id, string title, float fees)
        {
            AppID = id;
            AppTitle = title;
            Fees = fees;
            Mode = enMode.Update;
        }
        public static clsApplicationType FindApplicationTypeById(int id)
        {
            string AppTitle = "";
            float Fees = 0;
            bool isFound = clsAppType_DL.GetApplicationTypeInfoByID(id, ref AppTitle, ref Fees);

            if (isFound)
                return new clsApplicationType(id, AppTitle, Fees);
            else
                return null;
        }

        public static DataTable LoadAllApplication()
        {
            return clsAppType_DL.GetAllApplicationTypes();
        }

        private bool _UpdateAppType()
        {
            return clsAppType_DL.UpdateApplicationType(this.AppID, this.AppTitle, this.Fees);
        }
        private bool _AddNewApp()
        {
            return true;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApp())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateAppType();
            }
            return false;
        }

    }
    public class clsTestTypes
    {
        enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }

        public clsTestTypes()
        {
            TestTypeID = -1;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;
            _Mode = enMode.AddNew;
        }
        private clsTestTypes(int testTypeID, string testTypeTitle, string testTypeDescription, float testTypeFess)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFess;
            _Mode = enMode.Update;
        }
        public static clsTestTypes FindTestType(int id)
        {
            string testTitle = "";
            string testDescription = "";
            float Fees = 0;

            bool isFound = clsTestTypes_DL.GetTestTypeByID(id, ref testTitle, ref testDescription, ref Fees);

            if (isFound)
                return new clsTestTypes(id, testTitle, testDescription, Fees);
            else
                return null;
        }
        public static clsTestTypes Find(clsTestTypes.enTestType TestTypeID)
        {
            string Title = "", Description = ""; float Fees = 0;

            if (clsTestTypes_DL.GetTestTypeByID((int)TestTypeID, ref Title, ref Description, ref Fees))

                return new clsTestTypes((int)TestTypeID, Title, Description, Fees);
            else
                return null;

        }
        public static DataTable LoadAllTestTypes()
        {
            return clsTestTypes_DL.GetAllTestTypes();
        }
        private bool _UpdateTestType()
        {
            return clsTestTypes_DL.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
        private bool _AddNewApp()
        {
            return true;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApp())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateTestType();
            }
            return false;
        }

    }
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicens = 2, ReplaceLostDrivingLicens = 3,
            ReplaceDamagedDrivingLicens = 4, ReleaseDetainedDrivingLicsense = 5, NewInterNationalDrivingLicens = 6,
            RetakeTest = 7
        };
        public enMode Mode = enMode.AddNew;
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public int ApplicationID { set; get; }
        public int ApplicantPersonID { set; get; }
        public clsPeopleBuisnes PersonInfo { set; get; }
        public string ApplicantFullName
        {
            get
            {
                return clsPeopleBuisnes.Find(ApplicantPersonID)?.FullName ?? "Unknown";
            }
        }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }
        public clsApplicationType ApplicationTypeInfo;
        public enApplicationStatus ApplicationStatus { set; get; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime LastStatusDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public clsUsers CreatedByUserInfo;

        // Constructers
        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }
        private clsApplication(int applicationID, int applicationPersonID, DateTime applicationDate, int applicationTypeID,
            enApplicationStatus applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicationPersonID;
            this.PersonInfo = clsPeopleBuisnes.Find(ApplicantPersonID);
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.FindApplicationTypeById(applicationTypeID);
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.CreatedByUserInfo = clsUsers.FindUserByUserID(createdByUserID);
            Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsGeneralApplicationData.AddNewApplication(this.ApplicationID, this.ApplicantPersonID,
                this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate,
                this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }
        private bool _UpdateApplication()
        {
            return clsGeneralApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID,
                this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate,
                this.PaidFees, this.CreatedByUserID);
        }
        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            int applicationPersonid = -1;
            DateTime applicationDate = DateTime.Now;
            int applicationTypeID = -1;
            byte applicationStatus = 1;
            DateTime lastStatusDate = DateTime.Now;
            float paidFees = 0;
            int createdByUserid = -1;

            bool isFound = clsGeneralApplicationData.GetApplicationInfoByID
                (
                    ApplicationID, ref applicationPersonid, ref applicationDate,
                    ref applicationTypeID, ref applicationStatus, ref lastStatusDate,
                    ref paidFees, ref createdByUserid
                );
            if (isFound)
            {
                return new clsApplication(
                        ApplicationID, applicationPersonid, applicationDate, applicationTypeID,
                        (enApplicationStatus)applicationStatus, lastStatusDate, paidFees, createdByUserid
                    );
            }
            else return null;
        }
        public bool Cancel()
        {
            return clsGeneralApplicationData.UpdateStatus(ApplicationID, 2);
        }
        public bool SetComplete()
        {
            return clsGeneralApplicationData.UpdateStatus(ApplicationID, 3);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateApplication();
            }
            return false;
        }
        public bool Delete()
        {
            return clsGeneralApplicationData.DeleteApplication(this.ApplicationID);
        }
        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsGeneralApplicationData.IsApplicationExist(ApplicationID);
        }
        public static bool DosePersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsGeneralApplicationData.DosePersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }
        public bool DosePersonHaveActiveApplication(int ApplicationTypeID)
        {
            return clsGeneralApplicationData.DosePersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }
        public static int GetActiveApplicationID(int personID, clsApplication.enApplicationType applicationTypeID)
        {
            return clsGeneralApplicationData.GetActiveApplicationID(personID, (int)applicationTypeID);
        }
        public int GetActiveApplicationID(clsApplication.enApplicationType applicationTypeID)
        {
            return clsGeneralApplicationData.GetActiveApplicationID(this.ApplicantPersonID, (int)applicationTypeID);
        }
        public static int GetActiveApplicationIDForLicenseClass(int personID, clsApplication.enApplicationType applicationTypeID, int licenseClassID)
        {
            return clsGeneralApplicationData.GetActiveApplicationIDForLicenseClass(personID, (int)applicationTypeID, licenseClassID);
        }
    }
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public new enum enMode { AddNew = 0, Update = 1 };
        public new enMode Mode = enMode.AddNew;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        // public clsLicenseClass LicenseClassInfo;
        public string PersonFullName
        {
            get { return base.PersonInfo?.Fname ?? "Unknown"; }
        }
        // Constructers ...
        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
            Mode = enMode.AddNew;
        }
        private clsLocalDrivingLicenseApplication(int LocalDrivingLiceseApplicationId, int applicationID, int applicationPersonID, DateTime applicationDate, int applicationTypeID, enApplicationStatus appStatus, DateTime lastStatusDate, float fees, int CreatedByUserId, int LicenseClassId)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLiceseApplicationId;
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicationPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = appStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = fees;
            this.CreatedByUserID = CreatedByUserId;
            this.LicenseClassID = LicenseClassId;
            // this.LicensClassInfo = clsLicensCalss.Find(LicenseClassID);
            Mode = enMode.Update;
        }
        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }
        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseAppID)
        {
            int ApplcationID = -1, LicenseClassID = -1;
            bool isfound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseAppID, ref ApplcationID, ref LicenseClassID);
            if (isfound)
            {
                clsApplication app = clsApplication.FindBaseApplication(ApplcationID);

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseAppID, ApplcationID,
                    app.ApplicantPersonID, app.ApplicationDate, app.ApplicationTypeID, app.ApplicationStatus, app.LastStatusDate,
                    app.PaidFees, app.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }
        public static clsLocalDrivingLicenseApplication FindByApplicationID(int AppID)
        {
            int localDrivingLicenseAppID = -1, LicenseClassID = -1;
            bool isfound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(AppID, ref localDrivingLicenseAppID, ref LicenseClassID);

            if (isfound)
            {
                clsApplication app = clsApplication.FindBaseApplication(AppID);
                if (app != null)
                {
                    return new clsLocalDrivingLicenseApplication(localDrivingLicenseAppID, AppID, app.ApplicantPersonID,
                        app.ApplicationDate, app.ApplicationTypeID, app.ApplicationStatus, app.LastStatusDate, app.PaidFees,
                        app.CreatedByUserID, LicenseClassID);
                }
                else
                    return null;
            }
            else
                return null;
        }
        public new bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();
            }
            return false;
        }
        //public new bool Delete()
        //{
        //    return clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);
        //}
        // --- [ موجود في كلاس البزنس - Business Layer ] ---
        public bool Delete()
        {
            // 1. حذف البيانات من جدول الابن أولاً (الجدول المحلي)
            // هذا السطر يكلم كود الـ SQL مباشرة
            bool IsLocalDeleted = clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);

            if (!IsLocalDeleted) return false;

            // 2. إذا نجح، نحذف البيانات من جدول الأب (جدول الطلبات العام)
            // كلمة base هنا تعود على الكلاس الأب (clsApplication)
            return base.Delete();
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }
        // -----------------------------------------------------------------------------
        public bool DoesPassTestType(clsTestTypes.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesPassPreviousTest(clsTestTypes.enTestType CurrentTestType)
        {

            switch (CurrentTestType)
            {
                case clsTestTypes.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    return true;

                case clsTestTypes.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.

                    return this.DoesPassTestType(clsTestTypes.enTestType.VisionTest);


                case clsTestTypes.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    return this.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);

                default:
                    return false;
            }
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool AttendedTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }

        public bool AttendedTest(clsTestTypes.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)

        {

            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool IsThereAnActiveScheduledTest(clsTestTypes.enTestType TestTypeID)

        {

            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public clsTest GetLastTestPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTest.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }

        public byte GetPassedTestCount()
        {
            return clsTest.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return clsTest.PassedAllTests(LocalDrivingLicenseApplicationID);
        }

        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            clsLicense License = new clsLicense();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            //License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            //License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.SetComplete();

                return License.LicenseID;
            }

            else
                return -1;
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }
        // -----------------------------------------------------------------------------

    }
    public class clsTestAppointment
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public int TestAppointmentID { set; get; }
        public clsTestTypes.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestApplicationInfo { set; get; }
        public int TestID
        {
            get { return _GetTestID(); }
        }
        // Constructer
        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestTypes.enTestType.VisionTest;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
            Mode = enMode.AddNew;
        }
        private clsTestAppointment(int testAppointmentID, clsTestTypes.enTestType testTypeID,
            int localDLAID, DateTime AppointDate, float fees, int UserID, bool isLocked, int RTTAID)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.LocalDrivingLicenseApplicationID = localDLAID;
            this.AppointmentDate = AppointDate;
            this.PaidFees = fees;
            this.CreatedByUserID = UserID;
            this.IsLocked = isLocked;
            this.RetakeTestApplicationID = RTTAID;
            this.RetakeTestApplicationInfo = clsApplication.FindBaseApplication(RTTAID);
            Mode = enMode.Update;
        }
        private int _GetTestID()
        {
            return clsTestAppointmentData.GetTestID(TestAppointmentID);
        }
        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }
        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }
        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int testTypeID = -1, LocalDLAID = -1, reTakeTestAppID = -1, CreatedByUserId = -1;
            DateTime AppintmentDate = DateTime.Now; float feez = 0; bool isLocked = false;

            if (clsTestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentID, ref testTypeID, ref LocalDLAID,
                ref AppintmentDate, ref feez, ref CreatedByUserId, ref isLocked, ref reTakeTestAppID))
                return new clsTestAppointment(TestAppointmentID, (clsTestTypes.enTestType)testTypeID, LocalDLAID,
                    AppintmentDate, feez, CreatedByUserId, isLocked, reTakeTestAppID);
            else
                return null;
        }
        public static clsTestAppointment GetLastTestAppointment(int LDLAID, clsTestTypes.enTestType testTypeID)
        {
            int testAppointID = -1, reTakeTestAppID = -1, CreatedByUserId = -1;
            DateTime AppintmentDate = DateTime.Now; float feez = 0; bool isLocked = false;

            if (clsTestAppointmentData.GetLastTestAppointment(LDLAID, (int)testTypeID, ref testAppointID,
                ref AppintmentDate, ref feez, ref CreatedByUserId, ref isLocked, ref reTakeTestAppID))
                return new clsTestAppointment(testAppointID, (clsTestTypes.enTestType)testTypeID, LDLAID,
                    AppintmentDate, feez, CreatedByUserId, isLocked, reTakeTestAppID);
            else
                return null;
        }
        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }
        public DataTable GetApplicationTestAppointmentsPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int) TestTypeID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateTestAppointment();
            }
            return false;
        }
    }
    public class clsLicenseClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public byte MinimumAllowedAge { set; get; }
        public byte DefaultValidityLength { set; get; }
        public float ClassFees { set; get; }

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 10;
            this.ClassFees = 0;
            Mode = enMode.AddNew;
        }
        public clsLicenseClass(int LicenseClassID, string ClassName,
            string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            Mode = enMode.Update;
        }
        private bool _AddNewLicenseClass()
        {
            this.LicenseClassID = clsLicenseClassData.AddNewLicenseClass(this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
            return (this.LicenseClassID != -1);
        }
        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassData.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }
        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = ""; string ClassDescription = "";
            byte MinimumAllowedAge = 18; byte DefaultValidityLength = 10; float ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByID(LicenseClassID, ref ClassName, ref ClassDescription,
                    ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))

                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription,
                    MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }
        public static clsLicenseClass Find(string ClassName)
        {
            int LicenseClassID = -1; string ClassDescription = "";
            byte MinimumAllowedAge = 18; byte DefaultValidityLength = 10; float ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByClassName(ClassName, ref LicenseClassID, ref ClassDescription,
                    ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))

                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription,
                    MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateLicenseClass();
            }
            return false;
        }

    }
    public class clsDriver
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsPeopleBuisnes PersonInfo;

        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { get; }

        public clsDriver()

        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;

        }

        public clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)

        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsPeopleBuisnes.Find(PersonID);

            Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            //call DataAccess Layer 

            this.DriverID = clsDriverData.AddNewDriver(PersonID, CreatedByUserID);


            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            //call DataAccess Layer 

            return clsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
        }

        public static clsDriver FindByDriverID(int DriverID)
        {

            int PersonID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }

        public static clsDriver FindByPersonID(int PersonID)
        {

            int DriverID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateDriver();

            }

            return false;
        }

        public static DataTable GetLicenses(int DriverID)
        {
            return clsLicense.GetDriverLicenses(DriverID);
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsInternationalLicense.GetDriverInternationalLicenses(DriverID);
        }

    }

    public class clsDetainedLicense
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int DetainID { set; get; }
        public int LicenseID { set; get; }
        public DateTime DetainDate { set; get; }

        public float FineFees { set; get; }
        public int CreatedByUserID { set; get; }
        public clsUsers CreatedByUserInfo { set; get; }
        public bool IsReleased { set; get; }
        public DateTime ReleaseDate { set; get; }
        public int ReleasedByUserID { set; get; }
        public clsUsers ReleasedByUserInfo { set; get; }
        public int ReleaseApplicationID { set; get; }

        public clsDetainedLicense()

        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MaxValue;
            this.ReleasedByUserID = 0;
            this.ReleaseApplicationID = -1;



            Mode = enMode.AddNew;

        }

        public clsDetainedLicense(int DetainID,
            int LicenseID, DateTime DetainDate,
            float FineFees, int CreatedByUserID,
            bool IsReleased, DateTime ReleaseDate,
            int ReleasedByUserID, int ReleaseApplicationID)

        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUsers.FindUserByUserID(this.CreatedByUserID);
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ReleasedByUserInfo = clsUsers.FindUserByPersonID(this.ReleasedByUserID);
            Mode = enMode.Update;
        }

        private bool _AddNewDetainedLicense()
        {
            //call DataAccess Layer 

            this.DetainID = clsDetainedLicenseData.AddNewDetainedLicense(
                this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);

            return (this.DetainID != -1);
        }

        private bool _UpdateDetainedLicense()
        {
            //call DataAccess Layer 

            return clsDetainedLicenseData.UpdateDetainedLicense(
                this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);
        }

        public static clsDetainedLicense Find(int DetainID)
        {
            int LicenseID = -1; DateTime DetainDate = DateTime.Now;
            float FineFees = 0; int CreatedByUserID = -1;
            bool IsReleased = false; DateTime ReleaseDate = DateTime.MaxValue;
            int ReleasedByUserID = -1; int ReleaseApplicationID = -1;

            if (clsDetainedLicenseData.GetDetainedLicenseInfoByID(DetainID,
            ref LicenseID, ref DetainDate,
            ref FineFees, ref CreatedByUserID,
            ref IsReleased, ref ReleaseDate,
            ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDetainedLicense(DetainID,
                     LicenseID, DetainDate,
                     FineFees, CreatedByUserID,
                     IsReleased, ReleaseDate,
                     ReleasedByUserID, ReleaseApplicationID);
            else
                return null;

        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();

        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1; DateTime DetainDate = DateTime.Now;
            float FineFees = 0; int CreatedByUserID = -1;
            bool IsReleased = false; DateTime ReleaseDate = DateTime.MaxValue;
            int ReleasedByUserID = -1; int ReleaseApplicationID = -1;

            if (clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID,
            ref DetainID, ref DetainDate,
            ref FineFees, ref CreatedByUserID,
            ref IsReleased, ref ReleaseDate,
            ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDetainedLicense(DetainID,
                     LicenseID, DetainDate,
                     FineFees, CreatedByUserID,
                     IsReleased, ReleaseDate,
                     ReleasedByUserID, ReleaseApplicationID);
            else
                return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateDetainedLicense();

            }

            return false;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetainedLicenseData.ReleaseDetainedLicense(this.DetainID,
                   ReleasedByUserID, ReleaseApplicationID);
        }
    }
    public class clsLicense
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public clsDriver DriverInfo;
        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClass { set; get; }
        public clsLicenseClass LicenseClassIfo;
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public float PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public clsDetainedLicense DetainedInfo { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); }
        }

        public clsLicense()

        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        public clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)

        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            this.LicenseClassIfo = clsLicenseClass.Find(this.LicenseClass);
            this.DetainedInfo = clsDetainedLicense.FindByLicenseID(this.LicenseID);

            Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);


            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsLicenseData.UpdateLicense(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0; bool IsActive = true; int CreatedByUserID = 1;
            byte IssueReason = 1;
            if (clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref Notes,
            ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass,
                                     IssueDate, ExpirationDate, Notes,
                                     PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;

        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }

        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }

        public bool DeactivateCurrentLicense()
        {
            return (clsLicenseData.DeactivateLicense(this.LicenseID));
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToSingle(FineFees);
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {

                return -1;
            }

            return detainedLicense.DetainID;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.FindApplicationTypeById((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;


            return this.DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);

        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicens;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.FindApplicationTypeById((int)clsApplication.enApplicationType.RenewDrivingLicens).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClassIfo.DefaultValidityLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassIfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {


            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicens :
                (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicens;

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.FindApplicationTypeById(Application.ApplicationTypeID).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;// no fees for the license because it's a replacement.
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;



            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

    }

    public class clsInternationalLicense : clsApplication
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsDriver DriverInfo;
        public int InternationalLicenseID { set; get; }
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }


        public clsInternationalLicense()

        {
            //here we set the applicaiton type to New International License.
            this.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInterNationalDrivingLicens;

            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;

            this.IsActive = true;


            Mode = enMode.AddNew;

        }

        public clsInternationalLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID,
             int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)

        {
            //this is for the base clase
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInterNationalDrivingLicens;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;

            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID);

            Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            //call DataAccess Layer 

            this.InternationalLicenseID =
                clsInternationalLicenseData.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);


            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            //call DataAccess Layer 

            return clsInternationalLicenseData.UpdateInternationalLicense(
                this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1; int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            bool IsActive = true; int CreatedByUserID = 1;

            if (clsInternationalLicenseData.GetInternationalLicenseInfoByID(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID,
            ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                //now we find the base application
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);


                return new clsInternationalLicense(Application.ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID,
                                     InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID,
                                         IssueDate, ExpirationDate, IsActive);

            }

            else
                return null;

        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();

        }

        public bool Save()
        {

            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateInternationalLicense();

            }

            return false;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {

            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);

        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }
    }
    public class clsTest
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestID { set; get; }
        public int TestAppointmentID { set; get; }
        public clsTestAppointment TestAppointmentInfo { set; get; }
        public bool TestResult { set; get; }
        public string Notes { set; get; }
        public int CreatedByUserID { set; get; }

        public clsTest()

        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        public clsTest(int TestID, int TestAppointmentID,
            bool TestResult, string Notes, int CreatedByUserID)

        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewTest()
        {
            //call DataAccess Layer 

            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);


            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            //call DataAccess Layer 

            return clsTestData.UpdateTest(this.TestID, this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);
        }

        public static clsTest Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestData.GetTestInfoByID(TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTest(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

        public static clsTest FindLastTestPerPersonAndLicenseClass
            (int PersonID, int LicenseClassID, clsTestTypes.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTest(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTests();

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTest();

            }

            return false;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }

    }
}