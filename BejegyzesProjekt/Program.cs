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
        public List<Bejegyzes> bejegyzes;

        static void SzamBekeres()
        {
            Console.Write("Hány darab bejegyzést szeretnél írni? ");
            int darabSzam = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < darabSzam; i++)
            {
                BejegyzesKeszites();
            }

        }

        static void BejegyzesKeszites()
        {
            Console.WriteLine("X");
        }

        static void Main(string[] args)
        {
            SzamBekeres();

            Console.ReadKey();
        }
    }
}
