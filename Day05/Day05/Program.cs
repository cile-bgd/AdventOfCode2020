using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardingPasses = new List<BoardingPass>();
            const string fileName = @"../../../input.txt";
            var input = File.ReadAllLines(fileName).ToList();

            foreach (var line in input)
            {
                var bp = new BoardingPass {Input = line};
                
                bp.RowMap();
                bp.ColumnMap();
                bp.AssignSeatId();
                
                boardingPasses.Add(bp);
            }

            // Part 1 answer
            var maxSeatId = boardingPasses.Max(x => x.SeatId);
            Console.WriteLine($"Highest Seat ID on a boarding pass: {maxSeatId}");

            var seats = boardingPasses
                .Where(x => x.Row > 0 && x.Row < 127)
                .Select(s => s.SeatId)
                .OrderBy(s => s)
                .ToList();
            
            // seats.ForEach(x => Console.WriteLine(x.ToString()));
            var id = Consecutive(seats);
            
            // Part 2 answer
            Console.WriteLine($"My Seat ID on a boarding pass: {id}");
        }

        private static int Consecutive(IReadOnlyList<int> input)
        {
            for (var i = 1; i < input.Count - 1; i++)
            {
                if (input[i + 1] == input[i] + 2)
                {
                    return input[i] + 1;
                    break;
                }
            }

            return 0;
        }
    }
}