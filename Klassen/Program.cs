using System;
using System.Collections.Generic;
using System.Linq;

namespace Klassen
{
    class Program
    {
        static List<string> klassen = new List<string>();
        static Random random = new Random();
        static Dictionary<int, List<string>> attendeesSortedIntoGroups = new Dictionary<int, List<string>>();

        static void Main(string[] args)
        {
            AddData();
            PresentOriginalData();
            Attendees();
            PresentRandomGroups(GroupClass(klassen, NumberOfGroups(klassen)));
            PresentGroupToDoPresentation(ChoseGroupForPresentation(NumberOfGroups(RandomizeAttendees(klassen))));
        }

        static void AddData()
        {
            klassen.Add("Alexander Sonerud");
            klassen.Add("Adrian Göransson");
            klassen.Add("Bengt Åkesson");
            klassen.Add("Jenny Karlsson");
            klassen.Add("Pia Noren");
            klassen.Add("Ida Wahlström");
            klassen.Add("Johan Olense");
            klassen.Add("Per Persson");
            klassen.Add("Putte Puttsson");
            klassen.Add("Tomas Brolin");
            klassen.Add("Dr Alban");
            klassen.Add("Lena Filen");
        }
        static void PresentOriginalData()
        {
            Console.WriteLine("Klass 9A - 2003\n");
            for (int i = 0; i < klassen.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {klassen[i]}");
            }
        }
        static void Attendees()
        {
            Console.WriteLine("\nAnge antal ej närvarande elever: ");
            int numberOfNotAttendingPupils = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfNotAttendingPupils; i++)
            {
                Console.WriteLine("\nAnge nr på ej närvarande elev:");
                int pupilNotHere = int.Parse(Console.ReadLine());
                klassen.RemoveAt(pupilNotHere - 1);
                Console.Clear();
                PresentOriginalData();
            }
        }
        static void PresentRandomGroups(Dictionary<int, List<string>> sortedKlass)
        {
            int x = 1;
            Console.WriteLine("\nDagens gruppindelning:\n");
            foreach (var item in sortedKlass)
            {
                Console.WriteLine($"\nGrupp: {x}");
                foreach (var person in item.Value)
                {
                    Console.WriteLine(person);
                }
                x++;
            }
        }
        static List<string> RandomizeAttendees(List<string> list)
        {
            var models = list.OrderBy(c => random.Next()).Select(c => c).ToList();
            return models;
        }
        static int NumberOfGroups(List<string> list)
        {
            int nr = list.Count;
            int delat;
            if (nr % 3 == 0)
            {
                delat = nr / 3;
                return delat;
            }
            else if (nr % 3 == 2)
            {
                delat = nr / 3;
                return delat;
            }
            else if (nr % 3 == 1)
            {
                delat = nr / 2;
                return delat;
            }
            return 0;
        }
        static int ChoseGroupForPresentation(int nrOfGroups)
        {
            return random.Next(1, nrOfGroups + 1);
        }
        static void PresentGroupToDoPresentation(int groupToDoPresentation)
        {
            Console.WriteLine("\nVilka får äran att presentera idag? - Tryck Enter");
            Console.ReadLine();
            Console.WriteLine($"Grupp nr {groupToDoPresentation}! Tjoho!");
            Console.ReadLine();
        }
        static Dictionary<int, List<string>> GroupClass(List<string> list, int chunk)
        {
            var newRandomList = RandomizeAttendees(list);
            for (int i = 0; i <= list.Count / chunk; i++)
            {
                if (newRandomList.Count >= chunk)
                {
                    attendeesSortedIntoGroups.Add(i, newRandomList.Take(chunk).ToList());

                    for (int x = 0; x < chunk; x++)
                    {
                        newRandomList.RemoveAt(0);
                    }
                }
                else if (newRandomList.Count != 0)
                {
                    attendeesSortedIntoGroups.Add(i, newRandomList.Take(newRandomList.Count).ToList());
                }
            }
            return attendeesSortedIntoGroups;
        }
    }
}
