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

}

public class Hangman
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

        Global.List = new string[5];
        Global.List[0] = "Kakadu";
        Global.List[1] = "Blaubeerkuchen";
        Global.List[2] = "Hallo";
        Global.List[3] = "Arschloch";
        Global.List[4] = "Pipikakasee";

        Random rnd = new Random();
        int index = rnd.Next(Global.List.Length);
        Global.Word = Global.List[index];

        Global.Word1 = Global.Word.ToLower();
        Console.WriteLine(Global.Word1);

        foreach (char c in Global.Word)
        {
            Global.NumberWord++;
        }

        foreach (char c in Global.Word)
        {
            Global.UserWord += "#";
        }

        Console.WriteLine(Global.NumberWord + " Zeichen lang!");
        Console.WriteLine(Global.UserWord);

    }
    public static void GameLoop()
    {
        // Aktuell Endlos, muss angepasst werden Test
        int x = 1;

        char[] UserWord = Global.UserWord.ToCharArray();

        try
        {
            do
            {

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

                    }
                    else
                    {
                        UserWord[i] = '#';
                        //Insert Hangman here

                    }

                }
                Console.WriteLine(UserWord);
            } while (x != 0);
        } catch (SystemException)
        {

        };
        }
    }