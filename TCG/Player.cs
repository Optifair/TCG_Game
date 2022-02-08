using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCG
{
    public class Player : Targetable_Game_Object
    {
        public Player()
        {
            Deck = new Stack<Card>();
            Hand = new ObservableCollection<Card>();
            Board = new ObservableCollection<Creature>();
            Mana = 0;
            Attack_Point = 0;
            Hp = 30;
        }
        public string playerName;
        public GameController Controller;
        public Stack<Card> Deck { get; set; }
        public ObservableCollection<Card> Hand { get; set; }
        public ObservableCollection<Creature> Board { get; set; }
        public int Mana { get; set; }
        public Player Enemy { get; set; }

        public void Draw(int len)
        {
            for (int i = 0; i < len; i++)
            {
                if (Deck.Count > 0 )
                {
                    Hand.Add(Deck.Pop());
                }
            }
        }
        public override void Die()
        {
            Controller.Player_Win(Enemy);
        }
        public bool Play_Card(Card card)
        {
            bool size = true;
            bool mana = true;
            bool played = false;
            if (Mana < card.Mana_Cost)
            {
                mana = false;
            }

            if (card.Type == CardType.Creature)
            {
                if (Board.Count >= 6)
                {
                    size = false;
                }
            }
            if (mana && size)
            {
                played = true;
                Mana -= card.Mana_Cost;

                card.Play();
                Hand.Remove(card);
                played = true;
            }
            return played;
        }
    }
}
