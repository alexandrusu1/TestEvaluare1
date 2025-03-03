using System;
using System.Collections.Generic;

namespace TestEvaluare
{
    class Program
    {
        static void Main(string[] args)
        {
            Chestionar chestionar = new Chestionar();

            chestionar.AdaugaIntrebare(new Intrebare(
                "Care este capitala Franței?",
                new List<string> { "Berlin", "Madrid", "Paris", "Roma" },
                3));

            chestionar.AdaugaIntrebare(new Intrebare(
                "Cat face 2 + 2?",
                new List<string> { "3", "4", "5", "6" },
                2));

            Console.WriteLine("Bine ai venit la testul de evaluare!");
            Console.WriteLine("Apasa ENTER pentru a incepe...");
            Console.ReadLine();

            chestionar.Porneste();
            Console.WriteLine("Test terminat!");
        }
    }
}
