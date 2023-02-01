using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Log In server");

            const int port = 80;
            string prefix = $"http://localhost:{port}/";

            HttpListener server = new HttpListener();
            server.Prefixes.Add(prefix);
            server.Start();
            HttpListenerContext context = server.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            string html = "Hello World";

            switch (request.RawUrl)
            {
                case "/":
                    html = File.ReadAllText("../../static/index.html");
                    break;
                default:
                    string path = "../../static" + request.RawUrl;
                    if (File.Exists(path))
                    {
                        html = File.ReadAllText(path);
                    }
                    else
                    {
                        response.StatusCode = 404;
                        html = "sorry - file not found :(";
                        Console.WriteLine($"Unknown URL: {request.RawUrl}");
                    }
                    break;
            }

            byte[] buffer = Encoding.UTF8.GetBytes(html);
            Console.WriteLine($"Sending {buffer.Length} bytes. . .");

            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            server.Stop();

            Console.ReadLine();
        }
    }
}