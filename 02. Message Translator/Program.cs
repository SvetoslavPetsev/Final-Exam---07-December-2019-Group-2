using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main()
        {
            int numberInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberInput; i++)
            {
                string text = Console.ReadLine();
                Regex pattern = new Regex(@"^\!(?<cmd>[A-Z][a-z]{2,})\!\:\[(?<massage>[A-Za-z]{8,})\]$");
                Match matchText = pattern.Match(text);

                if (!matchText.Success)
                {
                    Console.WriteLine("The message is invalid");
                    continue;
                }
                else
                {
                    string command = matchText.Groups["cmd"].Value;
                    string massage = matchText.Groups["massage"].Value;
                    List<string> massageNum = new List<string>();
                    foreach (char symbol in massage)
                    {
                        int asciiNum = symbol;
                        string asciiStr = asciiNum.ToString();
                        massageNum.Add(asciiStr);
                    }
                    Console.WriteLine($"{command}: {string.Join(" ", massageNum)}");
                }
            }
        }
    }
}
