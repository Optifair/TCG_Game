using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TCG;

namespace WPF_Game.View_Models
{

    class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        GameController gameController { get; set; }

        public ICommand Turn_End_Command { get; set; }
        public ICommand Sound_Command { get; set; }
        public PlayerVM RedPlayer { get; set; }
        public PlayerVM BluePlayer { get; set; }
        public PlayerVM playerTurn;
        public PlayerVM notPlayerTurn;
        public Image sound_Image;
        public CreatureVM playerTurnSelectedCreature;
        public CreatureVM notPlayerTurnSelectedCreature;
        public CardVM selectedCard;
        public PlayerVM selectedPlayer;
        public Window win;

        public PlayerVM PlayerTurn
        {
            get { return playerTurn; }
            set
            {
                if (playerTurn != value)
                {
                    playerTurn = value;
                    OnPropertyChanged("PlayerTurn");
                }
            }
        }

        public PlayerVM NotPlayerTurn
        {
            get { return notPlayerTurn; }
            set
            {
                if (notPlayerTurn != value)
                {
                    notPlayerTurn = value;
                    OnPropertyChanged("NotPlayerTurn");
                }
            }
        }

        public Image Sound_Image
        {
            get { return sound_Image; }
            set
            {
                if (sound_Image != value)
                {
                    sound_Image = value;
                    OnPropertyChanged("Sound_Image");
                }
            }
        }

        public CreatureVM PlayerTurnSelectedCreature
        {
            get { return playerTurnSelectedCreature; }
            set
            {
                if (value != playerTurnSelectedCreature)
                {
                    playerTurnSelectedCreature = value;
                    OnPropertyChanged("PlayerTurnSelectedCreature");
                }
            }
        }

        public CreatureVM NotPlayerTurnSelectedCreature
        {
            get { return notPlayerTurnSelectedCreature; }
            set
            {
                if (value != notPlayerTurnSelectedCreature)
                {
                    notPlayerTurnSelectedCreature = value;
                    OnPropertyChanged("NotPlayerTurnSelectedCreature");
                    FightVM();
                }
            }
        }

        public CardVM SelectedCard
        {
            get { return selectedCard; }
            set
            {
                if (value != selectedCard)
                {
                    selectedCard = value;
                    OnPropertyChanged("SelectedCard");
                    PlayVM();
                }
            }
        }

        public PlayerVM SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if (value != selectedPlayer)
                {
                    selectedPlayer = value;
                    OnPropertyChanged("SelectedPlayer");
                    FightVM();
                }
            }
        }
        public MainVM(Window w)
        {
            win = w;
            gameController = new GameController();
            gameController.RedPlayer.playerName = "Красный";
            gameController.RedPlayer.Enemy = gameController.BluePlayer;
            gameController.BluePlayer.Enemy = gameController.RedPlayer;

            gameController.BluePlayer.playerName = "Синий";
            gameController.RedPlayer.Controller = gameController;
            gameController.BluePlayer.Controller = gameController;

            RedPlayer = new PlayerVM(gameController.RedPlayer);
            RedPlayer.Color = Brushes.Red;

            BluePlayer = new PlayerVM(gameController.BluePlayer);
            BluePlayer.Color = Brushes.Blue;

            Creature Raptor = new Creature()
            {
                Name = "Raptor",
                Attack_Point = 30,
                Hp = 2,
                Player = gameController.RedPlayer
            };
            Creature Pike = new Creature()
            {
                Name = "Pike",
                Attack_Point = 2,
                Hp = 3,
                Player = gameController.BluePlayer
            };
            for (int i = 0; i < 1; i++)
            {

                gameController.RedPlayer.Board.Add(Raptor);
                gameController.BluePlayer.Board.Add(Pike);

                RedPlayer.Board.Add(new CreatureVM(Raptor));
                BluePlayer.Board.Add(new CreatureVM(Pike));
            }
            for (int i = 0; i < 30; i++) //добавление карт в колоды
            {
                Card c = new Card()
                {
                    Type = CardType.Creature,
                    Name = "Raptor",
                    Mana_Cost = 2,
                    Text = "Обычный динозаврик",
                    SummonCreature = Raptor
                };
                c.Set_Player_and_Enemy(gameController.RedPlayer, gameController.BluePlayer);
                gameController.RedPlayer.Deck.Push(c);
                RedPlayer.Deck.Add(new CardVM(c));

                c = new Card()
                {
                    Type = CardType.Creature,
                    Name = "Pike",
                    Mana_Cost = 2,
                    Text = "Страшная щука",
                    SummonCreature = Pike
                };
                c.Set_Player_and_Enemy(gameController.BluePlayer, gameController.RedPlayer);
                gameController.BluePlayer.Deck.Push(c);
                BluePlayer.Deck.Add(new CardVM(c));
            }

            gameController.Randomize_First_Player();
            gameController.Game_Start();
            gameController.Turn_Start();

            if (gameController.PlayerTurn == gameController.RedPlayer)
            {
                PlayerTurn = RedPlayer;
                NotPlayerTurn = BluePlayer;
            }
            else
            {
                PlayerTurn = BluePlayer;
                NotPlayerTurn = RedPlayer;
            }


            Turn_End_Command = new RelayCommand(Turn_End);
            RefreshScene();
            Sound_Command = new RelayCommand(Sound);

        }

        private void Turn_End()
        {
            gameController.Turn_End();

            gameController.Turn_Start();
            PlayerVM buffer = PlayerTurn;
            PlayerTurn = NotPlayerTurn;
            NotPlayerTurn = buffer;
            RefreshScene();
        }

        private void Sound()
        {

        }


        private void FightVM()
        {
            Targetable_Game_Object a;
            Targetable_Game_Object at;
            if (PlayerTurnSelectedCreature != null && NotPlayerTurnSelectedCreature != null)
            {
                a = PlayerTurnSelectedCreature.creature;
                at = NotPlayerTurnSelectedCreature.creature;
                //MessageBox.Show(PlayerTurnSelectedCreature.Name_text + " подрался с " + NotPlayerTurnSelectedCreature.Name_text);
                PlayerTurnSelectedCreature = null;
                NotPlayerTurnSelectedCreature = null;
                gameController.Fight(a, at);
            }
            else if (PlayerTurnSelectedCreature != null && SelectedPlayer != null)
            {
                a = PlayerTurnSelectedCreature.creature;
                at = SelectedPlayer.Player;
                PlayerTurnSelectedCreature = null;
                SelectedPlayer = null;
                gameController.Fight(a, at);
            }
            RefreshScene();
        }

        private void PlayVM()
        {
            if (SelectedCard != null)
            {
                gameController.PlayerTurn.Play_Card(selectedCard.card);
                SelectedCard = null;
                RefreshScene();
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void RefreshScene()
        {


            NotPlayerTurn.Board.Clear();
            foreach (var item in gameController.NotPlayerTurn.Board)
            {
                NotPlayerTurn.Board.Add(new CreatureVM(item));
            }

            PlayerTurn.Board.Clear();
            foreach (var item in gameController.PlayerTurn.Board)
            {
                PlayerTurn.Board.Add(new CreatureVM(item));
            }

            PlayerTurn.Hand.Clear();
            foreach (var item in gameController.PlayerTurn.Hand)
            {
                PlayerTurn.Hand.Add(new CardVM(item));
            }

            NotPlayerTurn.Hand.Clear();
            foreach (var item in gameController.NotPlayerTurn.Hand)
            {
                NotPlayerTurn.Hand.Add(new CardVM(item));
            }

            PlayerTurn.Deck.Clear();
            foreach (var item in gameController.PlayerTurn.Deck)
            {
                PlayerTurn.Deck.Add(new CardVM(item));
            }

            NotPlayerTurn.Deck.Clear();
            foreach (var item in gameController.NotPlayerTurn.Deck)
            {
                NotPlayerTurn.Deck.Add(new CardVM(item));
            }
            PlayerTurn.HP = gameController.PlayerTurn.hp;
            NotPlayerTurn.HP = gameController.NotPlayerTurn.hp;

            PlayerTurn.Mana = gameController.PlayerTurn.Mana;
            PlayerTurn.ManaCol.Clear();
            for (int i = 0; i < PlayerTurn.Mana; i++)
            {
                PlayerTurn.ManaCol.Add(0);
            }
            NotPlayerTurn.Mana = gameController.NotPlayerTurn.Mana;

            if (gameController.Winner != null)
            {

                MessageBox.Show("Победил " + gameController.Winner.playerName);
                win.Close();
            }
        }
    }
}
