using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace PbiReportEditor.Misc
{
    public static class Helper
    {
        public static string AES_Encrypt(this string stringToEncrypted, string salt_key)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(stringToEncrypted);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(salt_key);
            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string AES_Decrypt(this string stringToDecrypted, string salt_key)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] bytesToBeDecrypted = Convert.FromBase64String(stringToDecrypted);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(salt_key);
            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return Encoding.UTF8.GetString(decryptedBytes);
        }

        public static string GetSystemDriveLetter()
        {
            string system_drive = string.Empty;
            try
            {
                system_drive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            }
            catch (Exception ex)
            {
                system_drive = "C:\\";
            }

            return system_drive.Substring(0, 1);
        }

        public static string GetHDDSerialNumber(string drive_letter)
        {
            string hddInfo = string.Empty;
            try
            {
                #region Get installed logical drive
                var logicalDiskId = drive_letter + ":"; //AppDomain.CurrentDomain.BaseDirectory.ToString().Substring(0, 2);
                var deviceId = string.Empty;

                var query = "ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" + logicalDiskId + "'} WHERE AssocClass = Win32_LogicalDiskToPartition";
                var queryResults = new ManagementObjectSearcher(query);
                var partitions = queryResults.Get();

                foreach (var partition in partitions)
                {
                    query = "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition";
                    queryResults = new ManagementObjectSearcher(query);
                    var drives = queryResults.Get();

                    foreach (var drive in drives)
                    {
                        deviceId = drive["DeviceID"].ToString().Replace("\\", "").Replace(".", "");
                    }

                    ManagementObjectSearcher searcher_diskdrive = new ManagementObjectSearcher("Select * From Win32_PhysicalMedia");
                    foreach (ManagementObject media in searcher_diskdrive.Get())
                    {
                        if (media["Tag"].ToString().Replace("\\", "").Replace(".", "") == deviceId)
                        {
                            hddInfo = media["SerialNumber"].ToString().Trim();
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                return hddInfo;
                #endregion Get installed logical drive
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
