using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> travellTimes = new Dictionary<string, int>();
            Dictionary<string, int> travellPassenders = new Dictionary<string, int>();
            string input;
            while ((input = Console.ReadLine()) != "Slide rule")
            {
                String[] inputParts = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                //  Console.WriteLine(String.Join('?', inputParts));
                string townName = inputParts[0];
                String[] otherInputParts = inputParts[1].Split("->", StringSplitOptions.RemoveEmptyEntries);
                //  Console.WriteLine(String.Join('?', parts));

                if (input.Contains("ambush"))
                {
                    //{townName}:ambush->{passengersCount}

                    int passengersCount = int.Parse(otherInputParts[1]);
                    if (travellTimes.ContainsKey(townName))
                    {

                        travellTimes[townName] = 0;

                    }

                    if (travellPassenders.ContainsKey(townName))
                    {
                        travellPassenders[townName] -= passengersCount;

                    }



                }
                else
                {
                    //{townName}:{time}->{passengersCount} 
                    int time = int.Parse(otherInputParts[0]);
                    int passengersCount = int.Parse(otherInputParts[1]);

                    if (!travellTimes.ContainsKey(townName))
                    {
                        travellTimes.Add(townName, time);

                    }
                    else
                    {
                        // int currentTime = travelTimes[name];
                        if (travellTimes[townName] > 0)
                        {
                            if (time < travellTimes[townName])
                            {
                                travellTimes[townName] = time;
                            }

                        }
                        else
                        {
                            travellTimes[townName] = time;
                        }



                    }

                    if (!travellPassenders.ContainsKey(townName))
                    {
                        travellPassenders.Add(townName, 0);
                    }
                    travellPassenders[townName] += passengersCount;

                }



            }

            foreach (var town in travellTimes.OrderBy(t => t.Value).ThenBy(t => t.Key))
            {

                if (town.Value > 0 && travellPassenders[town.Key] > 0)
                {

                    Console.WriteLine($"{town.Key} -> Time: {town.Value} -> Passengers: {travellPassenders[town.Key]}");
                }


            }

        }
    }
}
