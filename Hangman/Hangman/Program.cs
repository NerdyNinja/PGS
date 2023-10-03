using System;

public class Global
{
    public static string UserInput = "";
    public static char c;
    public static string Number;
    public static string[] List;
    public static string Word;
    public static string Word1;
    public static int NumberWord;
    public static string UserWord;
    public static string UserWord1;
    public static int NumberEach = 0;
    public static int Lives = 2;
    public static string charToString;
    public static bool MinusLife = false;
    public static bool MinusLife1 = false;
    public static bool CorrectChar = false;
    public static bool CorrectChar1 = false;

}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        UI();
        StartGame();
        GameLoop();
        //TODO:
        //Printen dass der User Minusleben bekommen hat
        //Aktuellen Hangman zeichnen?
        //Schwierigkeitsstufen kann im UI gewählt werden
        //Wörter werden random von einem web request geholt
        //
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

        Global.List = new string[6];
        Global.List[0] = "Hallo";
        Global.List[1] = "Kakadu";
        Global.List[2] = "Atomkraftwerk";
        Global.List[3] = "Menschlichkeit";
        Global.List[4] = "Grünepolitik";
        Global.List[5] = "Jeremyfegrance";

        Random rnd = new Random();
        int index = rnd.Next(Global.List.Length);
        Global.Word = Global.List[index];

        Global.Word1 = Global.Word.ToLower();

        foreach (char c in Global.Word)
        {
            Global.NumberWord++;
        }

        foreach (char c in Global.Word)
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

            Console.WriteLine(" ");
            Console.Write("Gebe einen Buchstaben ein: ");
            char cInput = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i != Global.NumberWord; i++)

            {
                if (UserWord[i] != '#')
                {
                    UserWord[i] = Global.Word1[i];
                }

                else if (cInput == Global.Word1[i])
                {
                    UserWord[i] = Global.Word1[i];
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

            if (Global.MinusLife == true)
            {
                Global.Lives--;
            }

            if (Global.Lives == 0)
            {
                Console.WriteLine("Game Over");
                Console.WriteLine("###########");
                Console.WriteLine("Du hast verloren");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine(UserWord);

            Global.charToString = new string(UserWord);

            if (Global.charToString == Global.Word1)
            {
                Console.WriteLine("Du hast das Wort erraten! Es lautet: " + Global.Word);
                Console.WriteLine("##############");
                Console.WriteLine("Glückwunsch!");
                x = 0;
            }
        } while (x != 0);

    }

}