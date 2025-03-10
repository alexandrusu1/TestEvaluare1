using System;
using System.Collections.Generic;
using System.Linq;

namespace TestEvaluare
{
    public class Chestionar
    {
        public List<Intrebare> Intrebari { get; private set; } = new List<Intrebare>();
        public int Scor { get; private set; }

        public void AdaugaIntrebare(Intrebare intrebare)
        {
            Intrebari.Add(intrebare);
        }

        public void Porneste()
        {
            Scor = 0;
            foreach (var intrebare in Intrebari)
            {
                intrebare.Afiseaza();
                Console.Write("Alege raspunsul (1-4): ");
                int raspunsUtilizator;

                while (!int.TryParse(Console.ReadLine(), out raspunsUtilizator) || raspunsUtilizator < 1 || raspunsUtilizator > 4)
                {
                    Console.Write("Raspuns invalid! Introdu un numar intre 1 si 4: ");
                }

                if (intrebare.VerificaRaspuns(raspunsUtilizator))
                {
                    Console.WriteLine("Corect!\n");
                    Scor++;
                }
                else
                {
                    Console.WriteLine($"Gresit! Raspunsul corect era {intrebare.RaspunsCorect}.\n");
                }
            }

            Console.WriteLine($"Scor final: {Scor}/{Intrebari.Count}");
        }

        public void AfiseazaToateIntrebarile()
        {
            Console.WriteLine("\nLista intrebarilor:");
            foreach (var intrebare in Intrebari)
            {
                intrebare.Afiseaza();
                Console.WriteLine();
            }
        }

        public void CautaIntrebare(string text)
        {
            var rezultate = Intrebari.Where(i => i.Text.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();


            if (rezultate.Any())
            {
                Console.WriteLine("\nIntrebari gasite:");
                foreach (var intrebare in rezultate)
                {
                    intrebare.Afiseaza();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("\nNicio intrebare gasita!");
            }
        }
    }
}
