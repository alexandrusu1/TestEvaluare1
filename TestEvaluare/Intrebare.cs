using System;
using System.Collections.Generic;

class Intrebare
{
    public string Text { get; private set; }
    public List<string> Optiuni { get; private set; }
    public int RaspunsCorect { get; private set; }

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
            Console.WriteLine((i + 1) + ". " + Optiuni[i]);
        }
        Console.Write("\nRăspuns: ");
    }

    public bool VerificaRaspuns(int raspuns)
    {
        return raspuns == RaspunsCorect;
    }
}
