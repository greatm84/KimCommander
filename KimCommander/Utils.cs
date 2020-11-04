using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace KimCommander
{
    class Utils
    {
        public static void sendShutdownOff()
        {
            sendShutdownCommand(0, false);
        }

        public static void sendShutdownCommand(int offsettime, bool timerOn)
        {
            string cmd_Str_on = "-s -f -t";
            string cmd_Str_off = "-a";
            ProcessStartInfo cmd = new ProcessStartInfo("ShutDown.exe");
            Process process = new Process();
            if (timerOn)
                cmd.Arguments = cmd_Str_on + offsettime.ToString();
            else
                cmd.Arguments = cmd_Str_off + offsettime.ToString();
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;
            cmd.UseShellExecute = false;
            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();
            process.WaitForExit();
            process.Close();
        }

        public static void sendWinCommandWithWindow(string order)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = order;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            process.Close();
        }

        public static string sendWindCommand(string order)
        {
            if(order.Length > 0)
            {
                return sendWindCommand("", order);
            }
            return "";
        }

        public static string sendWindCommand(string workdir, string order)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "CMD.exe";
            if (!workdir.Equals(""))
            {
                startInfo.WorkingDirectory = workdir;
            }
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            process.EnableRaisingEvents = false;

            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.Write(order + Environment.NewLine);
            process.StandardInput.Close();

            string result= process.StandardOutput.ReadToEnd();

            process.WaitForExit();
            process.Close();
            return result;
        }

        public static void LaunchApp(string fileName, string arguments, bool asAdmin)
        {
            // Use ProcessStartInfo class.
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = fileName;
            startInfo.Arguments = arguments;
            startInfo.WorkingDirectory = Path.GetDirectoryName(fileName);
            if (asAdmin)
            {
                startInfo.Verb = "runas";
            }
            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using-statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {                    
                }
            }
            catch
            {
                // Log error.
            }
        }

        public static void LaunchApp(string fileName, string arguments)
        {
            LaunchApp(fileName, arguments, false);
        }

        public static void CaptureApplication(string procName)
        {
            FileStream file = null;
            try
            {
                var proc = Process.GetProcessesByName(procName)[0];
                var rect = new User32.Rect();
                User32.GetWindowRect(proc.MainWindowHandle, ref rect);

                int width = rect.right - rect.left;
                int height = rect.bottom - rect.top;

                var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                Graphics graphics = Graphics.FromImage(bmp);
                graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);


                MemoryStream memStream = new MemoryStream();

                //bmp.Save("c:\\tmp\\test.png", ImageFormat.Png);
                bmp.Save(memStream, ImageFormat.Png);
                file = new FileStream("test.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                memStream.WriteTo(file);
                bmp.Dispose();
                file.Close();
                file = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                    file = null;
                }
            }
        }        

        public static string getAppVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }

        public static bool checkIconFileExit(string shortName)
        {
            if (File.Exists(getCacheFileName(shortName)))
            {
                return true;
            }
            return false;
        }

        public static string getCacheFileName(string shortName)
        {
            return Define.ICON_FILE_PATH + "\\" + shortName + ".png";
        }

        public static void makeIconCacheFile(Icon icon, string shortName)
        {
            string iconFullPath = getCacheFileName(shortName);
            Bitmap bitmap = icon.ToBitmap();
            bitmap.Save(iconFullPath, ImageFormat.Png);
            bitmap.Dispose();
        }

        public static void deleteIconCacheFile(string shortName)
        {
            File.Delete(getCacheFileName(shortName));
        }

        public static Icon getIconCache(string shortName)
        {
            Image image = Image.FromFile(getCacheFileName(shortName));
            Image thumbImage = image.GetThumbnailImage(32, 32, null, new IntPtr());
            Bitmap thumbBitmap = new Bitmap(thumbImage);
            Bitmap bitmap = new Bitmap(thumbBitmap);
            bitmap.SetResolution(72, 72);
            Icon icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
            image.Dispose();
            thumbImage.Dispose();
            thumbBitmap.Dispose();
            return icon;
        }

        public static Icon getIconFromAppPath(string filePath)
        {
            Icon icon = null;
            if (Path.HasExtension(filePath))
            {
                icon = Icon.ExtractAssociatedIcon(filePath);
            }
            else
            {
                icon = Properties.Resources.folder;
            }
            return icon;
        }        

        public static long getTimeStamp()
        {
            return Convert.ToInt64(DateTime.UtcNow.Subtract(new DateTime(1970,1,1)).TotalSeconds);
        }

        public static class EnumConv<T>
        {
            public static T Parse(string s)
            {
                return (T)Enum.Parse(typeof(T), s);
            }
        }

        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct Rect
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        }
    }
}
