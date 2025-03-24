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
        TipQuiz tipQuiz;

        if (alegere == "1") tipQuiz = TipQuiz.Matematica;
        else if (alegere == "2") tipQuiz = TipQuiz.Istorie;
        else if (alegere == "3") tipQuiz = TipQuiz.Geografie;
        else
        {
            Console.WriteLine("Opțiune invalidă.");
            return;
        }

        Chestionar quiz = new Chestionar(tipQuiz);
        quiz.Start();
    }
}
