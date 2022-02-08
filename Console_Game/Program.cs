using System;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using TCG;


namespace Console_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console_Controls controls = new Console_Controls();
            GameController gameController = new GameController();
            gameController.RedPlayer.playerName = "Красный";
            gameController.RedPlayer.Enemy = gameController.BluePlayer;
            gameController.BluePlayer.Enemy = gameController.RedPlayer;
            gameController.BluePlayer.playerName = "Синий";
            gameController.RedPlayer.Controller = gameController;
            gameController.BluePlayer.Controller = gameController;
            controls.GameController = gameController;

            for (int i = 0; i < 3; i++)
            {
                gameController.RedPlayer.Board.Add(new Creature()
                {
                    Name = "Raptor",
                    Attack_Point = 30,
                    Hp = 2,
                    Player = gameController.RedPlayer
                });

                gameController.BluePlayer.Board.Add(new Creature()
                {
                    Name = "Pike",
                    Attack_Point = 2,
                    Hp = 3,
                    Player = gameController.BluePlayer
                });

            }
            gameController.Randomize_First_Player();
            for (int i = 0; i < 15; i++) //добавление карт в колоды
            {
                Card c = new Card()
                {
                    Type = CardType.Creature,
                    Name = "Raptor",
                    Mana_Cost = 2,
                    Text = "Обычный динозаврик",
                    SummonCreature = new Creature()
                    {
                        Name = "Raptor",
                        Attack_Point = 3,
                        Hp = 2,
                        Player = gameController.RedPlayer
                    },
                };
                c.Set_Player_and_Enemy(gameController.RedPlayer, gameController.BluePlayer);
                gameController.RedPlayer.Deck.Push(c);

                c = new Card()
                {
                    Type = CardType.Creature,
                    Name = "Pike",
                    Mana_Cost = 2,
                    Text = "Страшная щука",
                    SummonCreature = new Creature()
                    {

                        Name = "Pike",
                        Attack_Point = 2,
                        Hp = 3,
                        Player = gameController.BluePlayer
                    }
                };
                c.Set_Player_and_Enemy(gameController.BluePlayer, gameController.RedPlayer);
                gameController.BluePlayer.Deck.Push(c);
            }
            controls.Game();
        }
    }
}
