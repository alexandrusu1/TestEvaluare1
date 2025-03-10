using System;
using System.Collections.Generic;

namespace TestEvaluare
{
    class Program
    {
        static void Main(string[] args)
        {
            Chestionar chestionar = new Chestionar();

            Console.WriteLine("Cate intrebari vrei sa adaugi?");
            int nrIntrebari;
            while (!int.TryParse(Console.ReadLine(), out nrIntrebari) || nrIntrebari <= 0)
            {
                Console.Write("Introdu un numar valid: ");
            }

            for (int i = 0; i < nrIntrebari; i++)
            {
                Console.WriteLine($"\nIntrodu detaliile pentru intrebarea {i + 1}:");
                Console.Write("Textul intrebarii: ");
                string text = Console.ReadLine();

                List<string> optiuni = new List<string>();
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"Varianta {j + 1}: ");
                    optiuni.Add(Console.ReadLine());
                }

                Console.Write("Numarul raspunsului corect (1-4): ");
                int raspunsCorect;
                while (!int.TryParse(Console.ReadLine(), out raspunsCorect) || raspunsCorect < 1 || raspunsCorect > 4)
                {
                    Console.Write("Introdu un numar valid (1-4): ");
                }

                chestionar.AdaugaIntrebare(new Intrebare(text, optiuni, raspunsCorect));
            }

            Console.WriteLine("\nApasa ENTER pentru a incepe testul...");
            Console.ReadLine();

            chestionar.Porneste();

            Console.WriteLine("\nTest terminat!");

            
            chestionar.AfiseazaToateIntrebarile();

            
            Console.Write("\nIntrodu textul unei intrebari pentru a cauta: ");
            string cautare = Console.ReadLine();
            chestionar.CautaIntrebare(cautare);
        }
    }
}
