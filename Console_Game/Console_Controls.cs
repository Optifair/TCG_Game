using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCG;
using Console_Game;

namespace TCG
{
    public class Console_Controls
    {
        public GameController GameController;

        private void Turn_Start()
        {
            GameController.Turn_Start();
            Console_Out.Start_Of_Turn(GameController.PlayerTurn);
            Console_Out.Players_Information(GameController.RedPlayer, GameController.BluePlayer);
            Console_Out.Board(GameController.RedPlayer, GameController.BluePlayer);
            Console_Out.PlayerHand(GameController.PlayerTurn);
        }

        private void Turn_End()
        {
            GameController.Turn_End();
            Console_Out.End_Of_Turn();
        }

        public void Game()
        {
            GameController.Game_Start();
            while (GameController.Winner == null)
            {
                Turn_Interactions();
            }
            Console_Out.Win(GameController.Winner);
        }

        public void Turn_Interactions()
        {
            bool tr = true;
            Turn_Start();
            while (tr && GameController.Winner == null)
            {
                Console_Out.Turn_Actions();
                switch (Console.ReadLine())
                {
                    case "1":
                        Console_Out.Players_Information(GameController.RedPlayer, GameController.BluePlayer);
                        break;
                    case "2":
                        Console_Out.Board(GameController.RedPlayer, GameController.BluePlayer);
                        break;
                    case "3":
                        Console_Out.PlayerHand(GameController.PlayerTurn);
                        break;
                    case "4":
                        int id = ConsoleI_In.Card();
                        Card card = GameController.PlayerTurn.Hand[id];
                        if (GameController.PlayerTurn.Play_Card(card))
                        {
                            Console_Out.Play_Card(card);
                        }
                        else
                        {
                            Console_Out.Not_Played();
                        }
                        break;
                    case "5":
                        int at = ConsoleI_In.Attacking();
                        int ated = ConsoleI_In.Attacked();

                        Targetable_Game_Object at_ob;
                        Targetable_Game_Object ated_ob;

                        if (at == 0)
                        {
                            at_ob = GameController.PlayerTurn;
                        }
                        else
                        {
                            at_ob = GameController.PlayerTurn.Board[at-1];
                        }
                        if (ated == 0)
                        {
                            ated_ob = GameController.NotPlayerTurn;
                        }
                        else
                        {
                            ated_ob = GameController.NotPlayerTurn.Board[ated-1];
                        }
                        GameController.Fight(at_ob, ated_ob);
                        Console_Out.Fight(at_ob, ated_ob);

                        break;
                    case "6":
                        tr = false;
                        Turn_End();
                        break;
                }
            }
        }
    }
}
