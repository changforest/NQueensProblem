Console.WriteLine("- N Queens Problem -");
Console.Write("Please enter N(integer): ");
string? input;
int n = default;

while (n <= 0)
{
    input = Console.ReadLine();
    if (!Int32.TryParse(input, out n) || n == 0)
        Console.Write("Please Enter Number(> 0): ");
}

int counter = 0;

for (int i = 0; i < n; i++)
{
    PutQueen(i, 0, new int[n]);
}

void PutQueen(int x, int y, int[] board)
{
    //下棋
    board[y] = x;

    if (y == n - 1)
    {
        //算出解法
        counter++;
        Output(board);
        return;
    }
    else
    {
        //探索下一步棋的位置
        for (int i = 0; i < n; i++)
        {
            if (CheckPlace(board, i, y + 1))
                PutQueen(i, y + 1, board);
        }
        return;
    }
}

bool CheckPlace(int[] board, int x, int y)
{
    for (int i = 0; i < y; i++)
    {
        if (board[i] == x || Math.Abs(x - board[i]) == Math.Abs(y - i))
            return false;
    }
    return true;
}

void Output(int[] board)
{
    Console.WriteLine($"Solution {counter}:\n");

    for (int y = 0; y < board.Length; y++)
    {
        string line = string.Empty;
        for (int x = 0; x < board.Length; x++)
        {
            line += board[y] == x ? "Q " : "_ ";
        }

        Console.WriteLine($"{line}");
    }

    Console.WriteLine("\n\n");
}
