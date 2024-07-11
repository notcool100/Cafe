namespace APP.COMMON
{
    public class ATTMessages
    {
        #region GENERAL
        public const string NO_RECORDS_FOUND = "Sorry, No Records Found .";
        public const string NO_TABLES_FOUND = "Sorry, No Tables Found .";
        public const string DUPLICATE_RECORDS_FOUND = "Duplicate Records Found, Please Re-Check The List .";
        public const string CANNOT_SAVE = "Failed To Save Data .";
        public const string SAVED_SUCCESS = "Saved Data Successfully .";
        public const string GENERIC_ERROR = "System Error Occured .";
        public const string RECORD_FOUND = "Records Found .";
        public const string DELETE_SUCCESS = "Records Deleted Successfully .";
        public const string DELETE_FAILED = "Failed To Delete Record(s).";
        #endregion


        #region Database
        public class DATABASE
        {
            public const string CONNECTION_SUCCESS = "Connected with the Server Successfully .";
            public const string CONNECTION_FAILURE = "Failed To Connect To The Server .";
            public const string CONNECTION_TIMEOUT = "Connection With The Server Is Taking Time .";
        }
        #endregion

        #region User
        public class USER
        {
            public const string LOGIN_SUCCESS = "User Logged In Succesfully .";
            public const string LOGIN_FAILURE = "User Logged In Failed .";
            public const string PASSWORD_CHANGE_SUCCESS = "Password Changed Succesfully .";
            public const string PASSWORD_CHANGE_FAILURE = "Failed To Change Password .";
        }
        #endregion
    }

}
