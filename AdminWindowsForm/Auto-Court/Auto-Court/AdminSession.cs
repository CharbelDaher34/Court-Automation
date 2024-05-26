using System;
using System.Collections.Generic;
using System.Text;

namespace Auto_Court
{
    public static class AdminSession
    {
        private static string admin_username;
        public static string Admin_Username
        {
            get
            {
                return admin_username;
            }
        }
        public static bool IsAdminLoggedIn
        {
            get
            {
                return !string.IsNullOrEmpty(admin_username);

            }

        }
        public static void Login (string username)
        {
            admin_username = username;
        }
        public static void Logout()
        {
            admin_username = null;
        
        }
    }
}
