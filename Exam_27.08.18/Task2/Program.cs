using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> grains = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse).ToList();
            //Console.WriteLine(String.Join(':', sands));

            string input;
            while ((input = Console.ReadLine()) != "Mort")
            {
                string[] inputParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                // Console.WriteLine(String.Join(':', inputParts));
                string command = inputParts[0];
                int value = int.Parse(inputParts[1]);
                switch (command)
                {
                    case "Add":
                        grains.Add(value);
                        break;

                    case "Remove":
                        if (grains.Contains(value))
                        {
                            grains.Remove(value);

                        }
                        else
                        {
                            //Check value is valid index
                            if (value >= 0 && value < grains.Count - 1)
                            {

                                //int index = grains.IndexOf(value);
                                grains.RemoveAt(value);
                            }

                        }
                        break;
                    case "Replace":
                        int replacement = int.Parse(inputParts[2]);
                        if (grains.Contains(value))
                        {
                            int index = grains.IndexOf(value);
                            grains[index] = replacement;

                        }

                        break;

                    case "Increase":
                        int increaseValue = 0;
                        for (int i = 0; i < grains.Count; i++)
                        {
                            if (grains[i] >= value)
                            {
                                increaseValue = grains[i];
                                break;
                            }


                        }

                        if (increaseValue > 0)
                        {
                            for (int i = 0; i < grains.Count; i++)
                            {
                                grains[i] += increaseValue;
                            }

                        }
                        else
                        {


                            for (int i = 0; i < grains.Count; i++)
                            {
                                grains[i] += grains[grains.Count - 1];
                            }

                        }
                        break;

                    case "Collapse":
                        // grains = grains.Where(g => g < value).ToList();
                        grains.RemoveAll(g => g < value);


                        break;

                    default:
                        break;
                }



            }

            Console.WriteLine(String.Join(' ', grains));
        }
    }
}
