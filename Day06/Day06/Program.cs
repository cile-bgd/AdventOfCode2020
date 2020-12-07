using System;
using System.Collections.Generic;
using System.IO;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = @"../../../input.txt";
            var partOneAnswer = 0;
            
            var input = File.ReadAllText(fileName);
            var inputs = input.Split("\n\n");
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = inputs[i].Replace("\n", string.Empty);
                var answers = inputs[i].ToCharArray();
                var set = new HashSet<char>(answers);
                partOneAnswer += set.Count;
            }
            
            Console.WriteLine($"Sum of group counts where anyone answered yes: {partOneAnswer}");

            var partTwoAnswer = 0;
            var inputList = File.ReadLines(fileName);
            var groups = new List<List<string>>
            {
                new List<string>()
            };
            
            foreach (var data in inputList)
            {
                if (data == "")
                {
                    groups.Add(new List<string>());
                }
                else
                {
                    groups[^1].Add(data);
                }
            }

            foreach (var group in groups)
            {
                if (group.Count == 1)
                {
                    partTwoAnswer += group[0].Length;
                }
                else
                {
                    foreach (var character in group[0])
                    {
                        var index = 1;
                        while (index < group.Count)
                        {
                            if (!group[index].Contains(character))
                            {
                                break;
                            }

                            if (++index == group.Count)
                            {
                                partTwoAnswer++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum of group counts where everyone answered yes: {partTwoAnswer}");
        }
    }
}