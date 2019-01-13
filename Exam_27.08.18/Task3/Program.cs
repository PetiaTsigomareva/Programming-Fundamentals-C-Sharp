using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder words = new StringBuilder();

            Dictionary<int, int> lettersCodelength = new Dictionary<int, int>();
            string lettersCount = "";
            string[] inputParts = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            //first part $AOTP$ 
            string firstPattern = @"([#$%*&])(?<letters>[A-Z]+)\1";
            Match matche = Regex.Match(inputParts[0], firstPattern);
            if (matche.Success)
            {

                lettersCount = matche.Groups["letters"].Value;


            }
            Console.WriteLine(lettersCount);


            //second part {asciiCode}:{length}"

            // string secondPattern = @"(?<code>[65-90]+):(?<length>\d{2})";
            string secondPattern = @"([.]*?)(?<code>(([6][5-9])|([7-8][0-9])|(90))):(?<length>\d{2})\1";
            MatchCollection matches1 = Regex.Matches(inputParts[1], secondPattern);
            foreach (Match m1 in matches1)
            {
                if (m1.Success)
                {
                    int code = int.Parse(m1.Groups["code"].Value);
                    int length = int.Parse(m1.Groups["length"].Value);


                    //  Regex thirthPattern = new Regex($@"([ ])(?<words>{(char)code}[a-z]{length})\1");

                    //  if (thirthPattern.IsMatch(inputParts[2]))
                    //  {
                    //Match match = thirthPattern.Match(inputParts[2]);

                    //   Console.WriteLine(code + ":" + length);

                    //  Console.WriteLine(match.Groups["words"].Value);

                    //  }

                    for (int i = 0; i < lettersCount.Length; i++)
                    {
                        if (lettersCount[i] == code)
                        {
                            if (!lettersCodelength.ContainsKey(code))
                            {
                                lettersCodelength.Add(code, 0);

                            }
                            lettersCodelength[code] = length;

                        }


                    }






                }

            }
            foreach (var item in lettersCodelength)
            {
                Console.WriteLine(item.Key + ":" + item.Value);
            }

            foreach (var l in lettersCodelength)
            {

                Console.WriteLine(l.Key + ":" + l.Value + "<->" + (char)l.Key + ":" + l.Value);
                // string thirthPattern = $@"([ ])(?<words>{(char)l.Key}[a-z]{l.Value})\1";
                // string thirthPattern = $@"{(char)l.Key} + [^ ]+{ l.Value}";

                Regex thirthPattern = new Regex($@"([ ])(?<words>{(char)l.Key}[a-z]{l.Value})\1");

                if (thirthPattern.IsMatch(inputParts[2]))
                {
                    Match match = thirthPattern.Match(inputParts[2]);

                    Console.WriteLine(l.Key + ":" + l.Value);

                    Console.WriteLine(match.Groups["words"].Value);

                }







            }
        }
    }
}
