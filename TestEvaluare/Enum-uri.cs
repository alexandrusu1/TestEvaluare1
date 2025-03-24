using System;

public enum TipQuiz
{
    Matematica,
    Istorie,
    Geografie
}

public enum OptiuniRaspuns
{
    A = 1,
    B = 2,
    C = 3,
    D = 4
}

[Flags]
public enum OptiuniExtra
{
    Nimic = 0,
    Ajutor50_50 = 1,
    TimpExtins = 2,
    RaspunsDublu = 4
}
