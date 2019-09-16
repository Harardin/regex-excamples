using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexFirstTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            string TextToParse = "This is some text to parse " +
            "\r\n" +
            "<h1>This is text to extract</h1> " + // This is text to extract from H1 HTML tag
            "\r\n" +
            "Jason Born " + // This is some name to parse
            "19286123 " + // This is numbers to extract
            "This is some number 123099378 'Number' " + // This is a number and a word -> 'Number' to extract
            // This is set of words that was written different
            "Boat " +
            "Boad " +
            "Baod " +
            // Making some space
            "\r\n" +
            "\r\n" +
            // A list of items to parse
            "Bread" +
            "\r\n" +
            "Briad" +
            "\r\n" +
            // A list of numbers to parse
            "12399234" +
            "\r\n" +
            "98428938" +
            "\r\n" +
            "Text1239With985Numbers" + // Should be parsed only numbers
            "\r\n" +
            // Next portion of data
            "Text Some other stuff Numbers";

            // • - This is space symbol in RegexExpression

            string regexExpression = @"(?<=Text).*(?=Numbers)";

            Regex rg = new Regex(
                regexExpression, 
                RegexOptions.Multiline
            );
            List<string> results = new List<string>();

            results = rg.Matches(TextToParse).Cast<Match>().Select(match => match.Value).ToList();

            foreach(string res in results)
            {
                Console.WriteLine(res);
            }

            // This excample just catches some words inbetween

            /*
            Works only for: 
            - Text1239With985Numbers
            - Text Some other stuff Numbers
             */
        }
    }
}
