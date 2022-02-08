using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TCG;

namespace WPF_Game.View_Models
{
    class PlayerVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SolidColorBrush color;
        public ObservableCollection<CardVM> Deck { get; set; }
        public ObservableCollection<CardVM> Hand { get; set; }
        public ObservableCollection<CreatureVM> Board { get; set; }
        public ObservableCollection<Object> ManaCol { get; set; }
        public Player Player { get; set; }
        public BitmapImage Image {get; set;}

        public PlayerVM(Player pl)
        {
            Player = pl;
            Deck = new ObservableCollection<CardVM>();
            Hand = new ObservableCollection<CardVM>();
            Board = new ObservableCollection<CreatureVM>();
            ManaCol = new ObservableCollection<Object>();
            var p = 1;
        }

        public SolidColorBrush Color 
        {
            get { return color; }
            set
            {
                if (value != color)
                {
                    color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        public int HP 
        {
            get { return Player.hp; }
            set
            {
                if (value != Player.hp)
                {
                    Player.hp = value;
                    OnPropertyChanged("HP");
                }
            }
        }

        public int Mana 
        {
            get { return Player.Mana; }
            set
            {
                if (value != Player.Mana)
                {
                    Player.Mana = value;
                    OnPropertyChanged("Mana");
                }
            }
            //get;set;
        }

        public string Name_text 
        { 
            get { return Player.playerName; }
            set
            {
                if (value != Player.playerName)
                {
                    Player.playerName = value;
                    OnPropertyChanged("Name_text");
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
