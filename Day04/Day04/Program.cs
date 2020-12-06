using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var passports = new List<Passport>();
            
            const string fileName = @"../../../input.txt";
            var input = File.ReadAllText(fileName);
            var inputs = input.Split("\n\n");
            for (var i = 0; i < inputs.Length; i++)
            {
                inputs[i] = inputs[i].Replace('\n', ' ');
                var tempSplit = inputs[i].Split(" ");
                var temp = new Dictionary<string, string>();
                var passport = new Passport();
                foreach (var ts in tempSplit)
                {
                    var tempPair = new KeyValuePair<string,string>(Helper.GetKey(ts), Helper.GetValue(ts));
                    switch (tempPair.Key)
                    {
                        case "ecl":
                            passport.EyeColor = tempPair.Value;
                            break;
                        case "pid":
                            passport.PassportId = tempPair.Value;
                            break;
                        case "eyr":
                            passport.ExpirationYear = tempPair.Value;
                            break;
                        case "hcl":
                            passport.HairColor = tempPair.Value;
                            break;
                        case "byr":
                            passport.BirthYear = tempPair.Value;
                            break;
                        case "iyr":
                            passport.IssueYear = tempPair.Value;
                            break;
                        case "cid":
                            passport.CountryId = tempPair.Value;
                            break;
                        case "hgt":
                            passport.Height = tempPair.Value;
                            break;
                    }
                }
                passports.Add(passport);
            }

            var validPassportsPartOne = passports.Count(x => x.IsValid());
            var validPassportsPartTwo = passports.Count(x => x.IsPartTwoValid());

            Console.WriteLine($"Part 1 - Number of valid passports: {validPassportsPartOne}");
            Console.WriteLine($"Part 2 - Number of valid passports: {validPassportsPartTwo}");
        }
    }

    static class Helper
    {
        public static string GetKey(string pair, int startAt = 0, string stopAt = ":")
        {
            if (string.IsNullOrWhiteSpace(pair)) return string.Empty;
            
            var charLocation = pair.IndexOf(stopAt, StringComparison.Ordinal);
            return charLocation > 0 ? pair.Substring(startAt, charLocation) : string.Empty;
        }
        
        public static string GetValue(string pair, string startAt = ":")
        {
            if (string.IsNullOrWhiteSpace(pair)) return string.Empty;
            
            var startChar = pair.IndexOf(startAt, StringComparison.Ordinal);
            return startChar > 0 ? pair.Substring(startChar + 1) : string.Empty;
        }
    }
}