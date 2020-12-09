using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = @"../../../input.txt";
            
            var ruleDictionary = File.ReadAllLines(fileName)
                .Select(str => str.Substring(0, str.Length - 1)
                    .Replace(" bags", "")
                    .Replace(" bag", ""))
                .ToDictionary(str => str.Split(" contain ")[0], str => str.Split(" contain ")[1]);

            Console.WriteLine(PartOne(ruleDictionary));
            Console.WriteLine(PartTwo(ruleDictionary));
        }

        private static int PartOne(Dictionary<string,string> rules)
        {
            var bagCount = 0;
            foreach (var key in rules.Keys)
            {
                if (HasShinyGold(key, rules))
                    bagCount++;
            }
            return bagCount;
        }

        private static bool HasShinyGold(string input, IReadOnlyDictionary<string, string> rules)
        {
            if (rules[input].Contains("shiny gold"))
                return true;
            else
            {
                foreach (var value in rules[input].Split(", "))
                {
                    if (value.Equals("no other")) continue;
                    if (!HasShinyGold(value.Substring(2), rules)) continue; 
                    
                    return true;
                }
            }
            return false;
        }

        private static int PartTwo(IReadOnlyDictionary<string, string> rules, string bagColor = "shiny gold")
        {
            var totalBags = 0;
            foreach (var s in rules[bagColor].Split(", "))
            {
                if (!s.Equals("no other"))
                {
                    var num = Convert.ToInt32(s.Substring(0, 1));
                    totalBags += num + num * PartTwo(rules, s.Substring(2));
                }
                else
                    break;
            }
            return totalBags;
        }
    }
}