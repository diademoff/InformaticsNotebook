using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MyNotebook.Models
{
    public class GitUpdater
    {
        public string ThisVersion { get; } = "0.7.8"; //TODO: Before commiting change version here and in file "version"
        string linkForNewVersion = "https://raw.githubusercontent.com/diademoff/InformaticsNotebook/master/version";
        string linkForDownloadFile = "https://github.com/diademoff/InformaticsNotebook/raw/master/MyNotebook/Build/MyNotebook.exe";
        string programName = "MyNotebook";
        string updateComment = "";
        public bool NeedUpdate => GetNewVersion() != ThisVersion;

        public void AskAndUpdate()
        {
            if (NeedUpdate)
            {
                if (MessageBox.Show($"Найдена новая версия, хотите обновить программу?\n{updateComment}", "Проверка обновлений", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Update();
                }
            }
            else
            {
                MessageBox.Show("Обновления не найдены или отсутствует доступ к репозиторию", "Проверка обновлений", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Use this method if update is necessary
        /// </summary>
        public void Update()
        {
            string fileName = DownloadFile();

            ReplaceFiles(Assembly.GetExecutingAssembly().Location, $"{Environment.CurrentDirectory}\\{fileName}");
        }

        void Cmd(string line)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {line}",
                WindowStyle = ProcessWindowStyle.Hidden
            }).Start();
        }

        private void ReplaceFiles(string oldFilePath, string newFileFullPath)
        {
            Cmd($"taskkill /f /pid \"{Process.GetCurrentProcess().Id}\" &" +
                $"del /f /q \"{oldFilePath}\" &" +
                $"ping 1 &" + // sleep a bit
                $"del /f /q \"{oldFilePath}\" &" + 
                $"start \"\" /high \"{newFileFullPath}\""); //kill current process and delete current file
        }

        /// <summary>
        /// Download file, returns filename
        /// </summary>
        /// <returns></returns>
        private string DownloadFile()
        {
            WebClient wc = new WebClient();
            wc.Headers["User-Agent"] = "Mozilla/4.0";
            wc.Encoding = Encoding.UTF8;

            if (!File.Exists($"{programName}.exe"))
            {
                wc.DownloadFile(linkForDownloadFile, $"{programName}.exe");
                return $"{programName}.exe";
            }
            else
            {

                int counter = 1;
                while (true)
                {
                    if (!File.Exists($"{programName}({counter}).exe"))
                    {
                        wc.DownloadFile(linkForDownloadFile, $"{programName}({counter}).exe");
                        return $"{programName}({counter}).exe";
                    }
                    counter++;
                }
            }
        }

        private string GetNewVersion()
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Headers["User-Agent"] = "Mozilla/4.0";
                wc.Encoding = Encoding.UTF8;

                string html = wc.DownloadString(linkForNewVersion);
                string[] splitted = html.Split('\n');

                string[] comments = new string[splitted.Length - 1];
                Array.Copy(html.Split('\n'), 1, comments, 0, splitted.Length - 1);

                updateComment = string.Join("\n", comments);

                return splitted[0];
            }
            catch { return ThisVersion; }
        }
    }
}
