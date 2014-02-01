using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    public class Node
    {
        public Node(string url)
        {
            Url = url;
            Children = new List<Node>();
        }

        public string Text { get; set; }

        public string Url { get; private set; }

        public List<Node> Children { get; set; }

        public string FileName { get; set; }
    }
}
