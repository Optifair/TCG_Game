using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TCG
{
    public class Card
    {
        public CardType Type { get; set; }
        public Player Player { get; private set; }
        public Player Enemy { get; private set; }
        public string Name { get; set; }
        public int Mana_Cost { get; set; }
        public Creature SummonCreature { get; set; }
        public string Text { get; set; }

        public void Play()
        {

            Summon();
        }
        private void Summon()
        {
            Player.Board.Add(SummonCreature);
        }
        public void Set_Player_and_Enemy(Player p, Player e)
        {
            Player = p;
            SummonCreature.Player = p;
            Enemy = e;
        }
    }
}
