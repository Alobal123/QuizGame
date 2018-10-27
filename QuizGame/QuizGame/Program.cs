using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizGame
{



    static class Program
    {



        public static void ShuffleMe<T>(this IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = list.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                T value = list[rnd];
                list[rnd] = list[i];
                list[i] = value;
            }
        }
        public static WebServer ws;

        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            startWifi();
            Game game = new Game(@"C:\Users\miros\Documents\QuizGame\GameData");
            // C:\WINDOWS\system32>netsh http add urlacl url=http://*:8080/ sddl=D:(A;;GX;;;S-1-1-0)
            ws = new WebServer("http://*:8080/" );
            ws.Run();

            MainScreen form = new MainScreen(game);
            Application.Run(form);
        }
        private static void startWifi()
        {
            
            string strCmdText = "/C netsh wlan set hostednetwork mode=allow ssid=QUIZ key=12345678";
            runCommandAsAdmin(strCmdText);
            strCmdText = "/C netsh wlan start hostednetwork";
            runCommandAsAdmin(strCmdText);
        }
        public static void stopWifi()
        {
            string strCmdText = "/C netsh wlan stop hostednetwork";
            runCommandAsAdmin(strCmdText);
        }

        private static void runCommandAsAdmin(string arguments)
        {
            System.Diagnostics.ProcessStartInfo myProcessInfo = new System.Diagnostics.ProcessStartInfo();
            myProcessInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
            myProcessInfo.Arguments = arguments;
            myProcessInfo.Verb = "runas";

            System.Diagnostics.Process.Start(myProcessInfo);
        }
    }

    static class LevenshteinDistance
    {
        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }

}
