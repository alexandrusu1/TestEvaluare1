using System;
using System.Collections.Generic;
using System.IO;

class Chestionar
{
    private List<Intrebare> Intrebari;
    private int Scor;
    private DateTime StartTime;
    private const int TimpLimita = 600; // 10 minute

    public Chestionar(string fisier)
    {
        Intrebari = IncarcaIntrebari(fisier);
    }

    public void Start()
    {
        StartTime = DateTime.Now;
        Scor = 0;

        foreach (var intrebare in Intrebari)
        {
            int timpRamas = TimpLimita - (int)(DateTime.Now - StartTime).TotalSeconds;
            if (timpRamas <= 0)
            {
                Console.WriteLine("Timp expirat! Test picat.");
                SalvareRezultat(0);
                return;
            }

            Console.WriteLine("Timp rămas: " + timpRamas + " secunde");
            intrebare.Afiseaza();
            int raspuns = CitesteRaspuns();

            if (intrebare.VerificaRaspuns(raspuns))
            {
                Console.WriteLine("✔ Corect!\n");
                Scor++;
            }
            else
            {
                Console.WriteLine("✖ Greșit! Răspuns corect: " + intrebare.RaspunsCorect + "\n");
            }
        }

        Console.WriteLine("Scor final: " + Scor + "/" + Intrebari.Count);
        SalvareRezultat(Scor);
    }

    private int CitesteRaspuns()
    {
        int raspuns;
        while (!int.TryParse(Console.ReadLine(), out raspuns) || raspuns < 1 || raspuns > 4)
        {
            Console.Write("Alege un număr între 1 și 4: ");
        }
        return raspuns;
    }

    private void SalvareRezultat(int scorFinal)
    {
        string rezultat = DateTime.Now + ", Scor: " + scorFinal + "/" + Intrebari.Count + "\n";
        File.AppendAllText("rezultate.txt", rezultat);
    }

    private List<Intrebare> IncarcaIntrebari(string fisier)
    {
        List<Intrebare> intrebari = new List<Intrebare>();
        string[] linii = File.ReadAllLines(fisier);

        for (int i = 0; i < linii.Length; i += 6)
        {
            List<string> optiuni = new List<string>();
            optiuni.Add(linii[i + 1]);
            optiuni.Add(linii[i + 2]);
            optiuni.Add(linii[i + 3]);
            optiuni.Add(linii[i + 4]);

            intrebari.Add(new Intrebare(linii[i], optiuni, int.Parse(linii[i + 5])));
        }

        return intrebari;
    }
}
