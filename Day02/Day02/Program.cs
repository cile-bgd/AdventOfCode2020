using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutionOne = new SolutionOne();
            //foreach (var solutionOnePasswordRule in solutionOne.PasswordRules)
            //{
            //    Console.WriteLine($"{solutionOnePasswordRule}");
            //}

            var validPasswordCount = solutionOne.PasswordRules.Count(x => x.IsValid());
            Console.WriteLine($"Valid passwords count (Solution 1): {validPasswordCount}");

            var solutionTwo = new SolutionTwo();
            //foreach (var solutionTwoPasswordRule in solutionTwo.PasswordRulesTwo)
            //{
            //    Console.WriteLine($"{solutionTwoPasswordRule}");
            //}

            validPasswordCount = solutionTwo.PasswordRulesTwo.Count(x => x.IsValid());
            Console.WriteLine($"Valid passwords count (Solution 2): {validPasswordCount}");
        }
    }

    public class PasswordRule
    {
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public char Character { get; set; }
        public string Password { get; set; }
        public int NumberOfOccurances { get; set; }

        public bool IsValid()
        {
            return NumberOfOccurances >= MinCount && NumberOfOccurances <= MaxCount;
        }
        public override string ToString()
        {
            return $"Min Count: {MinCount}\r\nMax Count: {MaxCount}\r\nCharacter: {Character}\r\nPassword: {Password}\r\nNumber of occurances: {NumberOfOccurances}\r\nIsValid: {IsValid()}";
        }
    }

    public class SolutionOne
    {
        public static string FileName = @"C:\GitHub\AdventOfCode2020\Day02\Day02\newInput.txt";
        public List<PasswordRule> PasswordRules { get; set; } = new List<PasswordRule>();

        public SolutionOne()
        {
            var inputList = File.ReadAllLines(FileName).ToList();

            foreach (var inputValue in inputList)
            {
                var splittedInput = inputValue.Split(" ");

                var minCount = Helper.GetMinCount(splittedInput[0]);
                var maxCount = Helper.GetMaxCount(splittedInput[0]);

                var character = Helper.GetMinCount(splittedInput[1], 0, ":");
                var pass = splittedInput[2];

                var passRule = new PasswordRule
                {
                    MinCount = int.Parse(minCount),
                    MaxCount = int.Parse(maxCount),
                    Character = char.Parse(character),
                    Password = pass,
                    NumberOfOccurances = pass.Count(x => x == char.Parse(character))
                };

                PasswordRules.Add(passRule);
            }
        }
    }

    public class PasswordRuleTwo
    {
        public int CharacterPositionOne { get; set; }
        public int CharacterPositionTwo { get; set; }
        public char Character { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            var pass = Password.ToCharArray();
            return pass[CharacterPositionOne] != pass[CharacterPositionTwo] && 
                (pass[CharacterPositionOne] == Character ||
                pass[CharacterPositionTwo] == Character);
        }
        public override string ToString()
        {
            return $"Position 1: {CharacterPositionOne}\r\nPosition 2: {CharacterPositionTwo}\r\nCharacter: {Character}\r\nPassword: {Password}\r\nIsValid: {IsValid()}";
        }
    }

    public class SolutionTwo
    {
        public static string FileName = @"C:\GitHub\AdventOfCode2020\Day02\Day02\newInput.txt";
        public List<PasswordRuleTwo> PasswordRulesTwo { get; set; } = new List<PasswordRuleTwo>();

        public SolutionTwo()
        {
            var inputList = File.ReadAllLines(FileName).ToList();

            foreach (var inputValue in inputList)
            {
                var splittedInput = inputValue.Split(" ");

                var positionOne = Helper.GetMinCount(splittedInput[0]);
                var positionTwo = Helper.GetMaxCount(splittedInput[0]);

                var character = Helper.GetMinCount(splittedInput[1], 0, ":");
                var pass = splittedInput[2];

                var passRule = new PasswordRuleTwo()
                {
                    CharacterPositionOne = int.Parse(positionOne) - 1,
                    CharacterPositionTwo = int.Parse(positionTwo) - 1,
                    Character = char.Parse(character),
                    Password = pass
                };

                PasswordRulesTwo.Add(passRule);
            }
        }
    }

    static class Helper
    {
        public static string GetMinCount(this string text, int startAt = 0, string stopAt = "-")
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

            return charLocation > 0 ? text.Substring(startAt, charLocation) : string.Empty;
        }

        public static string GetMaxCount(this string text, string startAt = "-")
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            int startChar = text.IndexOf(startAt, StringComparison.Ordinal);

            return startChar > 0 ? text.Substring(startChar + 1) : string.Empty;
        }
    }
}
