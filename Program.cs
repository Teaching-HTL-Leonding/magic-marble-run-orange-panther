﻿string marbleRun = args[0];
int segments = 0, teleports = 0, index = 0, arrayCount = 0;
char symbol = ' ';
var indexes = new int[marbleRun.Length];
bool doAgain = true;

do
{
    switch (marbleRun[index])
    {
        case '>':
            segments++; index++;
            symbol = '>';
            break;
        case '<':
            segments++; index--;
            symbol = '<';
            break;
        default:
            teleports++;
            switch (symbol)
            {
                case '>':
                    if (int.TryParse(marbleRun.Substring(index, 4), out int num1))
                    {
                        index = num1;
                    }
                    else
                    {
                        index = Convert.ToInt32(marbleRun.Substring(index + 2, 4), 16);
                    }
                    break;
                case '<':
                    if (int.TryParse(marbleRun.Substring(index - 3, 4), out int num2) && marbleRun.Substring(index - 5, 2) != "0x")
                    {
                        index = num2;
                    }
                    else
                    {
                        index = Convert.ToInt32(marbleRun.Substring(index - 3, 4), 16);
                    }
                    break;
                default:
                    break;
            }
            break;
    }
    if (!IsValidMarbleRun(index, indexes)) { doAgain = false; }
    else
    {
        indexes[arrayCount] = index;
        arrayCount++;
    }
} while (index < marbleRun.Length && doAgain);

if (!doAgain)
{
    Console.WriteLine("Oh no, the marble is running in a loop! The program will end now.");
}
else
{
    Console.WriteLine($"segments: {segments}\nteleports: {teleports}");
}

bool IsValidMarbleRun(int position, int[] indexes)
{
    if (indexes.Contains(position)) { return false; }
    else { return true; }
}
