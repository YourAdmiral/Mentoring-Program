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
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            // URI prefixes are required,
            var prefixes = new List<string>() { localHostPrefix, myNamePrefix };

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

                if (ParseRequest(request) != myNamePrefix)
                {
                    Console.WriteLine(documentContents);

                    responseString = "<HTML><BODY>Hello world!</BODY></HTML>";
                }
                else
                {
                    responseString = GetMyName();
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
            return "<HTML><BODY>Kiryl</BODY></HTML>"; ;
        }

        private static string ParseRequest(HttpListenerRequest request)
        {
            return request.Url.ToString();
        }
    }
}
