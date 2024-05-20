using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace SMT
{
    public enum State
    {
        OK, NG, WR
    }
    public static class Ultils
    {
        public static bool HasNewVersion()
        {
            var ROOT_RunApp = Properties.Settings.Default.ROOT_RunApp;
            var FileName_RUN = Properties.Settings.Default.FileName_RUN;
            //Tìm version mới nhất:
            List<FileInfo> lstFile = new List<FileInfo>();

            var pathFolder = ROOT_RunApp;
            var dirs = new DirectoryInfo(pathFolder).GetDirectories().ToList();
            foreach (var iDir in dirs)
            {
                var fileExe = iDir.GetFiles($"{FileName_RUN}.exe", SearchOption.AllDirectories).ToList();
                lstFile.AddRange(fileExe);
            }
            lstFile = lstFile.OrderByDescending(i => i.CreationTime).ToList();
            string fileRunEXE_NewestVersion = lstFile.FirstOrDefault().FullName.ToString();
            string newestVersion = lstFile.FirstOrDefault().Directory.Name.Replace(".", "");
            var version = GetRunningVersion();
            return int.Parse(newestVersion) > int.Parse(version.Replace(".", ""));
        }
        public static string GetRunningVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public static void RegisterInStartup(bool isChecked, string executablePath)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("ApplicationName", executablePath);
            }
            else
            {
                registryKey.DeleteValue("ApplicationName");
            }
        }

        /// <summary>
        /// create log
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="productionId"></param>
        /// <param name="status"></param>
        /// <param name="process"></param>
        public static void CreateFileLog(string model, string productId, string status, string process, DateTime dateCheck)
        {
            string _path = @"SOFTWARE\CANON_SUPPOR\Configs";
            string dateTime = dateCheck.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}_{model}_{productId}.txt";
            //string fileName1 = String.Format("{0}_{1}_{2}.txt", dateTime, model, productId);
            string folderRoot = $@"{GetValueRegistryKey(_path, "OutputLog")}\";

            bool exists = Directory.Exists(folderRoot);
            if (!exists)
                Directory.CreateDirectory(folderRoot);

            string path = folderRoot + fileName;
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{model}|{productId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{model}|{productId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
        }
        public static void WriteLog(string isWritelog, string umcBarcode, string vendorPartno, string dateCode)
        {
            //string _path = @"SOFTWARE\MC_SUPPOR\Configs";
            string dateTime = DateTime.Now.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}_{umcBarcode}.txt";
            //string fileName1 = String.Format("{0}_{1}_{2}.txt", dateTime, model, productId);
            //isWritelog = GetValueRegistryKey(_path, "OutputLog");
            string path = $@"C:\LOGPROCESS\{fileName}";
            bool exists = Directory.Exists(@"C:\LOGPROCESS");
            if (!exists)
                Directory.CreateDirectory(path);

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine($"{umcBarcode}|{vendorPartno}|{dateCode}|{dateTime}");
                tw.Close();
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistry(string path, string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(path);
            if (!string.IsNullOrEmpty(keyName) && !string.IsNullOrEmpty(content))
            {
                key.SetValue(keyName, content);
                key.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistryArray(string path, string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(path);
            if (!string.IsNullOrEmpty(keyName) && !string.IsNullOrEmpty(content))
            {
                string exitsValue = GetValueRegistryKey(path, keyName);
                if (exitsValue != null)
                {
                    exitsValue += content + ";";
                    key.SetValue(keyName, exitsValue);
                }
                else
                {
                    key.SetValue(keyName, content + ";");
                }
                key.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetValueRegistryKey(string path, string keyName)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(path);
            string value = null;
            if (key != null)
            {
                if (key.GetValue(keyName) != null)
                {
                    value = key.GetValue(keyName).ToString();
                    key.Close();
                    return value;
                }
            }

            return null;
        }

        public static void Waitting(int millisecond)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (true)
            {
                if (stopwatch.ElapsedMilliseconds >= millisecond)
                {
                    stopwatch.Stop();
                    return;
                }
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var a = host.AddressList;
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static string FriendlyName()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
        }
        public static bool IsWindowsActivated()
        {
            ManagementScope scope = new ManagementScope(@"\\" + System.Environment.MachineName + @"\root\cimv2");
            scope.Connect();

            SelectQuery searchQuery = new SelectQuery("SELECT * FROM SoftwareLicensingProduct WHERE ApplicationID = '55c92734-d682-4d71-983e-d6ec3f16059f' and LicenseStatus = 1");
            ManagementObjectSearcher searcherObj = new ManagementObjectSearcher(scope, searchQuery);

            using (ManagementObjectCollection obj = searcherObj.Get())
            {
                return obj.Count > 0;
            }
        }
        public static bool IsWindows64bit()
        {
            return Environment.Is64BitOperatingSystem;
        }
        public static string GetOfficeVersion()
        {
            // Using the file path to winword.exe
            // Retrieve the path e.g. from the InstallRoot Registry key
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(@"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.EXE");
            var version = new Version(fileVersionInfo.FileVersion);
            return version.ToString();
        }
        public static void UppercaseClassFields<T>(T theInstance)
        {
            if (theInstance == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var property in theInstance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var theValue = property.GetValue(theInstance, null);
                if (theValue is string)
                {
                    property.SetValue(theInstance, ((string)theValue).ToUpper(), null);
                }
            }
        }

        public static void UppercaseClassFields<T>(IEnumerable<T> theInstance)
        {
            if (theInstance == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var theItem in theInstance)
            {
                UppercaseClassFields(theItem);
            }
        }
    }
}
