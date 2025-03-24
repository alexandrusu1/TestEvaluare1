using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(@"
 ██████╗ ██╗   ██╗██╗███████╗ █████╗ ██████╗ ██████╗ 
██╔═══██╗██║   ██║██║╚══███╔╝██╔══██╗██╔══██╗██╔══██╗
██║   ██║██║   ██║██║  ███╔╝ ███████║██████╔╝██████╔╝
██║▄▄ ██║██║   ██║██║ ███╔╝  ██╔══██║██╔═══╝ ██╔═══╝ 
╚██████╔╝╚██████╔╝██║███████╗██║  ██║██║     ██║     
 ╚══▀▀═╝  ╚═════╝ ╚═╝╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝     
            ");
        Console.WriteLine("1. Matematică");
        Console.WriteLine("2. Istorie");
        Console.WriteLine("3. Geografie");
        Console.Write("Alege un quiz: ");

        string alegere = Console.ReadLine();
        string fisier = "";

        if (alegere == "1") fisier = "matematica.txt";
        else if (alegere == "2") fisier = "istorie.txt";
        else if (alegere == "3") fisier = "geografie.txt";
        else
        {
            Console.WriteLine("Opțiune invalidă.");
            return;
        }

        Chestionar quiz = new Chestionar(fisier);
        quiz.Start();
    }
}
