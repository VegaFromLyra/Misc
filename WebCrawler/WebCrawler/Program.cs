using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.IO;

namespace WebCrawler
{
    class Program
    {
        static Dictionary<string, Node> hashMapUrls = new Dictionary<string, Node>();

        static Queue<Node> queueNodes = new Queue<Node>();

        static void Main(string[] args)
        {
            // 1. Construct a graph with a given url
            Console.WriteLine("Enter url\n");
            string url = Console.ReadLine();

            Task<Node> crawlTask = Crawl(url);

            crawlTask.Wait();

            // 2. Figure out how to download all contents of this graph locally            
        }

        static async Task<Node> Crawl(string url)
        {
            Node node = new Node(url);

            try
            {
                hashMapUrls.Add(url, node);

                queueNodes.Enqueue(node);

                while (queueNodes.Count > 0)
                {
                    Node n = queueNodes.Dequeue();

                    List<string> outgoingUrls = await GetContent(n);

                    foreach (string outgoingUrl in outgoingUrls)
                    {
                        string processedUrl = null;
                        // Temp hack, remove trailing /
                        if (outgoingUrl[outgoingUrl.Length - 1] == '/')
                        {
                            processedUrl = outgoingUrl.Remove(outgoingUrl.Length - 1);
                        }
                        else
                        {
                            processedUrl = outgoingUrl;
                        }

                        if (!hashMapUrls.ContainsKey(processedUrl))
                        {
                            Node childNode = new Node(processedUrl);
                            hashMapUrls.Add(processedUrl, childNode);

                            n.Children.Add(childNode);

                            queueNodes.Enqueue(childNode);
                        }
                        else
                        {
                            n.Children.Add(hashMapUrls[processedUrl]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return node;
        }

        // TODO - Update this code to handle exceptions 
        // in FindUrls
        static async Task<List<string>> GetContent(Node n)
        {
            HttpClient client = new HttpClient();

            // Send async request to URL
            // await suspends execution of this method  on main thread and control 
            // goes back to caller of 'Download'
            // Controls resumes when GetStreamAsync is done
            Stream responseStream = await client.GetStreamAsync(n.Url);

            Console.WriteLine("Finding urls for {0}", n.Url);
            List<string> outGoingLinks = FindUrls(responseStream);

            return outGoingLinks;
        }

        private static void WriteStreamToFile(Node n, Stream responseStream)
        {
            n.FileName = Math.Abs(n.Url.GetHashCode()).ToString() + ".txt";

            using (Stream fileStream = File.OpenWrite(n.FileName))
            {
                responseStream.CopyTo(fileStream);
            }
        }


        private static List<string> FindUrls(Stream responseStream)
        {
            List<string> result = new List<string>();

            HtmlDocument document = new HtmlDocument();
            document.Load(responseStream);

            string xpath = "//a[@href]"; // This XPath means select all 'a' queueNodes that have a 'href' attribute
            foreach (HtmlNode link in document.DocumentNode.SelectNodes(xpath))
            {
                string href = link.GetAttributeValue("href", null);

                if (!String.IsNullOrEmpty(href) && href.StartsWith("http"))
                {
                    result.Add(href);
                }
            }

            return result;
        }
    }
}
