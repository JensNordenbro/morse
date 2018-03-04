using System;
using System.Collections.Generic;
using System.Threading;

namespace morse
{

    enum MorseTone
    {
        Short, 
        Long
    }
    class Program
    {
        const int longInterval = 500, shortInterval = 200, betweenInterval = 500;


        static Dictionary<char, MorseTone[]> m_Lookup = new Dictionary<char, MorseTone[]>()
        {

            { 'a', new [] { MorseTone.Short, MorseTone.Long} },

            { 'b', new [] { MorseTone.Long, MorseTone.Short, MorseTone.Short, MorseTone.Short} },

        };


        static void Main(string[] args)
        {
            while (true) {

                Console.WriteLine("Hej! Skriv in en text: " );
                string line = Console.ReadLine().Trim() ?? string.Empty;

                foreach (char c in line)
                {
                    MorseTone[] tones = m_Lookup[c];
                    foreach (MorseTone tone in tones)
                    {
                        Console.Beep(500, tone == MorseTone.Short ? shortInterval : longInterval);
                    }
                    Thread.Sleep(betweenInterval);

                }
            }
        }
    }
}
