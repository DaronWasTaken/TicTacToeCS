using System.Runtime.InteropServices;

internal class Program
{
    static char[,] playField =
    {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
    };

    static int turns = 0;
    static bool correctInput = true;

    private static void Main(string[] args)
    {
        int player = 2;
        int input = 0;

        do
        {
            if (player == 2)
            {
                player = 1;
                EnterXorO(player, input);
            }
            else if (player == 1)
            {
                player = 2;
                EnterXorO(player, input);
            }

            ShowPlayField();
            CheckEndGame();

            do
            {
                correctInput = true;
                Console.WriteLine($"Player {player} - choose a field: ");
                string? inputString = Console.ReadLine();
                correctInput = int.TryParse(inputString, out int result);
                input = result;
                
                if (!correctInput)
                {
                    Console.WriteLine("Please type a correct number!");
                } else
                {
                    CheckCorrectField(input);
                }

            } while (!correctInput);

        } while (true);
    }

    public static void ResetField()
    {
        char[,] playFieldInitial =
        {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };

        playField = playFieldInitial;
        ShowPlayField();
        turns = 0;
    }
    private static void ShowPlayField()
    {
        Console.Clear();
        Console.WriteLine("   -------------------");
        Console.WriteLine($"   |  {playField[0, 0]}  |  {playField[0, 1]}  |  {playField[0, 2]}  |");
        Console.WriteLine("   -------------------");
        Console.WriteLine($"   |  {playField[1, 0]}  |  {playField[1, 1]}  |  {playField[1, 2]}  |");
        Console.WriteLine("   -------------------");
        Console.WriteLine($"   |  {playField[2, 0]}  |  {playField[2, 1]}  |  {playField[2, 2]}  |");
        Console.WriteLine("   -------------------");
    }
    private static void EnterXorO(int player, int input)
    {
        char playerSign = ' ';
        if (player == 1)
            playerSign = 'X';
        else if (player == 2)
            playerSign = 'O';

        switch (input)
        {
            case 1: playField[0, 0] = playerSign; break;
            case 2: playField[0, 1] = playerSign; break;
            case 3: playField[0, 2] = playerSign; break;
            case 4: playField[1, 0] = playerSign; break;
            case 5: playField[1, 1] = playerSign; break;
            case 6: playField[1, 2] = playerSign; break;
            case 7: playField[2, 0] = playerSign; break;
            case 8: playField[2, 1] = playerSign; break;
            case 9: playField[2, 2] = playerSign; break;
        }

    }

    private static void CheckCorrectField(int input)
    {
        bool correctField = true;
        switch (input)
        {
            case 1: if (playField[0, 0] != '1') correctField = false; break;
            case 2: if (playField[0, 1] != '2') correctField = false; break;
            case 3: if (playField[0, 2] != '3') correctField = false; break;
            case 4: if (playField[1, 0] != '4') correctField = false; break;
            case 5: if (playField[1, 1] != '5') correctField = false; break;
            case 6: if (playField[1, 2] != '6') correctField = false; break;
            case 7: if (playField[2, 0] != '7') correctField = false; break;
            case 8: if (playField[2, 1] != '8') correctField = false; break;
            case 9: if (playField[2, 2] != '9') correctField = false; break;
        }

        if (!correctField)
        {
            Console.WriteLine("Incorrect input! Please use another field!");
            correctInput = false;
        }
    }

    private static void CheckEndGame()
    {
        turns++;
        char[] playerChars = { 'X', 'O' };

        foreach (char playerChar in playerChars)
        {
            if (((playField[0, 0] == playerChar) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar))
                 || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))
                 || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                 || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))
                 || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))
                 || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar))
                 || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))
                 || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar))
                 )
            {
                if (playerChar == 'X')
                {
                    Console.WriteLine("\nPlayer 2 has won!");
                }
                else
                {
                    Console.WriteLine("\nPlayer 1 has won!");
                }

                Console.WriteLine("Press any Key to Reset the Game");
                Console.ReadKey();
                ResetField();
            }
            else if (turns == 10)
            {
                Console.WriteLine("/Draw");
                Console.WriteLine("Press any Key to Reset the Game");
                Console.ReadKey();
                ResetField();
            }
        }
    }
}