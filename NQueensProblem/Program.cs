Console.WriteLine("- N Queens Problem -");
int n = GetNumber();
int counter = 0;

for (int i = 0; i < n; i++)
{
    PutQueen(i, 0, new int[n]);
}

/// <summary>
/// 取得 N (使用者輸入)
/// </summary>
int GetNumber()
{
    Console.Write("Please enter N(integer): ");
    string? input;
    int n = default;

    //使用者輸入檢測
    while (n <= 0)
    {
        input = Console.ReadLine();
        if (!Int32.TryParse(input, out n) || n == 0)
            Console.Write("Please Enter Number(> 0): ");
    }
    return n;
}
/// <summary>
/// 放置皇后，並持續試出下一步路
/// </summary>
void PutQueen(int x, int y, int[] board)
{
    //放置皇后
    board[y] = x;

    if (y == n - 1)
    {
        //輸出解法
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
/// <summary>
/// 確認該位置是否可放置皇后
/// </summary>
bool CheckPlace(int[] board, int x, int y)
{
    for (int i = 0; i < y; i++)
    {
        if (board[i] == x || Math.Abs(x - board[i]) == Math.Abs(y - i))
            return false;
    }
    return true;
}
/// <summary>
/// 輸出棋盤
/// </summary>
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
