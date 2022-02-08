using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TCG;

namespace WPF_Game.View_Models
{
    class CreatureVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Creature creature { get; set; }
        public ICommand Click_Command { get; set; }
        public CreatureVM(Creature cr)
        {
            creature = cr;
            //HP = 10;
            //Attack = 10;
            //Name_text = "Getter";

        }
        public int HP
        {
            get { return creature.hp; }
            set
            {
                if (creature.hp != value)
                {
                    creature.hp = value;
                    OnPropertyChanged("HP");
                }
            }
        }
        public int Attack
        {
            get { return creature.Attack_Point; }
            set
            {
                if (creature.Attack_Point != value)
                {
                    creature.Attack_Point = value;
                    OnPropertyChanged("Attack");
                }
            }
        }
        public string Name_text
        {
            get { return creature.Name; }
            set
            {
                if (creature.Name != value)
                {
                    creature.Name = value;
                    OnPropertyChanged("Name_text");
                }
            }
        }

        private void Click(object sender, MouseButtonEventArgs e)
        {
            DragDrop.DoDragDrop((CreatureV)sender, (CreatureV)sender, DragDropEffects.Copy);
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
