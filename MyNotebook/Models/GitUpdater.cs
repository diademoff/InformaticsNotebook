﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace MyNotebook.Models
{
    public class GitUpdater
    {
        public string ThisVersion { get; } = "0.5"; //TODO: Before commiting change version here and in file "version_info"
        string linkForNewVersion = "https://github.com/diademoff/InformaticsNotebook/blob/master/version";
        string linkForDownloadFile = "https://github.com/diademoff/InformaticsNotebook/raw/master/MyNotebook/Build/MyNotebook.exe";
        string programName = "InformaticsNotebook";
        public bool NeedUpdate => GetNewVersion() != ThisVersion;
        public void Update()
        {
            string newVersion = GetNewVersion();
            if (newVersion != ThisVersion)
            {
                string fileName = DownloadFile();

                ReplaceFiles(Assembly.GetExecutingAssembly().Location, $"{Environment.CurrentDirectory}\\{fileName}");
            }
        }

        private void ReplaceFiles(string oldFilePath, string newFileFullPath)
        {
            Process.Start(newFileFullPath);
            Environment.Exit(0);
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

                //get string array of coincidence: <title>Hello</title> - returns Hello
                //<td id="LC1" class="blob-code blob-code-inner js-file-line">0.1</td> - returns version
                string[] str = ParseMethod("<td id=\"LC1\" class=\"blob-code blob-code-inner js-file-line\">", "</td>", html);
                return str[0];
            }
            catch { return ThisVersion; }
        }
        public string[] ParseMethod(string str_begin, string str_end, string str_html)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < str_html.Length - str_begin.Length; i++)
            {
                if (str_html.Substring(i, str_begin.Length) == str_begin)
                {
                    int start = i + str_begin.Length;
                    for (int j = start; j < str_html.Length - str_end.Length; j++)
                    {
                        if (str_html.Substring(j, str_end.Length) == str_end)
                        {
                            int finish = j;
                            list.Add(str_html.Substring(start, finish - start));
                            break;
                        }
                    }
                }
            }
            return list.ToArray();
        }
    }
}
