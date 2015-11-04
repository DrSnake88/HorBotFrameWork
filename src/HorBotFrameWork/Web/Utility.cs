using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HorBotFrameWork.Web
{
    public static class Utility
    {
        // Get all text between 2 tokens
        public static List<string> GetBetween(string input, string[] tokens)
        {
            var matches = new List<string>(); // List with all the found text between tokens
            var tokenLocations = new int[2]; // Helper variable to store the locations of the token in the input

            // Convert all to lower text, so we don't have to compare capitalization
            var testInput = input.ToLower(); 
            tokens[0] = tokens[0].ToLower();
            tokens[1] = tokens[1].ToLower();
            
            var count = Regex.Matches(testInput, tokens[0]).Count; // The amount of times, the first token has been found

            // For every match
            for (var i = 0; i < count; i++)
            {
                var loc = new Regex[] {new Regex(tokens[0]), new Regex(tokens[1])  };
                tokenLocations[0] = loc[0].Match(testInput, tokenLocations[0] + 1).Index; // Location of the first token
                tokenLocations[1] = loc[1].Match(testInput, (tokenLocations[0] + tokens[0].Length) + 1).Index; // Location of the 2nd token after the first

                if (tokenLocations[0] == -1 || tokenLocations[1] == -1) return null; // If one of the tokens hasn't been found, return null

                tokenLocations[0] += tokens[0].Length; // Add the length of the token the index of the first token location, so the token will be removed from the matched output

                var extracted = input.Substring(tokenLocations[0], tokenLocations[1] - tokenLocations[0]); // Get the text between the tokens and also remove the " from the string
                
                matches.Add(extracted); // Add extracted text to the matches list.
            }


            return matches;
        }

        public static List<string> GetLinks(string input)
        {
            var regex = new Regex("(?:href|src|content)=[\"|']?(.*?)[\"|'|>]+", RegexOptions.Singleline | RegexOptions.CultureInvariant);
            var links = regex.Matches(input).Cast<Match>().Select(match => match.Value).ToList();

            for (var i = 0; i < links.Count; i++)
            {
                links[i] = links[i].Replace("\"", "");
                links[i] = links[i].Replace("src=", "");
                links[i] = links[i].Replace("content=", "");
                links[i] = links[i].Replace("href=", "");
                links[i] = links[i].Replace(">", "");
            }

            return links;
        } 
    }
}
