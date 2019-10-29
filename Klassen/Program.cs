using System;
using System.Collections.Generic;
using System.Linq;

namespace Klassen
{
    class Program
    {   static List<string> klassen = new List<string>();
        static Random random = new Random();
    
        static void Main(string[] args)
        {
            AddData();
            PresentData();
            Attendees();
            PresentRandomGroups(klassen.ChunkBy(klassen.Count / NumberOfGroups(klassen)));
            PresentGroupToDoPresentation(ChoseGroupForPresentation(NumberOfGroups(Randomize(klassen))));
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
        static void PresentData()
        {
            Console.WriteLine("Klass 9A - 2003\n");
            for (int i = 0; i < klassen.Count; i++)
            {
                Console.WriteLine($"{i+1}. {klassen[i]}");
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
                klassen.RemoveAt(pupilNotHere -1);
                Console.Clear();
                PresentData();
            }
       }
        static void PresentRandomGroups(List<List<string>> sortedKlass)
        {
            int x = 1;
            Console.WriteLine("\nDagens gruppindelning:\n");
            foreach (var item in sortedKlass)
            {
                Console.WriteLine($"Grupp {x}");
                foreach (var person in item)
                {
                    Console.WriteLine(person);
                }
                Console.WriteLine();
                x++;
            }
        }
      
        static List<string> Randomize(List<string> list)
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
            return random.Next(1, nrOfGroups+1);
        }
        static void PresentGroupToDoPresentation(int groupToDoPresentation)
        {
            Console.WriteLine("Vilka får äran att presentera idag? - Tryck Enter");
            Console.ReadLine();
            Console.WriteLine($"Grupp nr {groupToDoPresentation}! Tjoho!");
            Console.ReadLine();
        }

        ////static void ShowGroups(List<string> klassen)
        //{
        //    if (klassen.Count % 3 == 0 || klassen.Count % 3 == 2)
        //    {
        //        for (int i = 0; i < klassen.Count; i++)
        //        {
        //            if (i % 3 == 0)
        //            {
        //                Console.WriteLine($"\nGrupp {x}");
        //                x++;
        //            }
        //            Console.WriteLine(klassen[i]);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < klassen.Count; i++)
        //        {
        //            int x = 1;
        //            if (i % 2 == 0)
        //            {
        //                Console.WriteLine($"\nGrupp{x}");
        //                x++;
        //            }
        //            Console.WriteLine(klassen[i]);
        //        }
        //    }
        //}
    }
    public static class ListExtensions
    {
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
