using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DSA_Exam_Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * INPUT STRING
             * replace text inside the "" with your python source code
             */
            string input = @"
#!/usr/bin/env python27

#Importing the modules

from BeautifulSoup import BeautifulSoup
import sys
import urllib2
import re
import json

#Ask for movie title
title = raw_input(""Please enter a movie title: "")

#Ask for which year
year = raw_input(""which year? "")

#Search for spaces in the title string
raw_string = re.compile(r' ')

#Replace spaces with a plus sign
searchstring = raw_string.sub('+', title)

#Prints the search string
print searchstring

#The actual query
url = ""http://www.imdbapi.com/?t="" + searchstring + ""&y=""+year

request = urllib2.Request(url)

response = json.load(urllib2.urlopen(request))

print json.dumps(response,indent=2)
";


            /*
             *REGEX PATTERN
             *"?<var_name>" - group name
             *"([\w]+)" - group - match any character A-Z, a-z, 0-9 one or more times
             *"(?: =)" - non capture group - match " =" exactly
             * "|" - or
             *"(?: for )" - non capture group - match "for " exactly
             *"([\w]+)" - group - match any character A-Z, a-z, 0-9 one or more times
             *"(?: in)" - non capture group - match " in" exactly
             *see https://regex101.com/ for more info
             */
            string pattern = @"(?<var_name>[\w]+)(?: =)|(?: for )(?<var_name>[\w]+)(?: in)";
            RegexOptions options = RegexOptions.Multiline;

            Dictionary<string, int> matchesCount = new Dictionary<string, int>();
            foreach (Match match in Regex.Matches(input, pattern, options))
            {
                //Get string that corresponds to match of the "var_name" group
                string variableName = match.Groups["var_name"].ToString();

                if (!matchesCount.ContainsKey(variableName))
                {
                    matchesCount[variableName] = 1;
                }
                else
                {
                    matchesCount[variableName]++;
                }

                /*debug stuff*/
                Console.WriteLine($"'{match.Value}' found at index {match.Index}.");
            }

            Console.WriteLine();

            Console.WriteLine("List of variables found in source code:");
            foreach (KeyValuePair<string, int> keyValuePair in matchesCount)
            {
                Console.WriteLine($"Variable \"{keyValuePair.Key}\"");
            }
        }
    }
}