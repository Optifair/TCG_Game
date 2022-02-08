using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCG;

namespace Console_Game
{
    static class ConsoleI_In
    {
        public static int Card()
        {
            Console.WriteLine("Введите индекс карты: ");
            return Convert.ToInt32(Console.ReadLine()) - 1;
        }
        public static int Attacking()
        {
            Console.WriteLine("Введите индекс атакующего существа, " +
                    "если хотите атаковать вашим персонажем, введите 0 : ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int Attacked()
        {
            Console.WriteLine("Введите индекс атакуемого существа, " +
                    "если хотите атаковать вражеского персонажа, введите 0 : ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
