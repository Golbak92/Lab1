using System;
using System.Diagnostics.Tracing;
using System.IO;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write an input: ");
            string userInput = Console.ReadLine();
            string sum = "";  // sparar de grön-markerade talen i den tomma strängen.
            long totalSum = 0;

            for (int start = 0; start < userInput.Length; start++) //Loopen börjar på position 0, och kollar strängens längd.
            {
                if (Char.IsDigit(userInput[start])) // Om första positionen är en siffra så går den vidare till nästa for loop, annars fortsätter den och titta på position 1.
                {
                    for (int nextLetter = start + 1; nextLetter < userInput.Length; nextLetter++) //Om första positionen var en siffra så går den till position 1 och tittar om det är en siffra.
                    {
                        if (userInput[start] == userInput[nextLetter]) //Om position näst kommande position är samma som förgående så går den till nästa loop, annars fortsätter den i förra loopen tills den hittar samma.
                        {
                            for (int end = 0; end < userInput.Length; end++)
                            {
                                if (end >= start && end <= nextLetter)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(userInput[end]);
                                    sum += userInput[end];
                                } 
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write(userInput[end]);
                                    long.TryParse(sum, out long addSum);
                                    totalSum += addSum;
                                    sum = "";    // När de sista positionerna av strängen har skrivits ut i grått, så "resettar" jag sum inför nästa loop, så de grön-markerade talen kan sparas på nytt.
                                }
                            }
                            Console.WriteLine("");
                            break; //Behöver ha break här, annars så fortsätter loopen att leta till den hittat alla lika siffror, exempel: "454643754k22335", Då skriver den ut allt från första 4 till sista 4 i grön färg. 
                                   // men vi vill bara ha till den första 4:an
                        }
                        else if (Char.IsLetter(userInput[nextLetter]))
                        {
                            break;
                        }
                    }
                }
                else
                {
                    continue;  //om första positionen visar sig vara bokstav så fortsätter den i loopen igen och kollar position 1.
                }
            }
            long.TryParse(sum, out long addLast);
            totalSum = totalSum + addLast;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nTotalsumman: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(totalSum);
        }
    }
}