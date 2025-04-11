using System;

class TikTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char currPlayer = 'X' ;

    static void Main()
    {
        int moves = 0;
        bool playing = true;

        while (playing)
        {
            Console.Clear();
            PrintBoard();

            Console.Write($"Player {currPlayer}, choose num (1-9):");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int move) && move >= 1 && move <= 9)
                {
                if (board[move - 1] != 'X' && board[move - 1] != 'O')
                {
                    board[move - 1] = currPlayer;
                    moves++;

                    if (CheckWin())
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine("DRAW!");
                        playing = false;
                    }
                    else if (moves == 9)
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine($"Player {currPlayer} wins!");
                        playing = false;
                    }
                    else
                    {
                        currPlayer = currPlayer == 'X' ? 'O' : 'X';
                    }
 
                }
                else
                {
                    Console.WriteLine("Ops... Sell already taken! Press enter to continue");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Press enter to continue");
            }
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine("Tic-Tac-Toe Game\n");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}  ");
        Console.WriteLine("     |     |     \n");
    }

    static bool CheckWin()
    {
        int[,] wins = new int[,]
        {
            {0,1,2}, {3,4,5}, {6,7,8}, // rows
            {0,3,6}, {1,4,7}, {2,5,8}, // columns
            {0,4,8}, {2,4,6}           // diagonals
        };

        for (int i = 0; i < wins.GetLength(0); i++)
        {
            if (board[wins[i, 0]] == currPlayer &&
                board[wins[i, 1]] == currPlayer &&
                board[wins[i, 2]] == currPlayer)
            {
                return true;
            }
        }
        return false;
    }
}