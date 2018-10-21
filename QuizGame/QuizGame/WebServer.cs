using System;
using System.Net;
using System.Threading;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Web;
namespace QuizGame
{
    class WebServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, string> _responderMethod;
        private List<Answer> answers = new List<Answer>();

        public WebServer(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");

            // URI prefixes are required, for example 
            // "http://localhost:8080/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            foreach (string s in prefixes)
                _listener.Prefixes.Add(s);

            _responderMethod = this.SendResponse;
            _listener.Start();
        }

        public WebServer(string v)
        {
            _listener.Prefixes.Add(v);
            _responderMethod = this.SendResponse;
            _listener.Start();
        }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                Console.WriteLine("Webserver running...");
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                string rstr = _responderMethod(ctx.Request);
                                byte[] buf = Encoding.UTF8.GetBytes(rstr);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch { } // suppress any exceptions
                            finally
                            {
                                // always close the stream
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch { } // suppress any exceptions
            });
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }

        public Answer get_Answer()
        {
            if (answers.Count == 0){
                return null;
            }
            else
            {
                Answer ans = answers[0];
                answers.RemoveAt(0);
                return ans;
            }
        }

        public string SendResponse(HttpListenerRequest request)
        {
            answers.Add(ParseAnswer(request.Url));
            
            return MakeWebsite(request.Url);
        }

        private string MakeWebsite(Uri uri)
        {

            String line = "<HTML><BODY>My web page.<br>{0}</BODY></HTML>";
            using (StreamReader sr = new StreamReader(@"C:\Users\miros\Documents\QuizGame\GameData\page.html", Encoding.GetEncoding("windows-1250")))
            {
                // Read the stream to a string, and write the string to the console.
                line = sr.ReadToEnd();

            }
            line += ParseAnswer(uri).ToString();
            return line;
        }

        private Answer ParseAnswer(Uri uri)
        {
            string teamName = HttpUtility.ParseQueryString(uri.Query).Get("team");
            string answerString = HttpUtility.ParseQueryString(uri.Query).Get("answer");
            return new Answer(teamName, answerString);
        }
    }
}