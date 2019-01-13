using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int employee1Students = int.Parse(Console.ReadLine());
            int employee2Students = int.Parse(Console.ReadLine());
            int employee3Students = int.Parse(Console.ReadLine());
            int totalStudends = int.Parse(Console.ReadLine());

            int studentPerHour = employee1Students + employee2Students + employee3Students;
            // int workingHours = totalStudends / studentPerHour;
            //  int remainHours = totalStudends % studentPerHour;
            //  if (remainHours > 0)
            //  {
            //      workingHours++;
            //  }


            // int breakTimes = workingHours / 3;
            int workingHours = 0;

            while (totalStudends > 0)
            {
                workingHours++;
                if (workingHours % 4 == 0)
                {
                    continue;
                }
                else
                {
                    totalStudends -= studentPerHour;

                }
            }

            // int time = workingHours + breakTimes;

            Console.WriteLine($"Time needed: {workingHours}h.");

        }
    }
}
