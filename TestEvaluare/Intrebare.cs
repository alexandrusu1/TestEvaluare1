using System;
using System.Collections.Generic;

class Intrebare
{
    public string Text { get; private set; }
    public List<string> Optiuni { get; private set; }
    public OptiuniRaspuns RaspunsCorect { get; private set; }

    public Intrebare(string text, List<string> optiuni, OptiuniRaspuns raspunsCorect)
    {
        Text = text;
        Optiuni = optiuni;
        RaspunsCorect = raspunsCorect;
    }

    public void Afiseaza()
    {
        Console.WriteLine(Text);
        Console.WriteLine("A. " + Optiuni[0]);
        Console.WriteLine("B. " + Optiuni[1]);
        Console.WriteLine("C. " + Optiuni[2]);
        Console.WriteLine("D. " + Optiuni[3]);
        Console.Write("\nRăspuns: ");
    }

    public bool VerificaRaspuns(OptiuniRaspuns raspuns)
    {
        return raspuns == RaspunsCorect;
    }
}
