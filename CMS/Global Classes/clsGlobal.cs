using CMSBusinessLayer;
using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CMS.Classes
{
    internal static class clsGlobal
    {


        public static clsUsers CurrentUser;
        public static int RoleID;

        public static bool RememberUsernameAndPasswordInRegistry(string Username, string Password, string RoleID)
        {
            // Specify the Registry key and path

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\CMS";
            //string UsernameValue = "Username";
            //string UsernameData = Username;


            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, "Username", Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", Password, RegistryValueKind.String);
                Registry.SetValue(keyPath, "RoleID", RoleID, RegistryValueKind.String);


                return true;
            }
            catch (Exception ex)
            {
                return false;
                //Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static bool GetStoredCredentialFromRegistry(ref string Username, ref string Password, ref string RoleID)
        {
            // Specify the Registry key and path
            //string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\YourSoftware";
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\CMS";
            string UsernameValueName = "Username";
            string PasswordValueName = "Password";
            string RoleIDValueName = "RoleID";


            try
            {
                // Read the value from the Registry
                Username = Registry.GetValue(keyPath, UsernameValueName, null) as string;
                Password = Registry.GetValue(keyPath, PasswordValueName, null) as string;
                RoleID = Registry.GetValue(keyPath, RoleIDValueName, null) as string;


                if (Username != null && Password != null && RoleID != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
