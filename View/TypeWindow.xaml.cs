using Money.ViewModel;
using Money.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Money
{
    /// <summary>
    /// Логика взаимодействия для Type.xaml
    /// </summary>
    public partial class Type : Window
    {
        public TypeViewModel type;
        public Type()
        {
            InitializeComponent();
            type = new TypeViewModel(this);
            DataContext = type;
        }
    }
}
