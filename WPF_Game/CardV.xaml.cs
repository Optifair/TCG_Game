using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Game.View_Models;
using TCG;

namespace WPF_Game
{
    /// <summary>
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class CardV : UserControl
    {
        private CardWindow Zoom;
        public CardV()
        {
            InitializeComponent();
        }

        private void MouseEnt(object sender, MouseEventArgs e)
        {
            Zoom = new CardWindow();
            Zoom.cardv = this;
            Zoom.DataContext = this.DataContext;
            Zoom.Width *= 0.7;
            Zoom.Height *= 0.7;
            Zoom.Show();
        }

        private void MouseLe(object sender, MouseEventArgs e)
        {
            Zoom.Close();
        }
    }
}
