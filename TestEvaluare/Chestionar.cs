using System;
using System.Collections.Generic;
using System.IO;

class Chestionar
{
    private List<Intrebare> Intrebari;
    private int Scor;
    private DateTime StartTime;
    private const int TimpLimita = 600; // 10 minute
    private TipQuiz Tip;

    public Chestionar(TipQuiz tip)
    {
        Tip = tip;
        string fisier = $"{tip.ToString().ToLower()}.txt";
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
            OptiuniRaspuns raspuns = CitesteRaspuns();

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

    private OptiuniRaspuns CitesteRaspuns()
    {
        while (true)
        {
            Console.Write("Alege (A, B, C, D): ");
            string input = Console.ReadLine().ToUpper();

            if (Enum.TryParse(input, out OptiuniRaspuns raspuns))
                return raspuns;

            Console.WriteLine("Opțiune invalidă. Încearcă din nou.");
        }
    }

    private void SalvareRezultat(int scorFinal)
    {
        string rezultat = $"{DateTime.Now}, Quiz: {Tip}, Scor: {scorFinal}/{Intrebari.Count}\n";
        File.AppendAllText("rezultate.txt", rezultat);
    }

    private List<Intrebare> IncarcaIntrebari(string fisier)
    {
        List<Intrebare> intrebari = new List<Intrebare>();
        string[] linii = File.ReadAllLines(fisier);

        for (int i = 0; i < linii.Length; i += 6)
        {
            List<string> optiuni = new List<string>
            {
                linii[i + 1],
                linii[i + 2],
                linii[i + 3],
                linii[i + 4]
            };

            OptiuniRaspuns raspunsCorect = (OptiuniRaspuns)Enum.Parse(typeof(OptiuniRaspuns), linii[i + 5]);
            intrebari.Add(new Intrebare(linii[i], optiuni, raspunsCorect));
        }

        return intrebari;
    }
}
