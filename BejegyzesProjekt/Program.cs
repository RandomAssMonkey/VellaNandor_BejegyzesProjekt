using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BejegyzesProjekt
{
    class Program
    {
        static List<Bejegyzes> bejegyzes = new List<Bejegyzes>();
        static void SzamBekeres()
        {
            Console.Write("Hány darab bejegyzést szeretnél írni? ");
            int darabSzam = Convert.ToInt32(Console.ReadLine());
            if (darabSzam >= 0)
            {
                for (int i = 0; i < darabSzam; i++)
                {
                    BejegyzesKeszites();
                }
            }
            else
            {
                Console.WriteLine("Hibás adat!");
                SzamBekeres();
            }

        }

        static void BejegyzesKeszites()
        {
            Console.Write("Ki a szerző? ");
            string szerzo = Console.ReadLine();
            Console.Write("Mi a tartalom? ");
            string tartalom = Console.ReadLine();
            Bejegyzes b3 = new Bejegyzes(szerzo, tartalom);
            bejegyzes.Add(b3);
            Console.WriteLine(b3);
        }

        static void Beolvasas()
        {
            StreamReader r = new StreamReader("bejegyzesek.csv");
            while (!r.EndOfStream)
            {
                string[] adatok = r.ReadLine().Split(';');
                string szerzo = adatok[0];
                string tartalom = adatok[1];
                Bejegyzes b = new Bejegyzes(szerzo, tartalom);
                bejegyzes.Add(b);
                Console.WriteLine(b);
            }
        }

        static void LikeLike()
        {
            Random a = new Random();
            for (int i = 0; i < bejegyzes.Count * 20; i++)
            {
                int b = a.Next(0, bejegyzes.Count);
                bejegyzes[b].Like();
            }
        }

        static void TartalomModositas()
        {
            Console.Write("Add meg a módosíani kivánt tartalmat: ");
            string modosultTartalom = Console.ReadLine();
            bejegyzes[2].Tartalom = modosultTartalom;
            Console.WriteLine(bejegyzes[2]);
        }

        static void ListaTartalma()
        {
            foreach (var item in bejegyzes)
            {
                Console.WriteLine($"{item}");
            }
        }

        static void Legnepszerubb()
        {
            int like = 0;
            foreach (var item in bejegyzes)
            {
                if (item.Likeok > like )
                {
                    like = item.Likeok;
                }
            }
            Console.WriteLine(like);
        }

        static void TobbMint()
        {
            bool dont = false;
            foreach (var item in bejegyzes)
            {
                if (item.Likeok > 35)
                {
                    dont = true;
                }
            }
            if (dont == false)
            {
                Console.WriteLine("Nincs olyan bejegyzés ami több mint 35 like-ot kapott.");
            }
            else
            {
                Console.WriteLine("Van olyan bejegyzés ami több mint 35 like-ot kapott.");
            }
        }

        static void KevesebbMint()
        {
            int szam = 0;
            foreach (var item in bejegyzes)
            {
                if (15 > item.Likeok)
                {
                    szam++;
                }
            }
            Console.WriteLine($"Ennyi bejegyzésnek van 15-nél kevesebb like-ja: {szam}");
        }

        static void RendezesEsKiiratas()
        {
            List<Bejegyzes> rendezettLista = bejegyzes.OrderByDescending(o => o.Likeok).ToList();
            foreach (var item in rendezettLista)
            {
                Console.WriteLine(item);
            }
            StreamWriter sw = new StreamWriter("bejegyzesek_rendezett.txt");
            for (int i = 0; i < rendezettLista.Count; i++)
            {
                sw.WriteLine($"{rendezettLista[i].Szerzo},{rendezettLista[i].Tartalom},{rendezettLista[i].Letrejott},{rendezettLista[i].Szerkesztve},{rendezettLista[i].Likeok}");
            }
            sw.Close();
        }

        static void Main(string[] args)
        {
            Bejegyzes b1 = new Bejegyzes("Móth Tarcell", "Bocsánat :(");
            bejegyzes.Add(b1);
            Console.WriteLine(b1);
            Bejegyzes b2 = new Bejegyzes("Babó Széla", "BOMBA BOMBA");
            bejegyzes.Add(b2);
            Console.WriteLine(b2);
            SzamBekeres();
            Beolvasas();
            LikeLike();
            TartalomModositas();
            ListaTartalma();
            Legnepszerubb();
            TobbMint();
            KevesebbMint();
            RendezesEsKiiratas();


            Console.ReadKey();
        }
    }
}
