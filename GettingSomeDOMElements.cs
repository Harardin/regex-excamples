using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GetDomElements
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parsing some DOM elements with Regex excamples

            // Parsing a DateTime with RegularExpressions
            DoTheJobAsync().GetAwaiter().GetResult();
        }
        private static async Task DoTheJobAsync()
        {
            string RegexExpression = @"(?<=<time.*>).\d+.\d+.\d+.(?=</time>)"; // .* is also an option
            string RequestUrl = "http://localhost";

            HttpClient client = new HttpClient();
            var responce = await client.GetAsync(RequestUrl);
            string dom = await responce.Content.ReadAsStringAsync();

            Regex reg = new Regex(
                RegexExpression,
                RegexOptions.Multiline
            );

            List<string> results = new List<string>();
            results = reg.Matches(dom).Cast<Match>().Select(match => match.Value).ToList();

            foreach(string str in results)
            {
                Console.WriteLine(string.Concat("Result: ", str));
            }
        }
    }
}
