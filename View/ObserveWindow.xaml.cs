using Money.ViewModel;
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
using System.Windows.Shapes;

namespace Money.View
{
    /// <summary>
    /// Логика взаимодействия для ObserveWindow.xaml
    /// </summary>
    public partial class ObserveWindow : Window
    {
        public ObserveWindow(MainViewModel mainViewModel)
        {
            DataContext = new ObserveViewModel(mainViewModel);
            InitializeComponent();
        }
    }
}
