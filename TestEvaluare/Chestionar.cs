using System;
using System.Collections.Generic;

namespace TestEvaluare
{
    public class Chestionar
    {
        private List<Intrebare> intrebari;
        private int scor;

        public Chestionar()
        {
            intrebari = new List<Intrebare>();
            scor = 0;
        }

        public void AdaugaIntrebare(Intrebare intrebare)
        {
            intrebari.Add(intrebare);
        }

        public void Porneste()
        {
            foreach (var intrebare in intrebari)
            {
                intrebare.Afiseaza();
                Console.Write("Alege raspunsul (1-4): ");
                int raspunsUtilizator = Convert.ToInt32(Console.ReadLine());

                if (intrebare.VerificaRaspuns(raspunsUtilizator))
                {
                    Console.WriteLine("Corect!\n");
                    scor++;
                }
                else
                {
                    Console.WriteLine("Gresit! Raspunsul corect era " + intrebare.RaspunsCorect + ".\n");
                }
            }

            Console.WriteLine("Scor final: " + scor + "/" + intrebari.Count);
        }
    }
}
