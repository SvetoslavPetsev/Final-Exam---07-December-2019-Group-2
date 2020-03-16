using System;
using System.Text;
using System.Linq;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Finish")
                {
                    break;
                }
                string[] info = input.Split();
                string cmd = info[0];
                if (cmd == "Replace")
                {
                    char currChar = char.Parse(info[1]);
                    char newChar = char.Parse(info[2]);
                    if (text.Contains(currChar))
                    {
                        text = text.Replace(currChar, newChar);
                        Console.WriteLine(text);
                    }
                }
                else if (cmd == "Cut" && text.Length > 1)
                {
                    int startIndex = int.Parse(info[1]);
                    int endIndex = int.Parse(info[2]);

                    if (startIndex >= 0 && startIndex < text.Length && endIndex >= 0 && endIndex < text.Length)
                    {
                        int minIndex = Math.Min(startIndex, endIndex);
                        int maxIndex = Math.Max(startIndex, endIndex);
                        text = text.Remove(minIndex, maxIndex - minIndex + 1);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (cmd == "Make")
                {
                    string type = info[1];
                    if (type == "Upper")
                    {
                        text = text.ToUpper();
                    }
                    else if (type == "Lower")
                    {
                        text = text.ToLower();
                    }
                    Console.WriteLine(text);
                }
                else if (cmd == "Check")
                {
                    string subs = info[1];
                    if (text.Contains(subs))
                    {
                        Console.WriteLine($"Message contains {subs}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {subs}");
                    }
                }
                else if (cmd == "Sum")
                {
                    int startIndex = int.Parse(info[1]);
                    int endIndex = int.Parse(info[2]);

                    if (startIndex >= 0 && startIndex < text.Length && endIndex >= 0 && endIndex < text.Length)
                    {
                        int minIndex = Math.Min(startIndex, endIndex);
                        int maxIndex = Math.Max(startIndex, endIndex);

                        string substr = text.Substring(minIndex, maxIndex - minIndex + 1);
                        int sumAscii = 0;
                        foreach (var symbol in substr)
                        {
                            sumAscii += symbol;
                        }
                        Console.WriteLine(sumAscii);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
            }
        }
    }
}
