using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedules = Console.ReadLine().Split(',').ToList();
            for (int i = 0; i < schedules.Count; i++)
            {
                schedules[i] = schedules[i].Trim();
                //Console.WriteLine(schedules[i]);

            }
            string input;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] commandParts = input.Split(':');
                string command = commandParts[0];
                string lessonTitle = commandParts[1];
                string exercise = lessonTitle + "-Exercise";

                switch (command)
                {
                    case "Add":
                        if (!schedules.Contains(lessonTitle))
                        {
                            schedules.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(commandParts[2].Trim());
                        if ((!schedules.Contains(lessonTitle)) && (index >= 0 && index < schedules.Count - 1))
                        {
                            schedules.Insert(index, lessonTitle);
                        }
                        break;
                    case "Remove":
                        if (schedules.Contains(lessonTitle))
                        {
                            if (schedules.Contains(exercise))
                            {
                                schedules.Remove(exercise);
                            }
                            schedules.Remove(lessonTitle);

                        }

                        break;
                    case "Swap":
                        string lessonTitle1 = commandParts[2].Trim();
                        string exercise1 = lessonTitle1 + "-Exercise";
                        if (schedules.Contains(lessonTitle) && schedules.Contains(lessonTitle1))
                        {
                            int indexLesson = schedules.IndexOf(lessonTitle);
                            int indexLesson1 = schedules.IndexOf(lessonTitle1);

                            schedules[indexLesson] = lessonTitle1;
                            schedules[indexLesson1] = lessonTitle;
                            if (schedules.Contains(exercise))
                            {
                                int indexExercise = schedules.IndexOf(exercise);
                                schedules.RemoveAt(indexExercise);
                                if (indexLesson1 < schedules.Count - 1)
                                {
                                    schedules.Insert(indexLesson1 + 1, exercise);

                                }
                                else
                                {
                                    schedules.Add(exercise);
                                }

                            }

                            if (schedules.Contains(exercise1))
                            {
                                int indexExercise1 = schedules.IndexOf(exercise1);
                                schedules.RemoveAt(indexExercise1);
                                if (indexLesson < schedules.Count - 1)
                                {
                                    schedules.Insert(indexLesson + 1, exercise1);

                                }
                                else
                                {
                                    schedules.Add(exercise1);
                                }


                            }

                        }


                        break;
                    case "Exercise":

                        if (schedules.Contains(lessonTitle))
                        {
                            if (!schedules.Contains(exercise))
                            {
                                int indexLesson = schedules.IndexOf(lessonTitle);
                                schedules.Insert(indexLesson + 1, exercise);


                            }
                        }
                        else
                        {
                            schedules.Add(lessonTitle);
                            schedules.Add(exercise);
                        }
                        break;
                    default:
                        break;
                }




            }

            for (int i = 0; i < schedules.Count; i++)
            {
                Console.WriteLine(i + 1 + "." + schedules[i]);

            }


        }
    }
}

