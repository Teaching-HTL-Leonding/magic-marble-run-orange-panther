string marbleRun = args[0];
int segments = 0, teleports = 0;
char symbol = ' ';

int index = 0;
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
} while (index < marbleRun.Length);

Console.WriteLine($"segments: {segments}\nteleports: {teleports}");

// int ChangeHexToDecimal(string hex)
// {
//     hex = hex.Substring(2);
//     int pow = 0;
//     double number = 0;

//     for (int i = hex.Length - 1; i >= 0; i--)
//     {
//         int digit;
//         if (char.IsLetter(hex[i]))
//         {
//             digit = hex[i] switch
//             {
//                 'a' => 10,
//                 'b' => 11,
//                 'c' => 12,
//                 'd' => 13,
//                 'e' => 14,
//                 'f' => 15,
//                 _ => 0
//             };
//         }
//         else { digit = hex[i]; }

//         number += digit * Math.Pow(16, pow);
//         pow++;
//     }
//     return (int)number; //type-cast
// }
