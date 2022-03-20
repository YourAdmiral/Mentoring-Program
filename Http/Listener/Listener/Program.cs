using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Listener
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string localHostPrefix = "http://localhost:8888/";
            const string myNamePrefix = "http://localhost:8888/MyName/";
            const string code1Prefix = "http://localhost:8888/Information/";
            const string code2Prefix = "http://localhost:8888/Success/";
            const string code3Prefix = "http://localhost:8888/Redirection/";
            const string code4Prefix = "http://localhost:8888/ClientError/";
            const string code5Prefix = "http://localhost:8888/ServerError/";
            const string robertPrefix = "http://localhost:8888/MyNameByHeader/Robert/";
            const string williamPrefix = "http://localhost:8888/MyNameByHeader/William/";

            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }

            // URI prefixes are required,
            var prefixes = new List<string>()
            {
                localHostPrefix, 
                myNamePrefix,
                code1Prefix,
                code2Prefix,
                code3Prefix,
                code4Prefix,
                code5Prefix,
                robertPrefix,
                williamPrefix
            };

            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();

            Console.WriteLine("Listening...");

            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();

                HttpListenerRequest request = context.Request;

                string documentContents;

                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                // Construct a response.
                string responseString;

                Console.WriteLine($"Recived request for {request.Url}");

                switch (ParseRequest(request))
                {
                    case myNamePrefix:
                        responseString = GetMyName();
                        break;
                    
                    case code1Prefix:
                        responseString = GetInformation();
                        break;

                    case code2Prefix:
                        responseString = GetSuccess();
                        break;

                    case code3Prefix:
                        responseString = GetRedirection();
                        break;

                    case code4Prefix:
                        responseString = GetClientError();
                        break;

                    case code5Prefix:
                        responseString = GetServerError();
                        break;

                    case robertPrefix:
                        responseString = GetHeaderRobert();
                        break;

                    case williamPrefix:
                        responseString = GetHeaderWilliam();
                        break;

                    default:
                        responseString = "<HTML><BODY>Hello world!</BODY></HTML>";
                        break;
                }

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.

                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                // You must close the output stream.
                output.Close();
            }

            listener.Stop();
        }

        private static string GetMyName()
        {
            return "<HTML><BODY>Kiryl</BODY></HTML>";
        }

        private static string GetInformation()
        {
            return "<HTML><BODY>100</BODY></HTML>";
        }

        private static string GetSuccess()
        {
            return "<HTML><BODY>200</BODY></HTML>";
        }

        private static string GetRedirection()
        {
            return "<HTML><BODY>300</BODY></HTML>";
        }

        private static string GetClientError()
        {
            return "<HTML><BODY>400</BODY></HTML>";
        }

        private static string GetServerError()
        {
            return "<HTML><BODY>500</BODY></HTML>";
        }

        private static string GetHeaderRobert()
        {
            return "<HTML><BODY>Robert</BODY></HTML>";
        }

        private static string GetHeaderWilliam()
        {
            return "<HTML><BODY>William</BODY></HTML>";
        }

        private static string ParseRequest(HttpListenerRequest request)
        {
            return request.Url.ToString();
        }
    }
}
