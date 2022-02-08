using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCG;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace WPF_Game.View_Models
{
    class CardVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Card card;
        public CardVM(Card c)
        {
            card = c;
            HP = c.SummonCreature.hp;
            Attack = c.SummonCreature.Attack_Point;
            Mana = c.Mana_Cost;
            Name = c.Name;
            Text = c.Text;
        }

        public int HP
        {
            get { return card.SummonCreature.hp; }
            set
            {
                if (card.SummonCreature.hp != value)
                {
                    card.SummonCreature.hp = value;
                    OnPropertyChanged("HP");
                }
            }
        }
        public int Attack
        {
            get { return card.SummonCreature.Attack_Point; }
            set
            {
                if (card.SummonCreature.Attack_Point != value)
                {
                    card.SummonCreature.Attack_Point = value;
                    OnPropertyChanged("Attack");
                }
            }
        }
        public int Mana
        {
            get { return card.Mana_Cost; }
            set
            {
                if (card.Mana_Cost != value)
                {
                    card.Mana_Cost = value;
                    OnPropertyChanged("Mana");
                }
            }
        }

        public string Name
        {
            get { return card.Name; }
            set
            {
                if (card.Name != value)
                {
                    card.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Text
        {
            get { return card.Text; }
            set
            {
                if (card.Text != value)
                {
                    card.Text = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
