using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> guestAndMeals = new Dictionary<string, List<string>>();
            int unlikedMeals = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                string[] cmdCollection = input.Split("-");
                string cmd = cmdCollection[0];
                string guest = cmdCollection[1];
                string meal = cmdCollection[2];
                
                if (cmd == "Like")
                {
                    if (!guestAndMeals.ContainsKey(guest))
                    {
                        guestAndMeals.Add(guest, new List<string>());
                        guestAndMeals[guest].Add(meal);
                    }
                    else
                    {
                        if (!guestAndMeals[guest].Contains(meal))
                        {
                            guestAndMeals[guest].Add(meal);
                        }
                    }
                }
                else if (cmd == "Unlike")
                {
                    if (guestAndMeals.ContainsKey(guest))
                    {
                        if (guestAndMeals[guest].Contains(meal))
                        {
                            guestAndMeals[guest].Remove(meal);
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            unlikedMeals++;
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                }
            }
            foreach (var guest in guestAndMeals.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");
            }
            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }
}
