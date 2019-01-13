using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int homes = int.Parse(Console.ReadLine());
            int initialPresents = int.Parse(Console.ReadLine());
            int present = initialPresents;
            int totalSocks = 0;
            int timesBack = 0;
            int additionalPresents = 0;
            int totalAdditionalPresentsTaken = 0;

            for (int i = 1; i <= homes; i++)
            {
                int socks = int.Parse(Console.ReadLine());
                totalSocks += socks;
                if (socks > initialPresents)
                {
                    //go back for pressent
                    timesBack++;
                    additionalPresents = socks - initialPresents;
                    initialPresents = socks - additionalPresents;
                    //additionalPresents = socks - initialPresents;
                    //  ({ initialPresents} / { visitedHomes}) * { remainingHomes} + { additionalPresents}
                    //20/2=10*2=20+2=22
                    totalAdditionalPresentsTaken = (present / i) * (homes - i) + additionalPresents;
                    initialPresents += totalAdditionalPresentsTaken;
                }
                else
                {
                    initialPresents -= socks;
                }


            }


            if (timesBack > 0)
            {
                Console.WriteLine($"{timesBack}");
                Console.WriteLine($"{totalAdditionalPresentsTaken}");
            }
            else
            {
                int remainingPresents = present - totalSocks;
                Console.WriteLine($"{remainingPresents}");
            }




        }
    }
}
