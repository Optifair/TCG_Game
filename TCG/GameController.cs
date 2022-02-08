using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace TCG
{
    public class GameController
    {
        //public User_Interaction User_Controls;
        public Player RedPlayer = new Player();
        public Player BluePlayer = new Player();
        public Player PlayerTurn = new Player();
        public Player NotPlayerTurn = new Player();
        public Player Winner;
        public int ManaBuffer;

        public void Randomize_First_Player()
        {
            Random rnd = new Random();
            if (rnd.Next(2) == 0) //определение очередности и взятие карт
            {
                PlayerTurn = RedPlayer;
                NotPlayerTurn = BluePlayer;
            }
            else
            {
                PlayerTurn = BluePlayer;
                NotPlayerTurn = RedPlayer;
            }
        }
        public void Game_Start()
        {
            PlayerTurn.Draw(3);
            NotPlayerTurn.Draw(4);
        }
        public List<Targetable_Game_Object> Return_Possible_Targets(Player Player,
                                                                    bool is_creatures = true, 
                                                                    bool is_player = true)
        {
            List<Targetable_Game_Object> targets = new List<Targetable_Game_Object>();
            if (is_player)
            {
                targets.Add(Player);
            }
            if (is_creatures)
            {
                foreach (var item in Player.Board)
                {
                    targets.Add(item);
                }
            }
            return targets;
        }

        public void Player_Win(Player player)
        {
            Winner = player;
        }

        public void Fight(Targetable_Game_Object Attacking, Targetable_Game_Object Attacked)
        {
            Attacking.Hp -= Attacked.Attack_Point;
            Attacked.Hp -= Attacking.Attack_Point;
        }

        public void Turn_Start()
        {
            if (PlayerTurn.Mana < 10)
            {
                PlayerTurn.Mana++;
            }
            ManaBuffer = PlayerTurn.Mana;
            PlayerTurn.Draw(1);
        }
        public void Turn_End()
        {
            PlayerTurn.Mana = ManaBuffer;
            Player buff = PlayerTurn;
            PlayerTurn = NotPlayerTurn;
            NotPlayerTurn = buff;
        }
    }
}
