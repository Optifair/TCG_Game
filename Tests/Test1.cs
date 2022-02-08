using System;
using TCG;
using Xunit;

namespace TestProject1
{
    public class Test1
    {
        private GameController gameController;
        Creature r;
        Card c;
        public void CreateTestsSandBox()
        {
            gameController = new GameController();
            gameController.RedPlayer.playerName = "Красный";
            gameController.RedPlayer.Enemy = gameController.BluePlayer;
            gameController.BluePlayer.Enemy = gameController.RedPlayer;
            gameController.BluePlayer.playerName = "Синий";
            gameController.RedPlayer.Controller = gameController;
            gameController.BluePlayer.Controller = gameController;
            gameController.PlayerTurn = gameController.RedPlayer;
            gameController.NotPlayerTurn = gameController.BluePlayer;

            r = new Creature()
            {
                Attack_Point = 30,
                Hp = 2,
            };
            c = new Card()
            {
                Mana_Cost = 0,
                SummonCreature = r,
            };
        }
        [Fact]
        public void TestPlayerDie()
        {
            CreateTestsSandBox();
            gameController.Fight(r, gameController.BluePlayer);

            Assert.True(gameController.Winner == gameController.RedPlayer);
        }

        [Fact]
        public void TestCreatureDie()
        {
            CreateTestsSandBox();
            r.Player = gameController.RedPlayer;
            gameController.RedPlayer.Board.Add(r);
            r.Player = gameController.BluePlayer;
            gameController.BluePlayer.Board.Add(r);
            gameController.Fight(r, r);

            Assert.True(gameController.BluePlayer.Board.Count == 0);

        }

        [Fact]
        public void TestSummonCreature()
        {
            CreateTestsSandBox();
            gameController.RedPlayer.Hand.Add(c);
            r.Player = gameController.RedPlayer;
            c.Set_Player_and_Enemy(gameController.RedPlayer, gameController.BluePlayer);
            gameController.RedPlayer.Play_Card(c);

            Assert.True(gameController.RedPlayer.Board.Count == 1);
        }
    }
}
