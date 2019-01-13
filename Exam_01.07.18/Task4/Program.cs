using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, int> users = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputParts = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string userName = inputParts[0];
                if (input.Contains("banned"))
                {
                    if (users.ContainsKey(userName))
                    {
                        users.Remove(userName);
                    }
                }
                else
                {
                    string language = inputParts[1];
                    int points = int.Parse(inputParts[2]);
                    int countSubmission = 1;
                    if (users.ContainsKey(userName))
                    {
                        int currentPoints = users[userName];
                        if (points > currentPoints)
                        {
                            users[userName] = points;

                        }

                    }
                    else
                    {
                        users.Add(userName, points);
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, countSubmission);

                    }
                    else
                    {
                        submissions[language] += 1;
                    }



                }
            }
            Console.WriteLine("Results:");
            foreach (var userName in users.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                Console.WriteLine($"{userName.Key} | {userName.Value}");

            }

            Console.WriteLine("Submissions:");
            foreach (var submission in submissions.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");

            }
        }

        class User
        {
            public User(string name, string language, int points)
            {
                this.Name = name;
                this.Language = language;
                this.Points = points;
            }
            public string Name { get; set; }
            public string Language { get; set; }
            public int Points { get; set; }
        }
    }
}
