using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DSA_Exam_Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();

//            string input = @"asd = 
//s = (a+b+c)/2
//area = √(s(s-a)*(s-b)*(s-c))
//
//conv_fac = 0.621371
//
//# calculate miles
//miles = kilometers * conv_fac
//print('%0.3f kilometers is equal to %0.3f miles' %(kilometers,miles))
//
//num = int(input(""Enter a number: ""))
//if (num % 2) == 0:
//   print(""{0} is Even"".format(num))
//else:
//   print(""{0} is Odd"".format(num))
//num = 0";


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


            //Pattern to match variable declaration
            string pattern = @"[a-zA-Z_][a-zA-Z_$0-9]* =";
            RegexOptions options = RegexOptions.Multiline;


            Dictionary<string, int> matchesCount = new Dictionary<string, int>();
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                //trims last two characters of match which are " ="
                string variableName = m.Value.Substring(0, m.Value.Length - 2);

                if (!matchesCount.ContainsKey(variableName))
                {
                    matchesCount[variableName] = 1;
                }
                else
                {
                    matchesCount[variableName]++;
                }

                Console.WriteLine($"'{m.Value}' found at index {m.Index}.");
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