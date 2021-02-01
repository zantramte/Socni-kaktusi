using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sočni_kaktusi
{
    public class Kaktusi
    {
        public static string Izbrani_kaktus { get; set; }

        public static string Iskani_kaktus { get; set; }

        public static int Status_Puscave = 0;

        public static Random Kaktus = new Random();

        public static int Poskusi = 3;

        public static List<string> Puscavski_emoji = new List<string>()
        {
            "A", "B", "C", "D", "E"
        };

        public static List<string> Puscavski_emoji_kopija = new List<string>()
        {
            "A", "B", "C", "D", "E"
        };

        public static void Polni_Puscavske_Crke()
        {
            Puscavski_emoji.Clear();

            for (int indeks = 0; indeks < Puscavski_emoji_kopija.Count; indeks++)
            {
                Puscavski_emoji.Add(Puscavski_emoji_kopija[indeks]);
            }
        }

        public static void Izbrani_kaktusek()
        {
            int sedaj = Kaktus.Next(Puscavski_emoji.Count);
            Iskani_kaktus = Puscavski_emoji[sedaj];
        }

        public static bool Preveri_kaktus()
        {
            if (Izbrani_kaktus == Iskani_kaktus)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
