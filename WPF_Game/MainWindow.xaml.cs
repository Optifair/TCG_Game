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
using System.IO;
using System.Reflection;
using WPF_Game.View_Models;
using TCG;
using System.Collections.ObjectModel;

namespace WPF_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainVM m;
        public MainWindow()
        {
            m = new MainVM(this);
            InitializeComponent();
            DataContext = m;
        }


        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            m.SelectedPlayer = m.NotPlayerTurn;
        }

        private void Sound_Off_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Введите параметры в матричной форме в таблицу и координаты начальной точки x(a,b). Для получения результата нажмите кнопку выполнить.");
        }
    }
}
