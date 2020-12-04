using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = @"C:\GitHub\AdventOfCode2020\Day03\Day03\input.txt";
            var map = File.ReadAllLines(fileName).ToList();
            var solutionOne = Solve(map);
            
            Console.WriteLine($"Result 1: {solutionOne}");
            
            var solutionTwo = new List<long>
            {
                Solve(map, 1, 1),
                Solve(map, 3, 1),
                Solve(map, 5, 1),
                Solve(map, 7, 1),
                Solve(map, 1, 2)
            };

            Console.WriteLine($"Result 2: {solutionTwo.Aggregate((a, x) => a * x)}");
        }

        private static long Solve(IEnumerable<string> map, int rightSlope = 3, int downSlope = 1)
        {
            return map
                .Where((line, index) => index % downSlope == 0 && line[(rightSlope * (index / downSlope)) % line.Length] == '#')
                .Count();
        }
    }
}