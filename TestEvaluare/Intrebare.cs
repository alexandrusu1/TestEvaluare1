using System;
using System.Collections.Generic;

namespace TestEvaluare
{
    public class Intrebare
    {
        public string Text { get; set; }
        public List<string> Optiuni { get; set; }
        public int RaspunsCorect { get; set; }

        public Intrebare(string text, List<string> optiuni, int raspunsCorect)
        {
            Text = text;
            Optiuni = optiuni;
            RaspunsCorect = raspunsCorect;
        }

        public void Afiseaza()
        {
            Console.WriteLine(Text);
            for (int i = 0; i < Optiuni.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Optiuni[i]}");
            }
        }

        public bool VerificaRaspuns(int raspunsUtilizator)
        {
            return raspunsUtilizator == RaspunsCorect;
        }
    }
}
