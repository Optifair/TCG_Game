using System;
using TCG;

namespace Console_Game
{
    public static class Console_Out
    {
        public static void Players_Information(Player RedPlayer, Player BluePlayer)
        {
            Console.WriteLine("\r\n");
            Console.WriteLine("У игрока {0} {1} мана кристаллов, в колоде {2} карт, в руке {3} карт, {4} Хп", RedPlayer.playerName, RedPlayer.Mana, RedPlayer.Deck.Count, RedPlayer.Hand.Count, RedPlayer.Hp);
            Console.WriteLine("У игрока {0} {1} мана кристаллов, в колоде {2} карт, в руке {3} карт, {4} Хп", BluePlayer.playerName, BluePlayer.Mana, BluePlayer.Deck.Count, BluePlayer.Hand.Count, BluePlayer.Hp);
        }

        public static void Start_Of_Turn(Player PlayerTurn)
        {
            Console.WriteLine("/////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("Сейчас ходит {0} игрок", PlayerTurn.playerName);
        }

        public static void Play_Card(Card card)
        {
            Console.WriteLine("\r\n");
            Console.WriteLine("Игрок {0} сыграл карту {1}", card.Player.playerName, card.Name);
            Console.WriteLine("Игрок {0} призвал существо {1}", card.Player.playerName, card.SummonCreature.Name);

        }

        public static void End_Of_Turn()
        {
            Console.WriteLine("Конец хода");
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////// \r\n");
        }

        public static void Board(Player RedPlayer, Player BluePlayer)
        {
            Console.WriteLine("\r\n");
            Console.WriteLine("На поле боя находятся следующие существа:");
            string viv = "Существа красного игрока: \r\n";
            int i = 1;
            foreach (Creature cr in RedPlayer.Board)
            {

                viv += (" {Имя: " + cr.Name + "; Позиция: " + i + "; Атака: "
                    + cr.Attack_Point + "; Хп: " + cr.Hp + "}," + "\r\n");
                i++;
            }
            viv += "\r\n";
            viv += "Существа синего игрока: \r\n";
            i = 1;
            foreach (Creature cr in BluePlayer.Board)
            {
                viv += (" {Имя: " + cr.Name + "; Позиция: " + i + "; Атака: "
                    + cr.Attack_Point + "; Хп: " + cr.Hp + "}," + "\r\n");
                i++;
            }
            Console.WriteLine(viv);
        }
        public static void Fight(Targetable_Game_Object Attacking, Targetable_Game_Object Attacked)
        {

        }

        public static void Win(Player player)
        {
            Console.WriteLine("Игрок {0} победил!", player.playerName);
        }
        public static void PlayerHand(Player PlayerTurn)
        {
            Console.WriteLine("\r\n");
            string viv = "В руке находятся карты: \r\n";
            int i = 1;
            foreach (Card cr in PlayerTurn.Hand)
            {
                if (cr.Type == CardType.Creature)
                {
                    viv += (" {Название: " + cr.Name + "; Позиция: " + i + "; Стоимость: " + cr.Mana_Cost + "; Атака: "
                        + cr.SummonCreature.Attack_Point + "; Хп: " + cr.SummonCreature.Hp + "}," + "\r\n");
                }
                else if (cr.Type == CardType.Spell)
                {
                    viv += (" {Название: " + cr.Name + "; Позиция: " + i + "; Стоимость: " + cr.Mana_Cost + "}," + "\r\n");
                }
                i++;
            }
            Console.WriteLine(viv);
        }

        public static void Turn_Actions()
        {
            Console.WriteLine(
                "Выберите: \r\n" +
                "1: Информация об игроках \r\n" +
                "2: Отобразить стол \r\n" +
                "3: Отобразить руку \r\n" +
                "4: Разыграть карту \r\n" +
                "5: Атаковать \r\n" +
                "6: Завершить ход \r\n");
        }
        public static void Not_Played()
        {
            Console.WriteLine("Карта не сыграна!");
        }
    }
}
