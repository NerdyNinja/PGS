using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Bogus;

public class Global
{
    public static string UserInput = "";
    public static char c;
    public static char cInput;
    public static string uInput;
    public static string sInput;
    public static string Number;
    public static string[] List;
    public static List<char> UsedChars = new List<char>();
    public static string Word;
    public static string Word1;
    public static string RandomWord;
    public static int NumberWord;
    public static string UserWord;
    public static string UserWord1;
    public static int NumberEach = 0;
    public static int Lives = 2;
    public static string GamemMode = "0";
    public static string charToString;
    public static bool ContainsWhiteSpacesEg = false;
    public static bool alreadyUsed = false;
    public static bool MinusLife = false;
    public static bool MinusLife1 = false;
    public static bool CorrectChar = false;
    public static bool CorrectChar1 = false;

}

//TODO:
//Aktuellen Hangman zeichnen?
//Code Comments machen
//Je nach GameMode die Anzahl der Chars des generierenden Wort cappen
//

//Testing:
//Wörter werden random von einem web request geholt --> Wird jetzt durch BogusLib generiert, aktuell nur English (bug)?
//Schwierigkeitsstufen kann im UI gewählt werden --> Done? Sieht auf den ersten UseTest gut aus / muss debuggt werden
//Bereits Benutzte Buchstaben speichern und keine erneute Eingabe zulassen = kein MinusLeben mehr --> sollte Done sein




public class HelloWorld
{
    public static void Main(string[] args)
    {
        UI();
        StartGame();
        GameLoop();
    }

    public static void UI()
    {


        do
        {
            //Console.Clear();
            Global.Number = "0";
            Console.WriteLine("############");
            Console.WriteLine("Errate das Wort!");
            Console.WriteLine("############");
            Console.WriteLine(" ");

            Console.WriteLine("[1] GO");
            Console.WriteLine("[2] Stop");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("Action: ");

            Global.UserInput = Console.ReadLine();

            if (Global.UserInput == "1")
            {
                Global.Number = "1";
                Console.WriteLine("Du willst also das Spiel starten, bist du dir sicher dass du der Herausforderung gewachsen bist?");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                do
                {
                    Console.WriteLine("Welche Schwierigkeitsgrad moechtest du wählen?\nFolgendes steht zur Auswahl: Easy[1] -- Medium[2] -- Hard[3]");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.Write("Wäle deinen Schwierigskeitsgrad: ");

                    Global.GamemMode = Convert.ToString(Console.ReadLine());

                    switch (Global.GamemMode)
                    {
                        case "1":
                            Global.Lives = 6;
                            Console.WriteLine($"Du hast dich für Easy entschieden, du besitzt also {Global.Lives} Leben!");
                            Global.GamemMode = "1";
                            break;

                        case "2":
                            Global.Lives = 4;
                            Console.WriteLine($"Du hast dich für Easy entschieden, du besitzt also {Global.Lives} Leben!");
                            Global.GamemMode = "2";
                            break;

                        case "3":
                            Global.Lives = 2;
                            Console.WriteLine($"Du hast dich für Easy entschieden, du besitzt also {Global.Lives} Leben!");
                            Global.GamemMode = "3";
                            break;

                        default:
                            Console.WriteLine("Das war keine korrekte Eingabe!");
                            Global.GamemMode = "0";
                            break;
                    }

                } while (Global.GamemMode == "0");
            }

            else if (Global.UserInput == "2")
            {
                Console.WriteLine("STOPPED!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Falsche Eingabe!");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Global.Number = "3";
            }
        } while (Global.Number == "3");

    }

    public static void StartGame()
    {
        var fakerWord = new Faker("de"); //Bug in Bogus? Erzeugt dennoch Englishe Wörter

        do
        {
            Global.RandomWord = fakerWord.Random.Word();

            if (Global.RandomWord.Contains('-') || Global.RandomWord.Contains(' ') || Global.RandomWord.Length <= 3)
            {
                Global.ContainsWhiteSpacesEg = true;
            }
        } while (Global.ContainsWhiteSpacesEg == true);

        Global.RandomWord = Global.RandomWord.ToLower();
        Console.WriteLine($"Ich bin das Randmword: {Global.RandomWord}");



        foreach (char c in Global.RandomWord)
        {
            Global.NumberWord++;
        }

        foreach (char c in Global.RandomWord)
        {
            Global.UserWord += "#";
        }

        Console.WriteLine(Global.NumberWord + " Zeichen lang!");

    }
    public static void GameLoop()
    {
        int x = 1;

        char[] UserWord = Global.UserWord.ToCharArray();

        do
        {

            Global.CorrectChar = false;
            Global.MinusLife = false;

            do
            {
                Console.WriteLine(" ");
                Console.Write("Gebe einen Buchstaben ein: ");

                Global.uInput = Console.ReadLine();
                Global.uInput = Global.uInput.ToLower();

                if (char.TryParse(Global.uInput, out Global.cInput))
                {
                    if (Global.UsedChars.Contains(Global.cInput))
                    {
                        Console.WriteLine($"Den Buchstaben {Global.cInput} hast du bereits benutzt");
                        Global.alreadyUsed = true;
                    }
                    else if (!Global.UsedChars.Contains(Global.cInput))
                    {
                        Global.alreadyUsed = false;
                    }

                    Global.UsedChars.Add(Global.cInput);

                    for (int i = 0; i != Global.NumberWord; i++)

                    {
                        if (UserWord[i] != '#')
                        {
                            UserWord[i] = Global.RandomWord[i];
                        }

                        else if (Global.cInput == Global.RandomWord[i])
                        {
                            UserWord[i] = Global.RandomWord[i];
                            Global.CorrectChar = true;
                        }

                        else
                        {
                            UserWord[i] = '#';
                        }
                    }

                    if (Global.CorrectChar != true)
                    {
                        Global.MinusLife = true;
                    }
                    else
                    {
                        //Userword gab falschen Wert zrk daher der workaround aus line190
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Deine Eingabe war korrekt!");
                        Console.Write("Das aktuelle Wort lautet: ");
                    }

                    if (Global.MinusLife == true)
                    {
                        Global.Lives--;

                        if (Global.Lives == 0)
                        {
                            Console.WriteLine("Game Over");
                            Console.WriteLine("###########");
                            Console.WriteLine("Du hast verloren");
                            Console.WriteLine(" ");
                            Console.WriteLine($"Das gesuchte Wort lautete {Global.RandomWord}!");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }

                        Console.WriteLine("Du hast 1 Leben verloren!");
                        Console.WriteLine("Du besitzt noch: " +
                        Global.Lives + " uebrige Leben!");
                    }

                    //sollte das nicht in den else Block zu das aktuelle WOrt lautet..
                    Console.WriteLine(UserWord);

                    Global.charToString = new string(UserWord);

                    if (Global.charToString == Global.RandomWord)
                    {
                        Console.WriteLine("Du hast das Wort erraten! Es lautet: " + Global.RandomWord);
                        Console.WriteLine("##############");
                        Console.WriteLine("Glückwunsch!");
                        Console.ReadKey();
                        x = 0;
                    }

                }
                else if (Global.uInput.Length > 1)
                {
                    Console.WriteLine($"Hallo Zeile 278{Global.sInput}");

                    if (Global.uInput == Global.RandomWord)
                    {
                        Console.WriteLine("Du hast das Wort erraten! Es lautet: " + Global.RandomWord);
                        Console.WriteLine("##############");
                        Console.WriteLine("Glückwunsch!");
                        Console.ReadKey();
                        x = 0;
                    }
                    else
                    {
                        Global.MinusLife = true;
                        Global.Lives = Global.Lives - 2;

                        if (Global.Lives == 0)
                        {
                            Console.WriteLine("Game Over");
                            Console.WriteLine("###########");
                            Console.WriteLine("Du hast verloren");
                            Console.WriteLine(" ");
                            Console.WriteLine($"Das gesuchte Wort lautete {Global.RandomWord}!");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }

                        Console.WriteLine("Du hast 2 Leben verloren!");
                        Console.WriteLine("Du besitzt noch: " +
                        Global.Lives + " uebrige Leben!");

                    }
                }

            } while (Global.alreadyUsed == true);


        } while (x != 0);
    }

}