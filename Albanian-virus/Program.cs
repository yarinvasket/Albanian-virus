using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Albanian_virus
{
    static class Program
    {
        public const string virusMessage = "Hi, I am an Albanian virus but because of poor technology in my country unfortunately I " +
            "am not able to harm your computer. Please be so kind to delete one of your important files yourself and then forward me" +
            " to other users. Many thanks for your cooperation!  Best regards,Albanian virus";
        public const string titleMessage = "Virus Alert !";

        public const string startUp = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\StartUp\\Albanian-virus.lnk";
        public static string userStartUp = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\Albanian-virus.lnk";
        public static string appPath = System.Reflection.Assembly.GetEntryAssembly().Location;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!System.IO.File.Exists(startUp))
            {
                try
                {
                    CreateShortcut(startUp);
                }
                catch (Exception)
                {
                    CreateShortcut(userStartUp);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MessageBox.Show(virusMessage, titleMessage, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            
        }

        public static void CreateShortcut(string targetPath)
        {
            WshShell shell = new WshShell();
            string shortcutAddress = targetPath;
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "";
            shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.TargetPath = appPath;
            shortcut.Save();
        }
    }
}
