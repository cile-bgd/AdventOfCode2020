using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutionOne = new TwoSumSolutionOne();
            var solutionTwo = new ThreeSumSolutionTwo();

            Console.WriteLine($"Result 1: {solutionOne.ResultOne}");
            Console.WriteLine($"Result 2: {solutionTwo.ResultTwo}");
        }
    }

    public class TwoSumSolutionOne
    {
        public int ResultOne { get; set; }
        
        public List<int> Data { get; set; }
        
        public static string FileName = @"C:\GitHub\AdventOfCode2020\Day01\01-1\input.txt";
        public static int CorrectSum = 2020;

        public TwoSumSolutionOne()
        {
            var input = File.ReadAllLines(FileName).ToList();
            Data = input
                .Select(x => Convert.ToInt32(x))
                .ToList();

            Data.Sort();
            int lhs = 0, rhs = Data.Count - 1;
            while (lhs < rhs)
            {
                var sum = Data[lhs] + Data[rhs];
                if (sum == CorrectSum)
                {
                    ResultOne = Data[lhs] * Data[rhs];
                }
                if (sum < CorrectSum) lhs++;
                else rhs--;
            }
        }
    }

    public class ThreeSumSolutionTwo
    {
        public int ResultTwo { get; set; }
        public List<int> Data { get; set; }

        public static string FileName = @"C:\GitHub\AdventOfCode2020\Day01\01-1\input.txt";
        public static int CorrectSum = 2020;

        public ThreeSumSolutionTwo()
        {
            var input = File.ReadAllLines(FileName).ToList();
            Data = input
                .Select(x => Convert.ToInt32(x))
                .ToList();

            Data.Sort();

            for (int i = 0; i < Data.Count - 2; i++)
            {
                HashSet<int> set = new HashSet<int>();
                int currentSum = CorrectSum - Data[i];
                for (int j = i + 1; j < Data.Count; j++)
                {
                    if (set.Contains(currentSum - Data[j]))
                    {
                        ResultTwo = Data[i] * Data[j] * (currentSum - Data[j]);
                    }
                    set.Add(Data[j]);
                }
            }
        }
    }
}
