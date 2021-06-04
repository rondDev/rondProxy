using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using RestSharp;

namespace rondProxy
{
    class Program
    {
        static object @lock = new object();
        static int Scraped = 0;
        static void Main()
        {
            Console.Title = $"rondProxy | Proxy Scraper | Scraped: {Scraped}";
            string StartTime = DateTime.Now.ToString("MM.dd.yyyy H.mm");
            if (File.Exists("./Proxies.txt")) 
            {
                if (!Directory.Exists("Old")) { Directory.CreateDirectory("Old"); }
                Directory.CreateDirectory($"./Old/{StartTime}");
                try 
                {
                    File.Move("./Proxies.txt", $"./Old/{StartTime}/Proxies.txt");
                }
                catch
                {
                    File.Delete("./Proxies.txt");
                }
            }

            Console.WriteLine("Scraping Proxies from free-proxy-list.net");
            var client1 = new RestClient("https://free-proxy-list.net/anonymous-proxy.html");
            var request1 = new RestRequest(Method.GET);
            request1.AddCookie("__cfduid", "ddf3400da018be098cb3feaa97f6d5cd31594606537");
            IRestResponse response1 = client1.Execute(request1);
            string response1String = response1.Content;
            MatchCollection matches1 = Regex.Matches(response1String, "(?<=\n)([0-9].*?)(?=\n)");
            foreach (Match match in matches1)
            {
                //Console.WriteLine(match.Value);
                writeToText(match.ToString());
                Interlocked.Increment(ref Scraped);
                Console.Title = $"rondProxy | Proxy Scraper | Scraped: {Scraped}";
            }

            Thread.Sleep(400);

            Console.WriteLine($"Scraped {matches1.Count} proxies from free-proxy-list.net");

            Thread.Sleep(400);

            Console.WriteLine("Scraping Proxies from spys.me");
            var client2 = new RestClient("http://spys.me/proxy.txt");
            var request2 = new RestRequest(Method.GET);
            IRestResponse response2 = client2.Execute(request2);
            string response2String = response2.Content;
            MatchCollection matches2 = Regex.Matches(response2String, "(?<=\n)([0-9].*?)(?= )");
            foreach (Match match in matches2)
            {
                //Console.WriteLine(match.Value);
                writeToText(match.ToString());
                Interlocked.Increment(ref Scraped);
                Console.Title = $"rondProxy | Proxy Scraper | Scraped: {Scraped}";
            }

            Thread.Sleep(400);

            Console.WriteLine($"Scraped {matches2.Count} proxies from spys.me");

            Thread.Sleep(400);

            Console.WriteLine("Scraping Proxies from proxy-daily.com");
            var client3 = new RestClient("https://proxy-daily.com/");
            var request3 = new RestRequest(Method.GET);
            request3.AddCookie("__cfduid", "d9c1055d453083cff27ce1e2ea5540a901594610222");
            IRestResponse response3 = client3.Execute(request3);
            string response3String = response3.Content;
            MatchCollection matches3 = Regex.Matches(response3String, "(?<=\n)([0-9].*?)(?=\n)");
            foreach (Match match in matches3)
            {
                //Console.WriteLine(match.Value);
                writeToText(match.ToString());
                Interlocked.Increment(ref Scraped);
                Console.Title = $"rondProxy | Proxy Scraper | Scraped: {Scraped}";
            }

            Thread.Sleep(400);

            Console.WriteLine($"Scraped {matches3.Count} proxies from proxy-daily.com");

            Thread.Sleep(400);

            Console.WriteLine("Scraping Proxies from checkerproxy.net");
            string urlDate = DateTime.Today.ToString("yyyy-MM-dd");
            var client4 = new RestClient($"https://checkerproxy.net/api/archive/{urlDate}");
            var request4 = new RestRequest(Method.GET);
            request4.AddCookie("__cfduid", "de8719ba619e8722ea01c3a398372d8a61594610838");
            IRestResponse response4 = client4.Execute(request4);
            string response4String = response4.Content;
            MatchCollection matches4 = Regex.Matches(response4String, "(?<=\"addr\":\")([0-9].*?)(?=\")");
            foreach (Match match in matches4)
            {
                //Console.WriteLine(match.Value);
                writeToText(match.ToString());
                Interlocked.Increment(ref Scraped);
                Console.Title = $"rondProxy | Proxy Scraper | Scraped: {Scraped}";
            }

            Thread.Sleep(400);

            Console.WriteLine($"Scraped {matches4.Count} proxies from checkerproxy.net");

            Thread.Sleep(400);

            Console.WriteLine("Scraping Proxies from sslproxies.org");
            var client5 = new RestClient("https://www.sslproxies.org/");
            var request5 = new RestRequest(Method.GET);
            request5.AddCookie("__cfduid", "ddf3400da018be098cb3feaa97f6d5cd31594606537");
            IRestResponse response5 = client5.Execute(request5);
            string response5String = response5.Content;
            MatchCollection matches5 = Regex.Matches(response5String, "(?<=\n)([0-9].*?)(?=\n)");
            foreach (Match match in matches5)
            {
                //Console.WriteLine(match.Value);
                writeToText(match.ToString());
                Interlocked.Increment(ref Scraped);
                Console.Title = $"rondProxy | Proxy Scraper | Scraped: {Scraped}";
            }

            Thread.Sleep(400);

            Console.WriteLine($"Scraped {matches5.Count} proxies from sslproxies.org");

            Thread.Sleep(400);

            Console.WriteLine("Scraping Proxies from socks-proxy.net");
            var client6 = new RestClient("https://socks-proxy.net/");
            var request6 = new RestRequest(Method.GET);
            request6.AddCookie("__cfduid", "ddf3400da018be098cb3feaa97f6d5cd31594606537");
            IRestResponse response6 = client6.Execute(request6);
            string response6String = response6.Content;
            MatchCollection matches6 = Regex.Matches(response6String, "(?<=\n)([0-9].*?)(?=\n)");
            foreach (Match match in matches6)
            {
                //Console.WriteLine(match.Value);
                writeToText(match.ToString());
                Interlocked.Increment(ref Scraped);
                Console.Title = $"rondProxy | Proxy Scraper | Scraped: {Scraped}";
            }

            Thread.Sleep(400);

            Console.WriteLine($"Scraped {matches6.Count} proxies from socks-proxy.net");

            Thread.Sleep(400);

            for(int i = 1; i < 11; i++)
            {
                Console.WriteLine($"Scraping Proxies from proxy-list.org, page {i}");
                var client7 = new RestClient($"https://proxy-list.org/english/index.php?p={i}");
                var request7 = new RestRequest(Method.GET);
                request7.AddCookie("__cfduid", "ddf3400da018be098cb3feaa97f7d5cd31594707537");
                IRestResponse response7 = client7.Execute(request7);
                string response7String = response7.Content;
                MatchCollection matches7 = Regex.Matches(response7String, @"(?<=text/javascript\"">Proxy\(')(.*?)(?=')");
                foreach (Match match in matches7)
                {
                    string matchDecoded = Base64Decode(match.Value);
                    writeToText(matchDecoded);
                    Interlocked.Increment(ref Scraped);
                    Console.Title = $"rondProxy | Proxy Scraper | Scraped: {Scraped}";
                }
                Thread.Sleep(400);
                Console.WriteLine($"Scraped {matches7.Count} proxies from proxy-list.org, page {i}");
                Thread.Sleep(400);
            }

            Console.WriteLine("Scraping Proxies from 89ip.cn");
            var client8 = new RestClient("http://www.89ip.cn/tqdl.html?num=9999&address=&kill_address=&port=&kill_port=&isp=");
            var request8 = new RestRequest(Method.GET);
            request8.AddCookie("waf_cookie", "8b129353-25dd-4dfe06bdf3efa6ba2421869d8a83de34e5af");
            IRestResponse response8 = client8.Execute(request8);
            string response8String = response8.Content;
            MatchCollection matches8 = Regex.Matches(response8String, "(?<=<br>)([0-9].*?)(?=<br>)");
            foreach (Match match in matches8)
            {
                //Console.WriteLine(match.Value);
                writeToText(match.ToString());
                Interlocked.Increment(ref Scraped);
                Console.Title = $"rondProxy | Proxy Scraper | Scraped: {Scraped}";
            }

            Thread.Sleep(400);

            Console.WriteLine($"Scraped {matches8.Count} proxies from 89ip.cn");

            Thread.Sleep(400);

            Console.WriteLine("Scraping Proxies from proxyscrape.com");
            var client9 = new RestClient("https://api.proxyscrape.com/?request=getproxies&proxytype=http&timeout=10000&country=all&ssl=all&anonymity=all");
            var request9 = new RestRequest(Method.GET);
            IRestResponse response9 = client9.Execute(request9);
            string response9String = response9.Content;
            MatchCollection matches9 = Regex.Matches(response9String, "(?<=\n)([0-9].*?)(?=\n)");
            foreach (Match match in matches9)
            {
                //Console.WriteLine(match.Value);
                writeToText(match.ToString());
                Interlocked.Increment(ref Scraped);
                Console.Title = $"rondProxy | Proxy Scraper | Scraped: {Scraped}";
            }
            Thread.Sleep(400);
            Console.WriteLine($"Scraped {matches9.Count} proxies from proxyscrape.com");
            Thread.Sleep(400);

            Console.WriteLine("Done Scraping.");

            Thread.Sleep(-1);
        }

        public static void writeToText(string LINE)
        {
            lock (@lock)
            {
                using (StreamWriter writer = new StreamWriter($"./Proxies.txt", append: true))
                {
                    string cleaned = "";
                    try
                    {
                        cleaned = LINE.Replace("\n", "");
                    }
                    catch
                    {
                    }
                    try
                    {
                        cleaned = cleaned.Replace("\r", "");
                    }
                    catch
                    {}
                    writer.WriteLine(cleaned);
                }
            }
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
